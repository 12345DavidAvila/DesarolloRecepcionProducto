using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesarolloRecepcionProducto.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuProducPage : ContentPage
    {
        public MenuProducPage()
        {
            InitializeComponent();
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());

        }

     
        private async void btnPrueba_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}