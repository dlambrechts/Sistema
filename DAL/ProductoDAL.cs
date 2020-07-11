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
            DS = AccesoDB.LeerDatos("sp_ListarProductos", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    ProductoBE oProd = new ProductoBE();

                    oProd.Id = Convert.ToInt32(Item[0]);
                    oProd.Descripcion = Convert.ToString(Item[1]).Trim();
                    oProd.Tipo = Convert.ToString(Item[2]).Trim();
                    oProd.UnidadMedida = Convert.ToString(Item[3]);
                    oProd.Stock = Convert.ToInt32(Item[4]);
                    oProd.Precio = (float)Convert.ToDouble(Item[5]);
                    oProd.Activo = Convert.ToBoolean(Item[6]);

                    ListaProductos.Add(oProd);
                }

            }
            return ListaProductos;
        }
        public void AltaProducto (ProductoBE nProd)
        
        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Razon", nProd.Descripcion);
            Parametros.Add("@Direccion", nProd.Tipo);
            Parametros.Add("@CodigoPostal", nProd.UnidadMedida);
            Parametros.Add("@Tel", nProd.Stock);
            Parametros.Add("@Mail", nProd.Precio);

        
            Acceso AccesoDB = new Acceso();
        AccesoDB.Escribir("sp_InsertarProducto", Parametros);
        
        }

    }
}
