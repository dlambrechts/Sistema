using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Servicios;


namespace Servicios.Bitacora
{
    public class BitacoraActividadBE
    {

        public int Id { get; set; }
  
        private BitacoraTipoActividad _tipo;
        public BitacoraActividadBE()

        {
            _tipo = new BitacoraTipoActividad();
        }
        public DateTime Fecha { get; set; }        
        public string Detalle { get; set; }

        public BitacoraTipoActividad Tipo { get { return _tipo; } }
        
        public void SetTipo (BitacoraTipoActividad tipo) { _tipo = tipo; }

        public UsuarioBE Usuario = new UsuarioBE();

        public UsuarioBE usuario { get { return Usuario; } }

       
    }


}
