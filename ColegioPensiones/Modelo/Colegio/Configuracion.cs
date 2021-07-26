using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Configuracion : IDBEntity 
    {
        public int ConfiguracionId { get; set; }
        public double valorminApagar { get; set; }
        public double valormaxayuda { get; set; }        
        public string EscuelaN { get; set; }
        public DateTime DiaMax { get; set; }    
        public Periodo PeriodoV { get; set; }
        public int periodoidV { get; set; }
    }
}
