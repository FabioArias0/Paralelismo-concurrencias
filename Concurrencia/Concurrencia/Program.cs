using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Net.Http;


namespace Concurrencia
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Medir el tiempo de ejecucion

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var paginasURLs = new List<string> {
                "https://scrapeme.live/shop/page/1/",
                "https://scrapeme.live/shop/page/2/",
                "https://scrapeme.live/shop/page/3/",
                "https://scrapeme.live/shop/page/4/",
                "https://scrapeme.live/shop/page/5/",
            };

            //Aqui se inicializa HTTP comunes del cliente para relaizar todas las solicitudes 
            HttpClient cliente = new HttpClient();

            //Incializamos una lista de hilos
            List<Thread> hilos = new List<Thread>();

            //Definimos cada hilo y lo agregamos a la lista
            foreach (var paginaURL in paginasURLs)
            {
                Thread hilo = new Thread(() =>
                {
                    ProcessRequest(cliente, paginaURL);
                });
                hilos.Add(hilo);
            }

            //Ejecutamos cada hilo
            foreach (var hilo in hilos)
            {
                hilo.Start();
            }

            //Esperamos a que todos los hilos se completen
            foreach (var hilo in hilos)
            {
                hilo.Join();
            }

            //Disponer el Http del cliente
            cliente.Dispose();

            //Obtener el lapso de tiempo de ejecucion en segundos.
            stopwatch.Stop();
            double tiempo = stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine($"Tiempo de ejecucion: {tiempo} s");

            Console.ReadKey();
        }

        private static void ProcessRequest(HttpClient cliente, string paginaURL) {

            var response = cliente.GetAsync(paginaURL).Result;
            Console.WriteLine($"Solicitud a la pagina {paginaURL}, se ha completado con el siguiente estado: {response.StatusCode} !");
        }
    }

    
}
