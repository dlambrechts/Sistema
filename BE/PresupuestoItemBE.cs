using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PresupuestoItemBE
    {
        public ProductoBE Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PorcIVA { get; set; }
        public decimal IvaItem { get; set; }
        public decimal TotalItem { get; set; }

 
    }
}
