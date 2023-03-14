using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCoolTutores.Models
{
    public class AlumnoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Grado { get; set; } = "";
        public string Seccion { get; set; } = "";
        public string NombreMaestro { get; set; } = "";
        public List<AsingaturaDTO>? Asingaturas { get; set; } = new();
        public List<CalificacionDTO>? Calificaciones { get; set; } = new();
    }
    public class AsingaturaDTO
    {
        public string NombreAsignatura { get; set; } = null!;
        public string NombreDocente { get; set; } = null!;
    }
    public class CalificacionDTO
    {
        public short Año { get; set; }
        public string NombreAsignatura { get; set; } = null!;
        public double Calificacion { get; set; }
        public int Unidad { get; set; }
    }
}
