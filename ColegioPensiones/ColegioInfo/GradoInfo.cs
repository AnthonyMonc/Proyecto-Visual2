using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.Colegio;

namespace ColegioInfo
{
    public class GradoInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var grado = (Grado)entity;
            return String.Format(
                "GradoId: {0} \n nomgrado: {1} \n Seccion: {2} ",
                grado.GradoId,
                grado.nomgrado,
                grado.Seccion
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var grados = (List<Grado>)entity;
            string msj = "CalificacionId \t Matricula_DetId \t Notas \n";
            foreach (var gradoss in grados)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2}\n",
                    gradoss.GradoId,
                    gradoss.nomgrado,
                    gradoss.Seccion
                    );
            }
            return msj;
        }
    }
}
