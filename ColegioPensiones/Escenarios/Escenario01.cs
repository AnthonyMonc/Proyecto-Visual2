using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.Colegio;

namespace Escenarios
{
    public class Escenario01 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> Carga()
        {

            //---------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------
            //Creacion de periodo
            Periodo per2020_PAO2 = new()
            {                
                FechaInicio = new DateTime(2020, 9, 1),
                FechaFin = new DateTime(2021, 3, 1)                
            };
            List<Periodo> lstperiodo = new()
            {
                per2020_PAO2
            };
            datos.Add(ListaTipo.Periodo, lstperiodo);
            //---------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------
            //Creacion de Grados
            Grado Quinto = new() { nomgrado = "Quinto curso", Seccion = "Diurna" };
            Grado Sexto = new() { nomgrado = "Sexto curso", Seccion = "Diurna" };
            Grado Septimo = new() { nomgrado = "Septimo curso", Seccion = "Diurna" };
            List<Grado> lstgrados = new()
            {
                Quinto,
                Sexto,
                Septimo
            };
            datos.Add(ListaTipo.Grado, lstgrados);
            //---------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------
            //Creacion de Alumnos
            Alumno Anthony = new() { Nombrecompl = "Anthony Moncayo", Cedula = "1750420117",Grado = Quinto };
            Alumno Carla = new() { Nombrecompl = "Carla Gonzales", Cedula = "17652354325", Grado = Sexto };
            Alumno Manuela = new() { Nombrecompl = "Manuela Khalifa", Cedula = "1754329876", Grado = Septimo };
            List<Alumno> lstEstudiante = new()
            {
                Anthony,
                Carla,
                Manuela
            };
            datos.Add(ListaTipo.Alumno, lstEstudiante);
            //---------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------
            //Creacion de Estados
            Estado ConMora = new() { Mora="Con Mora",Clasesextra=false,Examenes=false,Laboratorio=false,Recorrido=false };
            Estado SinMora = new() { Mora = "Sin Mora", Clasesextra = true, Examenes = true, Laboratorio = true, Recorrido = true };
            List<Estado> lstestado = new()
            {
                ConMora,
                SinMora
                
            };
            datos.Add(ListaTipo.Estado, lstestado);
            //---------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------
            //Creacion de Colegio
            Colegio DonBosco = new() { NombreColegio = "Don Bosco", Direccion = "La Kennedy" };
            List<Colegio> lstColegio = new() { DonBosco };
            datos.Add(ListaTipo.Colegio, lstColegio);            
            //---------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------

            //Creacion de Ciclos
            Ciclo Enero = new() {Mes="Enero",FechaMora=new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Febrero = new() { Mes = "Febrero", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Marzo = new() { Mes = "Marzo", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Abril = new() { Mes = "Abril", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Mayo = new() { Mes = "Mayo", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Junio = new() { Mes = "Junio", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Julio = new() { Mes = "Julio", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Agosto = new() { Mes = "Agosto", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Septiembre = new() { Mes = "Septiembre", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Octubre = new() { Mes = "Octubre", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Noviembre = new() { Mes = "Noviembre", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };
            Ciclo Diciembre = new() { Mes = "Diciembre", FechaMora = new DateTime(2021, 4, 1), FechaPago = new DateTime(2021, 9, 1), periodo = per2020_PAO2 };

            List<Ciclo> lstciclos = new()
            {
                Enero,
                Febrero,
                Marzo,
                Abril,
                Mayo,
                Junio,
                Julio,
                Agosto,
                Septiembre,
                Octubre,
                Noviembre,
                Diciembre
            };
            datos.Add(ListaTipo.Ciclo, lstciclos);
            //---------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------
            //Creacion de Cofiguracion
            Configuracion configuraciones = new()
            {
                EscuelaN = "Don Bosco",
                DiaMax = new DateTime(2021, 3, 1),
                valorminApagar = 70,
                valormaxayuda = 45,
                PeriodoV = per2020_PAO2

            };
            List<Configuracion> lstconf = new() {configuraciones };
            datos.Add(ListaTipo.Configuracion,lstconf);
            return datos;

        }
    }
}
