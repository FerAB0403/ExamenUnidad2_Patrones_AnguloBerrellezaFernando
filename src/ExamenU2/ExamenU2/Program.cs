using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamenU2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VALIDANDO SINGLETON...");
            ChecadorTrafico checador1 = ChecadorTrafico.Instancia;
            ChecadorTrafico checador2 = ChecadorTrafico.Instancia;

            Console.WriteLine(ReferenceEquals(checador1, checador2));

            Taxi miTaxi = new Taxi("T-123-XYZ");
            Console.ReadKey();
            Console.Clear();

            checador1.PonerEnRuta(miTaxi);

            Console.ReadKey();
        }
    }
}
