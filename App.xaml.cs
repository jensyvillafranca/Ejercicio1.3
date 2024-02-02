using Ejercicio1._3.Vistas;

namespace Ejercicio1._3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Para permitir la navegación entre pantallas pero debo de colocar el que sera el principal
            MainPage = new NavigationPage(new FormularioRegistro());
        }
    }
}
