using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

        public abstract class PresupuestoEstadoBE
        {

        public String Descripción { get; set; }
        public abstract bool AprobacionTecnica();
        public abstract bool RechazoTecnico();
        public abstract bool AprobacionComercial();
        public abstract bool RechazoComercial();
        public abstract bool AprobacionCliente();
        public abstract bool RechazoCliente();

        public abstract bool EmitirPedido();
        public abstract bool Edicion();
        public abstract bool Eliminar();

        public override string ToString()
        {
            return Descripción;
        }
    }
    
}
