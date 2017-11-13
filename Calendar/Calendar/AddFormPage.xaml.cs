using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateModel;
using DayModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFormPage : ContentPage
    {
        private Day day;

        List<string>types=new List<string>(){"Test","Homework","Other"};

        public AddFormPage(Day d)
        {
            day = d;
            InitializeComponent();
            foreach (var i in types)
            {
                valuepicker.Items.Add(i);
            }
        }

        private async void CancelClicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }

        private async void AddEvent(object sender, EventArgs e)
        {

            if (FormIsValid())
            {
                DayEvent dayEvent=new DayEvent();
                dayEvent.Title = title.Text;
                dayEvent.Content = Editor.Text;
                dayEvent.Time = new DateTime(day.Date.Year,day.Date.Month,day.Date.Day,timePicker.Time.Hours,timePicker.Time.Minutes,0);
                dayEvent.Type=new Func<EventType>(() =>
                {
                    switch (valuepicker.SelectedIndex)
                    {
                        case 0: return EventType.test;
                        case 1: return EventType.homework;
                        default: return EventType.other;
                    }
                }).Invoke();
                //await DisplayAlert("DONE!", $"Title: {dayEvent.Title} Date: {dayEvent.Time.Day}" , "ok");
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Form is not valid","Title is null or white space","Try again");

        }

        private bool FormIsValid()
        {
            bool x = true;
            if (string.IsNullOrWhiteSpace(title.Text))
                x = false;
            
            return x;
        }
    }
}