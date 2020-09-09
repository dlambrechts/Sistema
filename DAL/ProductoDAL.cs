using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BE;
using System.Data;

namespace DAL
{
    public class ProductoDAL
    {

        public List<ProductoTipoBE> ListarTipoProducto()

        {
            List<ProductoTipoBE> TiposProductos = new List<ProductoTipoBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListaProductoTipo", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    ProductoTipoBE oTipo = new ProductoTipoBE();

                    oTipo.Id = Convert.ToString(Item[0]).Trim();
                    oTipo.Tipo = Convert.ToString(Item[1]).Trim();
       

                    TiposProductos.Add(oTipo);
                }

            }
            return TiposProductos;
        }

        public List<ProductoUnidadMedidaBE> ListarUnidadesMedida()

        {
            List<ProductoUnidadMedidaBE> Unidades = new List<ProductoUnidadMedidaBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListaProductoUm", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    ProductoUnidadMedidaBE oUm = new ProductoUnidadMedidaBE();

                    oUm.Id = Convert.ToString(Item[0]).Trim();
                    oUm.Descripcion = Convert.ToString(Item[1]).Trim();


                    Unidades.Add(oUm);
                }

            }
            return Unidades;
        }
        public List<ProductoBE> ListarProductos()

        {
            List<ProductoBE> ListaProductos = new List<ProductoBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListaProductos", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    ProductoBE oProd = new ProductoBE();

                    oProd.Id = Convert.ToInt32(Item[0]);
                    oProd.Descripcion = Convert.ToString(Item[1]).Trim();
                    oProd.tipo.Id = Convert.ToString(Item[2]).Trim();
                    oProd.tipo.Tipo = Convert.ToString(Item[3]).Trim();
                    oProd.UnidadMedida.Id = Convert.ToString(Item[4]).Trim();
                    oProd.UnidadMedida.Descripcion = Convert.ToString(Item[5]).Trim();
                    oProd.Stock = Convert.ToInt32(Item[6]);
                    oProd.Precio = Convert.ToDecimal(Item[7]);
                    oProd.Iva = Convert.ToDecimal(Item[8]);
                    oProd.Activo = Convert.ToBoolean(Item[9]);
                    

                    ListaProductos.Add(oProd);
                }

            }
            return ListaProductos;
        }
        public string AltaProducto (ProductoBE nProd)
        
        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Descripcion", nProd.Descripcion);
            Parametros.Add("@Tipo", nProd.Tipo.Id);
            Parametros.Add("@UnidadMedida", nProd.UnidadMedida.Id);
            Parametros.Add("@Stock", nProd.Stock);
            Parametros.Add("@Precio", nProd.Precio);
            Parametros.Add("@Iva", nProd.Iva);
      
            Acceso AccesoDB = new Acceso();
            return AccesoDB.Escribir("sp_InsertarProducto", Parametros);       
        }

        public void EditarProducto(ProductoBE eProd)

        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Id", eProd.Id);
            Parametros.Add("@Descripcion", eProd.Descripcion);
            Parametros.Add("@Tipo", eProd.Tipo.Id); 
            Parametros.Add("@UnidadMedida", eProd.UnidadMedida.Id);
            Parametros.Add("@Precio", eProd.Precio);
            Parametros.Add("@Activo", eProd.Activo);
            Parametros.Add("@Iva", eProd.Iva);

            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EditarProducto", Parametros);

        }

        public void EliminarProducto(ProductoBE eProd)

        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", eProd.Id);

            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EliminarProducto", Parametros);
        }

    }
}
