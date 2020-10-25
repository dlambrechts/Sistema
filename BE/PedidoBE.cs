using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PedidoBE
    {
        public int Id { get; set; }

        private ClienteBE _Cliente;

        private PresupuestoBE _Presupuesto;

        private List<PedidoItemBE> _Items;
        public PedidoBE (ClienteBE cliente, PresupuestoBE presupuesto) 
        
        {
            _Cliente = cliente;
            _Presupuesto = presupuesto;
            _Items = new List<PedidoItemBE>();
        }
     
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public void AgregarItem(ProductoBE Producto, int Cantidad) 
        
        {
            PedidoItemBE Item = new PedidoItemBE(Producto,Cantidad);
            _Items.Add(Item);
        }
       
        public List<PedidoItemBE> Items { get { return _Items; } }
        public ClienteBE Cliente { get { return _Cliente; } }

        public PresupuestoBE Presupuesto { get { return _Presupuesto; } }
    }
}
