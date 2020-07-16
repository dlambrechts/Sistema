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

        public void EliminarProducto(ProductoBE eProd)
        {
            ProductoDAL dProd = new ProductoDAL();
            dProd.EliminarProducto(eProd);
        }

        public bool ExisteProductoEnPresupuesto(ProductoBE Prod)

        {
            PresupuestoBLL bllPres = new PresupuestoBLL();
            List<PresupuestoBE> ListaPresup = new List<PresupuestoBE>(bllPres.ListarPresupuestos());
            bool Existe = false;
            foreach (PresupuestoBE Presup in ListaPresup)

            {
                PresupuestoBE checkPres = new PresupuestoBE();
                checkPres = bllPres.SeleccionarPresupuestoPorId(Presup.Id);
                if (checkPres.Items.Exists(x => x.Producto.Id == Prod.Id))

                {
                    Existe = true;
                    break;
                }

            }

            return Existe;
        }
    }
}
