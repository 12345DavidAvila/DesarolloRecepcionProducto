using DesarolloRecepcionProducto.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesarolloRecepcionProducto.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarProducPage : ContentPage
    {
        String codigo = "";

        Uri uri = new Uri("http://192.168.1.73:8080/ProyectoU/postProducto.php");
        public BuscarProducPage()
        {
            InitializeComponent();
            llenarDatos();
        }

        public async void llenarDatos()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = uri;
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<ProductoModel>>(content);
                lstProducto.ItemsSource = resultado;
            }
        }

        private async void lstProducto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (ProductoModel)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.Codigo.ToString()))
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(uri + "?codigo=" + obj.Codigo.ToString());             
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
               
                var client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ProductoModel usuarioModel = JsonConvert.DeserializeObject<ProductoModel>(content);
                    
                    codigo = usuarioModel.Codigo.ToString();

                    //txtcodigo.Text = usuarioModel.Codigo.ToString(); 
                    //txtserie.Text = usuarioModel.Serie;
                    //txtnombre.Text = usuarioModel.Nombre;
                    //txtcantidad.Text = usuarioModel.Cantidad;
                    //txtprecioCompra.Text = usuarioModel.PrecioCompra;
                    //txtprecioVenta.Text = usuarioModel.PrecioVenta;
                    //txtcategoria.Text = usuarioModel.Categoria;
                    //txtmarca.Text = usuarioModel.Marca;
                    //txtubicacion.Text = usuarioModel.Ubicacion;
                    //txtestado.Text = usuarioModel.Estado;


                    //btnguardar.IsVisible = false;
                    //btnmodificar.IsVisible = true;
                    btneliminar.IsVisible = true;
                }
            }

        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri + "?codigo=" + codigo);
            request.Method = HttpMethod.Delete;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Datos", "Se elimino correctamente", "ok");
                txtcodigo.Text = "";
                
                llenarDatos();
                
                btneliminar.IsVisible = false;
            }
            else
            {
                await DisplayAlert("Datos", "Ocurrio un error", "ok");
            }

        }

        private async void btnmodificar_Clicked(object sender, EventArgs e)
        {
            
                await Navigation.PushAsync(new ActualizarProductoPage(codigo));
            
        }
    }
}
