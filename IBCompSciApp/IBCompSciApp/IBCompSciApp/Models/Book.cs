using System;
using System.Collections.Generic;
using System.Text;

namespace IBCompSciApp.Models
{
    public class Book
    {
        public BookInformation bookInformation { get; set; }
        public TimeSpan daysToRead { get; set; }

        public Book(BookInformation b)
        {
            bookInformation = b;
        }

    }
}
