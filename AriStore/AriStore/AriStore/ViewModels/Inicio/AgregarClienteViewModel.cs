using AriStore.Models;
using AriStore.OS;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AriStore.ViewModels
{
    public class AgregarClienteViewModel: ViewModelBase
    {
        public AgregarClienteViewModel()
        {
            Cliente = new Cliente { Id = 1, Nombre = "Carlos", Paterno = "Vazquez", Materno = "Farrera"};
        }
        #region Atributes
        private Cliente cliente;

        #endregion

        #region Properties
        public Cliente Cliente
        {
            get { return this.cliente; }
            set { Set(ref this.cliente, value); }
        }
        #endregion

        #region Commands
        public ICommand AgregarCommand
        {
            get
            {
                return new RelayCommand(Agregar);
            }
        }
        #endregion

        #region Methods
        private async void Agregar()
        {
            MessagingCenter.Send<Cliente>(Cliente, "agregarCliente");
            await Navigation.PopAsync();
        }
        #endregion

    }
}
