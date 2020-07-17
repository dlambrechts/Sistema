using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.ComponentModel;
using DAL;

namespace BLL
{
    public class PresupuestoBLL
    {

        public decimal CalcularTotalIva(PresupuestoBE Presup)

        {
            decimal TotalIva = 0;

            foreach (PresupuestoItemBE item in Presup.Items)
            
            {
                TotalIva += item.IvaItem;
            }

            return TotalIva;
        }

        public decimal CalcularSubTotal(List<PresupuestoItemBE> Items)

        {
            decimal subtotal = 0;

            foreach (PresupuestoItemBE item in Items)
            {
                subtotal += item.TotalItem;
            }
            return subtotal;
        }

        public decimal CalcularTotal(decimal descuento, decimal subtotal)

        {
            decimal total = 0;

            total = subtotal - descuento;

            return total;

        }
        
        public decimal CalcularDescuento(decimal subtotal,int desc)
        {
            decimal descuento = 0;
            descuento = (subtotal * desc) / 100;
            return descuento;

        }

        public void AltaPresupuesto (PresupuestoBE nPresupuesto)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.AltaPresupuesto(nPresupuesto);

        }

        public void EditarPresupuesto(PresupuestoBE nPresupuesto)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.EditarPresupuesto(nPresupuesto);

        }

        public List<PresupuestoBE> ListarPresupuestos() // Listar Cabecera de Presupuestos
        
        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            return dPresup.ListarPresupuestos();
        }

        public PresupuestoBE SeleccionarPresupuestoPorId(int Id)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            return dPresup.SeleccionarPresupuestoPorId(Id);

        }

        public void AnalisisTecnico(PresupuestoAprobacionBE Resultado)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.AnalisisTecnico(Resultado);
        }

        public void AnalisisComercial(PresupuestoAprobacionBE Resultado)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.AnalisisComercial(Resultado);
        }

        public void Cierre(PresupuestoAprobacionBE Resultado)
        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.Cierre(Resultado);
        }
        public List<PresupuestoAprobacionBE> HistorialAnalisis(PresupuestoBE Presupuesto)
        {

            PresupuestoDAL dPresup = new PresupuestoDAL();
            return dPresup.HistorialAnalisis(Presupuesto);
        }

        public void Eliminar(PresupuestoBE ePresup) 
        
        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.Eliminar(ePresup);
        }
    }
}
