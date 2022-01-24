using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.Series
{
    class SeriesViewModel
    {

        public ICommand OnAddClicked { get; set; }

        public SeriesViewModel()
        {
            OnAddClicked = new Command(OnAddClickedAsync);
        }

        private async void OnAddClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddSeries.AddSeriesView());
        }
        
    }
}
