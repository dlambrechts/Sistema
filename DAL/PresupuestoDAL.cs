using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using BE.PresupuestoEstado;

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
                    UsuarioBE Aprobador = new UsuarioBE();
                    Aprobador.Nombre = Convert.ToString(Item["Nombre"]).Trim();
                    Aprobador.Apellido = Convert.ToString(Item["Apellido"]).Trim();
                    PresupuestoTipoAprobacionBE Tipo = new PresupuestoTipoAprobacionBE();
                    Tipo.Tipo = Convert.ToString(Item["Tipo"]).Trim();

                    PresupuestoAprobacionBE oAprob = new PresupuestoAprobacionBE(Presupuesto,Tipo,Aprobador);
                    oAprob.Fecha = Convert.ToDateTime(Item["Fecha"]); oAprob.Fecha.ToShortDateString();                   
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
                    ClienteBE Cliente = new ClienteBE();


                   
                    Cliente.RazonSocial = Convert.ToString(Item["RazonSocial"]).Trim();
                    Cliente.Direccion = Convert.ToString(Item["Direccion"]).Trim();

                    PresupuestoBE oPres = new PresupuestoBE(Cliente);
                    oPres.Id = Convert.ToInt32(Item["Id"]);
                    oPres.Vendedor = new UsuarioBE();
                    oPres.Vendedor.Id = Convert.ToInt32(Item["IdVendedor"]);
                    oPres.Vendedor.Nombre = Convert.ToString(Item["Nombre"]).Trim();
                    oPres.Vendedor.Apellido = Convert.ToString(Item["Apellido"]).Trim();
                    oPres.FechaEmision = Convert.ToDateTime(Item["FechaEmision"]);
                    oPres.FechaEntrega = Convert.ToDateTime(Item["FechaEntrega"]);
                    oPres.FechaValidez = Convert.ToDateTime(Item["FechaValidez"]);
                    oPres.Descuento = Convert.ToDecimal(Item["Descuento"]);
                    oPres.Total = Convert.ToDecimal(Item["Total"]);
                    oPres.Observaciones = Convert.ToString(Item["Observaciones"]).Trim();
                    oPres.PorcDescuento = Convert.ToInt32(Item["PorcDescuento"]);
                    oPres.Iva = Convert.ToDecimal(Item["Iva"]);

                    PresupuestoEstadoBE Est ;
                    switch (Convert.ToString(Item["Estado"]).Trim())

                    {
                        case "ApTecPend": { Est = new ApTecPend(); oPres.ActualizarEstado(Est); } break;
                        case "ApTecRech": { Est = new ApTecRech(); oPres.ActualizarEstado(Est); } break;
                        case "ApComPend": { Est = new ApComPend(); oPres.ActualizarEstado(Est); } break;
                        case "ApComRech": { Est = new ApComRech(); oPres.ActualizarEstado(Est); } break;
                        case "EnviarCli": { Est = new EnviarCli(); oPres.ActualizarEstado(Est); } break;
                        case "ApCli": { Est = new ApCli(); oPres.ActualizarEstado(Est); } break;
                        case "RechCli": { Est = new RechCli(); oPres.ActualizarEstado(Est); } break;
                        case "Finalizado": { Est = new Finalizado(); oPres.ActualizarEstado(Est); } break;
                            
                    }
                    
                    oPres.Estado.Descripción = Convert.ToString(Item["Descripcion"]).Trim();


                    ListaPresupuestos.Add(oPres);
                }

            }
            return ListaPresupuestos;
        }
        public string AltaPresupuesto(PresupuestoBE nPresupuesto)

        {
            Hashtable ParamCabecera = new Hashtable();                        // Cabecera
            ParamCabecera.Add("@IdCliente", nPresupuesto.Cliente.Id);
            ParamCabecera.Add("@IdVendedor", nPresupuesto.Vendedor.Id);
            ParamCabecera.Add("@FechaEmision", nPresupuesto.FechaEmision);
            ParamCabecera.Add("@FechaEntrega", nPresupuesto.FechaEntrega);
            ParamCabecera.Add("@FechaValidez", nPresupuesto.FechaValidez);
            ParamCabecera.Add("@Estado", nPresupuesto.Estado.GetType().Name);
            ParamCabecera.Add("@Descuento", nPresupuesto.Descuento);
            ParamCabecera.Add("@Total", nPresupuesto.Total);
            ParamCabecera.Add("@Observaciones", nPresupuesto.Observaciones);
            ParamCabecera.Add("@PorcDescuento", nPresupuesto.PorcDescuento);
            ParamCabecera.Add("@Iva", nPresupuesto.Iva);

            Acceso AccesoDB = new Acceso();
            string Id= AccesoDB.Escribir("sp_InsertarPresupuestoCabecera", ParamCabecera);

            foreach (PresupuestoItemBE item in nPresupuesto.Items)               // Items

            {
                Hashtable ParamItems = new Hashtable();
                ParamItems.Add("@IdPresup", Convert.ToInt32(Id));
                ParamItems.Add("@IdProducto", item.Producto.Id);
                ParamItems.Add("@Cantidad", item.Cantidad);
                ParamItems.Add("@PrecioUnitario", item.PrecioUnitario);
                ParamItems.Add("@TotalItem", item.TotalItem);
                ParamItems.Add("@IvaItem", item.IvaItem);
                ParamItems.Add("@PorcIva", item.PorcIVA);

                AccesoDB.Escribir("sp_InsertarPresupuestoItem", ParamItems);
            }

            return Id;
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
            ParamCabecera.Add("@Estado", nPresupuesto.Estado.GetType().Name);
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

        public BE.PresupuestoBE SeleccionarPresupuestoPorId(int Id)

        {
            ClienteBE Cli = new ClienteBE();
            PresupuestoBE oPres = new PresupuestoBE(Cli);
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
                    oPres.Cliente.Id = Convert.ToInt32(Item["IdCliente"]);
                    oPres.Cliente.RazonSocial = Convert.ToString(Item["RazonSocial"]).Trim(); ;
                    oPres.Vendedor = new UsuarioBE(); oPres.Vendedor.Id = Convert.ToInt32(Item["IdVendedor"]);
                    oPres.FechaEmision = Convert.ToDateTime(Item["FechaEmision"]);
                    oPres.FechaEntrega = Convert.ToDateTime(Item["FechaEntrega"]);
                    oPres.FechaValidez = Convert.ToDateTime(Item["FechaValidez"]);
                    oPres.Descuento = Convert.ToDecimal(Item["Descuento"]);
                    oPres.Total = Convert.ToDecimal(Item["Total"]);
                    oPres.Observaciones = Convert.ToString(Item["Observaciones"]).Trim();
                    oPres.PorcDescuento = Convert.ToInt32(Item["PorcDescuento"]);
                    oPres.Iva = Convert.ToDecimal(Item["Iva"]);


                    PresupuestoEstadoBE Est;
                    switch (Convert.ToString(Item["Estado"]).Trim())

                    {
                        case "ApTecPend": { Est = new ApTecPend(); oPres.ActualizarEstado(Est); } break;
                        case "ApTecRech": { Est = new ApTecRech(); oPres.ActualizarEstado(Est); } break;
                        case "ApComPend": { Est = new ApComPend(); oPres.ActualizarEstado(Est); } break;
                        case "ApComRech": { Est = new ApComRech(); oPres.ActualizarEstado(Est); } break;
                        case "EnviarCli": { Est = new EnviarCli(); oPres.ActualizarEstado(Est); } break;
                        case "ApCli": { Est = new ApCli(); oPres.ActualizarEstado(Est); } break;
                        case "RechCli": { Est = new RechCli(); oPres.ActualizarEstado(Est); } break;
                        case "Finalizado": { Est = new Finalizado(); oPres.ActualizarEstado(Est); } break;

                    }

                    oPres.Estado.Descripción = Convert.ToString(Item["Descripcion"]).Trim();


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

        public string AnalisisTecnico(PresupuestoAprobacionBE Resultado)

        {
            Hashtable ParamCabecera = new Hashtable();
            ParamCabecera.Add("@IdPresupuesto", Resultado.Presupuesto.Id);
            ParamCabecera.Add("@IdAprobador", Resultado.Aprobador.Id);
            ParamCabecera.Add("@Fecha", Resultado.Fecha);
            ParamCabecera.Add("@TipoAprobacion", Resultado.Tipo.Id);
            ParamCabecera.Add("@Accion", Resultado.Accion);
            ParamCabecera.Add("@Observaciones", Resultado.Observaciones);

            Acceso AccesoDB = new Acceso();
            return AccesoDB.Escribir("sp_InsertarPresupuestoAprobacionTec", ParamCabecera);

        }

        public string AnalisisComercial(PresupuestoAprobacionBE Resultado)

        {
            Hashtable ParamCabecera = new Hashtable();
            ParamCabecera.Add("@IdPresupuesto", Resultado.Presupuesto.Id);
            ParamCabecera.Add("@IdAprobador", Resultado.Aprobador.Id);
            ParamCabecera.Add("@Fecha", Resultado.Fecha);
            ParamCabecera.Add("@TipoAprobacion", Resultado.Tipo.Id);
            ParamCabecera.Add("@Accion", Resultado.Accion);
            ParamCabecera.Add("@Observaciones", Resultado.Observaciones);

            Acceso AccesoDB = new Acceso();
            return AccesoDB.Escribir("sp_InsertarPresupuestoAprobacionCom", ParamCabecera);

        }

        public string Cierre(PresupuestoAprobacionBE Resultado)

        {
            Hashtable ParamCabecera = new Hashtable();
            ParamCabecera.Add("@IdPresupuesto", Resultado.Presupuesto.Id);
            ParamCabecera.Add("@IdAprobador", Resultado.Aprobador.Id);
            ParamCabecera.Add("@Fecha", Resultado.Fecha);
            ParamCabecera.Add("@TipoAprobacion", Resultado.Tipo.Id);
            ParamCabecera.Add("@Accion", Resultado.Accion);
            ParamCabecera.Add("@Observaciones", Resultado.Observaciones);

            Acceso AccesoDB = new Acceso();
           return  AccesoDB.Escribir("sp_InsertarPresupuestoCierre", ParamCabecera);

        }

        public void Eliminar(PresupuestoBE ePresup)

        {
            Hashtable ParamCabecera = new Hashtable();
            ParamCabecera.Add("@IdPresupuesto", ePresup.Id);
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EliminarPresupuesto", ParamCabecera);
        }

        public BE.PresupuestoTipoAprobacionBE SeleccionarAprobacionTipo(string tipo)

        {
            PresupuestoTipoAprobacionBE Tipo = new PresupuestoTipoAprobacionBE();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Tipo", tipo);
            Acceso AccesoDB = new Acceso();
            DataSet Ds = new DataSet();
            Ds = AccesoDB.LeerDatos("sp_ListarPresupuestoAprobacionTipo", Parametros);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in Ds.Tables[0].Rows)
                {

                    Tipo.Id = Convert.ToInt32(Item["Id"]);
                    Tipo.Tipo = Convert.ToString(Item["Tipo"]);


                }
            }

            return Tipo;

        }

        public void ActualizarEstado(PresupuestoBE Pres, PresupuestoEstadoBE nEstado)

                {
                    Hashtable ParamCabecera = new Hashtable();
                    ParamCabecera.Add("@IdPresupuesto", Pres.Id);
                    ParamCabecera.Add("@Estado",nEstado.GetType().Name);
                    Acceso AccesoDB = new Acceso();
                    AccesoDB.Escribir("sp_ActualizarEstadoPresupuesto", ParamCabecera);
        }
}
}
