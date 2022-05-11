using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private const string Url = "http://192.168.1.212:8080/ProyectoU/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<DesarolloRecepcionProducto.Modelos.Login> _post;
        public BuscarProductoPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<DesarolloRecepcionProducto.Modelos.Login> posts = JsonConvert.DeserializeObject<List<DesarolloRecepcionProducto.Modelos.Login>>(content);
            _post = new ObservableCollection<Modelos.Login>(posts);

            Listas.ItemsSource = _post;
        }
    }
}