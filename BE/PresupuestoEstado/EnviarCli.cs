using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.PresupuestoEstado
{
    public class EnviarCli: PresupuestoEstadoBE
    {
        public override bool AprobacionCliente() { return true; }
        public override bool AprobacionComercial() { return false; }
        public override bool AprobacionTecnica() { return false; }
        public override bool RechazoCliente() { return true; }
        public override bool RechazoComercial() { return false; }
        public override bool RechazoTecnico() { return false; }
        public override bool Edicion() { return false; }
        public override bool Eliminar() { return false; }
        public override bool EmitirPedido() { return false; }
    }
}
