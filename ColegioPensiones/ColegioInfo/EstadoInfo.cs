using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioInfo
{
    public class EstadoInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var valorres = (Valor)entity;
            return String.Format(
                "ValorId: {0} \n PagoDetId: {1} \n PagoDet: {2} \n valorApagar: {3}\n valorayuda: {4}\n valorpagado: {5}\n valorpendiente: {6}",
                valorres.ValorId,
                valorres.PagoDetId,
                valorres.PagoDet,
                valorres.valorApagar,
                valorres.valorayuda,
                valorres.valorpagado,
                valorres.valorpendiente
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var valores = (List<Valor>)entity;
            string msj = "CalificacionId \t Matricula_DetId \t Notas \n";
            foreach (var valorres in valores)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \t {3} \t {4} \n",
                    valorres.ValorId,
                valorres.PagoDetId,
                valorres.PagoDet,
                valorres.valorApagar,
                valorres.valorayuda,
                valorres.valorpagado,
                valorres.valorpendiente
                    );
            }
            return msj;
        }
    }
}
