using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamenU2
{
    public sealed class ChecadorTrafico
    {
        private static readonly ChecadorTrafico _instancia = new ChecadorTrafico();
        private ChecadorTrafico()
        {
            Console.WriteLine($"\n--- SINGLETON: Checador de Tráfico '{this.GetHashCode()}' inicializado. ---");
        }

        // 3. La "Instancia" tiene la lógica de bloqueo
        public static ChecadorTrafico Instancia
        {
            get { return _instancia; }
        }

        public void PonerEnRuta(Taxi taxi)
        {
            //  DESTINO 1: Llenar el taxi 
            Console.WriteLine("\n\tINICIO DE RUTA");
            Console.WriteLine($"TAXI {taxi.Placa}: subiendo pasajeros");
            for (int i = 0; i < 15; i++)
            {
                Asiento asiento = taxi.PoolDeAsientos.Acquire();

                if (asiento != null)
                {
                    taxi.PasajerosABordo.Add(asiento);
                }
                Thread.Sleep(200);
            }

            // comprueba el estado del pool DIRECTAMENTE
            Console.WriteLine($"\nTAXI LLENO. Estado del Pool: {taxi.PoolDeAsientos.GetEstadoPool()}");
            Console.ReadKey();


            //  DESTINO 2: Parada intermedia
            Console.WriteLine("\n\tLLEGADA A DESTINO 2");
            int cantidadBajar = 5;
            Console.WriteLine($"TAXI {taxi.Placa}: Van a bajar {cantidadBajar} pasajeros");

            for (int i = 0; i < cantidadBajar; i++)
            {
                if (taxi.PasajerosABordo.Any())
                {
                    Asiento asientoALiberar = taxi.PasajerosABordo[0];
                    taxi.PasajerosABordo.RemoveAt(0);

                    taxi.PoolDeAsientos.Release(asientoALiberar);
                }
            }
            Console.WriteLine($"\nPARADA INTERMEDIA. Estado del Pool: {taxi.PoolDeAsientos.GetEstadoPool()}");
            Console.ReadKey();

            //    DESTINO 3: Fin de la ruta 
            Console.WriteLine("\n\tLLEGADA A DESTINO FINAL 3");
            int restantes = taxi.PasajerosRestantes();
            Console.WriteLine($"TAXI {taxi.Placa}: Van a bajar {restantes} pasajeros");

            // Usamos un bucle while para vaciar el taxi
            while (taxi.PasajerosABordo.Any())
            {
                Asiento asientoALiberar = taxi.PasajerosABordo[0];
                taxi.PasajerosABordo.RemoveAt(0);

                taxi.PoolDeAsientos.Release(asientoALiberar);
            }

            Console.WriteLine($"\nFIN DE RUTA. Estado del Pool: {taxi.PoolDeAsientos.GetEstadoPool()}");
            Console.WriteLine("Todos los asientos han sido devueltos a la piscina y están listos.");
        }
    }
}
