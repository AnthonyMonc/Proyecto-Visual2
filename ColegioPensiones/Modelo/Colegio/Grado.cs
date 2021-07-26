using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Grado : IDBEntity
    {
        public int GradoId { get; set; }
        public string nomgrado { get; set; }
        public string Seccion { get; set; }
        public List<Alumno> Alumno { get; set; }
    }
}
