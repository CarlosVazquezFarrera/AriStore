using AriStore.Models;
using AriStore.OS;
namespace AriStore.ViewModels
{
    using AriStore.Enumeration;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AgregarClienteViewModel: BaseViewModel
    {
        #region Constrcutor
        public AgregarClienteViewModel()
        {
            Cliente = new Cliente { Id = 1, Nombre = "Carlos", Paterno = "Vazquez", Materno = "Farrera" };
        } 
        #endregion

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
                try
                {
                    int resultado = await App.dataRepository.Insertar<Cliente>(Cliente);
                    if (resultado == 1)
                    {
                        MessagingCenter.Send<Cliente>(Cliente, "nuevoPedido");
                        await Navigation.PopAsync();
                    }
                }
                catch (Exception)
                {

                    await PopUpNavigation.PushModalAsync(PopUpKeys.Mensaje, "Error", $"Hubo un error a agregar el cliente {Cliente.Nombre}");
                }
            }
            else
            {
                await PopUpNavigation.PushModalAsync(PopUpKeys.Mensaje, respuesta.Mensaje);
            }
        }
        /// <summary>
        /// Realiza todas las validaciones referente los campos requeridos 
        /// </summary>
        /// <returns></returns>
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
