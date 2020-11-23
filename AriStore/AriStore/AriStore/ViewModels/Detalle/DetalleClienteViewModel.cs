namespace AriStore.ViewModels.Detalle
{
    using AriStore.Models;
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.ObjectModel;

    public class DetalleClienteViewModel : BaseViewModel
    {
        #region Constructor
        private DetalleClienteViewModel() {
            Detalles = new ObservableCollection<Detalle> { 
            new Detalle{ Id = 1, IdAdeudo = 1, IdTipo = 1, Monto =  1200, Fecha = DateTime.Today.ToShortDateString()} ,
            new Detalle{ Id = 2, IdAdeudo = 1, IdTipo = 0, Monto = 200, Fecha = DateTime.Today.ToShortDateString()} ,
            new Detalle{ Id = 3, IdAdeudo = 1, IdTipo = 0, Monto = 300.50F, Fecha = DateTime.Today.ToShortDateString()} ,
            new Detalle{ Id = 4, IdAdeudo = 1, IdTipo = 0, Monto = 50, Fecha = DateTime.Today.ToShortDateString()} ,
            new Detalle{ Id = 4, IdAdeudo = 1, IdTipo = 1, Monto = 2600, Fecha = DateTime.Today.ToShortDateString()} ,
            };
        }
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
