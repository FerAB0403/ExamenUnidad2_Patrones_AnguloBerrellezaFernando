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
            this.PoolDeAsientos = new AsientoPool(capacidad);
            this.PasajerosABordo = new List<Asiento>();
        }

        public int PasajerosRestantes() => PasajerosABordo.Count;
    }
}
