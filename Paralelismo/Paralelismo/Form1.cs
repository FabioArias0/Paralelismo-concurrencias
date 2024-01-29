using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Paralelismo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<int> GetFacturas(int limite) 
        {
            Random gen = new Random();
            var result = new List<int>();

            for (int i = 0; i < limite; i++)
            {
                result.Add(gen.Next());
            }
            return result;
        }

        private async Task<(int, bool)> Facturar(int factura)
        {
            Random gen = new Random();
            var boolResul = gen.Next(100) <= 70;
            await Task.Delay(1000); // simular proceso de espera
            return (factura, boolResul);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var watch = Stopwatch.StartNew();
            var facturas = GetFacturas(120000);
            var resultadoFactura = new List<Task<(int, bool)>>();
            foreach (var factura in facturas)
            {
                var facturaResult = Facturar(factura);
                resultadoFactura.Add(facturaResult);
            }
            await Task .WhenAll(resultadoFactura); // se espera que se ejecuten todas las tareas
            watch.Stop();
            MessageBox.Show($"Han pasado {watch.ElapsedMilliseconds} milisegundos");

        }
    }
}
