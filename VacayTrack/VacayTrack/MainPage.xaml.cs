using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VacayTrack
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected override void OnAppearing()
        {
            //StackLayout stack = new StackLayout();

            //Label label = new Label();
            //label.Text = "VacayTrack";
            //label.HorizontalOptions = LayoutOptions.Center;
            //stack.Children.Add(label);

            //Entry entrySurname = new Entry();
            //entrySurname.Placeholder = "Фамилия";
            //stack.Children.Add(entrySurname);

            //Entry entryName = new Entry();
            //entryName.Placeholder = "Имя";
            //stack.Children.Add(entryName);

            //Entry entryPassword = new Entry();
            //entryPassword.Placeholder = "Пароль";
            //entryPassword.IsPassword = true;
            //stack.Children.Add(entryPassword);

            //Button buttonEnter = new Button();
            //buttonEnter.Text = "Войти";
            //buttonEnter.BackgroundColor = Color.LightBlue;
            //buttonEnter.Clicked += ButtonClick;


            //stack.Children.Add(buttonEnter);


            //Content = stack;

            //StackLayout stack = new StackLayout();
            //Entry entryCode = new Entry();
            //entryCode.Placeholder = "Кодовое слово";
            //entryCode.IsPassword = true;
            //stack.Children.Add(entryCode);

            //Content = stack;
        }

        private async void RadioButtonClick(object sender, EventArgs e)
        {
            Entry entryCodeWord = new Entry();
            entryCodeWord.Placeholder = "Кодовое слово";
            entryCodeWord.IsPassword = true;
        }

        private async void ButtonEnterClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameField.Text) && string.IsNullOrEmpty(surnameField.Text) && string.IsNullOrEmpty(passwodField.Text))
                errorText.Text = "Данные для входа не указаны";
            else if (string.IsNullOrEmpty(nameField.Text))
                errorText.Text = "Имя не указано";
            else if (string.IsNullOrEmpty(surnameField.Text))
                errorText.Text = "Фамилия не указана";
            else if (string.IsNullOrEmpty(passwodField.Text))
                errorText.Text = "Пароль не указан";
            else
            {
                await Navigation.PushAsync(new MyCalendarPage());
            }
                
        }

        private async void ButtonWorkClick(object sender, EventArgs e)
        {
            //StackLayout stack = new StackLayout();
            //Entry entryCode = new Entry();
            //entryCode.Placeholder = "Кодовое слово";
            //entryCode.IsPassword = true;
            //stack.Children.Add(entryCode);

            //Content = stack;

            //await DisplayAlert("Вход в приложение", "Все данные получены", "OK");

            await Navigation.PushAsync(new EmployerPage());
        }
    }
}
