﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using DesarolloRecepcionProducto.Modelos;
using System.Net.Http;
using System.Net;

namespace DesarolloRecepcionProducto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Login log = new Login
                //{
                //    usuario = txtUser.Text,
                //    pass = txtPass.Text
                //};
                Uri RequestUri = new Uri("http://192.168.1.73:8080/ProyectoU/post.php?cedula=");
                var client = new HttpClient();
               // var json = JsonConvert.SerializeObject(log);
                //var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.GetAsync(RequestUri);
                
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var respuest = response.Content.ReadAsStringAsync();

                    await Navigation.PushAsync(new MenuPage());
                }
                else
                {
                    await DisplayAlert("Mensaje", "Datos invalidos", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error" + ex.Message, "ok");   
            }
        }
    }
}