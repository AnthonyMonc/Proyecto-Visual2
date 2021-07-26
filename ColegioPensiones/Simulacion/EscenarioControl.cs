using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escenarios;
using Modelo.Colegio;
using Persistencia;
using static Escenarios.Escenario;

namespace Simulacion
{
    public class EscenarioControl
    {
        public void Grabar(IEscenario escenario)
        {
            var datos = escenario.Carga();
            using (var db = new ColegioContext())
            {
                //Reiniciamos la Base de datos
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                //Insertamos los datos
                //hacemos un cast                
                db.alumnos.AddRange((List<Alumno>)datos[ListaTipo.Alumno]);
                db.grados.AddRange((List<Grado>)datos[ListaTipo.Grado]);
                db.colegios.AddRange((List<Colegio>)datos[ListaTipo.Colegio]);
                db.estados.AddRange((List<Estado>)datos[ListaTipo.Estado]);
                db.configuracions.AddRange((List<Configuracion>)datos[ListaTipo.Configuracion]);                                
                db.ciclos.AddRange((List<Ciclo>)datos[ListaTipo.Ciclo]);
                db.periodos.AddRange((List<Periodo>)datos[ListaTipo.Periodo]);                

                //Genera la persistencia
                db.SaveChanges();
            }
        }
    }
}
