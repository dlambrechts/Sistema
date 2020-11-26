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

        private PresupuestoBE _Presupuesto;

        private UsuarioBE _Aprobador;

        private PresupuestoTipoAprobacionBE _Tipo;
        public DateTime Fecha { get; set; }        
        public string Accion { get; set; }
        public string Observaciones { get; set; }
        public PresupuestoAprobacionBE(PresupuestoBE _presup,PresupuestoTipoAprobacionBE _tipo, UsuarioBE _aprobador) 
        
        {
            _Presupuesto = _presup;
            _Aprobador = _aprobador;
            _Tipo = _tipo;
        }
        public UsuarioBE Aprobador { get { return _Aprobador; } }
        public PresupuestoBE Presupuesto { get { return _Presupuesto; } }
        public PresupuestoTipoAprobacionBE Tipo { get { return _Tipo; } }
    }
}
