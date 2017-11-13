using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar.model
{
    public class DefaultCell:ViewCell
    {
        public DefaultCell()
        {
            var Wrapper = new StackLayout();
            Wrapper.Orientation = StackOrientation.Horizontal;
            Wrapper.Margin=new Thickness(20,0,20,0);
            
            var Title=new Label();
            Title.SetBinding(Label.TextProperty,"Title");
            Title.TextColor = Color.FromHex("#eee");
            Title.VerticalTextAlignment = TextAlignment.Center;
            Title.Margin = new Thickness(15, 0, 0, 0);

            var Time=new Label();
            Time.SetBinding(Label.TextProperty,"time");
            Time.TextColor = Color.FromHex("#eee");
            Time.VerticalTextAlignment = TextAlignment.Center;
            Time.FontSize = 18;
            Time.Margin=new Thickness(15,0,0,0);
            Time.MinimumWidthRequest = 45;
          
            var ColorBox=new BoxView();
            ColorBox.SetBinding(BoxView.BackgroundColorProperty,"type");
         
            var ColorWrapper = new AbsoluteLayout();
            ColorWrapper.WidthRequest = ColorWrapper.Height;
            ColorWrapper.Children.Add(ColorBox,new Rectangle(0.5,0.5,20,20),AbsoluteLayoutFlags.PositionProportional);
            
            Wrapper.Children.Add(ColorWrapper);
            Wrapper.Children.Add(Time);
            Wrapper.Children.Add(Title);
            var TypeColor=new BoxView();
           
            View = Wrapper;
        }
    }
}
