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
