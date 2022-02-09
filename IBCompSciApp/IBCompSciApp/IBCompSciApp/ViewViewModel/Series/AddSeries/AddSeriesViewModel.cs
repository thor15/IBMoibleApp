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

        public List<BookInformation> BookInfo { get; }
        public ObservableCollection<Models.Series> SearchedForSeries { get; }

        public string TitleToLookFor { get; set; }

        public ICommand SearchClicked { get; set; }



        public Command<Models.Series> AddToShelf
        {
            get
            {
                return new Command<Models.Series>((Models.Series s) =>
                {
                    CurrentUsers.ActiveUser.AllSeries.Add(s);
                    MessagingCenter.Send<Models.Series>(s, "AddBook");
                    Application.Current.MainPage.Navigation.PopAsync();
                });

            }
        }

        public AddSeriesViewModel()
        {
            SearchClicked = new Command(SearchClickedData);
            BookInfo = new List<BookInformation>();
            SearchedForSeries = new ObservableCollection<Models.Series>();
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

                string authorKey = apiData.docs[0].author_key[0];

                foreach (BookInformation book in apiData.docs)
                { 
                    if (book != null && CheckAuthorKey(book, authorKey) && !CheckBook(book))
                    {
                        BookInfo.Add(book);
                    }
                }
                
                List<Book> currentBooks = new List<Book>();

                foreach (BookInformation book in BookInfo)
                {
                    currentBooks.Add(new Book(book));
                }

                

                Models.Series series = new Models.Series(TitleToLookFor, currentBooks);

                SearchedForSeries.Add(series);
            }
        }

        private bool CheckBook(BookInformation book)
        {
            bool isInSeries = BookInfo.Contains(book);
            return isInSeries;
        }

        private bool CheckAuthorKey(BookInformation book, string key)
        {
            bool hasKeys = false;
            
            if(book.author_key == null)
            {
                return false;
            }

            for(int i = 0; i < book.author_key.Count; i++)
            {
                if(book.author_key[i] != null && book.author_key[i].Equals(key))
                {
                    hasKeys = true;
                    break;
                }
            }

            if(hasKeys == false)
            {
                return false;
            }

            return true;
        }
    }
}
