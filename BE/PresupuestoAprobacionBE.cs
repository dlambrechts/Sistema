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
        public DateTime Fecha { get; set; }

        public UsuarioBE Aprobador = new UsuarioBE();
        public UsuarioBE aprobador {  get { return Aprobador; }}       
        public string TipoAprobacion { get; set; }
        public string Accion { get; set; }
        public string Observaciones { get; set; }
        
    }
}
