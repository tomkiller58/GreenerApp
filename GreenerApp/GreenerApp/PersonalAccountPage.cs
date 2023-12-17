using System;
using Xamarin.Forms;

namespace GreenerApp
{
    public class PersonalAccountPage : ContentPage
    {
        Entry plotNumberEntry;
        StackLayout plotNumberStack;

        public PersonalAccountPage(string fullName)
        {
            Title = "Профиль собственника";

            Image userPhoto = new Image
            {
                Source = "no_photo.png",
                Aspect = Aspect.AspectFit,
                WidthRequest = 200,
                HeightRequest = 200
            };

            Label fullNameLabel = new Label
            {
                Text = fullName,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            plotNumberEntry = new Entry
            {
                Placeholder = "Номер участка",
                Keyboard = Keyboard.Numeric
            };

            Button addPlotNumberButton = new Button
            {
                Text = "Добавить номер участка",
                BackgroundColor = Color.FromHex("#C8E6C9"),
                TextColor = Color.FromHex("#1B5E20")
            };
            addPlotNumberButton.Clicked += OnAddPlotNumberButtonClicked;

            plotNumberStack = new StackLayout
            {
                Spacing = 10
            };

            var scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(20),
                    Children = {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            userPhoto,
                            fullNameLabel
                        }
                    },
                    new Label
                    {
                        Text = "Номера принадлежащих участков:",
                        FontSize = 20
                    },
                    plotNumberEntry,
                    addPlotNumberButton,
                    plotNumberStack
                }
                }
            };

            Content = scrollView;
        }

        private void OnAddPlotNumberButtonClicked(object sender, EventArgs e)
        {
            Entry newPlotNumberEntry = new Entry
            {
                Placeholder = "Номер участка",
                Keyboard = Keyboard.Numeric
            };
            plotNumberStack.Children.Add(newPlotNumberEntry);
        }
    }

}
