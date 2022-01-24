using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBCompSciApp.ViewViewModel.Series.AddSeries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSeriesView : ContentPage
    {
        public AddSeriesView()
        {
            InitializeComponent();
            BindingContext = new AddSeriesViewModel();
        }
    }
}