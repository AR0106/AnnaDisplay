using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using annaCore2.News;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AnnaDisplay.Shared
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class newsPage : Page
    {
        DispatcherTimer newsTimer = new DispatcherTimer();

        public newsPage()
        {
            this.InitializeComponent();

            InitNews();

            newsTimer.Tick += NewsTimer_Tick;
            newsTimer.Interval = new TimeSpan(0, 30, 0);

            newsTimer.Start();
        }

        private void InitNews()
        {
            var NewsAggregate = NewsCollector.NyPostCollector();

            foreach (var item in NewsCollector.BreitbartCollector())
            {
                NewsAggregate.Add(item);
            }

            foreach (var story in NewsAggregate)
            {
                var visibleStory = new ArticleControl
                {
                    LinkText = story.link,
                    Title = story.headline,
                    Topic = $"{story.source}"
                };

                NewsStack.Children.Add(visibleStory);
            }
        }

        private void NewsTimer_Tick(object sender, object e)
        {
            List<NewsCollector.newsStory> stories = new List<NewsCollector.newsStory>();
            foreach (var story in NewsCollector.AggregateStories())
            {
                var visibleStory = new ArticleControl
                {
                    LinkText = story.link,
                    Title = story.headline,
                    Topic = $"{story.topic} - {story.source}"
                };
            }
        }

        private void OnHomeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void OnNewsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(newsPage));
        }
    }
}
