using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOL.Clases
{
    class ERuedasDetalle
    {
        public int IdRuedaDetalle { get; set; }
        public int IdRuedaActual { get; set; }
        public int IdRuedaCompra { get; set; }
        public int IdRuedaVenta { get; set; }
        public string Operacion { get; set; }
        public DateTime FechaOperacion { get; set; }
        public string Simbolo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal UltimoPrecio { get; set; }
        public DateTime FechaUltimoPrecio { get; set; }
        public decimal Variacionenpesos { get; set; }
        public decimal Variacionenporcentajes { get; set; }
        public string Estado { get; set; }
    }
}
