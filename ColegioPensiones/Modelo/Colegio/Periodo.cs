using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Periodo : IDBEntity
    {
        public int PeriodoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<Ciclo> Ciclos { get; set; }
        public List<Pago> Pagos { get; set; }
    }
}
