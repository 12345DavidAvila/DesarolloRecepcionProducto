using DesarolloRecepcionProducto.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class BuscarProductoPage : ContentPage
    {
        Uri uri = new Uri("http://192.168.1.73:8080/ProyectoU/postProducto.php");
        public BuscarProductoPage()
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

        private void lstProducto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}