using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrenicaContinue
{
    class Program
    {
        static void Main(string[] args)
        {

            //Creamos un tarea que simula una operacion matematica asincrona
            Task<int> asyncTask = Task.Run(() =>
            {
                // Aqui simulamos un proceso interno que demora x segundos
                Task.Delay(8000).Wait();
                return 42;
            });

            //Manejamos la tarea completada
            asyncTask.ContinueWith((tareaCompletada) =>
            {
                //Obtenemos el resutlado de la tarea anterior
                int result = tareaCompletada.Result;
                Console.WriteLine($"Tarea completada con el resultado: {result}");
            });

            Console.ReadKey();
        }
    }
}
