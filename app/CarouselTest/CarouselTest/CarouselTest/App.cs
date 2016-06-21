using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CarouselTest
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            List<ContentPage> pages = new List<ContentPage>(0);
            string[] words = { "Matariki", "Manaaki", "Haora" };
            foreach (string w in words)
            {
                pages.Add(new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children = {
                            new Label {
                                Text = w,
                                HorizontalOptions = LayoutOptions.Center
                            }
                        }
                    }
                });
            }

            MainPage = new CarouselPage
            {
                Children =
                {
                    pages[0], pages[1],pages[2]
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
