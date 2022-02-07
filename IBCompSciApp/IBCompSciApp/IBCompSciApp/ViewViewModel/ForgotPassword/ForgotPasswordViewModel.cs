using IBCompSciApp.Models;
using MyFirstProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.ForgotPassword
{
    class ForgotPasswordViewModel : BaseViewModel
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

        public ICommand SendEmailClicked { get; set; }

        public ForgotPasswordViewModel()
        {
            SendEmailClicked = new Command(SendEmailClickedAsync);
        }

        private async void SendEmailClickedAsync(object obj)
        {
            bool hasUser = false;
            User us = null;
            
            foreach (User user in CurrentUsers.AllUsers)
            {
                if(user.Email.Equals(_emailText))
                {
                    us = user;
                    hasUser = true;
                    break;
                }
            }

            if (!hasUser)
            {
                await Application.Current.MainPage.DisplayAlert("forgot password", "no email found", "ok");
                return;
            }

            CodeGeneration.GenerateCode();
            SendEmail.EmailUser(_emailText, CodeGeneration.code);
            await Application.Current.MainPage.Navigation.PushAsync(new CodeEntry.CodeEntryView(us));
        }

        
    }
}
