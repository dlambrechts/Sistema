using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios;
using Servicios.Bitacora;

namespace BLL
{
    public class ClienteBLL
    {
        private DAL.ClienteDAL dCliente = new ClienteDAL();
        private Servicios.Bitacora.BitacoraBLL bllBit = new BitacoraBLL();
        private Servicios.Bitacora.BitacoraTipoActividad tipo = new BitacoraTipoActividad();

        public BE.ClienteBE SeleccionarPorId(int Id) 
        
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
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se agregó el Cliente " + Id;
            bllBit.NuevaActividad(nActividad);
        }

        public void EditarCliente(ClienteBE nCliente)

        {
            nCliente.UsuarioModificacion.Id = SesionSingleton.Instancia.Usuario.Id;
            nCliente.FechaModificacion = DateTime.Now;
            dCliente.EditarCliente(nCliente);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se modificó el Cliente " + nCliente.Id;
            bllBit.NuevaActividad(nActividad);
        }

        public void NuevaVersion(ClienteBE Anterior, ClienteBE Nuevo)

        {
            ClienteVersionCambiosBE Cambios = new ClienteVersionCambiosBE();
            Cambios = ControlCambios(Anterior, Nuevo);

            ClienteVersionBE Historico = new ClienteVersionBE(Anterior,SesionSingleton.Instancia.Usuario);

            Historico.UsuarioVersion.Id = SesionSingleton.Instancia.Usuario.Id;
            Historico.Fecha = DateTime.Now;
            Historico.SetCambios(Cambios);
          
            EditarCliente(Nuevo);
            dCliente.InsertarHistorico(Historico);

        }

        public BE.ClienteVersionCambiosBE ControlCambios(ClienteBE Anterior, ClienteBE Nuevo) // Aqui se compara el objeto anterior con el nuevo para identificar los cambios y registrar el versionado
        
        {
            ClienteVersionCambiosBE Cambios = new ClienteVersionCambiosBE();

            Cambios.RazonSocial = !(string.Equals(Anterior.RazonSocial.Trim(), Nuevo.RazonSocial.Trim()));
            Cambios.Direccion = !(string.Equals(Anterior.Direccion.Trim(), Nuevo.Direccion.Trim()));
            Cambios.CodigoPostal = !(int.Equals(Anterior.CodigoPostal, Nuevo.CodigoPostal));
            Cambios.Telefono = !(string.Equals(Anterior.Telefono.Trim(), Nuevo.Telefono.Trim()));
            Cambios.Mail = !(string.Equals(Anterior.Mail.Trim(), Nuevo.Mail.Trim()));
            Cambios.Cuit = !(string.Equals(Anterior.Cuit.Trim(), Nuevo.Cuit.Trim()));
            Cambios.Contacto = !(string.Equals(Anterior.Contacto.Trim(), Nuevo.Contacto.Trim()));
            Cambios.Activo = !(string.Equals(Anterior.Activo, Nuevo.Activo));

            return Cambios;
        }

        public void EliminarCliente(ClienteBE eCli)
        {
            ClienteDAL CliDal = new ClienteDAL();
            CliDal.EliminarCliente(eCli);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se eliminó el Cliente " + eCli.Id;
            bllBit.NuevaActividad(nActividad);
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

        public BE.ClienteVersionBE ObtenerVersionPorIdVersion(ClienteVersionBE Vers)

        {
            return dCliente.ObtenerVersionPorIdVersion(Vers);

        }

        public BE.ClienteVersionCambiosBE ObtenerCamposAfectadorEnVersion(ClienteVersionBE Vers)
        
        {
            return dCliente.ObtenerCamposAfectadorEnVersion(Vers);
        }
    }
}
