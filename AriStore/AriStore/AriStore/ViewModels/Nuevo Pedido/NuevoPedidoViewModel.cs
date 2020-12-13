namespace AriStore.ViewModels.Nuevo_Pedido
{
    using AriStore.Enumeration;
    using AriStore.Models;
    using AriStore.OS;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public class NuevoPedidoViewModel : BaseViewModel
    {
        #region Constructor
        private NuevoPedidoViewModel() {}
        #endregion

        #region Atributes
        private static NuevoPedidoViewModel ViewModel;
        private Detalle detalle;
        private Adeudo adeudo;
        private Response response = new Response();
        #endregion

        #region Properties
        /// <summary>
        /// Adeudo al que pertence el Nuevo pedido
        /// </summary>
        public Adeudo Adeudo
        {
            get { return this.adeudo; }
            set { Set(ref this.adeudo, value); }
        }
        /// <summary>
        /// Nuevo pedido a relizar
        /// </summary>
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
            ViewModel.Detalle = new Detalle { IdTipo = 1, Fecha = DateTime.Today };
            return ViewModel;
        }

        /// <summary>
        /// Registra el nuevo pedido que se ha ingresado
        /// </summary>
        private async void NuevoPedido()
        {
            IsValid();
            if (response.Valid)
            {
                try
                {
                    Detalle.IdAdeudo = Adeudo.Id;
                    int detalleResultado = await App.dataRepository.Insertar<Detalle>(Detalle);
                    if (detalleResultado == 1)
                    {
                        Adeudo.Total += Detalle.Monto;
                        int adeudoResultado = await App.dataRepository.Actualizar<Adeudo>(Adeudo);
                        if (adeudoResultado == 1)
                        {

                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await PopUpNavigation.PushModalAsync(PopUpKeys.Mensaje, $"Hubo un error al ingresar la cantidad");
                        }
                    }
                    else
                    {
                        await PopUpNavigation.PushModalAsync(PopUpKeys.Mensaje, $"Hubo un error al ingresar la cantidad");
                    }
                }
                catch (Exception)
                {
                    await PopUpNavigation.PushModalAsync(PopUpKeys.Mensaje, $"Hubo un error al ingresar la cantidad");
                }

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
