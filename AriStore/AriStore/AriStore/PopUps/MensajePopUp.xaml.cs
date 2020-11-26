namespace AriStore.PopUps
{
    using AriStore.ViewModels.PopUps;
    using Rg.Plugins.Popup.Pages;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MnesajePopUp : PopupPage
    {
        public MnesajePopUp()
        {
            InitializeComponent();
            BindingContext = PopUpViewModel.GetInstance();
        }
    }
}