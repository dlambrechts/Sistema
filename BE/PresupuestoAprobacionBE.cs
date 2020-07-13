using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PresupuestoAprobacionBE
    {
        public int Id { get; set; }

        public PresupuestoBE Presupuesto = new PresupuestoBE();

        public UsuarioBE Aprobador = new UsuarioBE();
        public DateTime Fecha { get; set; }
        public string TipoAprobacion { get; set; }
        public string Accion { get; set; }
        public string Observaciones { get; set; }
        
    }
}
