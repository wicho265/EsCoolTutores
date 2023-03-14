using EsCoolTutores.Models;
using EsCoolTutores.Services;
using EsCoolTutores.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EsCoolTutores.ViewModels
{
    public class HijoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AlumnoDTO> ListaAlumnos { get; set; } = new ObservableCollection<AlumnoDTO>();
        public ObservableCollection<CalificacionDTO> ListaCalificaciones { get; set; } = new ObservableCollection<CalificacionDTO>();


        public string Errores { get; set; }
        private AlumnoService AlumnoService { get; set; }

        CalifView vistacalif;
        public ICommand IniciarCommand { get; set; }

        public ICommand VerCalifCommand { get; set; }
        public ICommand VerListaAlumnos { get; set; }
        public ICommand CaneclarCommand { get; set; }
        public Usuario Usuario { get; set; }

        public HijoViewModel(Usuario user)
        {

            Usuario= user;
            VerListaAlumnos = new Command(CargarAlumnos);
            AlumnoService = new AlumnoService();
            IniciarCommand = new Command(Iniciar);
            CaneclarCommand = new Command(Cancel);
            
            Iniciar();


        }

      

        private void Cancel()
        {
            Application.Current.MainPage.Navigation.PopAsync();

        }

        private void Iniciar()
        {
            CargarAlumnos();
            Actualizar(nameof(ListaAlumnos));
    
        }

        ListaHijosView VistaAlumnos;


        async void CargarAlumnos()
        {
            var datos = await AlumnoService.GetAlumno(Usuario.Id);
            datos.ForEach(x => ListaAlumnos.Add(x));
        }

      



        public void Actualizar(string nombre)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
