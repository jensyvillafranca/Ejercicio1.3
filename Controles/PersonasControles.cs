using SQLite;

namespace Ejercicio1._3.Controles
{
    public class PersonasControles
    {
        /*Variable para la conexión*/
         SQLiteAsyncConnection conexion;

        //Constructor Vacío -> Para instanciar unicamente la clase
        public PersonasControles() { }

        //Conexión a la BD
        public async Task Inicializar()
        {
            //Si la conexión ya esta establecida que se salga y no la vuelva a crear
            if (conexion is not null)
            {
                return;
            }

            //Caso contrario permitir que la base de datos pueda escribir, leer
            SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite |
                                                 SQLite.SQLiteOpenFlags.Create |
                                                 SQLite.SQLiteOpenFlags.SharedCache;
            //Crear ruta de la BD
            conexion = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBPersonasTarea.db3"), extensiones);
            //conexion = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBPersonas.db3"), extensiones);

            //Crear la tabla
            var crearTabla = await conexion.CreateTableAsync<Modelos.Personas>();
        }

        //Guardar
        public async Task<int> GuardarPersona(Modelos.Personas personasTarea)
        {
            await Inicializar();

            if(personasTarea.idPersona == 0) //Porque no existe ese id y se debe insertar
            {
                return await conexion.InsertAsync(personasTarea);
            }
            else
            {
                return await conexion.UpdateAsync(personasTarea); //existe ese ID entonces se va actualizar
            }
        }

        //Read -> Retornar todos los elementos de manera asincrona
        public async Task<List<Modelos.Personas>> ObtenerPersonas()
        {
            await Inicializar();
            return await conexion.Table<Modelos.Personas>().ToListAsync();

        }

        //Read para leer un solo elemento usando una expresión Lamba
        public async Task<Modelos.Personas> ObtenerPersona(int pid)
        {
            await Inicializar();
            return await conexion.Table<Modelos.Personas>().Where(i => i.idPersona == pid).FirstOrDefaultAsync();
           
        }

        //Eliminar un elemento
        public async Task<int> EliminarPersona(Modelos.Personas personas)
        {
            await Inicializar();
            return await conexion.DeleteAsync(personas);
        }

    }
}
