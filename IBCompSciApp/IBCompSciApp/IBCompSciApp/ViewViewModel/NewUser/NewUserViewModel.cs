using IBCompSciApp.Models;
using MyFirstProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.NewUser
{
    class NewUserViewModel : BaseViewModel
    {
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

        private string _secondPassword;
        public string SecondPassword
        {
            get
            {
                return _secondPassword;
            }

            set
            {
                if (_secondPassword != value)
                {
                    SetProperty(ref _secondPassword, value);
                }
            }
        }

        public ICommand SignUpClicked { get; set; }

        public NewUserViewModel()
        {
            Title = Titles.NewUser;
            SignUpClicked = new Command(AddUser);
        }

        private void AddUser()
        {
            if (string.IsNullOrEmpty(_emailText.Trim()))
            {
                Application.Current.MainPage.DisplayAlert("Sign Up", "Email Empty", "Ok");
                return;
            }

            if (!IsValidEmail(_emailText))
            {
                Application.Current.MainPage.DisplayAlert("Sign Up", "Invalid email", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(_passwordText.Trim()))
            {
                Application.Current.MainPage.DisplayAlert("Sign Up", "Password Empty", "Ok");
                return;
            }

            

            if(!_passwordText.Equals(_secondPassword))
            {
                Application.Current.MainPage.DisplayAlert("Sign Up", "Passwords do not match", "Ok");
                return;
            }

            CurrentUsers.AllUsers.Add(new User(_emailText, _passwordText));
            UserPersist.SaveUsers(CurrentUsers.AllUsers);

            Application.Current.MainPage.Navigation.PopAsync();
            return;
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
