using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;


namespace Simple_Weather_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApiHandler apiHandler;
        public WeatherData weatherData = new WeatherData();

        public MainWindow()
        {
            InitializeComponent();

            if (Environment.GetEnvironmentVariable("API_WEATHER_KEY") != null)
                apiHandler = new ApiHandler(
                        Environment.GetEnvironmentVariable("API_WEATHER_KEY"), 
                        weatherData
                    );
            else
                MessageBox.Show("no api key set");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Call the API here
             await apiHandler.CallApiAsync();

            MessageBox.Show(weatherData.Name);
        }
    }
}
