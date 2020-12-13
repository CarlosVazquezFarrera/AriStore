namespace AriStore.ViewModels.Abono
{
    using AriStore.Enumeration;
    using AriStore.Models;
    using AriStore.OS;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public class AbonoViewModel: BaseViewModel
    {
        #region Atributes
        private static AbonoViewModel ViewModel;
        private Adeudo adeudo; 
        private Detalle detalle;
        private Response response = new Response();
        #endregion

        #region Propierties
        public Detalle Detalle
        {
            get { return this.detalle; }
            set { Set(ref this.detalle, value); }
        }
        public Adeudo Adeudo
        {
            get { return this.adeudo; }
            set { Set(ref this.adeudo, value); }
        }
        #endregion

        #region Commands
        public ICommand NuevoAbonoCommand
        {
            get
            {
                return new RelayCommand(NuevoAbono);
            }
        } 
        #endregion

        #region Methods
        public static AbonoViewModel GetInstance()
        {
            if (ViewModel == null)
            {
                ViewModel = new AbonoViewModel();
            }
            ViewModel.Detalle = new Detalle { IdTipo = 0, Fecha = DateTime.Today };
            return ViewModel;
        }

        private async void NuevoAbono()
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
                        Adeudo.Total -= Detalle.Monto;
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

        private Response IsValid()
        {
            response.Valid = false;
            if(Adeudo.Total == 0)
            {
                response.Mensaje = "El cliente no tiene aduedo alguno";
                return response;
            }
            if (this.Detalle.Monto <= 0)
            {
                response.Mensaje = "Debe ingregar una cantidad mayor a 0";
                return response;
            }
            if (Adeudo.Total < this.Detalle.Monto )
            {
                response.Mensaje = $"Ingrese una cantidad menor o igual a {Adeudo.Total}";
                return response;
            }
            response.Valid = true;
            response.Mensaje = string.Empty;
            return response;
        }
        #endregion
    }
}
