namespace AriStore.ViewModels.Nuevo_Pedido
{
    using AriStore.Enumeration;
    using AriStore.Models;
    using AriStore.OS;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class NuevoPedidoViewModel : BaseViewModel
    {
        #region Constructor
        private NuevoPedidoViewModel() 
        {
            Detalle = new Detalle();
        }
        #endregion

        #region Atributes
        private static NuevoPedidoViewModel ViewModel;
        private Detalle detalle;
        private Adeudo adeudo;
        private Response response = new Response();
        #endregion

        #region Properties
        public Adeudo Adeudo
        {
            get { return this.adeudo; }
            set { Set(ref this.adeudo, value); }
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
            ViewModel.Detalle = new Detalle();
            return ViewModel;
        }

        private async void NuevoPedido()
        {
            IsValid();
            if (response.Valid)
            {
                this.Detalle.IdTipo = 1;
                this.Detalle.IdAdeudo = 1;
                this.Detalle.Fecha = DateTime.Today;
                MessagingCenter.Send<Detalle>(Detalle, "nuevoPedido");
                await Navigation.PopAsync();
            }
            else
            {
                await PopUpNavigation.PushModalAsync(PopUpKeys.Mensaje, response.Mensaje);
            }
           
        }
        /// <summary>
        /// Valida si lo que se encuentra en el Entry es válido para ingresar
        /// </summary>
        /// <returns></returns>
        private Response IsValid()
        {
            response.Valid = false;

            if (this.Detalle.Monto <= 0)
            {
                response.Mensaje = "Debe ingregar una cantidad mayor a 0";
                return response;
            }
            response.Valid = true;
            response.Mensaje = string.Empty;
            return response;
        }
        #endregion
    }
}
