using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourAppName;

namespace GreenerApp
{
    public partial class App : Application
    {
        public App()
        {
            // Create the main menu page
            //var mainMenuPage = new MainMenuPage();

            // Set the main page of the application to the main menu
            MainPage = new NavigationPage(new WelcomePage());
        }
    }
}

