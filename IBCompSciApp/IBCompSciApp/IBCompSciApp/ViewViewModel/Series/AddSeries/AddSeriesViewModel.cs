using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.Series.AddSeries
{
    class AddSeriesViewModel
    {

        public string TitleToLookFor { get; set; }

        public ICommand SearchClicked { get; set; }

        public AddSeriesViewModel()
        {
            SearchClicked = new Command(SearchClickedData);
        }

        private void SearchClickedData(object obj)
        {
            string data = "https://openlibrary.org/search.json?q=lord+of+the+rings";
            
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(data));
        }
    }
}
