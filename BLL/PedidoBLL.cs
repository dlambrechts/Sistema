using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class PedidoBLL
    {
        PedidoDAL pDal = new PedidoDAL();
        public List<PedidoBE> ListarPedidos()

        {
            return pDal.ListarPedidos();
        }

        public void AltaPedido(PedidoBE Pedido) 
        
        {
            pDal.AltaPedido(Pedido);
        }
        public PedidoBE PresupuestoToPedido (PresupuestoBE Pres)  // Crear el Pedido en Base a un Presupesto
        
        {
            PresupuestoBLL presBLL = new PresupuestoBLL();

            Pres = presBLL.SeleccionarPresupuestoPorId(Pres.Id); // Traer los items del presupuesto de la DB

            PedidoBE nPedido = new PedidoBE(Pres.Cliente, Pres);

            foreach (PresupuestoItemBE item in Pres.Items)

            {
                nPedido.AgregarItem(item.Producto, item.Cantidad);
            }

            return nPedido;
        }

        public void CambiarFechaEntrega(PedidoBE PedidoEditado) 
        
        {
            pDal.Editar(PedidoEditado);
        }

        public void CargarItems(PedidoBE Pedido) 
        
        {
             List<PedidoItemBE> Items = new List<PedidoItemBE>();
            Items = pDal.ObtenerItems(Pedido);

            foreach (PedidoItemBE item in Items)
            {
                Pedido.AgregarItem(item.Producto, item.Cantidad);
            }    
        }
    }
}
