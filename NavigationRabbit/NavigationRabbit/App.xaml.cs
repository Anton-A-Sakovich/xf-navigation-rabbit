using Xamarin.Forms;

namespace NavigationRabbit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new MainPage();
            MainPage = new NavigationPage(page);
            page.OnPushed();
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
