using GreenerApp;
using System;
using Xamarin.Forms;

namespace YourAppName
{
    public class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            Title = "Новичок";

            var logoImage = new Image
            {
                Source = "green.png",
                Aspect = Aspect.AspectFit
            };

            var welcomeLabel = new Label
            {
                Text = "Добро пожаловать в садоводческое товарищество «Новичок»",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            var menuButton = new Button
            {
                Text = "Перейти к меню",
                BackgroundColor = Color.FromHex("#C8E6C9"),
                TextColor = Color.FromHex("#1B5E20")
            };
            menuButton.Clicked += OnMenuButtonClicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    logoImage,
                    welcomeLabel,
                    menuButton
                }
            };
        }

        private async void OnMenuButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenuPage());
        }
    }
}