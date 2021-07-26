using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.Colegio;

namespace ColegioInfo
{
    public class AlumnoInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var alumno = (Alumno)entity;
            return String.Format(
                "alumnoId: {0} \n Cedula: {1} \n Nombrecompl: {2} \n GradeId: {3}",
                alumno.alumnoId,
                alumno.Cedula,
                alumno.Nombrecompl,
                alumno.GradeId
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var alumno = (List<Alumno>)entity;
            string msj = "CalificacionId \t Matricula_DetId \t Notas \n";
            foreach (var alumnoss in alumno)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \t {3}\n",
                    alumnoss.alumnoId,
                    alumnoss.Cedula,
                    alumnoss.Nombrecompl,
                    alumnoss.GradeId
                    );
            }
            return msj;
        }
    }
}
