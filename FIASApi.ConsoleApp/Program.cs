using FIASApi.Response.RestClients;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace FIASApi.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var addrobRestClient = new AddrobRestClient();
            var streets = addrobRestClient.GetCities().Result.Content.ReadAsAsync<List<dynamic>>().Result;

            foreach(var street in streets)
            {
                Console.WriteLine($"{street.offname} \n");
            }

            Console.ReadLine();
        }
    }
}
