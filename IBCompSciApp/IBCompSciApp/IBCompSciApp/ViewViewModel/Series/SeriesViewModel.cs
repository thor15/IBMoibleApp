using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using IBCompSciApp.Models;
using System.Diagnostics;

namespace IBCompSciApp.ViewViewModel.Series
{
    class SeriesViewModel
    {

        public ObservableCollection<BookInformation> BookInfo { get; set; }

        public ICommand OnAddClicked { get; set; }

        public Command<BookInformation> RemoveSeries
        {
            get
            {
                return new Command<BookInformation>((BookInformation book) =>
                {
                    CurrentUsers.ActiveUser.Books.Remove(book);
                });

            }
        }

        public Command<BookInformation> AddCommand
        {
            get
            {

                return new Command<BookInformation>((BookInformation book) =>
                {

                    Application.Current.MainPage.Navigation.PushAsync(new AddSeries.AddSeriesView());
                    MessagingCenter.Subscribe<BookInformation>(this, "AddBook", async (data) =>
                    {
                        BookInfo.Add(data);
                        Debug.WriteLine(BookInfo.Count);

                        MessagingCenter.Unsubscribe<BookInformation>(this, "AddBook");
                    });
                });
            }
        }

        public SeriesViewModel()
        {
            OnAddClicked = new Command(OnAddClickedAsync);
            BookInfo = new ObservableCollection<BookInformation>();
        }

        

        private async void OnAddClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddSeries.AddSeriesView());
        }     
    }
}
