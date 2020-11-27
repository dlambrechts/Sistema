using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using BE.PresupuestoEstado;

namespace BLL
{
    public class PedidoBLL
    {
        private DAL.PedidoDAL pDal = new PedidoDAL();
        private DAL.PresupuestoDAL presDal = new PresupuestoDAL();
        public List<PedidoBE> ListarPedidos()

        {
            return pDal.ListarPedidos();
        }

        public void AltaPedido(PedidoBE Pedido) 
        
        {
            pDal.AltaPedido(Pedido);
            PresupuestoEstadoBE nEstado = new Finalizado();
            presDal.ActualizarEstado(Pedido.Presupuesto, nEstado);
        }
        public BE.PedidoBE PresupuestoToPedido(PresupuestoBE Pres)  // Crear el Pedido en Base a un Presupesto
        
        {
            PresupuestoBLL presBLL = new PresupuestoBLL();

            Pres = presBLL.SeleccionarPresupuestoPorId(Pres.Id); // Traer los items del presupuesto de la DB


            PedidoBE nPedido = new PedidoBE(Pres.Cliente, Pres);

            nPedido.Descuento = Pres.Descuento;
            nPedido.Impuestos = Pres.Iva;
            nPedido.Total = Pres.Total;

            foreach (PresupuestoItemBE item in Pres.Items)

            {
                nPedido.AgregarItem(item.Producto, item.Cantidad,item.PrecioUnitario,item.IvaItem,item.TotalItem);
            }

            return nPedido;
        }

        public void Editar(PedidoBE PedidoEditado) 
        
        {
            pDal.Editar(PedidoEditado);
        }

        public void CargarItems(PedidoBE Pedido) 
        
        {
             List<PedidoItemBE> Items = new List<PedidoItemBE>();
            Items = pDal.ObtenerItems(Pedido);

            foreach (PedidoItemBE item in Items)
            {
                Pedido.AgregarItem(item.Producto, item.Cantidad,item.PrecioUnitario, item.Impuestos,item.TotalItem);
            }    
        }

        public void Eliminar(PedidoBE Pedido) 
        
        {         
            pDal.Eliminar(Pedido);
            PresupuestoEstadoBE estado = new ApCli();
            presDal.ActualizarEstado(Pedido.Presupuesto, estado);
        }
    }
}
