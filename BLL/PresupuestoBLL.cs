using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.ComponentModel;
using DAL;
using Servicios;

namespace BLL
{
    public class PresupuestoBLL
    {
        BitacoraActividadBE nActividad = new BitacoraActividadBE();
        BitacoraBLL bllAct = new BitacoraBLL();
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
            string Id= dPresup.AltaPresupuesto(nPresupuesto);
        
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se agregó el Presupuesto N° " + Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void EditarPresupuesto(PresupuestoBE nPresupuesto)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.EditarPresupuesto(nPresupuesto);
       
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se modificó el Presupuesto N° " + nPresupuesto.Id;
            bllAct.NuevaActividad(nActividad);

        }

        public void Eliminar(PresupuestoBE ePresup)
        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.Eliminar(ePresup);

            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se eliminó el Presupuesto N° " + ePresup.Id;
            bllAct.NuevaActividad(nActividad);
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

            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Análisis Técnico realizado, Presupuesto N° " + Resultado.Presupuesto.Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void AnalisisComercial(PresupuestoAprobacionBE Resultado)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.AnalisisComercial(Resultado);

            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Análisis Comercial realizado, Presupuesto N° " + Resultado.Presupuesto.Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void Cierre(PresupuestoAprobacionBE Resultado)
        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.Cierre(Resultado);

            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Cierre de Presupuesto N° " + Resultado.Presupuesto.Id;
            bllAct.NuevaActividad(nActividad);
        }

        public List<PresupuestoAprobacionBE> HistorialAnalisis(PresupuestoBE Presupuesto)
        {

            PresupuestoDAL dPresup = new PresupuestoDAL();
            return dPresup.HistorialAnalisis(Presupuesto);
        }


        public PresupuestoTipoAprobacionBE SeleccionarAprobacionTipo(string tipo) 
        
        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            return dPresup.SeleccionarAprobacionTipo(tipo);
        }

        public void ActualizarEstado(PresupuestoBE Pres, PresupuestoEstadoBE nEstado)

        {
            PresupuestoDAL dPresup = new PresupuestoDAL();
            dPresup.ActualizarEstado(Pres,nEstado);

            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Actualización de Estado, Presupuesto N° " + Pres.Id;
            bllAct.NuevaActividad(nActividad);
        }
    }
}
