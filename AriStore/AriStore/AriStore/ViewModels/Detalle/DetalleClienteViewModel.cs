namespace AriStore.ViewModels.Detalle
{
    using AriStore.Enumeration;
    using AriStore.Models;
    using AriStore.OS;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class DetalleClienteViewModel : BaseViewModel
    {
        #region Constructor
        private DetalleClienteViewModel() {
            Detalles = new ObservableCollection<Detalle> { 
            new Detalle{ Id = 1, IdAdeudo = 1, IdTipo = 1, Monto =  1200, Fecha = DateTime.Today} ,
            new Detalle{ Id = 2, IdAdeudo = 1, IdTipo = 0, Monto = 200, Fecha = DateTime.Today} ,
            new Detalle{ Id = 3, IdAdeudo = 1, IdTipo = 0, Monto = 300.50F, Fecha = DateTime.Today} ,
            new Detalle{ Id = 4, IdAdeudo = 1, IdTipo = 0, Monto = 50, Fecha = DateTime.Today} ,
            new Detalle{ Id = 4, IdAdeudo = 1, IdTipo = 1, Monto = 2600, Fecha = DateTime.Today} ,
            };

            Adeudo = new Adeudo { Id = 1, Total = 500 };
            Total = Adeudo.Total;

            MessagingCenter.Subscribe<Detalle>(this, "nuevoPedido", (nuevoPedido) =>
            {
                Total += nuevoPedido.Monto;
                Detalles.Add(nuevoPedido);
            });
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
        #region Methods
        /// <summary>
        /// Retorna una isntancia del ViewModelSeleccionado
        /// </summary>
        /// <returns></returns>
        public static DetalleClienteViewModel GetInstance()
        {
            if(ViewModel == null)
            {
                ViewModel = new DetalleClienteViewModel();
            }
            return ViewModel;
        }

        private async void NavegarNuevoPedido()
        {
            Adeudo.IdCliente = Cliente.Id;
            await Navigation.Navegar(PagesKeys.NuevoPedido, Adeudo);
        }

        private async void NavegarAbono()
        {
            await Navigation.Navegar(PagesKeys.Abono, Cliente);
        }
        private async void NavegarHistotrial()
        {
            await Navigation.Navegar(PagesKeys.Historial, Cliente);
        }
        #endregion
    }
}
