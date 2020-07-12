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
        public float CalcularSubTotal(BindingList<PresupuestoItemBE> Items)

        {
            float subtotal = 0;
            foreach (PresupuestoItemBE item in Items)
            {
                subtotal += item.TotalItem;
            }
            return subtotal;
        }

        public float CalcularTotal(float descuento, float subtotal)

        {
            float total = 0;

            total = subtotal - descuento;

            return total;

        }
        
        public float CalcularDescuento(float subtotal,int desc)
        {
            float descuento = 0;
            descuento = (subtotal * desc) / 100;
            return descuento;

        }

        public void AltaPresupuesto (PresupuestoBE nPresupuesto)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.AltaPresupuesto(nPresupuesto);

        }

        public List<PresupuestoBE> ListarPresupuestos() 
        
        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            return dPresup.ListarPresupuestos();
        }
    }
}
