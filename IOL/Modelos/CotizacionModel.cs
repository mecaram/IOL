using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace IOL.Clases
{
    class CotizacionModel
    {
        public string simbolo { get; set; }
        public string mercado { get; set; }
        public string plazo { get; set; }
        public double? ultimoprecio { get; set; }
        public double? variacion { get; set; }
        public double? apertura { get; set; }
        public double? maximo { get; set; }
        public double? minimo { get; set; }
        public string fechahora { get; set; }
        public string tendencia { get; set; }
        public double? cierreAnterior { get; set; }
        public double? montoOperado { get; set; }
        public int volumenNominal { get; set; }
        public double? precioPromedio { get; set; }
        public string moneda { get; set; }
        public double? precioAjuste { get; set; }
        public double? interesesAbiertos { get; set; }
        public Puntas[] puntas = new Puntas[100];
        public int cantidadDeOperaciones { get; set; }
        public string contenido { get; set; }

        public CotizacionModel()
        {
        }
    }
}
