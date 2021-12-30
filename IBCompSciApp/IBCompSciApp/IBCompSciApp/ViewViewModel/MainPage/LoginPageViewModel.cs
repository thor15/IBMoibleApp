using MyFirstProject.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.MainPage
{
    class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginClicked { get; set; }
        public ICommand ForgotPassClicked { get; set; }
        public ICommand NewUserClicked { get; set; }

        public LoginPageViewModel()
        {
            Title = "Login";
            LoginClicked = new Command(LoginClickedAsync);
            ForgotPassClicked = new Command(ForgotPassClickedAsync);
            NewUserClicked = new Command(NewUserClickedAsync);
        }

        private async void LoginClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Home.HomePageView());
        }

        private async void ForgotPassClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ForgotPassword.ForgotPasswordView());
        }

        private async void NewUserClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewUser.NewUserView());
        }
    }
}
