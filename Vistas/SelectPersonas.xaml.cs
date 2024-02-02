using Ejercicio1._3.Modelos;
using System.Collections.ObjectModel;

namespace Ejercicio1._3.Vistas;

public partial class SelectPersonas : ContentPage
{
    private Controles.PersonasControles rutaTarea;

    //Lista para refrescar los datos
    public ObservableCollection<Modelos.Personas> Items { get; set; }
    /*public ObservableCollection<Modelos.Personas> Items //¿Que hace este metodo?
    {
        get { return items; }
        set
        {
            items = value;
            OnPropertyChanged(nameof(Items));
        }
    }*/

    public SelectPersonas(IEnumerable<Modelos.Personas> ItemPersonas)
	{
		InitializeComponent();
        BindingContext = new Modelos.ModeloSelect (ItemPersonas);
        rutaTarea = new Controles.PersonasControles();
        Items = new ObservableCollection<Modelos.Personas>();
        BindingContext = this; 
    }


    //Metodo para que se muestre el submenu al presionar un item del collection view
    private async void OnTapped(object sender, EventArgs e)
    {
        //Obtener el item que se ha seleccionado o tocado
        var elemento = (StackLayout)sender;
        var itemSeleccionado = (Modelos.Personas)elemento.BindingContext;

        //Muestra las opciones del submenú
        string opciones = await Application.Current.MainPage.DisplayActionSheet(
            "Opciones",
            "Cancelar",
            null,
            "Actualizar",
            "Eliminar",
            "Ver");

        //Realizar la respectiva programación dependiendo del elemento que se selecciono.
        switch (opciones)
        {
            case "Actualizar":
                //Mandar a llamar la pantalla donde se observaran los datos para actualizar
                var actualizarPantalla = new Vistas.UpdatePersonas();
                actualizarPantalla.BindingContext = itemSeleccionado;
                await Navigation.PushAsync(actualizarPantalla);
                break;
            case "Eliminar":
                eliminarPersona(itemSeleccionado);
                break;
            case "Ver":
                var verPantalla = new Vistas.ViewPersona();
                verPantalla.BindingContext = itemSeleccionado;
                await Navigation.PushAsync(verPantalla);
                break;
        }

    }


    //Este es el metodo que me sirve para refrescar la pantalla
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var listaPersonas = await rutaTarea.ObtenerPersonas(); //Lista actual de datos 
        Items.Clear(); //Limpia la lista

        //Recorrerla y llenarla con la nueva info actualizada

        foreach (var persona in listaPersonas) //cada registro de la tabla pasa a la variable persona
        {
            Items.Add(persona); //se agrega esos registros actualizados de nuevo a la lista.
        }
    }


    //Metodo para eliminar una persona
    public async Task eliminarPersona(Modelos.Personas itemSeleccionado)
    {
        bool answer = await DisplayAlert("Confirmación de Eliminación", "¿Estás seguro de que quieres eliminar este registro?", "Sí", "No");
        if (answer == true)
        {
            //Mandar a llamar el metodo de eliminar de PersonasControles
            await rutaTarea.EliminarPersona(itemSeleccionado);
            OnAppearing();
        }

    }


}