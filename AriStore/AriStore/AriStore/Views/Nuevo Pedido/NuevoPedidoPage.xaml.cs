using AriStore.ViewModels.Nuevo_Pedido;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AriStore.Views.Nuevo_Pedido
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevoPedidoPage : ContentPage
    {
        public NuevoPedidoPage()
        {
            InitializeComponent();
            BindingContext = NuevoPedidoViewModel.GetInstance();
        }
    }
}