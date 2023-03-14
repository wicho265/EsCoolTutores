using EsCoolTutores.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCoolTutores.Services
{
        public  class UsuarioService
        {
        
        HttpClient usuar = new HttpClient(); 
        public UsuarioService()
        {
            usuar.BaseAddress = new Uri("https://padres.sistemas19.com/");
        }
        public event Action<string> Error;



        public async Task<Usuario> GetUsuario(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) && string.IsNullOrWhiteSpace(password))
            {
                Error?.Invoke("Nombre de usuario o contrasena incorrecto");
            }
            Usuario usuario = new Usuario()
            {
                NombreUsuario = user,
                Password = password
            };
            var json = JsonConvert.SerializeObject(usuario);
            var response = usuar.PostAsync("api/usuario/login", new StringContent(json, Encoding.UTF8, "application/json"));
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                json = await response.Result.Content.ReadAsStringAsync();
                usuario = JsonConvert.DeserializeObject<Usuario>(json);
                return usuario;
            }
            else
            {
                var errores = await response.Result.Content.ReadAsStringAsync();
                Error?.Invoke(errores);
                return null;
            }

        }
    }
}
