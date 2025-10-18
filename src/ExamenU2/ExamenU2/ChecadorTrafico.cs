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
        // Lógica del Singleton (idéntica)
        private static readonly ChecadorTrafico _instancia = new ChecadorTrafico();
        private ChecadorTrafico()
        {
            Console.WriteLine($"\n--- SINGLETON: Checador de Tráfico '{this.GetHashCode()}' inicializado. ---");
        }

        // 3. La propiedad "Instancia" ahora contiene la lógica de bloqueo
        public static ChecadorTrafico Instancia
        {
            get { return _instancia; }
        }

        // --- CAMBIOS EN LA LÓGICA DE NEGOCIO ---
        public void PonerEnRuta(Taxi taxi)
        {
            // --- DESTINO 1: Llenar el taxi ---
            Console.WriteLine("\n\tINICIO DE RUTA");
            Console.WriteLine($"TAXI {taxi.Placa}: subiendo pasajeros");
            for (int i = 0; i < 15; i++)
            {
                // 1. El Singleton llama a Acquire() DIRECTAMENTE
                Asiento asiento = taxi.PoolDeAsientos.Acquire();

                if (asiento != null)
                {
                    // 2. El Singleton gestiona la lista de pasajeros del taxi
                    taxi.PasajerosABordo.Add(asiento);
                }
                Thread.Sleep(200);
            }

            // 3. El Singleton comprueba el estado del pool DIRECTAMENTE
            Console.WriteLine($"\nTAXI LLENO. Estado del Pool: {taxi.PoolDeAsientos.GetEstadoPool()}");
            Console.ReadKey();


            // --- DESTINO 2: Parada intermedia ---
            Console.WriteLine("\n\tLLEGADA A DESTINO 2");
            int cantidadBajar = 5;
            Console.WriteLine($"TAXI {taxi.Placa}: Van a bajar {cantidadBajar} pasajeros");

            for (int i = 0; i < cantidadBajar; i++)
            {
                if (taxi.PasajerosABordo.Any())
                {
                    // Gestiona la lista del taxi
                    Asiento asientoALiberar = taxi.PasajerosABordo[0];
                    taxi.PasajerosABordo.RemoveAt(0);

                    // 4. El Singleton llama a Release() DIRECTAMENTE
                    taxi.PoolDeAsientos.Release(asientoALiberar);
                }
            }
            Console.WriteLine($"\nPARADA INTERMEDIA. Estado del Pool: {taxi.PoolDeAsientos.GetEstadoPool()}");
            Console.ReadKey();

            // --- DESTINO 3: Fin de la ruta ---
            Console.WriteLine("\n\tLLEGADA A DESTINO FINAL 3");
            int restantes = taxi.PasajerosRestantes();
            Console.WriteLine($"TAXI {taxi.Placa}: Van a bajar {restantes} pasajeros");

            // Usamos un bucle while para vaciar la lista
            while (taxi.PasajerosABordo.Any())
            {
                Asiento asientoALiberar = taxi.PasajerosABordo[0];
                taxi.PasajerosABordo.RemoveAt(0);

                // 5. El Singleton llama a Release() DIRECTAMENTE
                taxi.PoolDeAsientos.Release(asientoALiberar);
            }

            Console.WriteLine($"\nFIN DE RUTA. Estado del Pool: {taxi.PoolDeAsientos.GetEstadoPool()}");
            Console.WriteLine("Todos los asientos han sido devueltos a la piscina y están listos.");
        }
    }
}
