using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarouselFormsApp
{
    class WordPage : CarouselPage
    {
        public WordPage()
        {
            //create list of pages
            List<ContentPage> pages = new List<ContentPage>(0);

            //cycle through colours - soon to be words
            Color[] colors = { Color.Red, Color.Green, Color.Blue };
            foreach (Color c in colors)
            {
                pages.Add(new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children = {
                        new Label { Text = c.ToString () },
                        new BoxView {
                            Color = c,
                            VerticalOptions = LayoutOptions.FillAndExpand
            }
                    }
                    }
                });
            }

            CarouselPage MainPage;
            MainPage = new CarouselPage
            {
                Children = { pages[0],
                         pages[1],
                         pages[2] }
            };
        }
    }
}
