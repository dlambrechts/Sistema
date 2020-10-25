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
        public string Cuit { get; set; }
        public string Contacto { get; set; }
        public bool Activo { get; set; }
        public ClienteTipoBE Tipo { get { return tipo; } }

        public ClienteTipoBE tipo = new ClienteTipoBE();

        public UsuarioBE UsuarioCreacion = new UsuarioBE();
        public UsuarioBE _UsuarioCreacion { get { return UsuarioCreacion; } }
        public DateTime FechaCreacion { get; set; }

        public UsuarioBE UsuarioModificacion = new UsuarioBE();
        public UsuarioBE _UsuarioModificacion { get { return UsuarioModificacion; } }
        public DateTime FechaModificacion { get; set; }

        public override string ToString()
        {
            return RazonSocial;
        }
    }
}
