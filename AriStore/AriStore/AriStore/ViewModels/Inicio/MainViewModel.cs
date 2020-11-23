namespace AriStore.ViewModels
{
    using AriStore.Enumeration;
    using AriStore.Models;
    using AriStore.OS;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel: BaseViewModel
    {
        #region Constructor
        public MainViewModel()
        {
            GetData();
            MessagingCenter.Subscribe<Cliente>(this, "agregarCliente", (cliente) =>
            {
                AgregarCliente(cliente);
            });
        }
        #endregion

        #region Atributes
        private string nombreFiltro;
        private Cliente clienteSeleccionado;
        private ObservableCollection<Cliente> clientes;
        private List<Cliente> clientesData;
        #endregion

        #region Properties
        /// <summary>
        /// Texto que se utiliza para hacer el filtrado de clientes
        /// </summary>
        public string NombreFiltro
        {
            get { return this.nombreFiltro; }
            set { 
                Set(ref this.nombreFiltro, value);
                Filter();
            }
        }

        public Cliente ClienteSeleccionado
        {
            get { return this.clienteSeleccionado; }
            set { 
                Set(ref this.clienteSeleccionado, value);
                if (value != null)
                {
                    DetalleCliente();
                }
            }
        }
        /// <summary>
        /// Clientes obtenidos de la base de datos y que se muestran en la vista
        /// </summary>
        public ObservableCollection<Cliente> Clientes
        {
            get { return this.clientes; }
            set { Set(ref this.clientes, value); }
        }
        #endregion

        #region Comands
        /// <summary>
        /// Comando de navegación
        /// </summary>
        public ICommand NavegarCommand
        {
            get
            {
                return new RelayCommand(Navegar);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Retorna la información de la base de datos
        /// </summary>
        private async void GetData()
        {
            clientesData = new List<Cliente>(await App.dataRepository.ObtenerTodo<Cliente>());
            Clientes = new ObservableCollection<Cliente>(clientesData);
        }

        /// <summary>
        /// Método de navegación
        /// </summary>
        private async void Navegar()
        {
             await Navigation.Navegar(PagesKeys.AgregarCliente);
        }
        /// <summary>
        /// Apila la página de detalle y envía el parametro indicado (El Cliente)
        /// </summary>
        private async void DetalleCliente()
        {
            await Navigation.Navegar(PagesKeys.DetalleCliente, clienteSeleccionado);
            ClienteSeleccionado = null;
        }
        /// <summary>
        /// Filtra la lista de clientes y retorna aquellos que cumplan con el criterio
        /// </summary>
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
                        c.Materno.ToLower().Contains(NombreFiltro.ToLower()) ||
                        $"{c.Nombre.ToLower()} {c.Paterno.ToLower()} {c.Materno}".Contains(NombreFiltro.ToLower())
                     )
                 );
            }
        }
        /// <summary>
        /// Agregar un cliente a la base de datos y a la lista que se muestra en la vista
        /// </summary>
        /// <param name="clienteAgregado"></param>
        private async void AgregarCliente(Cliente clienteAgregado)
        {
            try
            {
                int resultado = await App.dataRepository.Insertar<Cliente>(clienteAgregado);
                if (resultado == 1)
                {
                    clientesData.Add(clienteAgregado);
                    clientes.Add(clienteAgregado);
                }
            }
            catch (Exception)
            {

                await App.Current.MainPage.DisplayAlert("Error", $"Hubo un error a agregar el cliente {clienteAgregado.Nombre}", "Aceptar");
            }
        }
        #endregion
    }
}
