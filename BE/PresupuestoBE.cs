using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class PresupuestoBE
    {
        public int Id { get; set; }
        public ClienteBE Cliente { get; set; }
        public List<PresupuestoItemBE> Items { get; set; }
        public UsuarioBE Vendedor { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool AprobacionTecnica { get; set; }
        public bool AprobacionComercial { get; set; }    
        public string Estado { get; set; }
        public float Descuento { get; set; }
        public float Total { get; set; }

    }
}
