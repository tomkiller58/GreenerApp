using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Button = Xamarin.Forms.Button;

namespace GreenerApp
{
    class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            Label header = new Label
            {
                Text = "Меню",
                FontSize = 40,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            Button personalAccountButton = new Button
            {
                Text = "Личный кабинет",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                WidthRequest = 400,
                BackgroundColor = Color.FromHex("#C8E6C9"), 
                TextColor = Color.FromHex("#1B5E20") 
            };
            personalAccountButton.Clicked += async (sender, args) =>
            await Navigation.PushAsync(new LoginPage());


            Button PaymentPageButton = new Button
            {
                Text = "Совершить взнос",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                WidthRequest = 400,
                BackgroundColor = Color.FromHex("#C8E6C9"), 
                TextColor = Color.FromHex("#1B5E20") // 
            };
            PaymentPageButton.Clicked += async (sender, args) =>
            await Navigation.PushAsync(new PaymentPage());

            Button ComplaintsAndSuggestionsPageButton = new Button
            {
                Text = "Жалобы и предложения",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                WidthRequest = 400,
                BackgroundColor = Color.FromHex("#C8E6C9"), 
                TextColor = Color.FromHex("#1B5E20") 
            };
            ComplaintsAndSuggestionsPageButton.Clicked += async (sender, args) =>
            await Navigation.PushAsync(new ComplaintsAndSuggestionsPage());


            Content = new StackLayout
            {
                Children =
                 {
                    header,
                    new StackLayout
                    {
                     HorizontalOptions = LayoutOptions.Center,
                     Children =
                     {
                        personalAccountButton,
                        PaymentPageButton,
                        ComplaintsAndSuggestionsPageButton
                     }
                    }
                }
            };
        }
    }
}
