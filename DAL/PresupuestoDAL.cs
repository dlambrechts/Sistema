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

                    oPres.Id = Convert.ToInt32(Item[0]);
                    oPres.Cliente = new ClienteBE(); oPres.Cliente.Id = Convert.ToInt32(Item[1]);
                    oPres.Vendedor = new UsuarioBE();  oPres.Vendedor.Id = Convert.ToInt32(Item[2]);
                    oPres.FechaEmision = Convert.ToDateTime(Item[3]);
                    oPres.FechaEntrega = Convert.ToDateTime(Item[4]);
                    oPres.FechaValidez = Convert.ToDateTime(Item[5]);
                    oPres.AprobacionTecnica = Convert.ToBoolean(Item[6]);
                    oPres.AprobacionComercial = Convert.ToBoolean(Item[7]);
                    oPres.Estado = Convert.ToString(Item[8]).Trim();
                    oPres.Descuento = (float)Convert.ToDouble(Item[9]);
                    oPres.Total = (float)Convert.ToDouble(Item[10]);
                    oPres.Observaciones = Convert.ToString(Item[11]).Trim();

                    ListaPresupuestos.Add(oPres);
                }

            }
            return ListaPresupuestos;
        }
        public void AltaPresupuesto(PresupuestoBE nPresupuesto)

        {
           
                Hashtable ParamCabecera = new Hashtable();
                ParamCabecera.Add("@IdCliente", nPresupuesto.Cliente.Id);
                ParamCabecera.Add("@IdVendedor", nPresupuesto.Vendedor.Id);
                ParamCabecera.Add("@FechaEmision", nPresupuesto.FechaEmision);
                ParamCabecera.Add("@FechaEntrega", nPresupuesto.FechaEntrega);
                ParamCabecera.Add("@FechaValidez", nPresupuesto.FechaValidez);
                ParamCabecera.Add("@Estado", nPresupuesto.Estado);
                ParamCabecera.Add("@Descuento", nPresupuesto.Descuento);
                ParamCabecera.Add("@Total", nPresupuesto.Total);
                ParamCabecera.Add("@Observaciones", nPresupuesto.Observaciones);

                Acceso AccesoDB = new Acceso();
                AccesoDB.Escribir("sp_InsertarPresupuestoCabecera", ParamCabecera);


                foreach (PresupuestoItemBE item in nPresupuesto.Items)
           
                { 
                     Hashtable ParamItems = new Hashtable();
                    ParamItems.Add("@IdProducto", item.Producto.Id);
                    ParamItems.Add("@Cantidad", item.Cantidad);
                    ParamItems.Add("@PrecioUnitario", item.PrecioUnitario);
                    ParamItems.Add("@TotalItem", item.TotalItem);

                AccesoDB.Escribir("sp_InsertarPresupuestoItem", ParamItems);
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

                    oPres.Id = Convert.ToInt32(Item[0]);
                    oPres.Cliente = new ClienteBE(); oPres.Cliente.Id = Convert.ToInt32(Item[1]);
                    oPres.Vendedor = new UsuarioBE(); oPres.Vendedor.Id = Convert.ToInt32(Item[2]);
                    oPres.FechaEmision = Convert.ToDateTime(Item[3]);
                    oPres.FechaEntrega = Convert.ToDateTime(Item[4]);
                    oPres.FechaValidez = Convert.ToDateTime(Item[5]);
                    oPres.AprobacionTecnica = Convert.ToBoolean(Item[6]);
                    oPres.AprobacionComercial = Convert.ToBoolean(Item[7]);
                    oPres.Estado = Convert.ToString(Item[8]).Trim();
                    oPres.Descuento = (float)Convert.ToDouble(Item[9]);
                    oPres.Total = (float)Convert.ToDouble(Item[10]);
                    oPres.Observaciones = Convert.ToString(Item[11]).Trim();


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
                    oItemPres.PrecioUnitario = (float)Convert.ToDouble(Item["PrecioUnitario"]);
                    oItemPres.TotalItem = (float)Convert.ToDouble(Item["TotalItem"]);

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
            AccesoDB.Escribir("sp_InsertarPresupuestoAprobacion", ParamCabecera);

        }
    }
}
