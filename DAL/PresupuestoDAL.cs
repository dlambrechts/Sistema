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
                    oPres.AprobacionTecnica = Convert.ToBoolean(Item[5]);
                    oPres.AprobacionComercial = Convert.ToBoolean(Item[6]);
                    oPres.Estado = Convert.ToString(Item[7]).Trim();
                    oPres.Descuento = (float)Convert.ToDouble(Item[8]);
                    oPres.Total = (float)Convert.ToDouble(Item[9]);

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
                ParamCabecera.Add("@Estado", nPresupuesto.Estado);
                ParamCabecera.Add("@Descuento", nPresupuesto.Descuento);
                ParamCabecera.Add("@Total", nPresupuesto.Total);

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
    }
}
