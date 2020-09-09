using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    public class ProductoBLL

    {
        public List<ProductoUnidadMedidaBE> ListarUnidadesMedida()
        {
            ProductoDAL dProd = new ProductoDAL();
            return dProd.ListarUnidadesMedida();
        }

        public List<ProductoTipoBE> ListarTipoProducto() 
        
        {
            ProductoDAL dProd = new ProductoDAL();
            return dProd.ListarTipoProducto();
        }
       public List<ProductoBE> ListarProductos() 
        
        {
            ProductoDAL dProd = new ProductoDAL();
            return dProd.ListarProductos();
        }

        public void AltaProducto (ProductoBE nProd)
        
        {
            ProductoDAL dProd = new ProductoDAL();
            string Id=dProd.AltaProducto(nProd);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se agregó el Producto "+Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void EditarProducto(ProductoBE eProd)

        {
            ProductoDAL dProd = new ProductoDAL();
            dProd.EditarProducto(eProd);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se modificó el Producto " + eProd.Id;

            bllAct.NuevaActividad(nActividad);
        }

        public void EliminarProducto(ProductoBE eProd)
        {
            ProductoDAL dProd = new ProductoDAL();
            dProd.EliminarProducto(eProd);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se eliminó el Producto " + eProd.Id;

            bllAct.NuevaActividad(nActividad);
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
