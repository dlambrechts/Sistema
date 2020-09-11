using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClienteVersionBE
    {
        public int IdVersion { get; set; }        
        public DateTime Fecha { get; set; }

        public UsuarioBE UsuarioVersion = new UsuarioBE();

        public ClienteBE Cliente = new ClienteBE();

        public ClienteVersionCambiosBE Cambios = new ClienteVersionCambiosBE();
        public UsuarioBE Usuario { get { return UsuarioVersion; } }
    }
}
