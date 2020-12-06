using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Servicios;
using Servicios.Bitacora;

namespace BLL
{
    public class ProductoBLL

    {
        private DAL.ProductoDAL dProd = new ProductoDAL();
        private Servicios.Bitacora.BitacoraBLL bllBit = new BitacoraBLL();
        private Servicios.Bitacora.BitacoraTipoActividad tipo = new BitacoraTipoActividad();

       public List<ProductoBE> ListarProductos() 
        
        {            
            return dProd.ListarProductos();
        }

        public List<ProductoBE> ListarProductosActivos()

        {
            List<ProductoBE> Activos = new List<ProductoBE>(dProd.ListarProductos());
            Activos = Activos.Where(x => x.Activo == true).ToList();
            return Activos;
        }

        public void AltaProducto (ProductoBE nProd)
        
        {
            string Id=dProd.AltaProducto(nProd);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se agregó el Producto "+Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void EditarProducto(ProductoBE eProd)

        {           
            dProd.EditarProducto(eProd);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se modificó el Producto " + eProd.Id;

            bllAct.NuevaActividad(nActividad);
        }

        public void EliminarProducto(ProductoBE eProd)
        {
           
            dProd.EliminarProducto(eProd);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
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
                PresupuestoBE checkPres;
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
