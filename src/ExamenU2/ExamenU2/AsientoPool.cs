using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class AsientoPool
    {
        private readonly List<Asiento> _disponibles;
        private readonly List<Asiento> _enUso;

        public AsientoPool(int capacidad)
        {
            _disponibles = new List<Asiento>();
            _enUso = new List<Asiento>();

            // Crea la piscina de asientos
            for (int i = 0; i < capacidad; i++)
            {
                _disponibles.Add(new Asiento(i + 1));
            }
            Console.WriteLine($"POOL: Creando una piscina con {capacidad} asientos.");
        }

        public Asiento Acquire()
        {
            if (_disponibles.Count == 0)
            {
                Console.WriteLine("POOL: ¡Advertencia! No hay asientos disponibles en la piscina.");
                return null;
            }

            Asiento asiento = _disponibles[0];
            _disponibles.RemoveAt(0);

            asiento.Ocupado = true;
            _enUso.Add(asiento);

            Console.WriteLine($"POOL: Asiento {asiento.IdAsiento} adquirido. Disponibles: {_disponibles.Count}");
            return asiento;
        }

        public void Release(Asiento asiento)
        {
            if (asiento != null && _enUso.Contains(asiento))
            {
                asiento.Ocupado = false;
                _enUso.Remove(asiento);
                _disponibles.Add(asiento);
                Console.WriteLine($"POOL: Asiento {asiento.IdAsiento} Desocupado. Disponibles: {_disponibles.Count}");
            }
        }

        public string GetEstadoPool()
        {
            return $"Disponibles: {_disponibles.Count}, En Uso: {_enUso.Count}";
        }
    }
}
