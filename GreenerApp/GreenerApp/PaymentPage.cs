using Xamarin.Forms;
using System;
using System.Collections.Generic;

namespace GreenerApp
{
    public class PaymentPage : ContentPage
    {
        Entry fullNameEntry;
        Entry plotNumberEntry;
        Entry amountEntry;
        Button payButton;
        Button historyButton;
        List<string> paymentHistory;

        public PaymentPage()
        {
            Title = "Оплата";
            paymentHistory = new List<string>();

            fullNameEntry = new Entry
            {
                Placeholder = "ФИО",
                Keyboard = Keyboard.Text
            };

            plotNumberEntry = new Entry
            {
                Placeholder = "Номер участка",
                Keyboard = Keyboard.Numeric
            };

            amountEntry = new Entry
            {
                Placeholder = "Сумма взноса",
                Keyboard = Keyboard.Numeric
            };

            payButton = new Button
            {
                Text = "Совершить взнос",
                BackgroundColor = Color.FromHex("#C8E6C9"),
                TextColor = Color.FromHex("#1B5E20")
            };
            payButton.Clicked += OnPayButtonClicked;

            historyButton = new Button
            {
                Text = "История взносов",
                BackgroundColor = Color.FromHex("#C8E6C9"),
                TextColor = Color.FromHex("#1B5E20")
            };
            historyButton.Clicked += OnHistoryButtonClicked;

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children = {
                    new Label { Text = "Введите данные для оплаты", FontSize = 20 },
                    fullNameEntry,
                    plotNumberEntry,
                    amountEntry,
                    payButton,
                    historyButton
                }
            };
        }

        private async void OnPayButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fullNameEntry.Text) || string.IsNullOrEmpty(plotNumberEntry.Text) || string.IsNullOrEmpty(amountEntry.Text))
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "OK");
            }
            else
            {
                string cardNumber = await DisplayPromptAsync("Введите данные карты", "Номер карты", "OK", "Отмена", keyboard: Keyboard.Numeric);
                string expirationDate = await DisplayPromptAsync("Введите данные карты", "Срок действия карты", "OK", "Отмена", keyboard: Keyboard.Numeric);
                string cvv = await DisplayPromptAsync("Введите данные карты", "CVV-код", "OK", "Отмена", keyboard: Keyboard.Numeric);

                if (!string.IsNullOrEmpty(cardNumber) && !string.IsNullOrEmpty(expirationDate) && !string.IsNullOrEmpty(cvv))
                {
                    // Логика обработки успешной оплаты
                    string paymentInfo = $"Оплата на сумму {amountEntry.Text} прошла успешно ({DateTime.Now})";
                    paymentHistory.Add(paymentInfo);
                    await DisplayAlert("Оплата", "Оплата прошла успешно", "OK");
                }
            }
        }

        private async void OnHistoryButtonClicked(object sender, EventArgs e)
        {
            string history = "История взносов:\n";
            foreach (var payment in paymentHistory)
            {
                history += payment + "\n";
            }
            await DisplayAlert("История взносов", history, "OK");
        }
    }
}









