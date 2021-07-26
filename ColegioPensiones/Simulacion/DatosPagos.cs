using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Colegio;
using Persistencia;
using Procesos;

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
                "Octubre"
            };
            
            string tvivienda = "Arrendada";
            bool serBs= true;            
            double Ingresos= 1200;
            if(tvivienda== "Arrendada" && serBs == false && Ingresos <= 550)
            {
                AyudaE = true;
                Vayuda = 45;
                vapagar = vapagar-Vayuda;
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
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 60, valorpendiente = valorPend(150, vapagar, Vayuda) }
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

            //Pagos Anthony Moncayo
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
                "Octubre"
            };

            tvivienda = "Arrendada";
            serBs = true;
            Ingresos = 1200;
            if (tvivienda == "Arrendada" && serBs == false && Ingresos <= 550)
            {
                AyudaE = true;
                Vayuda = 45;
                vapagar = vapagar - Vayuda;
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
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 60, valorpendiente = valorPend(150, vapagar, Vayuda) }
                }
            };
            fecPago = dt2020_PAO2;
            estadoo = "Con Mora";
            //Persistencia de Anthony             
            using (var db = new ColegioContext())
            {
                pagosCarGon = PagosProc.Crearpago(db, estNombre, tvivienda, serBs, Ingresos, AyudaE, fecPago, MesePagadosAM, estadoo, fechaInicio);
                PagosProc.RegistrarPagos(pagosCarGon, dicvalorespagadosCG);
                db.pagos.Add(pagosCarGon);
                db.SaveChanges();
            }

            //Pagos Anthony Moncayo
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
                "Octubre"
            };

            tvivienda = "Arrendada";
            serBs = true;
            Ingresos = 1200;
            if (tvivienda == "Arrendada" && serBs == false && Ingresos <= 550)
            {
                AyudaE = true;
                Vayuda = 45;
                vapagar = vapagar - Vayuda;
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
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 150, valorpendiente = valorPend(150, vapagar, Vayuda) }
                },
                {
                    MesePagadosAM[1],
                    new Valor() { valorApagar = vapagar, valorayuda = Vayuda, valorpagado = 60, valorpendiente = valorPend(150, vapagar, Vayuda) }
                }
            };
            fecPago = dt2020_PAO2;
            estadoo = "Con Mora";
            //Persistencia de Anthony             
            using (var db = new ColegioContext())
            {
                pagosManKha = PagosProc.Crearpago(db, estNombre, tvivienda, serBs, Ingresos, AyudaE, fecPago, MesePagadosAM, estadoo, fechaInicio);
                PagosProc.RegistrarPagos(pagosManKha, dicvalorespagadosMK);
                db.pagos.Add(pagosManKha);
                db.SaveChanges();
            }
        }   

        static public double valorPend(double valorpagado, double valorApagar, double valorayuda)
        {
            double valpend = 0;
            valpend = valorApagar - (valorpagado - valorayuda);
            return valpend;
        }
    }
}
