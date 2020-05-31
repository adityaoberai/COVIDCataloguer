using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

using Xamarin.Forms;
using RookieHacksCOVID.Models;

namespace RookieHacksCOVID
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RookieHacksCOVID.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}