using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Estado : IDBEntity
    {
        public int EstadoId { get; set; }
        public string Mora { get; set; }      
        public bool Recorrido { get; set; }
        public bool Laboratorio { get; set; }
        public bool Clasesextra { get; set; }
        public bool Examenes { get; set; }        
    }
}
