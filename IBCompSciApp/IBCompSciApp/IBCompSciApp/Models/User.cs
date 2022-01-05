using System;
using System.Collections.Generic;
using System.Text;

namespace IBCompSciApp.Models
{
    public class User
    {
        public string email
        {
            get;
            private set;
        }

        public string password
        {
            get;
            private set;
        }

        public User(string e, string p)
        {
            email = e;
            password = p;
        }
    }
}
