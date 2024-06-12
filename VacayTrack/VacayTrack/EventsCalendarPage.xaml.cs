using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace VacayTrack
{
    public partial class EventsCalendarPage : ContentPage
    {
        //private Picker monthPicker;
        //private Picker yearPicker;
        //private ListView calendarListView;
        //private Button showCalendarButton;

        public EventsCalendarPage()
        {
            InitializeComponent();
            InitializeUI();

            // Установка обработчика события Clicked для кнопки
            showCalendarButton.Clicked += ShowCalendarButton_Clicked;
            NavigationPage.SetHasBackButton(this, false);
        }

        private Grid calendarGrid;

        private void InitializeUI()
        {
            monthPicker = new Picker
            {
                Title = "Выберите месяц"
            };
            PopulateMonthPicker(); // Заполнить месяцы

            yearPicker = new Picker
            {
                Title = "Выберите год"
            };
            PopulateYearPicker(); // Заполнить годы

            calendarGrid = new Grid();
            // Добавьте столбцы в Grid для каждого дня недели
            for (int i = 0; i < 7; i++)
            {
                calendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            calendarListView = new ListView();
            calendarListView.ItemTemplate = new DataTemplate(typeof(TextCell));

            showCalendarButton = new Button
            {
                Text = "Показать календарь"
            };
            showCalendarButton.Clicked += ShowCalendarButton_Clicked;

            Button goToButton = new Button // Добавляем кнопку "Перейти"
            {
                Text = "Перейти к режиму выбора дат",
                FontSize = 14
            };
            goToButton.Clicked += GoToButton_Clicked;

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(monthPicker);
            stackLayout.Children.Add(yearPicker);
            stackLayout.Children.Add(showCalendarButton);
            stackLayout.Children.Add(goToButton); // Добавляем кнопку "Перейти" перед кнопкой "Show Calendar"
            stackLayout.Children.Add(calendarGrid); // Добавляем calendarGrid в StackLayout

            Content = stackLayout;
        }

        private void ShowCalendarButton_Clicked(object sender, EventArgs e)
        {
            int selectedMonth = monthPicker.SelectedIndex + 1;
            int selectedYear = Convert.ToInt32(yearPicker.SelectedItem);

            ShowCalendar(selectedMonth, selectedYear);
        }



        private void ShowCalendar(int month, int year)
        {
            // Проверяем, выбран ли месяц и год
            if (month <= 0 || year <= 0)
            {
                // Если месяц или год не выбраны, выходим из метода
                return;
            }

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Получение дня недели для первого дня месяца
            DayOfWeek startDayOfWeek = firstDayOfMonth.DayOfWeek;
            int emptyCells = ((int)startDayOfWeek + 6) % 7; // Не забываем, что воскресенье - первый день недели

            // Очистка предыдущего содержимого Grid
            calendarGrid.Children.Clear();

            // Добавление подписей дней недели
            string[] daysOfWeek = { "ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ", "ВС" };
            for (int i = 0; i < 7; i++)
            {
                Label label = new Label
                {
                    Text = daysOfWeek[i],
                    HorizontalTextAlignment = TextAlignment.Center,
                    Margin = 10
                };
                calendarGrid.Children.Add(label, i, 0);
            }

            // Добавление пустых ячеек для первого дня месяца
            for (int i = 0; i < emptyCells; i++)
            {
                calendarGrid.Children.Add(new Label { Text = "", HorizontalTextAlignment = TextAlignment.Center }, i, 1);
            }

            // Добавление дней месяца
            int row = 1;
            int column = emptyCells;
            for (int day = 1; day <= daysInMonth; day++)
            {
                Button button = new Button
                {
                    Text = day.ToString(),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                button.Clicked += (sender, e) => DayButton_Clicked(sender, e); // Обработчик события для каждой кнопки
                calendarGrid.Children.Add(button, column, row);

                // Переход на новую строку в Grid после каждой недели
                if ((column + 1) % 7 == 0)
                {
                    row++;
                    column = 0;
                }
                else
                {
                    column++;
                }
            }

        }

        private async void GoToButton_Clicked(object sender, EventArgs e) // Переименовываем метод
        {
            await Navigation.PushAsync(new MyCalendarPage());
        }

        private async void DayButton_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("События на выбранную дату", "Назад", null, "Андрей Валерьевич выходит из отпуска",
               "Роберт Кириллович уходит в отпуск", "Алёна Валерьевна уходит в отпуск");
            if (action == "Действие 1")
            {
                // Обработка действия 1
            }
            else if (action == "Действие 2")
            {
                // Обработка действия 2
            }
            else if (action == "Действие 3")
            {
                // Обработка действия 3
            }
            //await Navigation.PushAsync(new EventViewPage());
        }

        private void PopulateMonthPicker()
        {
            // Создаем экземпляр CultureInfo с русской культурой
            CultureInfo russianCulture = new CultureInfo("ru-RU");

            for (int i = 1; i <= 12; i++)
            {
                // Получаем название месяца на русском языке
                string monthName = russianCulture.DateTimeFormat.GetMonthName(i);
                monthPicker.Items.Add(monthName);
            }
        }

        private void PopulateYearPicker()
        {
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 10; i <= currentYear + 10; i++) // Показать 10 лет назад и 10 лет вперед
            {
                yearPicker.Items.Add(i.ToString());
            }
        }
    }
}

