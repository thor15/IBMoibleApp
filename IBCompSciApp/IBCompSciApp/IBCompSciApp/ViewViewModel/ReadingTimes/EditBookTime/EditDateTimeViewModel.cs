using IBCompSciApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.ReadingTimes.EditBookTime
{
    internal class EditDateTimeViewModel
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Book book;

        public Command UdpateDate 
        {
            get
            {
                return new Command<Models.Series>((Models.Series s) =>
                {
                    book.daysToRead = EndDate - StartDate;
                    MessagingCenter.Send<Book>(book, "EditTime");
                    Application.Current.MainPage.Navigation.PopAsync();
                });

            }
        }

        

        public EditDateTimeViewModel(Book b)
        {
            book = b;
        }
    }
}
