using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Colegio : IDBEntity
    {
        public int ColegioId { get; set; }
        public string NombreColegio { get; set; }

        public string Direccion { get; set; }

    }
}
