using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.PresupuestoEstado
{
    public class ApComPend : PresupuestoEstadoBE
    {
        public override bool AprobacionCliente() { return false; }
        public override bool AprobacionComercial() { return true; }
        public override bool AprobacionTecnica() { return false; }
        public override bool RechazoCliente() { return false; }
        public override bool RechazoComercial() { return true; }
        public override bool RechazoTecnico() { return false; }
        public override bool Edicion() { return true; }
        public override bool Eliminar() { return true; }

        public override bool EmitirPedido() { return false; }
    }
}
