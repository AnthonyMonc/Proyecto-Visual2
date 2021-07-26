﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Colegio
{
    public class Valor : IDBEntity
    {
        public int ValorId { get; set; }
        public int PagoDetId { get; set; }
        public PagoDet PagoDet { get; set; }
        public double valorApagar { get; set; }
        public double valorayuda { get; set; }
        public double valorpagado { get; set; }
        public double valorpendiente { get; set; }

        public double PagoFinal( double valormaxayuda)
        {
            // Cálculo
            double valorT = 0;
            double valorpagadoT = valorpagado;
            valorpagadoT = valorpagadoT - valormaxayuda;
            valorT = valorApagar - valorpagadoT;            
            valorT = Math.Round(valorT, 2);
            return valorT;
        }
        // Verifica si cumple el mínimo
        public bool Aprueba(double valormaxayuda, double pagomin)
        {
            bool res;
            res = PagoFinal(valormaxayuda) >= pagomin;
            return res;
        }
    }
}
