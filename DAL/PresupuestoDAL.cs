using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace DAL
{
    public class PresupuestoDAL
    {
        public List<PresupuestoAprobacionBE> HistorialAnalisis(PresupuestoBE Presupuesto) 
        
        {
            List<PresupuestoAprobacionBE> Historial = new List<PresupuestoAprobacionBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@IdPresup", Presupuesto.Id);
            DS = AccesoDB.LeerDatos("sp_ListarPresupuestoHistorialAprobacion", Parametros);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    PresupuestoAprobacionBE oAprob = new PresupuestoAprobacionBE();
                    
                    oAprob.Fecha = Convert.ToDateTime(Item["Fecha"]); oAprob.Fecha.ToShortDateString();
                    oAprob.Aprobador.Nombre = Convert.ToString(Item["Nombre"]).Trim();
                    oAprob.Aprobador.Apellido = Convert.ToString(Item["Apellido"]).Trim();
                    oAprob.TipoAprobacion = Convert.ToString(Item["TipoAprobacion"]).Trim();
                    oAprob.Accion = Convert.ToString(Item["Accion"]).Trim();
                    oAprob.Observaciones = Convert.ToString(Item["Observaciones"]).Trim();
                   

                    Historial.Add(oAprob);
                }

            }
            return Historial;
        }

        public List<PresupuestoBE> ListarPresupuestos() // Solo muestra la cabecera para el listado
        
        {
            List<PresupuestoBE> ListaPresupuestos = new List<PresupuestoBE>();
            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListarPresupuestosCabecera", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    PresupuestoBE oPres = new PresupuestoBE();

                    oPres.Id = Convert.ToInt32(Item["Id"]);
                    oPres.Cliente = new ClienteBE(); 
                    oPres.Cliente.Id = Convert.ToInt32(Item["IdCliente"]);
                    oPres.Cliente.RazonSocial = Convert.ToString(Item["RazonSocial"]).Trim();
                    oPres.Vendedor = new UsuarioBE(); 
                    oPres.Vendedor.Id = Convert.ToInt32(Item["IdVendedor"]);
                    oPres.Vendedor.Nombre = Convert.ToString(Item["Nombre"]).Trim();
                    oPres.Vendedor.Apellido = Convert.ToString(Item["Apellido"]).Trim();
                    oPres.FechaEmision = Convert.ToDateTime(Item["FechaEmision"]);
                    oPres.FechaEntrega = Convert.ToDateTime(Item["FechaEntrega"]);
                    oPres.FechaValidez = Convert.ToDateTime(Item["FechaValidez"]);
                    oPres.AprobacionTecnica = Convert.ToBoolean(Item["AprobacionTecnica"]);
                    oPres.AprobacionComercial = Convert.ToBoolean(Item["AprobacionComercial"]);
                    oPres.estado.Id = Convert.ToInt32(Item["IdEstado"]);
                    oPres.estado.Descripcion = Convert.ToString(Item["Descripcion"]).Trim();
                    oPres.Descuento = Convert.ToDecimal(Item["Descuento"]);
                    oPres.Total = Convert.ToDecimal(Item["Total"]);
                    oPres.Observaciones = Convert.ToString(Item["Observaciones"]).Trim();
                    oPres.PorcDescuento = Convert.ToInt32(Item["PorcDescuento"]);
                    oPres.Iva = Convert.ToDecimal(Item["Iva"]);

                    ListaPresupuestos.Add(oPres);
                }

            }
            return ListaPresupuestos;
        }
        public void AltaPresupuesto(PresupuestoBE nPresupuesto)  

        {   
                Hashtable ParamCabecera = new Hashtable();                        // Cabecera
                ParamCabecera.Add("@IdCliente", nPresupuesto.Cliente.Id);
                ParamCabecera.Add("@IdVendedor", nPresupuesto.Vendedor.Id);
                ParamCabecera.Add("@FechaEmision", nPresupuesto.FechaEmision);
                ParamCabecera.Add("@FechaEntrega", nPresupuesto.FechaEntrega);
                ParamCabecera.Add("@FechaValidez", nPresupuesto.FechaValidez);
                ParamCabecera.Add("@Estado", nPresupuesto.estado.Id);
                ParamCabecera.Add("@Descuento", nPresupuesto.Descuento);
                ParamCabecera.Add("@Total", nPresupuesto.Total);
                ParamCabecera.Add("@Observaciones", nPresupuesto.Observaciones);
                ParamCabecera.Add("@PorcDescuento", nPresupuesto.PorcDescuento);
                ParamCabecera.Add("@Iva", nPresupuesto.Iva);

                Acceso AccesoDB = new Acceso();
                AccesoDB.Escribir("sp_InsertarPresupuestoCabecera", ParamCabecera);


                foreach (PresupuestoItemBE item in nPresupuesto.Items)               // Items
           
                { 
                     Hashtable ParamItems = new Hashtable();
                    ParamItems.Add("@IdProducto", item.Producto.Id);
                    ParamItems.Add("@Cantidad", item.Cantidad);
                    ParamItems.Add("@PrecioUnitario", item.PrecioUnitario);
                    ParamItems.Add("@TotalItem", item.TotalItem);
                    ParamItems.Add("@IvaItem", item.IvaItem);
                    ParamItems.Add("@PorcIva", item.PorcIVA);

                AccesoDB.Escribir("sp_InsertarPresupuestoItem", ParamItems);
            }           
        }

        public void EditarPresupuesto(PresupuestoBE nPresupuesto)
        {
            Hashtable ParamCabecera = new Hashtable();                         // Cabecera

            ParamCabecera.Add("@Id", nPresupuesto.Id);
            ParamCabecera.Add("@IdCliente", nPresupuesto.Cliente.Id);
            ParamCabecera.Add("@IdVendedor", nPresupuesto.Vendedor.Id);
            ParamCabecera.Add("@FechaEdicion", DateTime.Now);
            ParamCabecera.Add("@FechaEntrega", nPresupuesto.FechaEntrega);
            ParamCabecera.Add("@FechaValidez", nPresupuesto.FechaValidez);
            ParamCabecera.Add("@Estado", nPresupuesto.estado.Id);
            ParamCabecera.Add("@Descuento", nPresupuesto.Descuento);
            ParamCabecera.Add("@Total", nPresupuesto.Total);
            ParamCabecera.Add("@Observaciones", nPresupuesto.Observaciones);
            ParamCabecera.Add("@PorcDescuento", nPresupuesto.PorcDescuento);
            ParamCabecera.Add("@Iva", nPresupuesto.Iva);

            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EditarPresupuestoCabecera", ParamCabecera);


            foreach (PresupuestoItemBE item in nPresupuesto.Items)              // Items

            {
                Hashtable ParamItems = new Hashtable();
                ParamItems.Add("@Id", nPresupuesto.Id);
                ParamItems.Add("@IdProducto", item.Producto.Id);
                ParamItems.Add("@Cantidad", item.Cantidad);
                ParamItems.Add("@PrecioUnitario", item.PrecioUnitario);
                ParamItems.Add("@TotalItem", item.TotalItem);
                ParamItems.Add("@IvaItem", item.IvaItem);
                ParamItems.Add("@PorcIva", item.PorcIVA);

                AccesoDB.Escribir("sp_EditarPresupuestoItem", ParamItems);
            }

        }

        public PresupuestoBE SeleccionarPresupuestoPorId(int Id) 
        
        {
            PresupuestoBE oPres = new PresupuestoBE();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", Id);
            Acceso AccesoDB = new Acceso();
            DataSet Ds = new DataSet();
            Ds = AccesoDB.LeerDatos("sp_SeleccionarPresupuestoPorId", Parametros);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in Ds.Tables[0].Rows)
                {

                    oPres.Id = Convert.ToInt32(Item["Id"]);
                    oPres.Cliente = new ClienteBE(); 
                    oPres.Cliente.Id = Convert.ToInt32(Item["IdCliente"]);
                    oPres.Cliente.RazonSocial = Convert.ToString(Item["RazonSocial"]).Trim(); ;
                    oPres.Vendedor = new UsuarioBE(); oPres.Vendedor.Id = Convert.ToInt32(Item["IdVendedor"]);
                    oPres.FechaEmision = Convert.ToDateTime(Item["FechaEmision"]);
                    oPres.FechaEntrega = Convert.ToDateTime(Item["FechaEntrega"]);
                    oPres.FechaValidez = Convert.ToDateTime(Item["FechaValidez"]);
                    oPres.AprobacionTecnica = Convert.ToBoolean(Item["AprobacionTecnica"]);
                    oPres.AprobacionComercial = Convert.ToBoolean(Item["AprobacionComercial"]);                
                    oPres.estado.Id = Convert.ToInt32(Item["IdEstado"]);
                    oPres.estado.Descripcion= Convert.ToString(Item["Descripcion"]).Trim();
                    oPres.Descuento = Convert.ToDecimal(Item["Descuento"]);
                    oPres.Total = Convert.ToDecimal(Item["Total"]);
                    oPres.Observaciones = Convert.ToString(Item["Observaciones"]).Trim();
                    oPres.PorcDescuento = Convert.ToInt32(Item["PorcDescuento"]);
                    oPres.Iva = Convert.ToDecimal(Item["Iva"]);


                }

            }

            if (Ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow Item in Ds.Tables[1].Rows)
                {
                    PresupuestoItemBE oItemPres = new PresupuestoItemBE();
                    ProductoBE oProd = new ProductoBE();
                    oItemPres.Producto = oProd;
                    oItemPres.Producto.Id = Convert.ToInt32(Item["IdProducto"]);
                    oItemPres.Producto.Descripcion = Convert.ToString(Item["Descripcion"]).Trim();
                    oItemPres.Cantidad = Convert.ToInt32(Item["Cantidad"]);
                    oItemPres.PrecioUnitario = Convert.ToDecimal(Item["PrecioUnitario"]);
                    oItemPres.TotalItem = Convert.ToDecimal(Item["TotalItem"]);
                    oItemPres.PorcIVA = Convert.ToDecimal(Item["PorcIva"]);
                    oItemPres.IvaItem = Convert.ToDecimal(Item["IvaItem"]);

                    oPres.Items.Add(oItemPres);
                }

            }

            return oPres;
        }

        public void AnalisisTecnico (PresupuestoAprobacionBE Resultado)

        {
            Hashtable ParamCabecera = new Hashtable();
            ParamCabecera.Add("@IdPresupuesto", Resultado.Presupuesto.Id);
            ParamCabecera.Add("@IdAprobador", Resultado.Aprobador.Id);
            ParamCabecera.Add("@Fecha", Resultado.Fecha);
            ParamCabecera.Add("@TipoAprobacion", Resultado.TipoAprobacion);
            ParamCabecera.Add("@Accion", Resultado.Accion);
            ParamCabecera.Add("@Observaciones", Resultado.Observaciones);

            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_InsertarPresupuestoAprobacionTec", ParamCabecera);

        }

        public void AnalisisComercial(PresupuestoAprobacionBE Resultado)

        {
            Hashtable ParamCabecera = new Hashtable();
            ParamCabecera.Add("@IdPresupuesto", Resultado.Presupuesto.Id);
            ParamCabecera.Add("@IdAprobador", Resultado.Aprobador.Id);
            ParamCabecera.Add("@Fecha", Resultado.Fecha);
            ParamCabecera.Add("@TipoAprobacion", Resultado.TipoAprobacion);
            ParamCabecera.Add("@Accion", Resultado.Accion);
            ParamCabecera.Add("@Observaciones", Resultado.Observaciones);

            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_InsertarPresupuestoAprobacionCom", ParamCabecera);

        }

        public void Cierre(PresupuestoAprobacionBE Resultado)

        {
            Hashtable ParamCabecera = new Hashtable();
            ParamCabecera.Add("@IdPresupuesto", Resultado.Presupuesto.Id);
            ParamCabecera.Add("@IdAprobador", Resultado.Aprobador.Id);
            ParamCabecera.Add("@Fecha", Resultado.Fecha);
            ParamCabecera.Add("@TipoAprobacion", Resultado.TipoAprobacion);
            ParamCabecera.Add("@Accion", Resultado.Accion);
            ParamCabecera.Add("@Observaciones", Resultado.Observaciones);

            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_InsertarPresupuestoCierre", ParamCabecera);

        }

        public void Eliminar (PresupuestoBE ePresup)

        {
            Hashtable ParamCabecera = new Hashtable();
            ParamCabecera.Add("@IdPresupuesto", ePresup.Id);
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EliminarPresupuesto", ParamCabecera);
        }
    }
}
