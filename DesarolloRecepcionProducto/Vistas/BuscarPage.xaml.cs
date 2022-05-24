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
    public partial class BuscarPage : ContentPage
    {
        Uri uri = new Uri("http://192.168.1.212:8080/ProyectoU/post.php");
        public BuscarPage()
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
                var resultado = JsonConvert.DeserializeObject<List<UsuarioModel>>(content);
                lstUsuarios.ItemsSource = resultado;
            }
        }

        
        private void lstUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}