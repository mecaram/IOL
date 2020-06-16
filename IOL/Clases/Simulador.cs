using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOL.Clases
{
    class DatosSimulador
    {
        string simbolo = string.Empty;
        int idsimulacion = 0;
        int iddetalle = 0;
        double cantidad = 0;
        double precio = 0;
        double importe = 0;
        string operacion = string.Empty;
        string ultimaoperacion = string.Empty;
        int ultimoindiceoperacion = 0;
        double preciopuntacompradora = 0;
        double preciopuntavendedora = 0;
        double variacionpuntacompradora = 0;
        double variacionpuntavendedora = 0;
        double promediopuntacompradora = 0;

        public string Simbolo
        {
            get { return simbolo;}
            set { simbolo = value;}
        }

        public int IdSimulacion
        {
            get { return idsimulacion;}
            set { idsimulacion = value; }
        }
        public int IdDetalle
        {
            get { return iddetalle; }
            set { iddetalle = value; }
        }

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }

        public string UltimaOperacion
        {
            get { return ultimaoperacion; }
            set { ultimaoperacion = value; }
        }

        public int UltimoIndiceOperacion
        {
            get { return ultimoindiceoperacion; }
            set { ultimoindiceoperacion = value; }
        }

        public double PrecioPuntaCompradora
        {
            get { return preciopuntacompradora; }
            set { preciopuntacompradora = value; }
        }

        public double PrecioPuntaVendedora
        {
            get { return preciopuntavendedora; }
            set { preciopuntavendedora = value; }
        }
        public double VariacionPuntaCompradora
        {
            get { return variacionpuntacompradora; }
            set { variacionpuntacompradora = value; }
        }

        public double VariacionPuntaVendedora
        {
            get { return variacionpuntavendedora; }
            set { variacionpuntavendedora = value; }
        }
        public double PromedioPuntaCompradora
        {
            get { return promediopuntacompradora; }
            set { promediopuntacompradora = value; }
        }
    }
}
