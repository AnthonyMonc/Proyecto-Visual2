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
            // 5.- Detalles de la Matrícula
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
        // Validación de la matrícula
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
                    Console.WriteLine("  {0}", pgos.Pago.Alumno.Nombrecompl);                                    
                        Valoresproc opCalif = new Valoresproc(context);
                        Console.WriteLine("    ValorApagar   Valorayuda    Valorpagado    ValorPendiente");
                    Console.WriteLine("  {0} {1}", pgos.Valor.valorApagar, pgos.Valor.valorayuda);                                                         
                }
                Console.WriteLine();                               
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
                    .Where(pag => pag.EstadoID == 1 && pag.AlumnoID == Alumno)
                    .Single();              

                //res = (pago.PagoDets.Valor) >= pgos.Valor.valorpendiente;                    
                
            }

            return PagosAprobados(pago.PagoId);
        }
        public static bool PagosAprobados(int matriculaID)
        {
            bool aprobada = true;
            using (var db = new ColegioContext())
            {
                // Consulta a la configuración
                var configuracion = db.configuracions.Single();
                // Consulta de las matrículas pendientes
                var pagos = db.pagos
                    .Include(matr => matr.Alumno)
                    .Include(matr => matr.PagoDets)
                        .ThenInclude(det => det.Ciclo)                           
                    .Single(matri => matri.PagoId == matriculaID && matri.EstadoID == 1);
                // Revisa los prerequisitos
                foreach (var det in pagos.PagoDets)
                {                   
                    
                        var mesespagad = det.Ciclo;
                        // El estudiante habrá aprobado la materiaPreReq?
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
                               // 1.- No hay calificaciones
                               return false;
                           }
                           else
                           {
                               // 2.- Revisa calificaciónes
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

            // Consultar las matrículas del estudiante en estado Aprobadas
            using (var db = new ColegioContext())
            {
                var listapagos = db.pagos
                    .Include(matr => matr.PagoDets)
                        .ThenInclude(det => det.Valor)
                    .Include(matr => matr.PagoDets.Where(det => det.Ciclo.CicloId == meses.CicloId))
                        .ThenInclude(det => det.Ciclo)                            
                    .Where(matr =>
                        matr.AlumnoID == estudiante.alumnoId &&
                        matr.EstadoID == 1
                    )
                    .ToList();
                // Debbuger
                Console.WriteLine("-----------------------------------------------");                
                foreach (var pagos in listapagos)
                {                    
                    if (pagos.PagoDets.Count == 0)
                    Console.WriteLine("\nPago ID:" + pagos.PagoId);
                    Console.WriteLine("----> La matrícula no tiene detalles");
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
        /*static public bool ConsultaYValidaPagoconMora(string strEstudiante)
        {
            Pago pago;
            using (var db = new ColegioContext())
            {
                pago = db.pagos
                   .Include(matr => matr.Alumno)
                   .Single(matr =>
                       matr.Alumno.Nombrecompl == strEstudiante &&
                       matr.Estado.Mora == "Con Mora"
                   );
            }
            return MatriculaAprobada(pago.PagoId);
        }
        public static bool MatriculaAprobada(int pagoid)
        {
            bool aprobada = true;
            using (var db = new ColegioContext())
            {
                // Consulta a la configuración
                var configuracion = db.configuracions.Single();
                // Consulta de las matrículas pendientes
                var pago = db.pagos
                    .Include(matr => matr.Alumno)
                    .Include(matr => matr.PagoDets)
                        .ThenInclude(det => det.Ciclo)                            
                    .Single(matri => matri.PagoId == pagoid && matri.Estado.Mora == "Con Mora");
                // Revisa los prerequisitos
                foreach (var det in pago.PagoDets)
                {
                    var ciclo = det.Ciclo;
                    // Si la materia no tiene malla, entonces OK                    
                    // Verificación de prerequisitos
                    
                        var meses = det.Ciclo;
                        // El estudiante habrá aprobado la materiaPreReq?
                        if (!MateriaAprobada(pago.Alumno, meses, configuracion))
                        {
                            aprobada = false;
                        }
                    
                }
            }
            return aprobada;
        }
        private static bool MateriaAprobada(Alumno estudiante, Ciclo meses, Configuracion configuracion)
        {
            bool aprobada = false;
            double peso1 = configuracion.valorminApagar;
            double peso2 = configuracion.valormaxayuda;           
            // Consultar las matrículas del estudiante en estado Aprobadas
            using (var db = new ColegioContext())
            {
                var listapagos = db.pagos
                    .Include(al=>al.Alumno)
                    .Include(matr => matr.PagoDets)                        
                    .Include(matr => matr.PagoDets.Where(det => det.Ciclo.Mes==meses.Mes)                                                    
                    .Where(matr =>
                        matr.Alumno == estudiante.EstudianteId &&
                        matr.Estado == "Aprobada"
                    )
                    .ToList();
                // Debbuger
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(" " + estudiante.Nombre + " " + materia.Nombre);
                foreach (var matricula in listaMatriculas)
                {
                    Console.WriteLine("\tMatrícula ID:" + matricula.MatriculaId);
                    if (matricula.Matricula_Dets.Count == 0)
                        Console.WriteLine("----> La matrícula no tiene detalles");
                    foreach (var det in matricula.Matricula_Dets)
                    {
                        var materiaPreReq = det.Curso.Materia;
                        Console.WriteLine("   \t" + materiaPreReq.Nombre + " " +
                            det.Calificacion.Nota1 + " " +
                            det.Calificacion.Nota2 + " " +
                            det.Calificacion.Nota3 + " " +
                            (det.Calificacion.Aprueba(peso1, peso2, peso3, notaMin) ? "Aprueba" : "Reprueba")
                        );
                        if (det.Calificacion.Aprueba(peso1, peso2, peso3, notaMin))
                            aprobada = true;
                    }
                }
            }
            return aprobada;
        }*/
    }
}
