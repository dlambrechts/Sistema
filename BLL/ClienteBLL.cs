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
        ClienteDAL dCliente = new ClienteDAL();
        public ClienteBE SeleccionarPorId(int Id) 
        
        {          
            return dCliente.SeleccionarPorId(Id);
        }
        public List<ClienteBE> ListarClientes ()

        {
            List<ClienteBE> Lista = new List<ClienteBE>();
            Lista = dCliente.ListarClientes();
            UsuarioBLL bllU = new UsuarioBLL();

            foreach(ClienteBE item in Lista)

            {
                item.UsuarioCreacion = bllU.SeleccionarUsuarioPorId(item.UsuarioCreacion.Id);
                if (item.UsuarioModificacion != null) { item.UsuarioModificacion = bllU.SeleccionarUsuarioPorId(item.UsuarioModificacion.Id); }

            }    

            return Lista;

            

        }
        public void InsertarCliente (ClienteBE nCliente)

        {
            nCliente.FechaCreacion = DateTime.Now;
            nCliente.UsuarioCreacion = SesionSingleton.Instancia.Usuario;         
            string Id=dCliente.AltaCliente(nCliente);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se agregó el Cliente " + Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void EditarCliente(ClienteBE nCliente)

        {
            nCliente.UsuarioModificacion.Id = SesionSingleton.Instancia.Usuario.Id;
            nCliente.FechaModificacion = DateTime.Now;
            dCliente.EditarCliente(nCliente);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se modificó el Cliente " + nCliente.Id;
            bllAct.NuevaActividad(nActividad);
        }

        public void NuevaVersion(ClienteBE Anterior, ClienteBE Nuevo)

        {
            ClienteVersionCambiosBE Cambios = new ClienteVersionCambiosBE();
            Cambios = ControlCambios(Anterior, Nuevo);

            ClienteVersionBE Historico = new ClienteVersionBE();

            Historico.UsuarioVersion.Id = SesionSingleton.Instancia.Usuario.Id;
            Historico.Fecha = DateTime.Now;        
            Historico.Cambios = Cambios;
            Historico.Cliente = Anterior;

           

            EditarCliente(Nuevo);
            dCliente.InsertarHistorico(Historico);

        }

        public ClienteVersionCambiosBE ControlCambios(ClienteBE Anterior, ClienteBE Nuevo) // Aqui se compara el objeto anterior con el nuevo para identificar los cambios y registrar el versionado
        
        {
            ClienteVersionCambiosBE Cambios = new ClienteVersionCambiosBE();

            Cambios.RazonSocial = !(string.Equals(Anterior.RazonSocial, Nuevo.RazonSocial));
            Cambios.Direccion = !(string.Equals(Anterior.Direccion, Nuevo.Direccion));
            Cambios.CodigoPostal = !(int.Equals(Anterior.CodigoPostal, Nuevo.CodigoPostal));
            Cambios.Telefono = !(string.Equals(Anterior.Telefono, Nuevo.Telefono));
            Cambios.Mail = !(string.Equals(Anterior.Mail, Nuevo.Mail));
            Cambios.Tipo = !(string.Equals(Anterior.Tipo.Id, Nuevo.Tipo.Id));
            Cambios.Cuit = !(string.Equals(Anterior.Cuit, Nuevo.Cuit));
            Cambios.Contacto = !(string.Equals(Anterior.Contacto, Nuevo.Contacto));
            Cambios.Activo = !(string.Equals(Anterior.Activo, Nuevo.Activo));

            return Cambios;
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

        public List<ClienteVersionBE> ListarVersionesClientePorId(ClienteBE Cli)

        {
            return dCliente.ListarVersionesClientePorId(Cli);

        }

        public ClienteVersionBE ObtenerVersionPorIdVersion(ClienteVersionBE Vers)

        {
            return dCliente.ObtenerVersionPorIdVersion(Vers);

        }

        public ClienteVersionCambiosBE ObtenerCamposAfectadorEnVersion(ClienteVersionBE Vers)
        
        {
            return dCliente.ObtenerCamposAfectadorEnVersion(Vers);
        }
    }
}
