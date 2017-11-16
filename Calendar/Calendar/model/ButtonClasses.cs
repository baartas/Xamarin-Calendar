using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar.model
{
    public static class ButtonClasses
    {
       public static Style PrimaryButton=new Style(typeof(Button))
        {
            Setters =
            {
                new Setter(){Property = Button.BackgroundColorProperty ,Value = Color.FromRgba(1,1,1,1)},
                new Setter(){Property = Button.TextColorProperty,Value = Color.FromHex("ddd")},
                new Setter(){Property = Button.HeightRequestProperty, Value = 40}
               
            }
        };
        public static Style OtherMonthButton=new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.TextColorProperty,Value = Color.FromHex("888")},             
            }
        };
        public static Style TodayButton = new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.BorderWidthProperty, Value = 2},
                new Setter(){Property = Button.BorderRadiusProperty, Value = 0},
            new Setter(){Property = Button.BorderColorProperty, Value = Color.FromHex("333")}
            }
        };
        public static Style SelectedDayButton = new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.BackgroundColorProperty, Value = Color.FromHex("333")},
                new Setter(){Property = Button.BorderRadiusProperty, Value = 0}
                
            }
        };
        public static Style TestDayButton = new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.BackgroundColorProperty, Value = Color.FromHex("#b43137")},
                new Setter(){Property = Button.BorderRadiusProperty, Value = 0}

            }
        };
        public static Style TestDayButtonClicked = new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.BackgroundColorProperty, Value = Color.FromHex("#563233")},
                new Setter(){Property = Button.BorderRadiusProperty, Value = 0}

            }
        };
        public static Style HomeworkDayButton = new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.BackgroundColorProperty, Value = Color.FromHex("#4286b4")},
                new Setter(){Property = Button.BorderRadiusProperty, Value = 0}

            }
        };
        public static Style HomeworkDayButtonClicked = new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.BackgroundColorProperty, Value = Color.FromHex("#364b59")},
                new Setter(){Property = Button.BorderRadiusProperty, Value = 0}

            }
        };
        public static Style OtherDayButton = new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.BackgroundColorProperty, Value = Color.FromHex("#398c3b")},
                new Setter(){Property = Button.BorderRadiusProperty, Value = 0}

            }
        };
        public static Style OtherDayButtonClicked = new Style(typeof(Button))
        {
            BasedOn = PrimaryButton,
            Setters =
            {
                new Setter(){Property = Button.BackgroundColorProperty, Value = Color.FromHex("#273d28")},
                new Setter(){Property = Button.BorderRadiusProperty, Value = 0}

            }
        };
    }
    
}
