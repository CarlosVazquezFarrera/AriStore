namespace AriStore
{
    using AriStore.Helpers;
    using AriStore.Repositories;
    using Xamarin.Forms;
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("aris.db3");

        public static DataRepository dataRepository { get; private set; }

        public App()
        {
            InitializeComponent();

            dataRepository = new DataRepository(dbPath);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
