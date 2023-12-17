using System;
using Xamarin.Forms;

namespace GreenerApp
{
    public class LoginPage : ContentPage
    {
        Entry usernameEntry;
        Entry passwordEntry;
        Button loginButton;

        public LoginPage()
        {
            Title = "Личный кабинет собственника";

            usernameEntry = new Entry
            {
                Placeholder = "Логин",
                Keyboard = Keyboard.Text
            };

            passwordEntry = new Entry
            {
                Placeholder = "Пароль",
                IsPassword = true
            };

            loginButton = new Button
            {
                Text = "Войти",
                BackgroundColor = Color.FromHex("#C8E6C9"),
                TextColor = Color.FromHex("#1B5E20")
            };
            loginButton.Clicked += OnLoginButtonClicked;

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children = {
                    new Label { Text = "Введите логин и пароль", FontSize = 20 },
                    usernameEntry,
                    passwordEntry,
                    loginButton
                }
            };
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (username == "nastya" && password == "liza")
            {
                await Navigation.PushAsync(new PersonalAccountPage("Кузьминых Елизавета Сергеевна"));
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
            }
        }
    }
}
