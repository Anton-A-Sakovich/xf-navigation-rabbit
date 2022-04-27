using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace NavigationRabbit
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            PushModelessPageCommand = new Command(PushModelessPage, () => BindingContext != null);
            PushModalPageCommand = new Command(PushModalPage, () => BindingContext != null);
            PopModelessPageCommand = new Command(PopModelessPage, () => BindingContext != null);
            PopModalPageCommand = new Command(PopModalPage, () => BindingContext != null);
        }

        public Page CurrentPage => this;

        public IEnumerable<Page> LocalNavigationStack => Navigation.NavigationStack;

        public IEnumerable<Page> LocalModalStack => Navigation.ModalStack;

        public IEnumerable<Page> MainNavigationStack => (Application.Current.MainPage as NavigationPage).Navigation.NavigationStack;

        public IEnumerable<Page> MainModalStack => (Application.Current.MainPage as NavigationPage).Navigation.ModalStack;

        public Command PushModelessPageCommand { get; }

        public Command PushModalPageCommand { get; }

        public Command PopModelessPageCommand { get; }

        public Command PopModalPageCommand { get; }

        public void OnPoped()
        {

        }

        public void OnPushed()
        {
            BindingContext = this;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(BindingContext))
            {
                PushModelessPageCommand.ChangeCanExecute();
                PushModalPageCommand.ChangeCanExecute();
                PopModelessPageCommand.ChangeCanExecute();
                PopModalPageCommand.ChangeCanExecute();
            }
        }

        private async void PushModelessPage()
        {
            var page = new MainPage();
            await Navigation.PushAsync(page);
            page.OnPushed();
        }

        private async void PushModalPage()
        {
            var page = new MainPage();
            await Navigation.PushModalAsync(page);
            page.OnPushed();
        }

        private async void PopModelessPage()
        {
            var page = await Navigation.PopAsync();
            (page as MainPage).OnPoped();
        }

        private async void PopModalPage()
        {
            var page = await Navigation.PopModalAsync();
            (page as MainPage).OnPoped();
        }
    }
}
