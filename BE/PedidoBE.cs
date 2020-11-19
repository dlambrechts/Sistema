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
        public PedidoBE(ClienteBE cliente, PresupuestoBE presupuesto)

        {
            _Cliente = cliente;
            _Presupuesto = presupuesto;
            _Items = new List<PedidoItemBE>();
        }


        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }

        public void AgregarItem(ProductoBE Producto, int Cantidad,decimal unitario,decimal impuestos,decimal totalitem) 
        
        {
            PedidoItemBE Item = new PedidoItemBE(Producto,Cantidad,unitario,impuestos,totalitem);
            _Items.Add(Item);
        }
       
        public List<PedidoItemBE> Items { get { return _Items; } }
        public ClienteBE Cliente { get { return _Cliente; } }

        public decimal Descuento { get; set; }

        public decimal Impuestos { get; set; }

        public decimal Total { get; set; }

        public PresupuestoBE Presupuesto { get { return _Presupuesto; } }

        public bool Envio { get; set; }
        public string DireccionEnvio { get; set; }
        public string ResponsableEnvio { get; set; }
    }
}
