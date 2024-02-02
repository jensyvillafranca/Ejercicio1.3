using SQLite;
using System.ComponentModel;

namespace Ejercicio1._3.Modelos
{
    /*Tabla de Personas*/
    [Table("Personas")] /*Nombre de la tabla*/
    public class Personas : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int idPersona { get; set; }

        [NotNull, MaxLength(50)]
        public string nombresPersona { get; set; }

        [NotNull, MaxLength(50)]
        public string apellidosPersona { get; set;}

        [NotNull, MaxLength(3)]
        public int edadPersona { get; set; }

        [NotNull, MaxLength(50)]
        public string correo {  get; set; }

        [NotNull, MaxLength(100)]
        public string direccionPersona { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
