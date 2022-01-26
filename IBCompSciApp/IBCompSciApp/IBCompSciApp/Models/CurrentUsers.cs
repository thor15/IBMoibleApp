using System;
using System.Collections.Generic;
using System.Text;

namespace IBCompSciApp.Models
{
    public class CurrentUsers
    {
        public static List<User> AllUsers = new List<User>();

        public static User ActiveUser;

        public override string ToString()
        {
            string users = "";
            foreach (User user in AllUsers)
            {
                users += user.Email + " " + user.Password + ",";
            }
            return users;
        }
    }
}
