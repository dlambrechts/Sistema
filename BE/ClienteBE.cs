using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class ClienteBE
    {
        [XmlElement("IdCliente")]
        public int Id { get; set; }
        public string RazonSocial {get;set; }
        public string Direccion { get; set; }
        
        [XmlIgnoreAttribute]
        public int CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }

        [XmlIgnoreAttribute]
        public string Cuit { get; set; }
        
        [XmlIgnoreAttribute]
        public string Contacto { get; set; }
        [XmlIgnoreAttribute]
        public bool Activo { get; set; }

        [XmlIgnoreAttribute]
        public ClienteTipoBE Tipo { get { return tipo; } }

        [XmlIgnoreAttribute]
        public ClienteTipoBE tipo = new ClienteTipoBE();

        [XmlIgnoreAttribute]
        public UsuarioBE UsuarioCreacion = new UsuarioBE();
        public UsuarioBE _UsuarioCreacion { get { return UsuarioCreacion; } }
        [XmlIgnoreAttribute]
        public DateTime FechaCreacion { get; set; }

        [XmlIgnoreAttribute]
        public UsuarioBE UsuarioModificacion = new UsuarioBE();
  
        [XmlIgnoreAttribute]
        public UsuarioBE _UsuarioModificacion { get { return UsuarioModificacion; } }

        [XmlIgnoreAttribute]
        public DateTime FechaModificacion { get; set; }

        public override string ToString()
        {
            return RazonSocial;
        }
    }
}
