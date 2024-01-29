using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Calculos
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.For(0, 10000, count => Console.WriteLine(count));

            //var limit = 10000;

            //for (int i = 0; i < limit; i++)
            //{
            //    Console.WriteLine(i);
            //}

            stopwatch.Stop();
            double tiempo = stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine($"El tiempo de ejecucion: {tiempo} segundos");
            Console.ReadKey();
        }
    }
}
