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
        public PresupuestoEstadoBE Estado { get { return estado; } }      
        public int PorcDescuento { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }

        public PresupuestoEstadoBE estado = new PresupuestoEstadoBE();
        public bool ExisteItem (ProductoBE Prod){return this.Items.Exists(x => x.Producto.Id == Prod.Id);}
        public void AgregarItems(ProductoBE Prod, int Cant)

        {
            PresupuestoItemBE nItem = new PresupuestoItemBE();
            nItem.Cantidad = Cant;
            nItem.Producto = Prod;
            nItem.PrecioUnitario = Prod.Precio;
            nItem.PorcIVA = Prod.Iva;
            nItem.IvaItem = ((nItem.PrecioUnitario*nItem.PorcIVA)/100) *nItem.Cantidad;
            nItem.TotalItem = (Prod.Precio * nItem.Cantidad)+nItem.IvaItem;
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
