namespace AriStore.Views.Detalle
{
    using AriStore.ViewModels.Detalle;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleClientePage : ContentPage
    {
        public DetalleClientePage()
        {
            InitializeComponent();
            BindingContext = DetalleClienteViewModel.GetInstance();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await DetalleClienteViewModel.GetInstance().GetData();
        }
    }
}