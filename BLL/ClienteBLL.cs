using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CliDal.AltaCliente(nCliente);
        }

        public void EditarCliente(ClienteBE nCliente)

        {
            ClienteDAL CliDal = new ClienteDAL();
            CliDal.EditarCliente(nCliente);
        }

        public void EliminarCliente(ClienteBE eCli)
        {
            ClienteDAL CliDal = new ClienteDAL();
            CliDal.EliminarCliente(eCli);
        }

        public bool ExisteClienteEnPresupuesto(ClienteBE Cli)

        {
            PresupuestoBLL bllPres = new PresupuestoBLL();
            List<PresupuestoBE> ListaPresup = new List<PresupuestoBE>(bllPres.ListarPresupuestos());
            bool Existe = false;
            foreach (PresupuestoBE Presup in ListaPresup)

            {
                if (Presup.Cliente.Id == Cli.Id)
                Existe = true;
                break;
             
            }

            return Existe;
        }
    }
}
