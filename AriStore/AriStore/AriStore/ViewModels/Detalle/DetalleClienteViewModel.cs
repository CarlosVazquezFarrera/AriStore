namespace AriStore.ViewModels.Detalle
{
    using AriStore.Enumeration;
    using AriStore.Models;
    using AriStore.OS;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class DetalleClienteViewModel : BaseViewModel
    {
        #region Constructor
        private DetalleClienteViewModel() {

        }
        #endregion

        #region Atributes
        private ObservableCollection<Detalle> detalles;
        private static DetalleClienteViewModel ViewModel;
        private Cliente cliente;
        private Adeudo adeudo;
        private float total;
        #endregion

        #region Properties
        /// <summary>
        /// Cliente que se ha seleccionado
        /// </summary>
        public float Total
        {
            get { return this.total; }
            set { Set(ref this.total, value); }
        }
        public Cliente Cliente
        {
            get { return this.cliente; }
            set { Set(ref this.cliente, value); }
        }
        public Adeudo Adeudo
        {
            get { return this.adeudo; }
            set { Set(ref this.adeudo, value); }
        }
        public ObservableCollection<Detalle> Detalles
        {
            get { return this.detalles; }
            set { Set(ref this.detalles, value); }
        }
        #endregion

        #region Commands
        public ICommand NavegarNuevoPedidoCommand
        {
            get
            {
                return new RelayCommand(NavegarNuevoPedido);
            }
        }

        public ICommand NavegarAbonoCommand
        {
            get
            {
                return new RelayCommand(NavegarAbono);
            }
        }

        public ICommand NavegarHistotrialCommand
        {
            get
            {
                return new RelayCommand(NavegarHistotrial);
            }
        } 
        #endregion
        #region Methods
        /// <summary>
        /// Retorna una isntancia del ViewModelSeleccionado
        /// </summary>
        /// <returns></returns>
        public static DetalleClienteViewModel GetInstance()
        {
            if (ViewModel == null)
            {
                ViewModel = new DetalleClienteViewModel();
            }
            ViewModel.Adeudo = new Adeudo();
            return ViewModel;
        }

        private async void NavegarNuevoPedido()
        {
            await Navigation.Navegar(PagesKeys.NuevoPedido, Adeudo);
        }

        private async void NavegarAbono()
        {
            await Navigation.Navegar(PagesKeys.Abono, Adeudo);
        }
        private async void NavegarHistotrial()
        {
            await Navigation.Navegar(PagesKeys.Historial, Cliente);
        }

        public async Task GetData()
        {
            ///Se obtiene el deuda del cliente
            Adeudo = await App.dataRepository.ObtenerPorIdYQuery<Adeudo>("*", "Adeudo", $"IdCliente = '{Cliente.Id}'");
            Total = Adeudo.Total;
            ///Se obtiene los detalles de la deuda del cliente
            var datosData = await App.dataRepository.QueryListAsync<Detalle>("*", "Detalle ", $"IdAdeudo = '{Adeudo.Id}'");
            Detalles = new ObservableCollection<Detalle>(datosData);
        }
        #endregion
    }
}
