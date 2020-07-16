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
        public ClienteBE SeleccionarPorId(int Id)

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
                    oCliente.Tipo = Item["Tipo"].ToString().Trim();
                    oCliente.Cuit = Item["Cuit"].ToString().Trim();
                    oCliente.Contacto = Item["Contacto"].ToString().Trim();
                    oCliente.CondicionPago= Item["CondicionPago"].ToString().Trim();
                    oCliente.Activo = Convert.ToBoolean(Item["Activo"]);

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
                    oCli.Telefono= Convert.ToString(Item[4]).Trim();
                    oCli.Mail = Convert.ToString(Item[5]).Trim();
                    oCli.Tipo = Convert.ToString(Item[6]).Trim();
                    oCli.Cuit = Convert.ToString(Item[7]).Trim();
                    oCli.Contacto = Convert.ToString(Item[8]).Trim();
                    oCli.CondicionPago = Convert.ToString(Item[9]).Trim();
                    oCli.Activo = Convert.ToBoolean(Item[10]);

                    ListaClientes.Add(oCli);
                }
               
            }
            return ListaClientes;
        }
        public void AltaCliente(ClienteBE nCli)

        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Razon", nCli.RazonSocial);
            Parametros.Add("@Direccion", nCli.Direccion);
            Parametros.Add("@CodigoPostal", nCli.CodigoPostal);
            Parametros.Add("@Tel", nCli.Telefono);
            Parametros.Add("@Mail", nCli.Mail);
            Parametros.Add("@Tipo", nCli.Tipo);
            Parametros.Add("@Cuit", nCli.Cuit);
            Parametros.Add("@Contacto", nCli.Contacto);
            Parametros.Add("@CondicionPago", nCli.CondicionPago);
        
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_InsertarCliente", Parametros);
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
            Parametros.Add("@Tipo", nCli.Tipo);
            Parametros.Add("@Cuit", nCli.Cuit);
            Parametros.Add("@Contacto", nCli.Contacto);
            Parametros.Add("@CondicionPago", nCli.CondicionPago);
            Parametros.Add("@Activo", nCli.Activo);


            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EditarCliente", Parametros);
        }

        public void EliminarCliente(ClienteBE nCli)

        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", nCli.Id);
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_EliminarCliente", Parametros);
        }
    }
}
