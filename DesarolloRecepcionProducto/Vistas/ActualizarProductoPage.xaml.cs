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
    public partial class ActualizarProductoPage : ContentPage
    {
        Uri uri = new Uri("http://192.168.1.73:8080/ProyectoU/Actualizar.php");
        public object producto;
        public object lstProducto;

        string codigoGl;
        public ActualizarProductoPage(string codigo)
        {
            codigoGl = codigo;
            InitializeComponent();
            llenarDatos();
        }

        private  void btnActualizarProducto_Clicked(object sender, EventArgs e)
        {
            var axu = codigoGl;          
            //Uri RquestUri = uri;
            //var client = new HttpClient();
            //var json = JsonConvert.SerializeObject(producto);
            //var contenJson = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync(RquestUri, contenJson);
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    await DisplayAlert("Datos", "Se actualizo Correctamente", "ok");
            //    txtcodigo.Text = "";
            //    txtSerie.Text = "";
            //    txtNombre.Text = "";
            //    txtCantidad.Text = "";
            //    txtPrecioCompra.Text = "";
            //    txtPrecioVenta.Text = "";
            //    txtCategoria.Text = "";
            //    txtMarca.Text = "";
            //    txtUbicacion.Text = "";
            //    txtEstado.Text = "";
            //    llenarDatos();
            //}
            //else
            //{
            //    await DisplayAlert("Datos", "Ocurrio un error", "ok");
            //}

        }

        private async void llenarDatos()
        {
            //var request = new HttpRequestMessage();
            //request.RequestUri = uri;
            //request.Method = HttpMethod.Get;
            //request.Headers.Add("Accept", "application/json");
            //var client = new HttpClient();
            //HttpResponseMessage response = await client.SendAsync(request);
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    string content = await response.Content.ReadAsStringAsync();
            //    var resultado = JsonConvert.DeserializeObject<List<ProductoModel>>(content);
            //    lstProducto.ItemsSource = resultado;
            //}
        }
    }
}