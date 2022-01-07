using System;
using System.Collections.Generic;
using System.Text;

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

        public User(string e, string p)
        {
            Email = e;
            Password = p;
        }
    }
}
