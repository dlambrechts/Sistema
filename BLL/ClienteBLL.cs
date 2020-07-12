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
    }
}
