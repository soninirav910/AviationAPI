using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AviationAPI
{
    class Program
    {
        private static string accessKey = "2165a00b0dd2091356b19e2d27ca132e";
        private static string aircraft_types = "aircraft_types";
        private static string baseUrl = "http://api.aviationstack.com/v1/";
        static void Main(string[] args)
        {
            GetAircraftDetails();
            Console.ReadLine();
        }

        private static void GetAircraftDetails()
        {
            try
            {
                using (var request = new HttpClient())
                {
                    //Test
                    request.BaseAddress = new Uri(baseUrl);
                    request.Timeout = TimeSpan.FromSeconds(100);
                    var finalUrl = aircraft_types + "?access_key=" + accessKey;
                    var response = request.GetAsync(finalUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Response completed");
                        var result = response.Content.ReadAsStringAsync();
                        Console.WriteLine(result.Result);
                    }
                    else
                        Console.WriteLine("Response failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
