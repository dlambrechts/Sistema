using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Servicios
{
    public class Encriptador
    {

        public static string Hash(string Cadena)
        {
            byte[] tmpSource;
            byte[] tmpData;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(Cadena);
            tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return Convert.ToBase64String(tmpData);
        }
    }


}
