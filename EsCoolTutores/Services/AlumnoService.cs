using EsCoolTutores.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCoolTutores.Services
{
    public class AlumnoService
    {
        HttpClient alumno = new HttpClient
        {
            BaseAddress = new Uri("https://padres.sistemas19.com/")
        };


        public event Action<string> Error;
        void LanzarError(string mensaje)
        {
            Error?.Invoke(mensaje);
        }

        void LanzarErrorJson(string json)
        {
            string obj = JsonConvert.DeserializeObject<string>(json);
            if (obj != null)
            {
                Error?.Invoke(obj);
            }
        }

        public async Task<List<AlumnoDTO>> GetAlumno(int id)
        {
            List<AlumnoDTO> listAlumnos = new List<AlumnoDTO>();
            var response = await alumno.GetAsync("api/alumno/"+ id);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                listAlumnos = JsonConvert.DeserializeObject<List<AlumnoDTO>>(json);
            }
            if (listAlumnos != null)
            {
                return listAlumnos;
            }
            else
            {
                return new List<AlumnoDTO>();
            }
        }

        public async Task<List<CalificacionDTO>> GetCalifs(int id)
        {
            List<CalificacionDTO> listCalificaciones = new List<CalificacionDTO>();
            var response = await alumno.GetAsync("api/alumno/" + id);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                listCalificaciones = JsonConvert.DeserializeObject<List<CalificacionDTO>>(json);
            }
            if (listCalificaciones != null)
            {
                return listCalificaciones;
            }
            else
            {
                return new List<CalificacionDTO>();
            }
        }


    } 
}
