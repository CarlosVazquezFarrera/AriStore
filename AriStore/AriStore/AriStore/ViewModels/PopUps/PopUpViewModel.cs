namespace AriStore.ViewModels.PopUps
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Rg.Plugins.Popup.Services;
    using System;
    using System.Windows.Input;

    public class PopUpViewModel: ViewModelBase
    {
        #region Constructor
        private PopUpViewModel() { }

        #endregion

        #region Atributes
        private static PopUpViewModel ViewModel;
        private string mensaje;
        #endregion

        #region Properties
        public string Mensaje
        {
            get { return this.mensaje; }
            set { Set(ref this.mensaje, value); }
        }
        #endregion

        #region Commands
        public ICommand AceptarCommand
        {
            get
            {
                return new RelayCommand(Aceptar);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Recupera la instancia del objeto de ViewModel
        /// </summary>
        /// <returns></returns>
        public static PopUpViewModel GetInstance()
        {
            if(ViewModel == null)
            {
                ViewModel = new PopUpViewModel();
            }
            return ViewModel;
        }

        /// <summary>
        /// Desapila el PopUp actual
        /// </summary>
        private async void Aceptar()
        {
            await PopupNavigation.Instance.PopAsync();
        }
        #endregion
    }
}
