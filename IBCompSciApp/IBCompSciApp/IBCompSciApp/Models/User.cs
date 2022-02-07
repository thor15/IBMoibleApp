using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IBCompSciApp.Models
{
    public class User
    {
        public string Email
        {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }

        public List<Series> AllSeries{ get; set; }

        public User(string e, string p)
        {
            Email = e;
            Password = p;
            AllSeries = new List<Series>();
        }


        public void SetPassword(string pass)
        {
            Password = pass;
        }
    }
}
