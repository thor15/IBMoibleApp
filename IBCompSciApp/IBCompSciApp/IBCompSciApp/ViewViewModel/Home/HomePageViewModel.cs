using IBCompSciApp.Models;
using MyFirstProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBCompSciApp.ViewViewModel.Home
{
    class HomePageViewModel : BaseViewModel
    {

        public HomePageViewModel()
        {
            Title = "Home";
            SaveUsers();
        }

        private void SaveUsers()
        {
            //string allUsers = CurrentUsers.ToString();
        }
    }
}
