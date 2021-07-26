using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Colegio;
using Xunit;

namespace TestProject1
{
    public class PruebaValores
    {

        [Theory]
        //le entrego las calificaciones
        [InlineData(150, 150, 0, false)]
        [InlineData(150, 60, 90, true)]
        
        public void PruebaCalificacion(double n1, double n2, double n3, bool resEsperando)
        {
            //Preparacion 
            //declaramos una variable del resultado real
            bool resReal;            
            double pagomins = 75;
            double valormaxayudas = 45;

            //Instancion de la clase modelos 
            Valor calif = new Valor()
            {
                valorApagar = n1,
                valorpagado = n2,
                valorpendiente = n3
            };

            //Ejecucion 

            resReal = calif.Aprueba(valormaxayuda: valormaxayudas, pagomin: pagomins);
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
