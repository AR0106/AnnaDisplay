using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using annaCore2.Weather;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Drawing;
using Windows.UI.Xaml.Media.Imaging;
using AnnaDisplay.Shared;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AnnaDisplay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer timeTimer = new DispatcherTimer();
        public string month;
        public string hour;
        public string minute;


        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;

            switch (DateTime.Now.Month)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;
                default:
                    month = "error";
                    break;
            }

            if (DateTime.Now.Hour > 12)
            {
                Console.WriteLine("true");
                hour = (DateTime.Now.Hour - 12).ToString();
            }
            else
            {
                Console.WriteLine("false");
                hour = DateTime.Now.Hour.ToString();
            }

            if (DateTime.Now.Minute < 10)
            {
                minute = "0" + DateTime.Now.Minute;
            }
            else
            {
                minute = DateTime.Now.Minute.ToString();
            }
            time_HM.Text = $"{hour}:{minute}";
            day.Text = DateTime.Now.DayOfWeek.ToString();
            date.Text = $"{month} {DateTime.Now.Day}, {DateTime.Now.Year}";

            WeatherCollector.weatherData wData = WeatherCollector.WeatherData();
            currentTempBlock.Text = $"{wData.currentTemp}°F";
            tempRangeBlock.Text = $"High: {wData.highTemp}°F - Low: {wData.lowTemp}°F";
            if (wData.rain == 1)
            {
                weatherIcon.Source = Application.Current.Resources["rain"] as ImageSource;
            }
            else
            {
                weatherIcon.Source = Application.Current.Resources["sun"] as ImageSource;
            }

            timeTimer.Tick += TimeTimer_Tick;
            timeTimer.Interval = new TimeSpan(0, 0, 1);

            timeTimer.Tick += WeatherTimer_Tick;
            timeTimer.Interval = new TimeSpan(0, 15, 0);

            timeTimer.Start();
            timeTimer.Start();
        }

        private void WeatherTimer_Tick(object sender, object e)
        {
            WeatherCollector.weatherData wData = WeatherCollector.WeatherData();
            currentTempBlock.Text = $"{wData.currentTemp}°F";
            tempRangeBlock.Text = $"High: {wData.highTemp}°F - Low: {wData.lowTemp}°F";
            if (wData.rain == 1)
            {
                weatherIcon.Source = Application.Current.Resources["rain"] as ImageSource;
            }
            else
            {
                weatherIcon.Source = Application.Current.Resources["sun"] as ImageSource;
            }
        }

        private void TimeTimer_Tick(object sender, object e)
        {
            switch (DateTime.Now.Month)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;
                default:
                    month = "error";
                    break;
            }

            if (DateTime.Now.Hour > 12)
            {
                Console.WriteLine("true");
                hour = (DateTime.Now.Hour - 12).ToString();
            }
            else
            {
                Console.WriteLine("false");
                hour = DateTime.Now.Hour.ToString();
            }

            if (DateTime.Now.Minute < 10)
            {
                minute = "0" + DateTime.Now.Minute;
            }
            else
            {
                minute = DateTime.Now.Minute.ToString();
            }
            time_HM.Text = $"{hour}:{minute}";
            day.Text = DateTime.Now.DayOfWeek.ToString();
            date.Text = $"{month} {DateTime.Now.Day}, {DateTime.Now.Year}";
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
