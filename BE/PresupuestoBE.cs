using BE.PresupuestoEstado;
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
        public PresupuestoEstadoBE Estado { get; set; }    
        public int PorcDescuento { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }
       
        public PresupuestoBE() 
        
        { this.Estado = new ApTecPend(); } // Todos los Presupuestos nuevos quedan pendientes de Aprobación Técnica
        
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

        public override string ToString()
        {
            return "Presupuesto N° " + Id + "  Cliente: " + Cliente.RazonSocial;
        }
    }
}
