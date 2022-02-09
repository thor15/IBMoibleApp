using System;
using System.Collections.Generic;
using System.Text;


namespace IBCompSciApp.Models
{
    [Serializable]
    public class Series
    {

        public string seriesName { get; set; }
        public int LenghtOfSeries = 0;
        public int CurrentBook = 0;
        public List<Book> books;
        
        public Series()
        {

        }

        public Series(string n, List<Book> b)
        {
            seriesName = n;
            books = b;

            LenghtOfSeries = books.Count;

            OrderList();
        }

        private void OrderList()
        {
            for (int i = 0; i < books.Count - 1; i++)
            {
                for (int j = 0; j < books.Count - i - 1; j++)
                {
                    if (books[j].bookInformation.first_publish_year > books[j + 1].bookInformation.first_publish_year)
                    {
                        // swap temp and arr[i]
                        var temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }

        }

        public void IncreaseCurrentBook()
        {
            if(CurrentBook < LenghtOfSeries - 1)
            {
                CurrentBook++;
            }
        }
    }
}
