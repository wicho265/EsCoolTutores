using EsCoolTutores.Models;
using EsCoolTutores.Views;

namespace EsCoolTutores;

public partial class App : Application
{

    public static Usuario Usuario { get; set; } = new Usuario();
    public App()
	{
		InitializeComponent();

		MainPage = new LoginView();
	}

   
}
