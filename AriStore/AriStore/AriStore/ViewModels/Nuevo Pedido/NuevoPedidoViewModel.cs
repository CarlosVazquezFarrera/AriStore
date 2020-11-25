namespace AriStore.ViewModels.Nuevo_Pedido
{
    using AriStore.Models;
    public class NuevoPedidoViewModel : BaseViewModel
    {
        #region Constructor
        private NuevoPedidoViewModel() {
            Cliente = new Cliente { Nombre = "Carlos"};
        }
        #endregion

        #region Atributes
        private static NuevoPedidoViewModel ViewModel;
        private Cliente cliente;
        #endregion

        #region Cliente
        public Cliente Cliente
        {
            get { return this.cliente; }
            set { Set(ref this.cliente, value); }
        } 
        #endregion

        #region Methods
        public static NuevoPedidoViewModel GetInstance()
        {
            if (ViewModel == null)
            {
                ViewModel = new NuevoPedidoViewModel();
            }
            return ViewModel;
        } 
        #endregion
    }
}
