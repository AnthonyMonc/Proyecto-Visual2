using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Ciclo : IDBEntity
    {
        public int CicloId { get; set; }                      
        public string Mes { get; set; }
        public DateTime Matricula { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaMora { get; set; }
        public int PeriodoID { get; set; }
        public Periodo periodo { get; set; }
        public List<PagoDet> PagoDets { get; set; }
    }
}
