namespace AriStore.ViewModels
{
    using AriStore.OS;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public  class BaseViewModel: ViewModelBase
    {
        #region Comands
        /// <summary>
        /// Comando para desapilar la página actual
        /// </summary>
        public ICommand AtrasCommand
        {
            get
            {
                return new RelayCommand(Atras);
            }
        }
        #endregion

        #region Methods
        private async void Atras()
        {
            await Navigation.PopAsync();
        }
        #endregion
    }
}
