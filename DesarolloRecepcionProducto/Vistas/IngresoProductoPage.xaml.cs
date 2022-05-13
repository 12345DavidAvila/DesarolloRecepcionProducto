using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesarolloRecepcionProducto.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresoProductoPage : ContentPage
    {
        public IngresoProductoPage()
        {
            InitializeComponent();
        }

        private async void btnRegistrarProducto_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                
                parametros.Add("serie", txtSerie.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("cantidad", txtCantidad.Text);
                parametros.Add("precioCompra", txtPrecioCompra.Text);
                parametros.Add("precioVenta", txtPrecioVenta.Text);
                parametros.Add("categoria", txtCategoria.Text);
                parametros.Add("marca", txtMarca.Text);
                parametros.Add("ubicacion", txtUbicacion.Text);
                parametros.Add("estado", txtEstado.Text);

                cliente.UploadValues("http://192.168.1.73:8080/ProyectoU/postProducto.php", "POST", parametros);
                await DisplayAlert("Alerta", "Producto Ingresado Correctamente", "ok");
                
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error" + ex.Message, "ok");
            }
        }
        public IList<string> CountryList
        {
            get
            {
                return new List<string> { "USA", "Germany", "England" };
            }
        }
    }
    
}