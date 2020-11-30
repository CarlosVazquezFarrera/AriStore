using AriStore.ViewModels.Abono;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AriStore.Views.Abono
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbonoPage : ContentPage
    {
        public AbonoPage()
        {
            InitializeComponent();
            BindingContext = AbonoViewModel.GetInstance();
        }
    }
}