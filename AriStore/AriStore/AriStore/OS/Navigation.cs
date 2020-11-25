namespace AriStore.OS
{
    using AriStore.Enumeration;
    using AriStore.Models;
    using AriStore.ViewModels.Detalle;
    using AriStore.ViewModels.Nuevo_Pedido;
    using AriStore.Views;
    using AriStore.Views.Detalle;
    using AriStore.Views.Nuevo_Pedido;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    public class Navigation
    {
        /// <summary>
        /// Apila la página indicada en el Stack
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task Navegar(PagesKeys page)
        {
            switch (page)
            {
                case PagesKeys.AgregarCliente:
                    await IsInstanced(new AgregarCliente());
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Apila la página indicada en el Stack y envía los parametros
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task Navegar(PagesKeys page, params object[] parameters)
        {
            switch (page)
            {
                case PagesKeys.DetalleCliente:
                    DetalleClienteViewModel.GetInstance().Cliente = (Cliente)parameters[0];
                    await IsInstanced(new DetalleClientePage());
                    break;
                case PagesKeys.NuevoPedido:
                    NuevoPedidoViewModel.GetInstance().Cliente = (Cliente)parameters[0];
                    await IsInstanced(new NuevoPedidoPage());
                    break;
                default:
                    break;
            }
        }

        public static async Task PopAsync()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// Evita que una página que ya está instanciada se apile en el stack
        /// </summary>
        /// <param name="NuevaPagina"></param>
        /// <returns></returns>
        private static async Task IsInstanced(Page NuevaPagina)
        {
            List<Page> ListaDePaginas = App.Current.MainPage.Navigation.NavigationStack.ToList();
            short PaginasSimilaresApiladas = (short)ListaDePaginas.Where(p => p.GetType() == NuevaPagina.GetType()).Count();
            if (PaginasSimilaresApiladas < 1)
                await App.Current.MainPage.Navigation.PushAsync(NuevaPagina, true);

        }
    }
}
