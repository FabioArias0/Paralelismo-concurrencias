using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paralelo
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var limite = 200;
            string url = "https://jsonplaceholder.typicode.com/todos/";
            var httpClient = new HttpClient();
            var request = Enumerable.Range(1, limite).ToList();

            var watch = Stopwatch.StartNew();

            Parallel.ForEach(request, async r =>
            {
                var response = await httpClient.GetAsync(url);
            });

            //En este caso se debe convertir el main en async task para poder correrlo
            //for (int i = 1; i < limite; i++)
            //{
                  //    var response = await httpClient.GetAsync(url);
            //}



            watch.Stop();

            Console.WriteLine($"Ha tardado : { watch.ElapsedMilliseconds / 1000.0}");
            Console.ReadKey();
        }

        
    }
}
