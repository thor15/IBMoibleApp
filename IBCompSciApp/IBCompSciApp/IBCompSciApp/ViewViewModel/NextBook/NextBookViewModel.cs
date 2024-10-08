﻿using IBCompSciApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;


namespace IBCompSciApp.ViewViewModel.NextBook
{
    class NextBookViewModel
    {
        public ObservableCollection<BookInformation> UseresBooks { get; set; }

        public Command<BookInformation> FinishedBook
        {
            get
            {

                return new Command<BookInformation>((BookInformation book) =>
                {
                    var series = CurrentUsers.ActiveUser.AllSeries.FirstOrDefault(x => x.books[x.CurrentBook].bookInformation.Equals(book));

                    if(!series.IncreaseCurrentBook())
                    {
                        Application.Current.MainPage.DisplayAlert("Next Book", "You have finished the series", "OK");
                        series.Finished = true;
                    }

                    int indexToReplace = UseresBooks.IndexOf(book);

                    UseresBooks.Remove(book);
                    UseresBooks.Insert(indexToReplace, series.books[series.CurrentBook].bookInformation);
                    UserPersist.SaveUsers(CurrentUsers.AllUsers);
                });
            }
        }

        public NextBookViewModel()
        {
            UseresBooks = new ObservableCollection<BookInformation>();
            foreach (Models.Series book in CurrentUsers.ActiveUser.AllSeries)
            {
                if (book.Finished != true)
                {
                    UseresBooks.Add(book.books[book.CurrentBook].bookInformation);
                }
            }

            if(UseresBooks.Count == 0)
            {
                Application.Current.MainPage.DisplayAlert("Books", "You have no unfinished series", "OK");
            }
        }


    }
}
