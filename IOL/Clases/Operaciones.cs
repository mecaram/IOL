using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinHttp;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using IOL.Clases;


namespace IOL
{
    class Operaciones
    {

        public PanelModel ObtenerPanel(string token)
        {
            var client = new RestClient("https://api.invertironline.com/api/v2/Cotizaciones/acciones/merval/argentina");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            string cadena = string.Format("Bearer {0}", token);
            request.AddHeader("Authorization", cadena);
            IRestResponse response = client.Execute(request);
            try
            {
                response = client.Execute(request);
                var contenido = JObject.Parse(response.Content);

                JavaScriptSerializer js = new JavaScriptSerializer();
                PanelModel registros = js.Deserialize<PanelModel>(contenido.ToString());
                return registros;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
        }
        public bool ObtenerCotizacion(string token, string mercado, string simbolo, string plazo)
        {
            var client = new RestClient("https://api.invertironline.com/api/v2/{Mercado}/Titulos/{Simbolo}/Cotizacion");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            string cadena = string.Format("Bearer {0}", token);
            request.AddHeader("Authorization", cadena);
            request.AddParameter("mercado", mercado);
            request.AddParameter("simbolo", simbolo);
            request.AddParameter("plazo", plazo);
            IRestResponse response = client.Execute(request);
            try
            {
                response = client.Execute(request);
                var contenido = JObject.Parse(response.Content);

                JavaScriptSerializer js = new JavaScriptSerializer();
                CotizacionModel registros = js.Deserialize<CotizacionModel>(contenido.ToString());
                registros.mercado = mercado;
                registros.simbolo = simbolo;
                registros.plazo = plazo;
                registros.contenido = contenido.ToString();

                string registro = string.Format("Simbolo: {0} /r Ultimo Precio: {1}", registros.simbolo, registros.ultimoprecio.ToString());
                MessageBox.Show(registro, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (var cajas in registros.puntas)
                {
                    registro = string.Format("Cantidad Compra: {0} /r Precio Compra: {1} Cantidad Venta: {2} /r Precio Venta: {3}", cajas.cantidadCompra.ToString(), cajas.precioCompra.ToString(), cajas.cantidadVenta.ToString(), cajas.precioVenta.ToString());
                    MessageBox.Show(registro, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.HResult.ToString(), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }
        public TituloModel ObtenerDatosTitulo(string token, string mercado, string simbolo)
        {
            var client = new RestClient("https://api.invertironline.com/api/v2/{mercado}/Titulos/{simbolo}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            string cadena = string.Format("Bearer {0}", token);
            request.AddHeader("Authorization", cadena);
            request.AddParameter("mercado", mercado);
            request.AddParameter("simbolo", simbolo);
            IRestResponse response = client.Execute(request);
            try
            {
                response = client.Execute(request);
                var contenido = JObject.Parse(response.Content);

                JavaScriptSerializer js = new JavaScriptSerializer();
                TituloModel registros = js.Deserialize<TituloModel>(contenido.ToString());
                registros.mercado = mercado;
                registros.simbolo = simbolo;
                registros.contenido = contenido.ToString();

                return registros;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
        }
        public bool ObtenerSerieHistorica(string token, string mercado, string simbolo, string ajustada, string fechadesde, string fechahasta)
        {
            var client = new RestClient("https://api.invertironline.com/api/v2/bCBA/Titulos/{simbolo}/Cotizacion/seriehistorica/{fechaDesde}/{fechaHasta}/{ajustada}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            string cadena = string.Format("Bearer {0}", token);
            request.AddHeader("Authorization", cadena);
            request.AddParameter("mercado", mercado);
            request.AddParameter("simbolo", simbolo);
            request.AddParameter("fechaDesde", fechadesde);
            request.AddParameter("fechaHasta", fechahasta);
            request.AddParameter("ajustada", ajustada);
            IRestResponse response = client.Execute(request);
            try
            {
                response = client.Execute(request);
                JArray jsonVector = JArray.Parse(response.Content.ToString());

                for(int indice = 0; indice < jsonVector.Count; indice++)
                {
                    dynamic registro = JObject.Parse(jsonVector[indice].ToString());
                    MessageBox.Show(string.Format("Ultimo Precio:{0}{1}variacion:{2}", registro.ultimoPrecio, Environment.NewLine, registro.variacion));
                }
                return true;
            }
            catch (Exception ex)            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

    }
}
