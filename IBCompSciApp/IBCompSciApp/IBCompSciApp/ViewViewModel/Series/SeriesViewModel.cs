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

        public ObservableCollection<Models.Series> SeriesInfo { get; set; }

        public ICommand OnAddClicked { get; set; }

        public Command<Models.Series> RemoveSeries
        {
            get
            {
                return new Command<Models.Series>((Models.Series s) =>
                {
                    CurrentUsers.ActiveUser.AllSeries.Remove(s);
                    UserPersist.SaveUsers(CurrentUsers.AllUsers);
                    SeriesInfo.Remove(s);
                });

            }
        }

        public Command<Models.Series> AddCommand
        {
            get
            {

                return new Command<Models.Series>((Models.Series s) =>
                {

                    Application.Current.MainPage.Navigation.PushAsync(new AddSeries.AddSeriesView());
                    MessagingCenter.Subscribe<Models.Series>(this, "AddBook", async (data) =>
                    {
                        SeriesInfo.Add(data);

                        UserPersist.SaveUsers(CurrentUsers.AllUsers);

                        MessagingCenter.Unsubscribe<Models.Series>(this, "AddBook");
                    });
                });
            }
        }

        public SeriesViewModel()
        {
            OnAddClicked = new Command(OnAddClickedAsync);
            SeriesInfo = new ObservableCollection<Models.Series>();
            LoadSeries();
        }

        private void LoadSeries()
        {
            foreach (Models.Series series in CurrentUsers.ActiveUser.AllSeries)
            {
                SeriesInfo.Add(series);
            }
        }

        private async void OnAddClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddSeries.AddSeriesView());
        }     
    }
}
