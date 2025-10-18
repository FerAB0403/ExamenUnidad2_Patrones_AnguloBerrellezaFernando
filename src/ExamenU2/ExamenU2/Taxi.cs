using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class Taxi
    {
        public string Placa { get; private set; }
        public AsientoPool PoolDeAsientos { get; private set; }
        public List<Asiento> PasajerosABordo { get; private set; }

        public Taxi(string placa, int capacidad = 15)
        {
            this.Placa = placa;
            // El taxi sigue siendo responsable de CREAR sus componentes
            this.PoolDeAsientos = new AsientoPool(capacidad);
            this.PasajerosABordo = new List<Asiento>();
        }

        public int PasajerosRestantes() => PasajerosABordo.Count;

        //public void SubirPasajero()
        //{
        //    Asiento asiento = _poolDeAsientos.Acquire();
        //    if (asiento != null)
        //    {
        //        _pasajerosABordo.Add(asiento);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"  > TAXI {Placa}: El taxi está lleno, no pueden subir más pasajeros.");
        //    }
        //}

        //public void BajarPasajeros(int cantidad)
        //{
        //    Console.WriteLine($"TAXI {Placa}: Van a bajar {cantidad} pasajeros...");
        //    for (int i = 0; i < cantidad; i++)
        //    {
        //        if (_pasajerosABordo.Any())
        //        {
        //            Asiento asientoALiberar = _pasajerosABordo[0];
        //            _pasajerosABordo.RemoveAt(0);
        //            _poolDeAsientos.Release(asientoALiberar);
        //        }
        //    }
        //}

        //public int PasajerosRestantes() => _pasajerosABordo.Count;

        //// Método público para exponer el estado del pool de forma segura
        //public string GetEstadoDelPool()
        //{
        //    return _poolDeAsientos.GetEstadoPool();
        //}
    }
}
