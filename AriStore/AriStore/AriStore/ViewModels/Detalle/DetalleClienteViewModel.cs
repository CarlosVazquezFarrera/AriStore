namespace AriStore.ViewModels.Detalle
{
    using AriStore.Models;
    using GalaSoft.MvvmLight;
    using System.Collections.ObjectModel;

    public class DetalleClienteViewModel : BaseViewModel
    {
        #region Constructor
        private DetalleClienteViewModel() { }
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
        #endregion
    }
}
