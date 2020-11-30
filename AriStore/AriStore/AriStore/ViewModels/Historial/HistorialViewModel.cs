
namespace AriStore.ViewModels.Historial
{
    using AriStore.Models;
    public class HistorialViewModel : BaseViewModel
    {
        #region Constructor
        private HistorialViewModel() { }

        #endregion

        #region Atributes
        private static HistorialViewModel ViewModel;
        private Cliente cliente;
        #endregion

        public Cliente Cliente
        {
            get { return this.cliente; }
            set { Set(ref this.cliente, value); }
        }

        #region Methods
        public static HistorialViewModel GetInstance()
        {
            if (ViewModel == null)
            {
                ViewModel = new HistorialViewModel();
            }
            return ViewModel;
        } 
        #endregion
    }
}
