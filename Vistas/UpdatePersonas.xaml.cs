using Ejercicio1._3.Modelos;

namespace Ejercicio1._3.Vistas;

public partial class UpdatePersonas : ContentPage
{
    //Zona de variables
    private Controles.PersonasControles rutaTarea;
    //private int _idPersona;

    public UpdatePersonas(Controles.PersonasControles rutaBD)
	{
		InitializeComponent();
        rutaTarea = rutaBD;
    }

    public UpdatePersonas()
    {
        InitializeComponent();
        rutaTarea = new Controles.PersonasControles(); //Instanciando la clase de PersonasControles
    }

    private async void actualizar(object sender, EventArgs e)
    {
        //Console.WriteLine("El id es: ", _idPersona);
        //Capturar la nueva información que le vamos a pasar al metodo de PersonasControles
        var Datos = new Personas
        {
            idPersona = int.Parse(txtUpOculto.Text),
            nombresPersona = txtUpNombres.Text,
            apellidosPersona = txtUpApellidos.Text,
            edadPersona = int.Parse(txtUpEdad.Text), //int.Parse sirve para convertir de string a int
            correo = txtUpCorreo.Text,
            direccionPersona = txtUpDireccion.Text
        };

        //Mandar los datos para hacer el respectivo de update de la tabla

        if (await rutaTarea.GuardarPersona(Datos) > 0) //
        {
            await DisplayAlert("Aviso", "Registro actualizado con exito", "OK");
        }
        else
        {
            await DisplayAlert("Aviso", "No se puede actualizar la información", "OK");
        }

    }
}