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
using System.Collections.ObjectModel;

namespace IBCompSciApp.ViewViewModel.Series.AddSeries
{
    class AddSeriesViewModel
    {

        public ObservableCollection<BookInformation> BookInfo { get; }

        public string TitleToLookFor { get; set; }

        public ICommand SearchClicked { get; set; }



        public Command<BookInformation> AddToShelf
        {
            get
            {
                return new Command<BookInformation>((BookInformation book) =>
                {
                    CurrentUsers.ActiveUser.Books.Add(book);
                    Application.Current.MainPage.Navigation.PopAsync();
                    Application.Current.MainPage.Navigation.PopAsync();
                    Application.Current.MainPage.Navigation.PushAsync(new Series.SeriesView());
                });

            }
        }

        public AddSeriesViewModel()
        {
            SearchClicked = new Command(SearchClickedData);
            BookInfo = new ObservableCollection<BookInformation>();
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

                BookInfo.Clear();

                SearchInformation apiData = JsonConvert.DeserializeObject<SearchInformation>(content);

                foreach (BookInformation book in apiData.docs)
                {
                    if (book != null)
                    {
                        BookInfo.Add(book);
                    }
                }

                Debug.WriteLine("aasfdasdf");
            }
        }
    }
}
