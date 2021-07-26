using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using static Escenarios.Escenario;

namespace Escenarios
{
    public interface IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> Carga();
    }
}
