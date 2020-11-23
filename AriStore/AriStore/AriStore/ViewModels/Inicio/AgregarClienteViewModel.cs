using AriStore.Models;
using AriStore.OS;
namespace AriStore.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AgregarClienteViewModel: BaseViewModel
    {
        public AgregarClienteViewModel()
        {
            Cliente = new Cliente { Id = 1, Nombre = "Carlos", Paterno = "Vazquez", Materno = "Farrera"};
        }
        #region Atributes
        private Cliente cliente;
        private Response respuesta = new Response();
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
            IsValid();
            if (respuesta.Valid)
            {
                MessagingCenter.Send<Cliente>(Cliente, "agregarCliente");
                await Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", respuesta.Mensaje, "Aceptar");
            }
        }

        private Response IsValid()
        {
            respuesta.Valid = false;
            if (string.IsNullOrEmpty(Cliente.Nombre))
            {
                respuesta.Mensaje = "Debe ingresar el Nombre";
                return respuesta;
            }
            else if (string.IsNullOrEmpty(Cliente.Paterno))
            {
                respuesta.Mensaje = "Debe ingresar el Apellido Paterno";
                return respuesta;
            }
            respuesta.Valid = true;
            return respuesta;
        }
        #endregion

    }
}
