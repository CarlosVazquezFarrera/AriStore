namespace AriStore.ViewModels.Abono
{
    using AriStore.Models;
    public class AbonoViewModel: BaseViewModel
    {
        #region Atributes
        private static AbonoViewModel ViewModel;
        private Cliente cliente; 
        #endregion

        #region Propierties
        public Cliente Cliente
        {
            get { return this.cliente; }
            set { Set(ref this.cliente, value); }
        } 
        #endregion

        #region Methods
        public static AbonoViewModel GetInstance()
        {
            if (ViewModel == null)
            {
                ViewModel = new AbonoViewModel();
            }
            return ViewModel;
        } 
        #endregion
    }
}
