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

        private UsuarioBE _Usuario;

        private ClienteBE _Cliente;

        private ClienteVersionCambiosBE _Cambios;
        public ClienteVersionBE(ClienteBE cliente, UsuarioBE usuario)

        {
            _Usuario = usuario;
            _Cliente = cliente;
            _Cambios = new ClienteVersionCambiosBE();
        }
        public UsuarioBE UsuarioVersion {get{return _Usuario; } }
        public ClienteBE Cliente { get { return _Cliente; }  }
        public ClienteVersionCambiosBE Cambios { get { return _Cambios; } }
        public void SetCambios (ClienteVersionCambiosBE Cambios) { _Cambios = Cambios; }
        
    }
}
