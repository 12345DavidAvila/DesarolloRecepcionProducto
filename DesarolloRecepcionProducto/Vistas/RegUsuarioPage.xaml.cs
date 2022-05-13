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
    public partial class RegUsuarioPage : ContentPage
    {
        public RegUsuarioPage()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
             WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            parametros.Add("cedula", txtCedula.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("usuario", txtUsuario.Text);
            parametros.Add("pass", txtPass.Text);
            parametros.Add("telefono", txtTelefono.Text);
            parametros.Add("email", txtEmail.Text);
            parametros.Add("rol", txtRol.Text);
            parametros.Add("estado", txtEstado.Text);

            cliente.UploadValues("http://192.168.1.73:8080/ProyectoU/post.php", "POST", parametros);
            await DisplayAlert("alerta", "Dato Ingresado Correctamente", "ok");


            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error" + ex.Message, "ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }
    }
}