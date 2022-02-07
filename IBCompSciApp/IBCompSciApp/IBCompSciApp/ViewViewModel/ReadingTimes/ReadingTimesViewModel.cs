using IBCompSciApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.ReadingTimes
{
    class ReadingTimesViewModel
    {
        public ObservableCollection<Book> FinishedBooks { get; set; }
        public ObservableCollection<BookInformation> FinishedBooksInfo { get; set; }

        public Command<Book> EditTimesClicked
        {
            get
            {
                return new Command<Book>((Book book) =>
                {
                    Application.Current.MainPage.Navigation.PushAsync(new EditBookTime.EditBookTimeView(book));
                    MessagingCenter.Subscribe<Book>(this, "EditTime", async (data) =>
                    {
                        int index = FinishedBooks.IndexOf(book);
                        FinishedBooks.Remove(book);
                        FinishedBooks.Insert(index, data);

                        MessagingCenter.Unsubscribe<Book>(this, "EditTime");
                    });
                });
            }
        }

        public ReadingTimesViewModel()
        {
            FinishedBooks = new ObservableCollection<Book>();
            FinishedBooksInfo = new ObservableCollection<BookInformation>();
            SetBooks();
        }

        private void SetBooks()
        {
            foreach (Models.Series series in CurrentUsers.ActiveUser.AllSeries)
            {
                for(int i = 0; i < series.CurrentBook; i++)
                {
                    FinishedBooks.Add(series.books[i]);
                    FinishedBooksInfo.Add(series.books[i].bookInformation);
                }

            }
        }
    }
}
