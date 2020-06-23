using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOL.Clases
{
    class ERuedasDetalleSimulador
    {
        public int IdRuedaDetalle { get; set; }
        public int IdRuedaActual { get; set; }
        public int IdRuedaCompra { get; set; }
        public int IdRuedaVenta { get; set; }
        public int IdSimulacion { get; set; }
        public int IdPanel { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal ImporteVenta { get; set; }
        public string Simbolo { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal ImporteCompra { get; set; }
        public decimal PorcComisionIOL { get; set; }
        public decimal ImporteComisionIOL { get; set; }
        public decimal UltimoPrecio { get; set; }
        public DateTime FechaUltimoPrecio { get; set; }
        public decimal Variacionenpesos { get; set; }
        public decimal Variacionenporcentajes { get; set; }
        public string Estado { get; set; }
    }
}
