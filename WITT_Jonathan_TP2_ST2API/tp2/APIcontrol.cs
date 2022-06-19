using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace tp2
{
    class APIcontrol
    {
        private static readonly HttpClient Client = new HttpClient();
        public Root objectRes { get; set; }

        
        public  async void GetInfo(string lat, string lon)
        {
            var responseBody = Client.GetAsync("https://api.openweathermap.org/data/2.5/weather?lat="+lat+"&lon="+lon+"&appid=02f51cc081aaadce756d51caf9911932&units=metric").Result;
            var res = await responseBody.Content.ReadAsStringAsync();
            //Console.WriteLine(res);
            objectRes = JsonConvert.DeserializeObject<Root>(res);

            
        }
        
    }
}