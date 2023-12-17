using Xamarin.Forms;
using System;
using System.Collections.Generic;

namespace GreenerApp
{
    public class ComplaintsAndSuggestionsPage : ContentPage
    {
        Picker typePicker;
        Entry subjectEntry;
        Editor descriptionEditor;
        List<string> history = new List<string>();

        public ComplaintsAndSuggestionsPage()
        {
            Title = "Жалобы и предложения";

            typePicker = new Picker
            {
                Title = "Выберите тип",
                Items = { "Жалоба", "Предложение" }
            };

            subjectEntry = new Entry
            {
                Placeholder = "Тема"
            };

            descriptionEditor = new Editor
            {
                Placeholder = "Введите текст жалобы или предложения",
                HeightRequest = 200
            };

            Button submitButton = new Button
            {
                Text = "Отправить",
                BackgroundColor = Color.FromHex("#C8E6C9"),
                TextColor = Color.FromHex("#1B5E20")
            };
            submitButton.Clicked += OnSubmitButtonClicked;

            Button historyButton = new Button
            {
                Text = "История",
                BackgroundColor = Color.FromHex("#C8E6C9"),
                TextColor = Color.FromHex("#1B5E20")
            };
            historyButton.Clicked += OnHistoryButtonClicked;

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children = {
                    typePicker,
                    subjectEntry,
                    descriptionEditor,
                    submitButton,
                    historyButton
                }
            };
        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            string type = typePicker.SelectedItem.ToString();
            string subject = subjectEntry.Text;
            string description = descriptionEditor.Text;

            string entry = $"{type}: {subject} - {description}";
            history.Add(entry);

            await DisplayAlert("Успешно", $"Ваша {type.ToLower()} отправлено", "OK");

            subjectEntry.Text = "";
            descriptionEditor.Text = "";
        }

        private async void OnHistoryButtonClicked(object sender, EventArgs e)
        {
            string historyText = "История жалоб и предложений:\n";
            foreach (string entry in history)
            {
                historyText += entry + "\n";
            }
            await DisplayAlert("История", historyText, "OK");
        }
    }
}

