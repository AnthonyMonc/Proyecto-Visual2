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
        }   

        static public double valorPend(double valorpagado, double valorApagar, double valorayuda)
        {
            double valpend = 0;
            valpend = valorApagar - (valorpagado - valorayuda);
            return valpend;
        }
    }
}
