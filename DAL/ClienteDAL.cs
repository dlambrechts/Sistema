using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace DAL
{
    public class ClienteDAL
    {
        public BE.ClienteBE SeleccionarPorId(int Id)

        {
            Acceso AccesoDB = new Acceso();
            Hashtable Param = new Hashtable();
            DataSet Ds = new DataSet();
            ClienteBE oCliente = new ClienteBE();
            Param.Add("@Id", Id);

            Ds = AccesoDB.LeerDatos("sp_SeleccionarClientePorId", Param);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in Ds.Tables[0].Rows)
                {

                    oCliente.Id = Convert.ToInt32(Item["Id"]);
                    oCliente.RazonSocial = Item["RazonSocial"].ToString().Trim();
                    oCliente.Direccion = Item["Direccion"].ToString().Trim();
                    oCliente.CodigoPostal = Convert.ToInt32(Item["CodigoPostal"]);
                    oCliente.Telefono = Item["Telefono"].ToString().Trim();
                    oCliente.Mail = Item["Mail"].ToString().Trim();
                    oCliente.Cuit = Item["Cuit"].ToString().Trim();
                    oCliente.Contacto = Item["Contacto"].ToString().Trim();
                    oCliente.Activo = Convert.ToBoolean(Item["Activo"]);
                    oCliente.UsuarioCreacion.Id = Convert.ToInt32(Item["UsuarioCreacion"]);
                    oCliente.FechaCreacion = Convert.ToDateTime(Item["FechaCreacion"]);

                    if (Item["UsuarioModificacion"] != DBNull.Value) { 
                    oCliente.UsuarioModificacion.Id = Convert.ToInt32(Item["UsuarioModificacion"]);
                    oCliente.FechaModificacion = Convert.ToDateTime(Item["FechaModificacion"]);
                    }
                }

            }
            return oCliente;

        }
        public List<ClienteBE> ListarClientes()

        {
            List<ClienteBE> ListaClientes = new List<ClienteBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListarClientes", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    ClienteBE oCli = new ClienteBE();
                    oCli.Id = Convert.ToInt32(Item[0]);
                    oCli.RazonSocial = Convert.ToString(Item[1]).Trim();
                    oCli.Direccion = Convert.ToString(Item[2]).Trim();
                    oCli.CodigoPostal = Convert.ToInt32(Item[3]);
                    oCli.Telefono= Convert.ToString(Item["Telefono"]).Trim();
                    oCli.Mail = Convert.ToString(Item["Mail"]).Trim();
                    oCli.Cuit = Convert.ToString(Item["Cuit"]).Trim();
                    oCli.Contacto = Convert.ToString(Item["Contacto"]).Trim();                   
                    oCli.Activo = Convert.ToBoolean(Item["Activo"]);
                    oCli.UsuarioCreacion.Id = Convert.ToInt32(Item["UsuarioCreacion"]);
                    oCli.FechaCreacion = Convert.ToDateTime(Item["FechaCreacion"]);
                    if (Item["UsuarioModificacion"]!=DBNull.Value) { oCli.UsuarioModificacion.Id = Convert.ToInt32(Item["UsuarioModificacion"]); }
                    if (Item["FechaModificacion"] != DBNull.Value) { oCli.FechaModificacion = Convert.ToDateTime(Item["FechaModificacion"]); }

                    ListaClientes.Add(oCli);
                }
               
            }
            return ListaClientes;
        }
        public string AltaCliente(ClienteBE nCli)

        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Razon", nCli.RazonSocial);
            Parametros.Add("@Direccion", nCli.Direccion);
            Parametros.Add("@CodigoPostal", nCli.CodigoPostal);
            Parametros.Add("@Tel", nCli.Telefono);
            Parametros.Add("@Mail", nCli.Mail);
            Parametros.Add("@Cuit", nCli.Cuit);
            Parametros.Add("@Contacto", nCli.Contacto);
            Parametros.Add("@UsuarioIns", nCli._UsuarioCreacion.Id);
            Parametros.Add("@FechaIns", nCli.FechaCreacion);

            Acceso AccesoDB = new Acceso();
            return AccesoDB.Escribir("sp_InsertarCliente", Parametros);
        }

        public void EditarCliente(ClienteBE nCli)

        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Id", nCli.Id);
            Parametros.Add("@Razon", nCli.RazonSocial);
            Parametros.Add("@Direccion", nCli.Direccion);
            Parametros.Add("@CodigoPostal", nCli.CodigoPostal);
            Parametros.Add("@Tel", nCli.Telefono);
            Parametros.Add("@Mail", nCli.Mail);
            Parametros.Add("@Cuit", nCli.Cuit);
            Parametros.Add("@Contacto", nCli.Contacto);
            Parametros.Add("@Activo", nCli.Activo);
            Parametros.Add("@UsuarioMod", nCli._UsuarioModificacion.Id);
            Parametros.Add("@FechaMod", nCli.FechaModificacion);


            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EditarCliente", Parametros);
        }

        public void InsertarHistorico (ClienteVersionBE Version)
        
        {

            Acceso AccesoDB = new Acceso();
            Hashtable Parametros = new Hashtable();


            Parametros.Add("@Fecha", Version.Fecha);
            Parametros.Add("@UsVers", Version.UsuarioVersion.Id);
            Parametros.Add("@IdCli", Version.Cliente.Id);
            Parametros.Add("@Razon", Version.Cliente.RazonSocial);
            Parametros.Add("@Direccion", Version.Cliente.Direccion);
            Parametros.Add("@CodigoPostal", Version.Cliente.CodigoPostal);
            Parametros.Add("@Tel", Version.Cliente.Telefono);
            Parametros.Add("@Mail", Version.Cliente.Mail);
            Parametros.Add("@Cuit", Version.Cliente.Cuit);
            Parametros.Add("@Contacto", Version.Cliente.Contacto);
            Parametros.Add("@Activo", Version.Cliente.Activo);
            if (Version.Cliente.UsuarioModificacion.Id == 0) 
            { Parametros.Add("@UsuarioMod", DBNull.Value); }
            else { Parametros.Add("@UsuarioMod", Version.Cliente.UsuarioModificacion.Id); }
            
            if (Version.Cliente.FechaModificacion.Year!=1) 
            { Parametros.Add("@FechaMod", Version.Cliente.FechaModificacion); }
            else { Parametros.Add("@FechaMod", DBNull.Value); }

           string Id=AccesoDB.Escribir("sp_InsertarClienteVersion", Parametros);

            Hashtable ParametrosCampos = new Hashtable();

            ParametrosCampos.Add("@IdVers", Convert.ToInt32(Id));
            ParametrosCampos.Add("@FlagRazon", Version.Cambios.RazonSocial);
            ParametrosCampos.Add("@FlagDireccion", Version.Cambios.Direccion);
            ParametrosCampos.Add("@FlagCodigoPostal", Version.Cambios.CodigoPostal);
            ParametrosCampos.Add("@FlagTel", Version.Cambios.Telefono);
            ParametrosCampos.Add("@FlagMail", Version.Cambios.Mail);
            ParametrosCampos.Add("@FlagCuit", Version.Cambios.Cuit);
            ParametrosCampos.Add("@FlagContacto", Version.Cambios.Contacto);
            ParametrosCampos.Add("@FlagActivo", Version.Cambios.Activo);
            ParametrosCampos.Add("@IdCli", Version.Cliente.Id);

            AccesoDB.Escribir("sp_InsertarClienteVersionCampos", ParametrosCampos);


        }
        public void EliminarCliente(ClienteBE nCli)

        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", nCli.Id);
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EliminarCliente", Parametros);
        }


        public List<ClienteVersionBE> ListarVersionesClientePorId (ClienteBE Cli)

        {
            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Cliente", Cli.Id);
            DS = AccesoDB.LeerDatos("sp_SeleccionarVersionesPorCliente", Parametros);

            List<ClienteVersionBE> Lista = new List<ClienteVersionBE>();

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    UsuarioBE Us = new UsuarioBE();

                    ClienteVersionBE Version = new ClienteVersionBE(Cli,Us);

                    Version.IdVersion = Convert.ToInt32(Item[0]);
                    Version.Fecha = Convert.ToDateTime(Item[1]);
                    Version.UsuarioVersion.Nombre = Convert.ToString(Item[2]).Trim();
                    Version.UsuarioVersion.Apellido = Convert.ToString(Item[3]).Trim();

                    Lista.Add(Version);
                }

            }
            return Lista;
        }

        public BE.ClienteVersionBE ObtenerVersionPorIdVersion(ClienteVersionBE Vers)

        {
            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@IdVers", Vers.IdVersion);
            DS = AccesoDB.LeerDatos("sp_SeleccionarVersionClientePorVersion", Parametros);
            ClienteBE CliVer = new ClienteBE();

            if (DS.Tables[0].Rows.Count > 0)
            {
                DataTable Tabla = DS.Tables[0];

                    CliVer.RazonSocial = Convert.ToString(Tabla.Rows[0]["RazonSocial"]);
                    CliVer.Direccion = Convert.ToString(Tabla.Rows[0]["Direccion"]);
                    CliVer.CodigoPostal = Convert.ToInt32(Tabla.Rows[0]["CodigoPostal"]);
                    CliVer.Telefono = Convert.ToString(Tabla.Rows[0]["Telefono"]);
                    CliVer.Mail = Convert.ToString(Tabla.Rows[0]["Mail"]);
                    CliVer.Cuit = Convert.ToString(Tabla.Rows[0]["Cuit"]);
                    CliVer.Contacto = Convert.ToString(Tabla.Rows[0]["Contacto"]);
                    CliVer.Activo = Convert.ToBoolean(Tabla.Rows[0]["Activo"]);
                    if (Tabla.Rows[0]["FechaModificacion"] != DBNull.Value) { CliVer.FechaModificacion = Convert.ToDateTime(Tabla.Rows[0]["FechaModificacion"]); }
                    CliVer.Id = Convert.ToInt32(Tabla.Rows[0]["Cliente"]);

                    ClienteVersionBE Version = new ClienteVersionBE(CliVer, Vers.UsuarioVersion);
                    Version.IdVersion = Vers.IdVersion;
                    Version.Fecha = Convert.ToDateTime(Tabla.Rows[0]["Fecha"]);

                return Version;
            }
            else return null;


        }

        public BE.ClienteVersionCambiosBE ObtenerCamposAfectadorEnVersion(ClienteVersionBE Vers)

        {
            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@IdVers", Vers.IdVersion);
            DS = AccesoDB.LeerDatos("sp_SeleccionarVersionCamposPorId", Parametros);

            ClienteVersionCambiosBE Cambios = new ClienteVersionCambiosBE();

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                   
                   Cambios.RazonSocial = Convert.ToBoolean(Item["RazonSocial"]);
                   Cambios.Direccion = Convert.ToBoolean(Item["Direccion"]);
                   Cambios.CodigoPostal = Convert.ToBoolean(Item["CodigoPostal"]);
                   Cambios.Telefono = Convert.ToBoolean(Item["Telefono"]);
                   Cambios.Mail = Convert.ToBoolean(Item["Mail"]);
                   Cambios.Cuit = Convert.ToBoolean(Item["Cuit"]);
                   Cambios.Contacto = Convert.ToBoolean(Item["Contacto"]);
                   Cambios.Activo = Convert.ToBoolean(Item["Activo"]);
                }
            }
            return Cambios;
        }
    }
}
