namespace Ejercicio1._3.Vistas;

public partial class FormularioRegistro : ContentPage
{
	//Variable de tipo PersonasControles
	private Controles.PersonasControles rutaTarea;
	public FormularioRegistro(Controles.PersonasControles rutaBD)
	{
		InitializeComponent();
        rutaTarea = rutaBD; //Asignando el parametro que viene de la clase PersonasControles
	}

	public FormularioRegistro()
	{
		InitializeComponent();
		rutaTarea = new Controles.PersonasControles(); //Instanciando la clase de PersonasControles
	}

    private async void guardarDatos(object sender, EventArgs e)
    {
		//Inicializar el objeto personas con sus propiedades
		var persona = new Modelos.Personas
		{
			nombresPersona = txtNombres.Text,
			apellidosPersona = txtApellidos.Text,
			edadPersona = int.Parse((txtEdad.Text)),
			correo = txtCorreo.Text,
			direccionPersona = txtDireccion.Text
		};

        if (await rutaTarea.GuardarPersona(persona) > 0) //
        {
            await DisplayAlert("Aviso", "Registro ingresado con exito", "OK");
        }
        else
        {
            await DisplayAlert("Aviso", "No se puede insertar la información", "OK");
        }


    }

    private async void mostrarDatos(object sender, EventArgs e)
    {
        //Console.WriteLine("")
		//Pasar los datos a PersonasControles
		var items = await rutaTarea.ObtenerPersonas();
		await Navigation.PushAsync(new Vistas.SelectPersonas(items));
    }
}