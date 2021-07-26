using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.Colegio;
using Persistencia;
using Procesos;

namespace Reportes
{
    public class Reporte
    {
        static public void ValoresporMes(string ciclonombre)
        {

            using (var context = new ColegioContext())
            {
                Ciclo meses = context.ciclos
                    .Include(cur => cur.PagoDets)
                        .ThenInclude(det => det.Valor)
                    .Include(cur => cur.PagoDets)
                        .ThenInclude(det => det.Pago)
                            .ThenInclude(matr => matr.Alumno)
                    .Single(cur => cur.Mes == ciclonombre);

                Console.WriteLine("Mes Id: {0} - {1}",
                    meses.CicloId, meses.Mes);
                foreach (var det in meses.PagoDets)
                {
                    Console.WriteLine("  {0}", det.Pago.Alumno.Nombrecompl);
                    if (det.Valor != null)
                    {
                        Valoresproc opvalor = new Valoresproc(context);
                        Console.WriteLine("    Valor Pagado   Valor Ayuda   Valor a Pagar   ValorTotal");
                        Console.WriteLine("    {0}     {1}     {2}     {3}   {4}",
                            det.Valor.valorpagado, det.Valor.valorayuda, det.Valor.valorApagar,
                            opvalor.NotaFinal(det.Valor), opvalor.Aprobado(det.Valor));
                    }
                    
                }
            }
        }

        public static void ReportePagos(Alumno alumno)
        {
            
            Console.WriteLine("Reporte de Pagos del Estudiante {0}", alumno.Nombrecompl);
            foreach (var pagos in alumno.Pagos)

            {
                Console.WriteLine("Pago Id: {0}",
                    pagos.PagoId);
                // Barre los detalles de cada matrícula
                foreach (var pagdetall in pagos.PagoDets)
                {
                    Console.WriteLine(" Det: {0} - Mes {1}", pagdetall.PagoDetId, pagdetall.Ciclo.Mes);
                    
                        Valor valo = pagdetall.Valor;
                        Console.WriteLine(" Valor Id: {0}", pagdetall.Valor.ValorId);
                        Console.WriteLine("    Valor A pagar    Valor Ayuda   Valor Pagado");
                        Console.WriteLine("        {0}             {1}               {2}",
                            valo.valorApagar, valo.valorayuda, valo.valorpagado
                        );                    
                }
            }
        }
       
    }
}
