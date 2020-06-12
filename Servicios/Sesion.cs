using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios
{
    public class Sesion
    {
        private UsuarioBE _usuario { get; set; }
        public UsuarioBE Usuario 
        { 
           get 
            
            {
                return _usuario;
            }
        
        }

        public void Login (UsuarioBE Usuario)

        {
            _usuario = Usuario;

        }

        public void Logout ()
        
        {
            _usuario = null;
        }

        public bool IsLogged()
        {
            return _usuario != null;
        }
    }
}
