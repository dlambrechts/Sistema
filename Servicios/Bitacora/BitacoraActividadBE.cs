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
        public UsuarioBE usuario { get { return Usuario; } }      
        public DateTime Fecha { get; set; }
        public BitacoraClasifActividad Clasificacion { get; set; }

        public UsuarioBE Usuario = new UsuarioBE();
        public string Detalle { get; set; }
    }


}
