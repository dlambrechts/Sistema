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

                    oProd.Id = Convert.ToInt32(Item["Id"]);
                    oProd.Descripcion = Convert.ToString(Item["Descripcion"]).Trim();
                    oProd.Stock = Convert.ToInt32(Item["Stock"]);
                    oProd.Precio = Convert.ToDecimal(Item["Precio"]);
                    oProd.Iva = Convert.ToDecimal(Item["Iva"]);
                    oProd.Activo = Convert.ToBoolean(Item["Activo"]);
                    

                    ListaProductos.Add(oProd);
                }

            }
            return ListaProductos;
        }
        public string AltaProducto (ProductoBE nProd)
        
        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Descripcion", nProd.Descripcion);
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
