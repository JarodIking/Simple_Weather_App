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
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
        public string Response {  get; set; }

        public ApiHandler(string apiKey, string apiUrl)
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl + ApiKey;
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
            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(response);

            MessageBox.Show(weatherData.name);
        }
    }
}
