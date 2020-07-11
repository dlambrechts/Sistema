using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClienteBE
    {
        public int Id { get; set; }
        public string RazonSocial {get;set; }
        public string Direccion { get; set; }
        public int CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Tipo { get; set; }
        public string Cuit { get; set; }
        public string Contacto { get; set; }
        public string CondicionPago { get; set; }
        public bool Activo { get; set; }
    }
}
