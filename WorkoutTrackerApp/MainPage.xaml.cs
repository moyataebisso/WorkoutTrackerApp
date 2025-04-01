using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Microsoft.Maui.Storage;

namespace WorkoutTrackerApp
{
    public partial class MainPage : ContentPage
    {
        private int selectedMonth = 3;
        private int selectedYear = 2025;

        private Dictionary<string, string> workoutData = new();

        public MainPage()
        {
            InitializeComponent();
            LoadWorkoutData();
            GenerateCalendar(selectedMonth, selectedYear);
        }

        private void OnMonthChanged(object sender, EventArgs e)
        {
            var button = (Button)sender;
            selectedMonth = int.Parse(button.CommandParameter.ToString());
            GenerateCalendar(selectedMonth, selectedYear);
        }

        private void GenerateCalendar(int month, int year)
        {
            CalendarGrid.Children.Clear();

            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDayOfWeek = (int)firstDay.DayOfWeek;

            MonthLabel.Text = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}";

            // Add weekday headers
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 0; i < 7; i++)
            {
                var headerLabel = new Label
                {
                    Text = weekDays[i],
                    HorizontalOptions = LayoutOptions.Center,
                    FontAttributes = FontAttributes.Bold
                };

                Grid.SetRow(headerLabel, 0);
                Grid.SetColumn(headerLabel, i);
                CalendarGrid.Children.Add(headerLabel);
            }

            // Fill calendar days
            int row = 1;
            int col = startDayOfWeek;
            for (int day = 1; day <= daysInMonth; day++)
            {
                string dateKey = $"{year}-{month:D2}-{day:D2}";
                Color backgroundColor = Colors.LightPink;
                string emoji = "";

                if (workoutData.TryGetValue(dateKey, out string workout))
                {
                    if (workout.ToLower().Contains("rest"))
                    {
                        backgroundColor = Colors.LightYellow;
                        emoji = "😴 ";
                    }
                    else
                    {
                        backgroundColor = Colors.LightGreen;
                        emoji = "💪 ";
                    }
                }

                var dayLabel = new Label
                {
                    Text = $"{emoji}{day}",
                    BackgroundColor = backgroundColor,
                    Padding = 8,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill
                };

                // Make day tappable to mark as rest
                var tapGesture = new TapGestureRecognizer();
                int capturedDay = day;
                tapGesture.Tapped += async (s, e) =>
                {
                    bool confirm = await DisplayAlert(
                        "Mark Rest Day",
                        $"Set {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {capturedDay} as a Rest Day?",
                        "Yes", "Cancel");

                    if (confirm)
                    {
                        string key = $"{year}-{month:D2}-{capturedDay:D2}";
                        workoutData[key] = "Rest";
                        SaveWorkoutData();
                        GenerateCalendar(month, year);
                    }
                };
                dayLabel.GestureRecognizers.Add(tapGesture);

                Grid.SetRow(dayLabel, row);
                Grid.SetColumn(dayLabel, col);
                CalendarGrid.Children.Add(dayLabel);

                col++;
                if (col > 6)
                {
                    col = 0;
                    row++;
                }
            }
        }

        private void SaveWorkoutData()
        {
            string json = JsonConvert.SerializeObject(workoutData);
            Preferences.Set("WorkoutData", json);
        }

        private void LoadWorkoutData()
        {
            string saved = Preferences.Get("WorkoutData", null);
            if (!string.IsNullOrEmpty(saved))
            {
                workoutData = JsonConvert.DeserializeObject<Dictionary<string, string>>(saved);
            }
            else
            {
                // First time loading, populate with original history
                workoutData = new Dictionary<string, string>
                {
                    { "2025-01-03", "Chest + Arms" },
                    { "2025-01-05", "Chest + Arms" },
                    { "2025-01-14", "Chest + Arms" },
                    { "2025-01-22", "Chest + Arms" },
                    { "2025-01-24", "Back + Shoulders" },
                    { "2025-01-27", "Chest + Arms" },
                    { "2025-01-28", "Chest + Arms" },

                    { "2025-02-02", "Chest + Arms" },
                    { "2025-02-04", "Legs" },
                    { "2025-02-08", "Chest + Arms" },
                    { "2025-02-23", "Chest + Arms" },

                    { "2025-03-01", "Chest + Arms" },
                    { "2025-03-03", "Back + Shoulders" },
                    { "2025-03-04", "Chest + Arms" },
                    { "2025-03-06", "Chest + Arms" },
                    { "2025-03-09", "Chest + Arms" },
                    { "2025-03-10", "Chest + Arms" },
                    { "2025-03-12", "Back + Shoulders" },
                    { "2025-03-14", "Chest + Arms" },
                    { "2025-03-17", "Chest + Arms" },
                    { "2025-03-19", "Back + Shoulders" },
                    { "2025-03-20", "Chest + Arms" },
                    { "2025-03-22", "Chest + Arms" }
                };
            }
        }
    }
}
