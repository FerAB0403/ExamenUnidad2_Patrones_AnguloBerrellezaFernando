using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class Asiento
    {
        public int IdAsiento { get; private set; }
        public bool Ocupado { get; set; }

        public Asiento(int id)
        {
            this.IdAsiento = id;
            this.Ocupado = false;
        }

        public override string ToString()
        {
            string estado = Ocupado ? "Ocupado" : "Libre";
            return $"Asiento No. {IdAsiento} ({estado})";
        }
    }
}
