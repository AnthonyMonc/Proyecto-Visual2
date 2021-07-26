using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.Colegio;
using Persistencia;
using Procesos;
using Reportes;

namespace Simulacion
{
    public class DatosPagos
    {
        public void Generar()
        {

            //Pagos Anthony Moncayo
            //--------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------
            bool AyudaE =true;
            int Vayuda = 0;
            double vapagar = 150;
            //Alumno
            string estNombre = "Anthony Moncayo";
            Pago pagosAntMon;
            DateTime dt2020_PAO2 = new DateTime(2020, 9, 1);
            DateTime fechaInicio = new DateTime(2020, 9, 1);
            string[] MesePagadosAM = new string[]
            {
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre",
                "Enero",
                "Febrero"
            };
            
            string tvivienda = "Arrendada";
            bool serBs= true;            
            double Ingresos= 1200;
            if (ayudaEc(tvivienda, serBs, Ingresos) ==true )
            {
                AyudaE = true;
                Vayuda = 45;
                vapagar = 150;
            }
            else
            {
                AyudaE = false;
                Vayuda = 0;
                vapagar = 150;
            }
            Dictionary<string, Valor> dicvalorespagados = new()
            {
                {
                    MesePagadosAM[0],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150 ,valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[1],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150, valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[2],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150, valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[3],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 60, valorpendiente = valorPend(60, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[4],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 50, valorpendiente = valorPend(50, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[5],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 0, valorpendiente = valorPend(0, vapagar, Vayuda) }
                }
            };
            DateTime fecPago = dt2020_PAO2;            
            string estadoo = "Con Mora";            
            //Persistencia de Anthony             
            using (var db = new ColegioContext())
            {
                pagosAntMon = PagosProc.Crearpago(db,estNombre,tvivienda,serBs,Ingresos,AyudaE, fecPago, MesePagadosAM,estadoo,fechaInicio);
                PagosProc.RegistrarPagos(pagosAntMon,dicvalorespagados);
                db.pagos.Add(pagosAntMon);
                db.SaveChanges();
            }
            Reportes.Reporte.ReportePagos(DatosPagos.ValorporAlumno(estNombre));
            Console.WriteLine("Estado: {0}", estadoo);
            Console.WriteLine("----------------------------------------------------------------------------");
            //Pagos Carla Gonzales
            //--------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------
            AyudaE = true;
             Vayuda = 0;
             vapagar = 150;
            //Alumno
            estNombre = "Carla Gonzales";
            Pago pagosCarGon;
             dt2020_PAO2 = new DateTime(2020, 9, 1);
            fechaInicio = new DateTime(2020, 9, 1);
            string[] MesePagadosCG = new string[]
            {
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre",
                "Enero",
                "Febrero"
            };

            tvivienda = "Arrendada";
            serBs = true;
            Ingresos = 1200;
            if (ayudaEc(tvivienda, serBs, Ingresos) == true)
            {
                AyudaE = true;
                Vayuda = 45;
                vapagar = 150;
            }
            else
            {
                AyudaE = false;
                Vayuda = 0;
                vapagar = 150;
            }
            Dictionary<string, Valor> dicvalorespagadosCG = new()
            {
                {
                    MesePagadosAM[0],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150, valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[1],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150, valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[2],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150, valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[3],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150, valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[4],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150, valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[5],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 0, valorpendiente = valorPend(0, vapagar, Vayuda) }
                }
            };
            fecPago = dt2020_PAO2;
            estadoo = "Sin Mora";
            //Persistencia de Carla             
            using (var db = new ColegioContext())
            {
                pagosCarGon = PagosProc.Crearpago(db, estNombre, tvivienda, serBs, Ingresos, AyudaE, fecPago, MesePagadosCG, estadoo, fechaInicio);
                PagosProc.RegistrarPagos(pagosCarGon, dicvalorespagadosCG);
                db.pagos.Add(pagosCarGon);
                db.SaveChanges();
            }
            Reportes.Reporte.ReportePagos(DatosPagos.ValorporAlumno(estNombre));
            Console.WriteLine("Estado: {0}", estadoo);
            Console.WriteLine("----------------------------------------------------------------------------");
            //Pagos Manuela
            //--------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------
            AyudaE = true;
            Vayuda = 0;
            vapagar = 150;
            //Alumno
            estNombre = "Manuela Khalifa";
            Pago pagosManKha;
            dt2020_PAO2 = new DateTime(2020, 9, 1);
            fechaInicio = new DateTime(2020, 9, 1);
            string[] MesePagadosMK = new string[]
            {
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre",
                "Enero",
                "Febrero"
            };

            tvivienda = "Arrendada";
            serBs = false;
            Ingresos = 400;
            if (ayudaEc(tvivienda, serBs, Ingresos) == true)
            {
                AyudaE = true;
                Vayuda = 45;
                vapagar = 150;
            }
            else
            {
                AyudaE = false;
                Vayuda = 0;
                vapagar = 150;
            }
            Dictionary<string, Valor> dicvalorespagadosMK = new()
            {
                {
                    MesePagadosAM[0],
                    new Valor() { valorApagar = (vapagar - Vayuda), valorayuda = Vayuda, valorpagado = 105, valorpendiente = valorPend(105, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[1],
                    new Valor() { valorApagar = (vapagar - Vayuda), valorayuda = Vayuda, valorpagado = 105, valorpendiente = valorPend(105, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[2],
                    new Valor() { valorApagar = (vapagar - Vayuda), valorayuda = Vayuda, valorpagado = 105, valorpendiente = valorPend(105, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[3],
                    new Valor() { valorApagar = (vapagar - Vayuda), valorayuda = Vayuda, valorpagado = 105, valorpendiente = valorPend(105, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[4],
                    new Valor() { valorApagar = (vapagar - Vayuda), valorayuda = Vayuda, valorpagado = 0, valorpendiente = valorPend(0, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[5],
                    new Valor() { valorApagar = (vapagar - Vayuda), valorayuda = Vayuda, valorpagado = 0, valorpendiente = valorPend(0, vapagar, Vayuda) }
                }
            };
            fecPago = dt2020_PAO2;
            estadoo = "Con Mora";                       
            using (var db = new ColegioContext())
            {
                pagosManKha = PagosProc.Crearpago(db, estNombre, tvivienda, serBs, Ingresos, AyudaE, fecPago, MesePagadosMK, estadoo, fechaInicio);
                PagosProc.RegistrarPagos(pagosManKha, dicvalorespagadosMK);
                db.pagos.Add(pagosManKha);
                db.SaveChanges();
            }
            Reportes.Reporte.ReportePagos(DatosPagos.ValorporAlumno(estNombre));
            Console.WriteLine("Estado: {0}", estadoo);
            Console.WriteLine("----------------------------------------------------------------------------");
        }   

        static public double valorPend(double valorpagado, double valorApagar, double valorayuda)
        {
            double valpend = 0;
            valpend = valorApagar - (valorpagado - valorayuda);
            return valpend;
        }
        static public bool ayudaEc(string tvivienda, bool serBs, double Ingresos)
        {
            bool AyudaE = true;
            if (tvivienda == "Arrendada" && serBs == false && Ingresos <= 550)
            {
                AyudaE = true;                
            }
            else
            {
                AyudaE = false;              
            }
            return AyudaE;
        }
        static public Alumno ValorporAlumno(string sEstNombre)
        {
            Alumno estudiante;
            // Consulta las notas de un alumno
            using (var context = new ColegioContext())
            {
                estudiante = context.alumnos
                    .Include(est => est.Pagos)
                        .ThenInclude(matr => matr.PagoDets)
                            .ThenInclude(det => det.Valor)
                    .Include(est => est.Pagos)
                        .ThenInclude(matr => matr.PagoDets)
                            .ThenInclude(det => det.Ciclo)
                    .Include(est => est.Pagos)
                    .Single(est => est.Nombrecompl.Equals(sEstNombre));
            }
            return estudiante;
        }
    }
}
