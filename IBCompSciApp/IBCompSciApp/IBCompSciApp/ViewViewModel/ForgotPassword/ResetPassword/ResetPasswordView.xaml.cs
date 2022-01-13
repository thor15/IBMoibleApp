using IBCompSciApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBCompSciApp.ViewViewModel.ForgotPassword.ResetPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPasswordView : ContentPage
    {
        public ResetPasswordView()
        {
            InitializeComponent();
            
        }

        public ResetPasswordView(User user)
        {
            InitializeComponent();
            BindingContext = new ResetPasswordViewModel(user);
        }
    }
}