using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.ComponentModel;
using DAL;
using Servicios;
using Servicios.Bitacora;
using Servicios.SerializadorXML;
using System.Security.Cryptography.X509Certificates;
using BE.PresupuestoEstado;

namespace BLL
{
    public class PresupuestoBLL
    {
        private DAL.PresupuestoDAL dPresup = new PresupuestoDAL();
        private Servicios.Bitacora.BitacoraActividadBE nActividad = new BitacoraActividadBE();
        private Servicios.Bitacora.BitacoraBLL bllBit = new BitacoraBLL();
        private Servicios.Bitacora.BitacoraTipoActividad tipo = new BitacoraTipoActividad();
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
            string Id= dPresup.AltaPresupuesto(nPresupuesto);
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se agregó el Presupuesto N° " + Id;
            bllBit.NuevaActividad(nActividad);
        }

        public void EditarPresupuesto(PresupuestoBE nPresupuesto)

        {
            PresupuestoEstadoBE nEstado = new ApTecPend();
            nPresupuesto.ActualizarEstado(nEstado);                                // Al editar vuelve a estar pendiente de Aprobación Técnica
            dPresup.EditarPresupuesto(nPresupuesto);
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se modificó el Presupuesto N° " + nPresupuesto.Id;
            bllBit.NuevaActividad(nActividad);

        }

        public void Eliminar(PresupuestoBE ePresup)
        {
            dPresup.Eliminar(ePresup);

            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se eliminó el Presupuesto N° " + ePresup.Id;
            bllBit.NuevaActividad(nActividad);
        }

        public List<PresupuestoBE> ListarPresupuestos() // Listar Cabecera de Presupuestos
        
        {
            return dPresup.ListarPresupuestos();
        }

        public BE.PresupuestoBE SeleccionarPresupuestoPorId(int Id)

        {
            return dPresup.SeleccionarPresupuestoPorId(Id);
        }

        public void AnalisisTecnico(PresupuestoAprobacionBE Resultado)

        {
            dPresup.AnalisisTecnico(Resultado);

            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Análisis Técnico realizado, Presupuesto N° " + Resultado.Presupuesto.Id;
            bllBit.NuevaActividad(nActividad);
        }

        public void AnalisisComercial(PresupuestoAprobacionBE Resultado)

        {
            dPresup.AnalisisComercial(Resultado);

            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Análisis Comercial realizado, Presupuesto N° " + Resultado.Presupuesto.Id;
            bllBit.NuevaActividad(nActividad);
        }

        public void Cierre(PresupuestoAprobacionBE Resultado)
        {
            dPresup.Cierre(Resultado);
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);

            nActividad.Detalle = "Cierre de Presupuesto N° " + Resultado.Presupuesto.Id;
            bllBit.NuevaActividad(nActividad);
        }

        public List<PresupuestoAprobacionBE> HistorialAnalisis(PresupuestoBE Presupuesto)
        {
            return dPresup.HistorialAnalisis(Presupuesto);
        }


        public BE.PresupuestoTipoAprobacionBE SeleccionarAprobacionTipo(string tipo) 
        
        {
            return dPresup.SeleccionarAprobacionTipo(tipo);
        }

        public void ActualizarEstado(PresupuestoBE Pres, PresupuestoEstadoBE nEstado)

        {
            dPresup.ActualizarEstado(Pres,nEstado);
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Actualización de Estado, Presupuesto N° " + Pres.Id;
            bllBit.NuevaActividad(nActividad);
        }

        public void Serializar() 
        
        {
            List<PresupuestoBE> Presupuestos = new List<PresupuestoBE>();
            Presupuestos = dPresup.ListarPresupuestos();
            Serializador<List<PresupuestoBE>> Serializador = new Serializador<List<PresupuestoBE>>();

            Serializador.Serializar(Presupuestos);
        }

        public List<PresupuestoBE> PresupuestosAtrasados(DateTime desde,DateTime hasta) 

        {
            List<PresupuestoBE> Lista = new List<PresupuestoBE>(dPresup.ListarPresupuestos());
            Lista = Lista.Where(x => x.FechaEmision > desde).ToList();
            Lista = Lista.Where(x => x.FechaEmision < hasta).ToList();
            Lista = Lista.Where(x => x.FechaValidez < DateTime.Now).ToList();
            Lista = Lista.Where(x => x.Estado.GetType().Name !=  "Finalizado").ToList();

            return Lista;
        }
    }
}
