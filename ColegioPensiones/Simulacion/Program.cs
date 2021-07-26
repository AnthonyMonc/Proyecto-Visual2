using System;
using Escenarios;
using Microsoft.EntityFrameworkCore;
using Modelo.Colegio;
using Persistencia;
using Procesos;

namespace Simulacion
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Escenario = new Escenario01();
            var EscenarioControl = new EscenarioControl();
            EscenarioControl.Grabar(Escenario);
            var datosPagos = new DatosPagos();
            datosPagos.Generar();
            //PagosProc.ValidarPago();
            
        }
    }
}
