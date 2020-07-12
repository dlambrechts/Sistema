using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class ProductoBLL
    {
       public List<ProductoBE> ListarProductos() 
        
        {
            ProductoDAL dProd = new ProductoDAL();
            return dProd.ListarProductos();
        }

        public void AltaProducto (ProductoBE nProd)
        
        {
            ProductoDAL dProd = new ProductoDAL();
            dProd.AltaProducto(nProd);
        }

        public void EditarProducto(ProductoBE eProd)

        {
            ProductoDAL dProd = new ProductoDAL();
            dProd.EditarProducto(eProd);
        }

    }
}
