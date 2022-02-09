using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBCompSciApp.Models
{
    [Serializable]
    public class Book
    {
        public BookInformation bookInformation { get; set; }

        //[JsonIgnore]
        public TimeSpan daysToRead { get; set; }

        /*public long daysToReadStore
        {
            get
            {
                if (daysToRead != null)
                    return daysToRead.Ticks;
                return 0;
            }
            set
            {
                if (value != 0)
                    daysToRead = new TimeSpan(value);
            }
        }*/

        public Book()
        {

        }

        public Book(BookInformation b)
        {
            bookInformation = b;
        }

    }
}
