using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IOL
{
    class Correo
    {
        private string _correo = string.Empty;
        public Correo(string Correo)
        {
            _correo = Correo;
        }

        public bool ValidarCorreo()
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(_correo, expresion))
            {
                if (Regex.Replace(_correo, expresion, String.Empty).Length == 0)
                   return true;
                else
                   return false;
            }
            else
               return false;
        }
    }
}
