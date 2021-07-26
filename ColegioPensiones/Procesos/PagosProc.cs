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
    public class PagosProc
    {
        public ColegioContext _context;
        public PagosProc(ColegioContext context)
        {
            _context = context;
        }
        static public Pago Crearpago(ColegioContext context
            ,string estNombre,string tvivienda, bool serBs, double Ingresos, 
            bool AyudaE,DateTime fecPago, string[] mesesnombres, string estadoo, DateTime periodoFechaInicio)
        {
            //consulto el alumno
            Alumno alumno = context.alumnos
                .Single(alu => alu.Nombrecompl == estNombre);
            //consulto el estado
            Estado estado = context.estados
                .Single(alu => alu.Mora == estadoo);
            //Consulta del período
            Periodo periodo = context.periodos
                .Single(periodo => periodo.FechaInicio == periodoFechaInicio);
            Pago pago = new Pago()
            {
                Alumno = alumno,
                Vivienda = tvivienda,
                ServiciosBasicos = serBs,
                IngresosT = Ingresos,
                AyudaEco = AyudaE,
                fechapago = fecPago,
                Estado=estado,
                periodo=periodo
            };
            // 5.- Detalles de la Pago
            pago.PagoDets= new List<PagoDet>();
            foreach (var mesesnombre in mesesnombres)
            {
                Ciclo ciclo= context.ciclos
                    .Single(cic => cic.Mes== mesesnombre);
                PagoDet pagdet = new PagoDet()
                {
                    Pago = pago,
                    Ciclo = ciclo
                };
                pago.PagoDets.Add(pagdet);
            }
            return pago;
        }
        static public void RegistrarPagos(
           Pago pago, Dictionary<string, Valor> dicmesesvalor)
        {
            // Buscar el mes para asignar el pago
            foreach (var det in pago.PagoDets)
            {
                det.Valor = dicmesesvalor[det.Ciclo.Mes];
            }
        }
        // Validación de el pago
        static public void ValidarPago()
        {
            using (var context = new ColegioContext())
            {
               Pago pago = context.pagos
                    .Include(pag => pag.Alumno)
                    .Include(pag => pag.PagoDets)
                     .ThenInclude(det => det.Valor)                        
                    .Single(pag => pag.EstadoID== 1 );
                foreach ( var pgos in pago.PagoDets )
                {                    
                        Valoresproc opCalif = new Valoresproc(context);                                                                            
                }                
            }
        }
        static public bool PagosconMora(int Alumno)
        {
            Pago pago;
            //consulta 
            using (var context = new ColegioContext())
            {

                pago = context.pagos
                    .Include(pag => pag.Alumno)
                    .Include(pag => pag.PagoDets)
                     .ThenInclude(det => det.Valor)
                    .Where(pag =>  pag.AlumnoID == Alumno)
                    .Single();    
                
            }

            return PagosAprobados(pago.PagoId);
        }
        public static bool PagosAprobados(int matriculaID)
        {
            bool aprobada = true;
            using (var db = new ColegioContext())
            {
                
                var configuracion = db.configuracions.Single();
                
                var pagos = db.pagos
                    .Include(matr => matr.Alumno)
                    .Include(matr => matr.PagoDets)
                        .ThenInclude(det => det.Ciclo)                           
                    .Single(matri => matri.PagoId == matriculaID );
                
                foreach (var det in pagos.PagoDets)
                {                   
                    
                        var mesespagad = det.Ciclo;
                        
                        if (!PagoAproba(pagos.Alumno, mesespagad, configuracion))
                        {
                            aprobada = false;
                        }                    
                }
            }
            return aprobada;
        }
        static public bool PagoAprobado(int alumnoid, int pago)
           {
               bool resultado = false;
               using (var context = new ColegioContext())
               {
                   Pago pagoss = context.pagos                    
                        .Include(cic => cic.PagoDets)                        
                        .Include(est => est.AlumnoID == alumnoid)
                        .Single(pag=>pag.PagoId == pago );
                   foreach (var pagoo in pagoss.PagoDets)
                   {

                           if (pagoo.Valor is null)
                           {
                               
                               return false;
                           }
                           else
                           {                               
                               Valoresproc opCalif = new Valoresproc(context);
                               if (opCalif.Aprobado(pagoo.Valor))
                                   return true;
                           }                    
                   }
               }
                   return resultado;
           }
        private static bool PagoAproba(Alumno estudiante, Ciclo meses, Configuracion configuracion)
        {
            bool aprobada = false;

            double valorAyuda = configuracion.valormaxayuda;
            double valorminPagar = configuracion.valorminApagar;            

            
            using (var db = new ColegioContext())
            {
                var listapagos = db.pagos
                    .Include(matr => matr.PagoDets)
                        .ThenInclude(det => det.Valor)
                    .Include(matr => matr.PagoDets.Where(det => det.Ciclo.CicloId == meses.CicloId))
                        .ThenInclude(det => det.Ciclo)                            
                    .Where(matr =>
                        matr.AlumnoID == estudiante.alumnoId 
                    )
                    .ToList();
                // Debbuger
                Console.WriteLine("-----------------------------------------------");                
                foreach (var pagos in listapagos)
                {                    
                    if (pagos.PagoDets.Count == 0)
                    Console.WriteLine("\nPago ID:" + pagos.PagoId);                    
                    foreach (var det in pagos.PagoDets)
                    {
                        var mesesc = det.Ciclo;
                        Console.WriteLine("   \t" + mesesc.Mes + " " +
                            det.Valor.valorApagar + " " +
                            det.Valor.valorayuda + " " +
                            det.Valor.valorpagado 
                        );
                        if (det.Valor.Aprueba(valorminPagar, valorAyuda))
                            aprobada = true;
                    }
                }
            }
            return aprobada;
        }
      
    }
}
