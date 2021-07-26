using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Colegio;
using Persistencia;
using Procesos;
using Xunit;

namespace TestProject1
{
    public class PruebaValores
    {

        [Theory]
        //le entrego los valores pagados por Anthony
        [InlineData("1.- Anthony Moncayo",150, 150, 0, false)]
        [InlineData("2.- Anthony Moncayo", 150, 150, 0, false)]
        [InlineData("3.- Anthony Moncayo", 150, 150, 0, false)]
        [InlineData("4.- Anthony Moncayo", 150, 60, 90, true)]
        [InlineData("5.- Anthony Moncayo", 150, 50, 100, true)]
        [InlineData("6.- Anthony Moncayo", 150, 0, 150, true)]
        //le entrego los valores pagados por Carla
        [InlineData("1.- Carla Gonzales", 150, 150, 0, false)]
        [InlineData("2.- Carla Gonzales", 150, 150, 0, false)]
        [InlineData("3.- Carla Gonzales", 150, 150, 0, false)]
        [InlineData("4.- Carla Gonzales", 150, 150, 0, false)]
        [InlineData("5.- Carla Gonzales", 150, 150, 0, false)]
        [InlineData("6.- Carla Gonzales", 150, 0, 150, true)]
        //le entrego los valores pagados por Manuela
        [InlineData("1.- Manuela Khalifa", 150, 150, 0, false)]
        [InlineData("2.- Manuela Khalifa", 150, 150, 0, false)]
        [InlineData("3.- Manuela Khalifa", 150, 150, 0, false)]
        [InlineData("4.- Manuela Khalifa", 150, 150, 0, false)]
        [InlineData("5.- Manuela Khalifa", 150, 0, 150, true)]
        [InlineData("6.- Manuela Khalifa", 150, 0, 150, true)]


        public void PruebaValor(string nombre, double n1, double n2, double n3, bool resEsperando)
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

        //Pruebas cuantitativas
        [Theory]
        //le entrego los valores pagados por Anthony
        [InlineData(1,"Anthony Moncayo", 0)]
        [InlineData(2,"Anthony Moncayo", 0)]
        [InlineData(3,"3.- Anthony Moncayo", 0)]
        [InlineData(4,"4.- Anthony Moncayo", 90)]
        [InlineData(5,"5.- Anthony Moncayo", 100)]
        [InlineData(6,"6.- Anthony Moncayo", 150)]
        //le entrego los valores pagados por Carla
        [InlineData(7,"1.- Carla Gonzales", 0)]
        [InlineData(8,"2.- Carla Gonzales", 0)]
        [InlineData(9,"3.- Carla Gonzales", 0)]
        [InlineData(10,"4.- Carla Gonzales", 0)]
        [InlineData(11,"5.- Carla Gonzales", 0)]
        [InlineData(12,"6.- Carla Gonzales", 150)]
        //le entrego los valores pagados por Manuela
        [InlineData(13,"1.- Manuela Khalifa", 0)]
        [InlineData(14,"2.- Manuela Khalifa", 0)]
        [InlineData(15,"3.- Manuela Khalifa", 0)]
        [InlineData(16,"4.- Manuela Khalifa", 0)]
        [InlineData(17,"5.- Manuela Khalifa", 105)]
        [InlineData(18,"6.- Manuela Khalifa", 105)]


        public void PruebavalorNumerico(int valorid, string nombre,  double resEsperando)
        {
            //Preparacion 
            //declaramos una variable del resultado real
            double resultado;
            using (var context = new ColegioContext())
            {
                Configuracion config = context.configuracions.Find(1);
                config.valormaxayuda = 45;               
                context.SaveChanges();
                Valor valor = context.valors.Find(valorid);
                Valoresproc opCalif = new Valoresproc(context);
                resultado = opCalif.PagoFinall(valor);
            }
            Assert.True(resEsperando == resultado, " Esperado " + resEsperando + " != " + resultado + " - " + nombre);
        }
    }
}
