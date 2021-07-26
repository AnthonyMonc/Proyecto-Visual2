using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.Colegio;
using Persistencia;

namespace Procesos
{
    public class Valoresproc
    {
        public ColegioContext _context;
        double valorminApagar, valormaxayuda;
        public Valoresproc(ColegioContext context)
        {
            _context = context;
            // Carga los parámetros para calcular el pago final
            var config = context.configuracions
                .Include(ctx => ctx.PeriodoV)
                .Single(ctx => ctx.ConfiguracionId == 1);
            valorminApagar = config.valorminApagar;
            valormaxayuda = config.valormaxayuda;     
        }

        public bool Aprobado(int valorid)
        {
            Valor valo = _context.valors
                .Single(val => val.ValorId == valorid);
            return Aprobado(valo);
        }

        public bool Aprobado(Valor valo)
        {
            return valo.Aprueba(valormaxayuda, valorminApagar);
        }

        public double NotaFinal(Valor val)
        {
            return val.PagoFinal(valormaxayuda);
        }

        public void RegistrarNotas(PagoDet det, Valor val)
        {
            det.Valor = val;

            try
            {
                _context.valors.Add(val);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                Exception ex = new Exception("Conficto de concurrencia", exception);
                throw ex;
            }
        }
    }
}
