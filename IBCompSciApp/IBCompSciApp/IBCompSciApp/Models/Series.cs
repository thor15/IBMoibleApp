using System;
using System.Collections.Generic;
using System.Text;


namespace IBCompSciApp.Models
{
    public class Series
    {

        public string Name = "";
        public int LenghtOfSeries = 0;
        

        public Series(string n, int l)
        {
            Name = n;
            LenghtOfSeries = l;
        }


        public static List<Series> CurrentSeries = new List<Series>() { new Series("Lord of the Rings", 3), new Series("Harry Potter", 7), new Series("Dune", 6), 
            new Series("Foundation", 3), new Series("Ser", 4) };
        
    }
}
