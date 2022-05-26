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
    public partial class ActuProductoPage : ContentPage
    {
        Uri uri = new Uri("http://192.168.1.73:8080/ProyectoU/postProducto.php");
        public ActuProductoPage()
        {
            InitializeComponent();
            llenarDatos();
        }

        private async void llenarDatos()
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

        private async void btnmodificar_Clicked(object sender, EventArgs e)
        {
            ProductoModel usuario = new ProductoModel
            {
                Codigo = Convert.ToInt32(txtcodigo.Text),
                Serie = txtserie.Text,
                Nombre = txtnombre.Text,
                Cantidad = txtcantidad.Text,
                PrecioCompra = txtprecioCompra.Text,
                PrecioVenta = txtprecioVenta.Text,
                Categoria = txtcategoria.Text,
                Marca = txtmarca.Text,
                Ubicacion = txtubicacion.Text,
                Estado = txtestado.Text,

            };

            Uri RquestUri = uri;
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(usuario);
            var contenJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(RquestUri, contenJson);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Datos", "Se actualizo Correctamente", "ok");
                txtcodigo.Text = "";
                txtserie.Text = "";
                txtnombre.Text = "";
                txtcantidad.Text = "";
                txtprecioCompra.Text = "";
                txtprecioVenta.Text = "";
                txtcategoria.Text = "";
                txtmarca.Text = "";
                txtubicacion.Text = "";
                txtestado.Text = "";
                llenarDatos();
                
                btnmodificar.IsVisible = false;
               
            }
            else
            {
                await DisplayAlert("Datos", "Ocurrio un error", "ok");
            }
        }

        private async void lstProducto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (ProductoModel)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.Codigo.ToString()))
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(uri + obj.Codigo.ToString());
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                var client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ProductoModel usuarioModel = JsonConvert.DeserializeObject<ProductoModel>(content);
                    txtcodigo.Text = usuarioModel.Codigo.ToString();
                    txtserie.Text = usuarioModel.Serie;
                    txtnombre.Text = usuarioModel.Nombre;
                    txtcantidad.Text = usuarioModel.Cantidad;
                    txtprecioCompra.Text = usuarioModel.PrecioCompra;
                    txtprecioVenta.Text = usuarioModel.PrecioVenta;
                    txtmarca.Text = usuarioModel.Marca;
                    txtubicacion.Text = usuarioModel.Ubicacion;
                    txtestado.Text = usuarioModel.Estado;

                   
                    btnmodificar.IsVisible = true;
                    
                }
            }
        }
    }
}