
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Ejercicio1._3.Modelos
{
    public class ModeloSelect : INotifyPropertyChanged //INotifyPropertyChanged es de MVVM sirve para notificar a la interfaz de usuario
    {
        public ObservableCollection<Modelos.Personas> items; //¿Para que sirve el ObservableCollection

        public ObservableCollection<Modelos.Personas> Items //¿Que hace este metodo?
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public ModeloSelect(IEnumerable<Modelos.Personas> items) //¿Que hace este metodo?
        {
            Items = new ObservableCollection<Modelos.Personas>(items);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) //¿Que hace este metodo?
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
