using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOL.Clases
{
    class ETenenciasSimulador
    {
        public int IdSimulacion { get; set; }
        public decimal DisponibleParaOperar { get; set; }
        public decimal ActivosValorizados { get; set; }
        public decimal TotalTenencia { get; set; }
        public DateTime Fecha { get; set; }
    }
}
