using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class PagoDet
    {
        public int PagoDetId { get; set; }
        public int PagoId { get; set; }
        public Pago Pago { get; set; }
        public int CicloId { get; set; }
        public Ciclo Ciclo { get; set; }
        public Valor Valor { get; set; }
    }
}
