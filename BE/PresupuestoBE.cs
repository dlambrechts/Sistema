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

        public List<PresupuestoItemBE> Items = new List<PresupuestoItemBE>();
        public UsuarioBE Vendedor { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaValidez { get; set; }
        public bool AprobacionTecnica { get; set; }
        public bool AprobacionComercial { get; set; }    
        public string Estado { get; set; }
        public float Descuento { get; set; }
        public float Total { get; set; }
        public string Observaciones { get; set; }

        public bool ExisteItem (ProductoBE Prod){return this.Items.Exists(x => x.Producto.Id == Prod.Id);}
        public void AgregarItems(ProductoBE Prod, int Cant)

        {
            PresupuestoItemBE nItem = new PresupuestoItemBE();
            nItem.Cantidad = Cant;
            nItem.Producto = Prod;
            nItem.PrecioUnitario = Prod.Precio;
            nItem.TotalItem = Prod.Precio * nItem.Cantidad;
            this.Items.Add(nItem);
        }
        public void QuitarItem(ProductoBE Prod)        
        {
            if (this.ExisteItem(Prod) == true)         
            {
                var ItemRemover = this.Items.Single(x => x.Producto.Id == Prod.Id);
                this.Items.Remove(ItemRemover);
            }
        }
    }
}
