using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOL.Clases
{
    class ESimulador
    {
        public string Simbolo { get; set; }
        public int IdSimulacion { get; set; }
        public int IdDetalle { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }
        public string Operacion { get; set; }
        public string UltimaOperacion { get; set; }
        public int UltimoIndiceOperacion { get; set; }
        public double PrecioPuntaCompradora { get; set; }
        public double PrecioPuntaVendedora { get; set; }
        public double VariacionPuntaCompradora { get; set; }
        public double VariacionPuntaVendedora { get; set; }
        public double PromedioPuntaCompradora { get; set; }
    }
}
