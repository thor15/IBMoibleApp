using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBCompSciApp.ViewViewModel.NewUser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserView : ContentPage
    {
        public NewUserView()
        {
            InitializeComponent();
            BindingContext = new NewUserViewModel();
        }
    }
}