namespace AriStore.ViewModels
{
    using AriStore.Models;
    using GalaSoft.MvvmLight;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class MainViewModel: ViewModelBase
    {
        public MainViewModel()
        {
            Clientes = new ObservableCollection<Cliente>
            {
                new Cliente{Id = 1, Nombre = "Diego", Paterno = "Ocaña", Materno = "Solorzana"},
                new Cliente{Id = 2, Nombre = "Gisel", Paterno = "Marques", Materno = "Fuentes"}
            };
            clientesData = new List<Cliente>(Clientes);
            
        }
        #region Atributes
        private string nombreFiltro;
        private ObservableCollection<Cliente> clientes;
        private List<Cliente> clientesData;
        #endregion

        #region Properties
        public string NombreFiltro
        {
            get { return this.nombreFiltro; }
            set { 
                Set(ref this.nombreFiltro, value);
                Filter();
            }
        }

        public ObservableCollection<Cliente> Clientes
        {
            get { return this.clientes; }
            set { Set(ref this.clientes, value); }
        }
        #endregion

        private void Filter()
        {
            if (string.IsNullOrEmpty(NombreFiltro))
            {
                Clientes = new ObservableCollection<Cliente>(clientesData);
            }
            else
            {
                Clientes = new ObservableCollection<Cliente>(
                    clientesData.Where(c => 
                        c.Nombre.ToLower().Contains(NombreFiltro.ToLower()) ||
                        c.Paterno.ToLower().Contains(NombreFiltro.ToLower()) ||
                        c.Materno.ToLower().Contains(NombreFiltro.ToLower())
                     )
                 );
            }
        }
    }
}
