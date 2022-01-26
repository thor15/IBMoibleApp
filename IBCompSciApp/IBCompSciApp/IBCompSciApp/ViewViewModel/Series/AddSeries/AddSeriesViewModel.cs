using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using IBCompSciApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

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

        private async void SearchClickedData(object obj)
        {
            string search = WebUtility.UrlEncode(TitleToLookFor);
            
            Uri dataSource = new Uri("https://openlibrary.org/search.json?q=" + search);

            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(data));

            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = await client.GetAsync(dataSource);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                 

                Root apiData  = JsonConvert.DeserializeObject<Root>(content);
                Debug.WriteLine("aasfdasdf");
            }
        }
    }
}
