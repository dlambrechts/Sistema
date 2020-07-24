using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BE.PresupuestoEstado
{
    public class ApTecRech : PresupuestoEstadoBE
    {
        public override bool AprobacionCliente() {return false;}
        public override bool AprobacionComercial() {return false;}
        public override bool AprobacionTecnica() { return true; }
        public override bool RechazoCliente() { return false; }
        public override bool RechazoComercial() {return false;}
        public override bool RechazoTecnico(){ return false; }
        public override bool Edicion() { return true; }
        public override bool Eliminar() { return true; }
    }
}
