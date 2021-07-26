using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Pago : IDBEntity
    {
        
        public int PagoId { get; set; }
        public Alumno Alumno { get; set; }
        public int AlumnoID { get; set; }
        public string Vivienda { get; set; }
        public bool ServiciosBasicos { get; set; }
        public double IngresosT { get; set; }
        public bool AyudaEco { get; set; }
        public DateTime fechapago { get; set; }        
        /*
        public double valorapagar { get; set; }
        public double valorayuda { get; set; }
        public double valorpagado { get; set; }
        */
        public Periodo periodo { get; set; }
        public int PeriodoId { get; set; }
        public Estado Estado { get; set; }
        public int EstadoID { get; set; }
        //public double saldoPendiente { get; set; }       
        public List<PagoDet> PagoDets { get; set; }

    }
}
