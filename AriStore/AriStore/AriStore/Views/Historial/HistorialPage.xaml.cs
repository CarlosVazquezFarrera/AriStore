using AriStore.ViewModels.Historial;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AriStore.Views.Historial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorialPage : ContentPage
    {
        public HistorialPage()
        {
            InitializeComponent();
            BindingContext = HistorialViewModel.GetInstance();
        }
    }
}