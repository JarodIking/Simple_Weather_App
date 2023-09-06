using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.Dynamic;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Security.Principal;

namespace Simple_Weather_App
{
    public class ApiHandler
    {
        private string ApiKey { get; set; }
        private string ApiUrl { get; set; }
        private string Response {  get; set; }
        private double Longtitude { get; set; }
        private double Latittude { get; set; }
        private WeatherData _weatherData { get; set; }

        public ApiHandler(string apiKey, WeatherData weatherData)
        {
            ApiKey = apiKey;
            _weatherData = weatherData;
            Latittude = 40;
            Longtitude = -74;
            ApiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={Latittude}&lon={Longtitude}&appid={ApiKey}";
        }

        public async Task CallApiAsync()
        {
            try
            {
              await  GetApiCall();
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private async Task GetApiCall()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = ApiUrl;
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    Response = await response.Content.ReadAsStringAsync();
                    DeserializeResponse(Response);
                }
                else
                {
                    // Handle API error here
                    MessageBox.Show("API request failed with status code: " + response.StatusCode);
                }
            }
        }

        private void DeserializeResponse(string response)
        {
            var tempWeatherData = JsonConvert.DeserializeObject<WeatherData>(response);
            _weatherData.Coord = tempWeatherData.Coord;
            _weatherData.Weather = tempWeatherData.Weather;
            _weatherData.Base = tempWeatherData.Base;
            _weatherData.Main = tempWeatherData.Main;
            _weatherData.Visibility = tempWeatherData.Visibility;
            _weatherData.Wind = tempWeatherData.Wind;
            _weatherData.Rain = tempWeatherData.Rain;
            _weatherData.Clouds = tempWeatherData.Clouds;
            _weatherData.Dt = tempWeatherData.Dt;
            _weatherData.Sys = tempWeatherData.Sys;
            _weatherData.Timezone = tempWeatherData.Timezone;
            _weatherData.Id = tempWeatherData.Id;
            _weatherData.Name = tempWeatherData.Name;
            _weatherData.Cod = tempWeatherData.Cod;
        }
    }
}
