using MyFirstProject.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;
using IBCompSciApp.Models;

namespace IBCompSciApp.ViewViewModel.MainPage
{
    class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginClicked { get; set; }
        public ICommand ForgotPassClicked { get; set; }
        public ICommand NewUserClicked { get; set; }

        private string _emailText;
        public string EmailText
        {
            get
            {
                return _emailText;
            }
            set
            {
                if (_emailText != value)
                {
                    SetProperty(ref _emailText, value);
                }
            }
        }

        private string _passwordText;
        public string PasswordText
        {
            get
            {
                return _passwordText;
            }
            set
            {
                if (_passwordText != value)
                {
                    SetProperty(ref _passwordText, value);
                }
            }
        }

        public LoginPageViewModel()
        {
            Title = "Login";
            LoginClicked = new Command(LoginClickedAsync);
            ForgotPassClicked = new Command(ForgotPassClickedAsync);
            NewUserClicked = new Command(NewUserClickedAsync);
            LoadUsers();
        }

        private void LoadUsers()
        {
            FileManager.LoadFromFile("Users", out var allUsers);
            if(string.IsNullOrEmpty(allUsers))
            {
                return;
            }
            string[] users = allUsers.Split(',');
            for(int i = 0; i < users.Length; i++)
            {
                string[] user = users[i].Split(' ');
                CurrentUsers.AllUsers.Add(new User(user[0], user[1]));
            }
        }

        private async void LoginClickedAsync(object obj)
        {
            bool hasEmail = false;
            User user = null;
            foreach (User us in CurrentUsers.AllUsers)
            {
                if(us.Email.Equals(_emailText))
                {
                    hasEmail = true;
                    user = us;
                }
            }

            if(!hasEmail)
            {
                await Application.Current.MainPage.DisplayAlert("Login", "No Email Found", "Ok");
                return;
            }

            
            if(!user.Password.Equals(_passwordText))
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Password Is incorrect", "Ok");
                return;
            }

            PasswordText = "";


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
