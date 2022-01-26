using System;
using System.Collections.Generic;
using System.Text;

namespace IBCompSciApp.Models
{
    public class SearchInformation
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public bool numFoundExact { get; set; }
        public List<BookInformation> docs { get; set; }
        public int num_found { get; set; }
        public string q { get; set; }
        public object offset { get; set; }
    }
}
