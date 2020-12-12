namespace AriStore.ViewModels.Nuevo_Pedido
{
    using AriStore.Models;
    using AriStore.OS;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class NuevoPedidoViewModel : BaseViewModel
    {
        #region Constructor
        private NuevoPedidoViewModel() {}
        #endregion

        #region Atributes
        private static NuevoPedidoViewModel ViewModel;
        private Cliente cliente;
        private Detalle detalle;
        #endregion

        #region Properties
        public Cliente Cliente
        {
            get { return this.cliente; }
            set { Set(ref this.cliente, value); }
        }

        public Detalle Detalle
        {
            get { return this.detalle; }
            set { Set(ref this.detalle, value); }
        }
        #endregion

        #region Commands
        public ICommand NuevoPedidoCommand
        {
            get
            {
                return new RelayCommand(NuevoPedido);
            }
        }    
        #endregion

        #region Methods
        /// <summary>
        /// Recupera la instancia del viewModel
        /// </summary>
        /// <returns></returns>
        public static NuevoPedidoViewModel GetInstance()
        {
            if (ViewModel == null)
            {
                ViewModel = new NuevoPedidoViewModel();
            }
            return ViewModel;
        }

        private async void NuevoPedido()
        {
            this.Detalle.IdTipo = 1;
            this.Detalle.Fecha = DateTime.Today;
            MessagingCenter.Send<Detalle>(Detalle, "nuevoPedido");
            await Navigation.PopAsync();
        }
        #endregion
    }
}
