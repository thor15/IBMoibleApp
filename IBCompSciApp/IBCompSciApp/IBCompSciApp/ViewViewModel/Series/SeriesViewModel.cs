using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using IBCompSciApp.Models;

namespace IBCompSciApp.ViewViewModel.Series
{
    class SeriesViewModel
    {

        public ObservableCollection<string> Titles { get; set; } = new ObservableCollection<string>();

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

        public SeriesViewModel()
        {
            OnAddClicked = new Command(OnAddClickedAsync);
            LoadBooks();
        }

        private void LoadBooks()
        {
            foreach (BookInformation b in CurrentUsers.ActiveUser.Books)
            {
                Titles.Add(b.title);
            }
        }

        private async void OnAddClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddSeries.AddSeriesView());
        }
        
    }
}
