using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.model;
using DateModel;
using DayModel;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Calendar
{
    public partial class MainPage : ContentPage
    {
        private DateTime SelectedDay;
       
        private DateTime SelectedMonth;

        public List<Day> Days;

        private Button SelectedButton;

        private async void ReDrawCalendar()
        {
            Calendar.Children.Clear();
            ActualMonth.Text = $"{MonthName(SelectedMonth.Month)} {SelectedMonth.Year}";
            Days = await MonthView.GetMonthView(SelectedMonth.Year, SelectedMonth.Month);

            for (int i = 0; i < Days.Count(); i++)
            {
                var button = new Button
                {
                    Text = Days[i].Date.Day.ToString(),
                    CommandParameter = Days[i],
                    Style = new Func<Style>(() =>
                    {
                        if (Days[i].Date == SelectedDay.Date)                        
                            return ButtonClasses.SelectedDayButton;
                        else if (Days[i].DayValue == EventType.test)
                            return ButtonClasses.TestDayButton;
                        else if (Days[i].DayValue == EventType.homework)
                            return ButtonClasses.HomeworkDayButton;
                        else if (Days[i].DayValue == EventType.other)
                            return ButtonClasses.OtherDayButton;
                        else if (Days[i].Date.Date == DateTime.Today)
                            return ButtonClasses.TodayButton;
                        else if (Days[i].Date.Month == SelectedMonth.Month)
                            return ButtonClasses.PrimaryButton;
                        else
                            return ButtonClasses.OtherMonthButton;
                    }).Invoke()
                };
                button.Clicked += ButtonClicked;
                if (button.Style == ButtonClasses.SelectedDayButton)
                    SelectedButton = button;

                Calendar.Children.Add(button, i % 7, i / 7);

            }
        }

        private string MonthName(int month)
        {
            switch (month)
            {
                case 1: { return $"Janury"; }
                case 2: { return $"Febuary"; }
                case 3: { return $"March"; }
                case 4: { return $"April"; }
                case 5: { return $"May"; }
                case 6: { return $"June"; }
                case 7: { return $"July"; }
                case 8: { return $"August"; }
                case 9: { return $"September"; }
                case 10: { return $"November"; }
                case 11: { return $"October"; }
                case 12: { return $"December"; }
                default: return "";
            }
        }

        public async void ChangeMonth(object sender, EventArgs e)
        {
            Button btn=sender as Button;
            if (btn.Text == "Next")
                SelectedMonth = SelectedMonth.AddMonths(1);
            else
                SelectedMonth = SelectedMonth.AddMonths(-1);

           

            ReDrawCalendar();

        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            Day day =(Day) btn.CommandParameter;
            if (SelectedButton != btn)
            {
                SelectedButton.Style =new Func<Style>(() =>
                {
                    var temp=SelectedButton.CommandParameter as Day;
                    if (temp.DayValue == EventType.test)
                        return ButtonClasses.TestDayButton;
                    else if (temp.DayValue == EventType.homework)
                        return ButtonClasses.HomeworkDayButton;
                    else if (temp.DayValue == EventType.other)
                        return ButtonClasses.OtherDayButton;
                    else if (temp.Date.Date == DateTime.Now.Date)
                        return ButtonClasses.TodayButton;
                    else
                        return ButtonClasses.PrimaryButton;
                        
                }).Invoke();
                SelectedButton = btn;
            }
            btn.Style = ButtonClasses.SelectedDayButton;

            SelectedDay = (btn.CommandParameter as Day).Date;

            #region Set EventList source

            EventsList.ItemsSource = day.Events;

            #endregion

            #region Set TimeSpanLabel property

            if (day.Date == DateTime.Now.Date)
            {
                TimeSpanLabel.Text = $"Today is {MonthName(DateTime.Now.Month)} {DateTime.Now.Day}";
            }
            else if (day.Date > DateTime.Now.Date)
            {
                
                TimeSpanLabel.Text = $" {MonthName(day.Date.Month)} {day.Date.Day}, "+new Func<string>(() =>
                {
                    int timespan = int.Parse(Math.Round((day.Date.Date-DateTime.Now.Date).TotalDays).ToString());
                    if (timespan == 1)
                        return "Tomorrow";
                    else
                        return $"in {timespan} days";
                }).Invoke();
            }
            else
            {
                TimeSpanLabel.Text = $" {MonthName(day.Date.Month)} {day.Date.Day}, "+ new Func<string>(() =>
                {
                    int timespan = int.Parse(Math.Round((DateTime.Now.Date-day.Date.Date).TotalDays).ToString());
                    if (timespan == 1)
                        return "Yesterday";
                    else
                        return $"{timespan} days ago";
                }).Invoke();
            }
            #endregion

            #region Change month when other month clicked
            if(day.Date.Month == 1 && SelectedMonth.Month == 12)
            {
                SelectedMonth = SelectedMonth.AddMonths(1);
                ReDrawCalendar();
            }
            else if (day.Date.Month == 12 && SelectedMonth.Month == 1)
            {
                SelectedMonth = SelectedMonth.AddMonths(-1);
                ReDrawCalendar();
            }
            else if (day.Date.Month > SelectedMonth.Month)
            {
                SelectedMonth=SelectedMonth.AddMonths(1);
                ReDrawCalendar();
            }
            else if (day.Date.Month < SelectedMonth.Month)
            {
                SelectedMonth = SelectedMonth.AddMonths(-1);
                ReDrawCalendar();
            }

            #endregion
        }

        public async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFormPage(SelectedButton.CommandParameter as Day));
        }

  
        public MainPage()
        {
            InitializeComponent();
            //Days = MonthView.GetMonthView(DateTime.Now.Year, DateTime.Now.Month).ToList();
            SelectedMonth = DateTime.Now;
            SelectedDay=DateTime.Now.Date;           
            SelectedButton=new Button(){CommandParameter = new Day(DateTime.Now){DayValue = EventType.empty}};
            TimeSpanLabel.Text = $"Today is {MonthName(DateTime.Now.Month)} {DateTime.Now.Day}";
            ReDrawCalendar();
            EventsList.ItemTemplate=new DataTemplate(typeof(DefaultCell));
 
          
        }

       


       
    }
}
