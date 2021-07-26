using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Alumno : IDBEntity
    {
        public int alumnoId { get; set; }
        public string Cedula { get; set; }
        public string Nombrecompl { get; set; }
        public int GradeId { get; set; }
        public Grado Grado { get; set; }        
        public List<Pago> Pagos { get; set; }        
    }
}
