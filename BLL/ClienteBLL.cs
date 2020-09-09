using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios;

namespace BLL
{
    public class ClienteBLL
    {
        public ClienteBE SeleccionarPorId(int Id) 
        
        {
            ClienteDAL dCliente = new ClienteDAL();
            return dCliente.SeleccionarPorId(Id);
        }
        public List<ClienteBE> ListarClientes ()

        {
            ClienteDAL CliDal = new ClienteDAL();
            return CliDal.ListarClientes();

        }
        public void InsertarCliente (ClienteBE nCliente)

        {
            ClienteDAL CliDal = new ClienteDAL();
            string Id=CliDal.AltaCliente(nCliente);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se agregó el Cliente " + Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void EditarCliente(ClienteBE nCliente)

        {
            ClienteDAL CliDal = new ClienteDAL();
            CliDal.EditarCliente(nCliente);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se modificó el Cliente " + nCliente.Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void EliminarCliente(ClienteBE eCli)
        {
            ClienteDAL CliDal = new ClienteDAL();
            CliDal.EliminarCliente(eCli);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se eliminó el Cliente " + eCli.Id;
            bllAct.NuevaActividad(nActividad);
        }

        public List<ClienteTipoBE> ListarTipoCliente()

        {
            ClienteDAL CliDal = new ClienteDAL();
            return CliDal.ListarTipoCliente();

        }
        public bool ExisteClienteEnPresupuesto(ClienteBE Cli)

        {
            PresupuestoBLL bllPres = new PresupuestoBLL();
            List<PresupuestoBE> ListaPresup = new List<PresupuestoBE>(bllPres.ListarPresupuestos());
            bool Existe = false;
            foreach (PresupuestoBE Presup in ListaPresup)

            {
                if (Presup.Cliente.Id == Cli.Id)
                { 
                Existe = true;
                break;
                }

            }

            return Existe;
        }
    }
}
