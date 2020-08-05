using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOL.Modelos
{
    class PanelPrincipal
    {
        public int Id { get; set; }
        public int IdRueda { get; set; }
        public int IdPanel { get; set; }
        public string simbolo { get; set; }
        public double? ultimoprecio { get; set; }
        public double? variacionPorcentual { get; set; }
        public double? apertura { get; set; }
        public double? maximo { get; set; }
        public double? minimo { get; set; }
        public double? ultimoCierre { get; set; }
        public double? volumen { get; set; }
        public double? cantidadOperaciones { get; set; }
        public string fecha { get; set; }
        public string tipoOpcion { get; set; }
        public double? precioEjercicio { get; set; }
        public string fechaVencimiento { get; set; }
        public string mercado { get; set; }
        public string moneda { get; set; }
        public Puntas puntas { get; set; }
        public string contenido { get; set; }
        public double? PuntaCompradoraP { get; set; }
        public double? PuntaVendedoraP { get; set; }
        public double? PuntaCompradoraC { get; set; }
        public double? PuntaVendedoraC { get; set; }
    }
}
