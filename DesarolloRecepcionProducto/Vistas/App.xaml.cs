using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesarolloRecepcionProducto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.BuscarPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        
    }
}
