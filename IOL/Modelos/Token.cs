using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace IOL
{
    class Token
    {
        public string username { get; set; }
        public string password { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
        public string refreshexpires { get; set; }
        public Token()
        {
        }

        public Token(string usuario, string contrasenia)
        {
            username = usuario;
            password = contrasenia;
        }

        public bool ObtenerToken()
        {
            var client = new RestClient("https://api.invertironline.com/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            Token nuevoToken = new Token();
            IRestResponse response = null;
            try
            {
                response = client.Execute(request);
                var jObject = JObject.Parse(response.Content);

                access_token = jObject.GetValue("access_token").ToString();
                token_type = jObject.GetValue("token_type").ToString();
                expires_in = jObject.GetValue("expires_in").ToString();
                refresh_token = jObject.GetValue("refresh_token").ToString();
                issued = jObject.GetValue(".issued").ToString();
                expires = jObject.GetValue(".expires").ToString();
                refreshexpires = jObject.GetValue(".refreshexpires").ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RefrescarToken()
        {
            var client = new RestClient("https://api.invertironline.com/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("refresh_token", refresh_token);

            Token nuevoToken = new Token();
            IRestResponse response = null;
            try
            {
                response = client.Execute(request);
                var jObject = JObject.Parse(response.Content);

                access_token = jObject.GetValue("access_token").ToString();
                token_type = jObject.GetValue("token_type").ToString();
                expires_in = jObject.GetValue("expires_in").ToString();
                refresh_token = jObject.GetValue("refresh_token").ToString();
                issued = jObject.GetValue(".issued").ToString();
                expires = jObject.GetValue(".expires").ToString();
                refreshexpires = jObject.GetValue(".refreshexpires").ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
