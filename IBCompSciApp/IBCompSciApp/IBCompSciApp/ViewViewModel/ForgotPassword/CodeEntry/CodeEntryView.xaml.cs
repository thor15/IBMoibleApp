using IBCompSciApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBCompSciApp.ViewViewModel.ForgotPassword.CodeEntry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeEntryView : ContentPage
    {
        public CodeEntryView()
        {
            InitializeComponent();
            
        }
        public CodeEntryView(User user) 
        {
            InitializeComponent();
            BindingContext = new CodeEntryViewModel(user);
        }
    }
}