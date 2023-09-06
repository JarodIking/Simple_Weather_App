using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.Dynamic;
using System.Text.Json;

namespace Simple_Weather_App
{
    public class ApiHandler
    {
        private string ApiKey { get; set; }
        private string ApiUrl { get; set; }
        private string Response {  get; set; }
        private WeatherData _weatherData {  get; set; }

        public ApiHandler(string apiKey, string apiUrl, WeatherData weatherData)
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl + ApiKey;
            _weatherData = weatherData;
        }

        public async Task CallApiAsync()
        {
            try
            {
                GetApiCall();
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
            _weatherData = JsonSerializer.Deserialize<WeatherData>(response);

            MessageBox.Show(_weatherData.name);
        }
    }
}
