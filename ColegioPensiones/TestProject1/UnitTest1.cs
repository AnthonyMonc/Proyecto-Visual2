using System;
using Escenarios;
using Procesos;
using Simulacion;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        public UnitTest1()
        {
                              
                Escenario01 escenario = new Escenario01();
                EscenarioControl control = new EscenarioControl();
                control.Grabar(escenario);
                var datosPagos = new DatosPagos();
                datosPagos.Generar();
        }
        [Theory]
        //le entrego las calificaciones
        [InlineData(1, true)]        

        public void PruebaCalificacion(int strEstudiante,  bool resEsperando)
            {
                //Preparacion 
                //declaramos una variable del resultado real
                bool resReal;
                  

                //Ejecucion 

                resReal = PagosProc.PagosconMora(strEstudiante);
                //Validación
                if (resEsperando)
                {
                    Assert.True(resReal);
                }
                else
                {
                    Assert.False(resReal);
                }
        }
        
    }
}
