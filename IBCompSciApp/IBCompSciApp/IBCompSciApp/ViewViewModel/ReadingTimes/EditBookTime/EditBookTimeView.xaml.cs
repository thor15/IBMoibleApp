using IBCompSciApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBCompSciApp.ViewViewModel.ReadingTimes.EditBookTime
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBookTimeView : ContentPage
    {
        public EditBookTimeView(Book b)
        {
            InitializeComponent();
            BindingContext = new EditDateTimeViewModel(b);
        }
    }
}