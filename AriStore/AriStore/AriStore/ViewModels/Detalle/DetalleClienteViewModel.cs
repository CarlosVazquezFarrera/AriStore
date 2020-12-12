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

            MessagingCenter.Subscribe<Detalle>(this, "nuevoPedido", (nuevoPedido) =>
            {
                Detalles.Add(nuevoPedido);
            });
        }
        #endregion

        #region Atributes
        private ObservableCollection<Detalle> detalles;
        private static DetalleClienteViewModel ViewModel;
        private Cliente cliente;
        #endregion

        #region Properties
        /// <summary>
        /// Cliente que se ha seleccionado
        /// </summary>
        public Cliente Cliente
        {
            get { return this.cliente; }
            set { Set(ref this.cliente, value); }
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
            await Navigation.Navegar(PagesKeys.NuevoPedido, Cliente);
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
