using EsCoolTutores.Models;
using EsCoolTutores.Services;
using EsCoolTutores.Views;
using EsCoolTutores.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;

namespace EsCoolTutores.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }

        public Usuario Usuario { get; set; }
       

        UsuarioService usuarioService;
        public Command IniciarSesionCommand { get; set; }

        
        public LoginViewModel()
        {
            IniciarSesionCommand = new Command(IniciarSesion);
            Usuario = new();
            usuarioService = new UsuarioService();
            usuarioService.Error += UsuarioService_Error;
        }

        [Obsolete]
        private async void UsuarioService_Error(string error)
        {
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await App.Current.MainPage.DisplayAlert("Error", error, "Ok");
            });
        }

        private async void IniciarSesion()
        {
                   
            try
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {
                    Usuario = await usuarioService.GetUsuario(NombreUsuario, Password);
                    if (Usuario != null)
                    {
                        App.Usuario = Usuario;
                        App.Current.MainPage = new NavigationPage(new ListaHijosView() { BindingContext= new HijoViewModel(Usuario)});
                        

                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No hay conexion a internet.", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
