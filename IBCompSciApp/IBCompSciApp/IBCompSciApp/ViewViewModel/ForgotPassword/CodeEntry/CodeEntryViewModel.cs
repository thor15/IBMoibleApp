using IBCompSciApp.Models;
using MyFirstProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace IBCompSciApp.ViewViewModel.ForgotPassword.CodeEntry
{
    class CodeEntryViewModel : BaseViewModel
    {
        private string _codeText;
        public string CodeText
        {
            get
            {
                return _codeText;
            }
            set
            {
                if (_codeText != value)
                {
                    SetProperty(ref _codeText, value);
                }
            }
        }

        public ICommand CheckCodeClickedClicked { get; set; }

        public int attempts = 0;

        public User user;

        public CodeEntryViewModel(User us)
        {
            CheckCodeClickedClicked = new Command(CheckCodeClickedClickedAsync);
            user = us;
        }

        private async void CheckCodeClickedClickedAsync(object obj)
        {
            int inputedCode;
            if(int.TryParse(_codeText,out inputedCode))
            {
                if(inputedCode != CodeGeneration.code)
                {
                    attempts++;
                    await Application.Current.MainPage.DisplayAlert("Code Entry", "Invalid Code", "Ok");
                    return;
                }
            }

            if(attempts == 3)
            {
                await Application.Current.MainPage.DisplayAlert("Code Entry", "Reset Code", "Ok");
                await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordView());
            }

            await Application.Current.MainPage.Navigation.PushAsync(new ResetPassword.ResetPasswordView(user));
        }

        /*protected virtual void OnAppearing()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }*/
    }
}
