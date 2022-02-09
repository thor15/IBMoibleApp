using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IBCompSciApp.Models
{
    [Serializable]
    public class User
    {
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public List<Series> AllSeries{ get; set; }

        public User(string e, string p)
        {
            Email = e;
            Password = p;
            AllSeries = new List<Series>();
        }
        public User()
        {

        }


        public void SetPassword(string pass)
        {
            Password = pass;
        }
    }
}
