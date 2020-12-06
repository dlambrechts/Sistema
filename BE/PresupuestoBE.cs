using BE.PresupuestoEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace BE
{

    [Serializable()]
	[XmlInclude(typeof(ApCli)), XmlInclude(typeof(ApComPend)),XmlInclude(typeof(ApComRech)), XmlInclude(typeof(ApTecPend)), XmlInclude(typeof(ApTecRech)), XmlInclude(typeof(EnviarCli)), XmlInclude(typeof(Finalizado)), XmlInclude(typeof(RechCli))]
	public class PresupuestoBE
    {
        [XmlElement("Num_Presupuesto")]
        public int Id { get; set; }

        private ClienteBE _Cliente;

        private PresupuestoEstadoBE _Estado;

        private List<PresupuestoItemBE> _Items;
        public PresupuestoBE(ClienteBE _cliente) 
        
        {
            _Cliente = _cliente;
            _Items = new List<PresupuestoItemBE>();
            this._Estado = new ApTecPend();      // Todos los Presupuestos nuevos quedan pendientes de Aprobación Técnica
        }
        public UsuarioBE Vendedor { get; set; }
        public ClienteBE Cliente { get { return this._Cliente; } }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaValidez { get; set; }

        public PresupuestoEstadoBE Estado { get { return this._Estado; } }
        public int PorcDescuento { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }        
        public void ActualizarEstado (PresupuestoEstadoBE NuevoEstado) { this._Estado = NuevoEstado;}
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
                this._Items.Remove(ItemRemover);
            }
        }
        public override string ToString()
        {
            return "Presupuesto N° " + Id + "  Cliente: " + _Cliente.RazonSocial;
        }

        [XmlIgnoreAttribute]
        public List<PresupuestoItemBE> Items { get { return _Items; } }
        public void ActualizarCliente (ClienteBE NuevoCliente) { this._Cliente = NuevoCliente; }

        public PresupuestoBE() { } // Constructor vacío para serializar XML
    }
}
