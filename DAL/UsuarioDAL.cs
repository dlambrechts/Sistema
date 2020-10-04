using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        public List<UsuarioBE> ListarUsuarios() 
        
        {
            List<UsuarioBE> ListaUsuarios = new List<UsuarioBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListaUsuarios", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    UsuarioBE oUsuario = new UsuarioBE();
                    oUsuario.Id = Convert.ToInt32(Item[0]);                 
                    oUsuario.Nombre = Item[1].ToString().Trim();
                    oUsuario.Apellido = Item[2].ToString().Trim();
                    oUsuario.Mail = Item[3].ToString().Trim();
                    IdiomaBE uIdioma = new IdiomaBE();
                    oUsuario.Idioma = uIdioma;
                    oUsuario.Idioma.Id = Convert.ToInt32(Item[4]);
                    oUsuario.Idioma.Nombre = Convert.ToString(Item[5]);
                     oUsuario.dvh = Convert.ToInt32(Item[6]); 
                    oUsuario.Password = Convert.ToString(Item[7]).Trim();

                    ListaUsuarios.Add(oUsuario);
                }

                return ListaUsuarios ;
            }
            else
            {
                return null;
            }
        }

        public UsuarioBE LeerUsuario(string Mail)  // Para Login, selecciona por mail

        {
            Acceso AccesoDB = new Acceso();
            Hashtable Param = new Hashtable();
            DataSet Ds = new DataSet();
            UsuarioBE oUsuario = new UsuarioBE();
            Param.Add("@Mail", Mail);

            Ds = AccesoDB.LeerDatos("sp_UsuarioLogin", Param);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in Ds.Tables[0].Rows)
                {

                    oUsuario.Id = Convert.ToInt32(Item["Id"]);
                    oUsuario.Nombre = Item["Nombre"].ToString().Trim();
                    oUsuario.Apellido = Item["Apellido"].ToString().Trim();
                    oUsuario.Mail = Item["Mail"].ToString().Trim();
                    oUsuario.Password = Item["Password"].ToString().Trim();

                    IdiomaBE Idioma = new IdiomaBE();
                    Idioma.Id= Convert.ToInt32(Item["IdIdioma"]);
                    Idioma.Nombre= Item["NombreIdioma"].ToString().Trim();

                    oUsuario.Idioma = Idioma;

                }
                
            }
            return oUsuario;
        }

        public UsuarioBE SeleccionarUsuarioPorId(int Id)

        {
            Acceso AccesoDB = new Acceso();
            Hashtable Param = new Hashtable();
            DataSet Ds = new DataSet();
            UsuarioBE oUsuario = new UsuarioBE();
            Param.Add("@Id", Id);

            Ds = AccesoDB.LeerDatos("sp_SeleccionarUsuarioPorId", Param);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in Ds.Tables[0].Rows)
                {

                    oUsuario.Id = Convert.ToInt32(Item["Id"]);
                    oUsuario.Nombre = Item["Nombre"].ToString().Trim();
                    oUsuario.Apellido = Item["Apellido"].ToString().Trim();
                    oUsuario.Mail = Item["Mail"].ToString().Trim();
                    
                  
                }

            }
            return oUsuario;
        }

        public string Alta (UsuarioBE Usuario) 
        
        {
            string Consulta = "sp_InsertarUsuario";
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Nombre", Usuario.Nombre);
            Parametros.Add("@Apellido", Usuario.Apellido);
            Parametros.Add("@Mail", Usuario.Mail);
            Parametros.Add("@Password", Usuario.Password);
            Parametros.Add("@Idioma", Usuario.Idioma.Id);
            Parametros.Add("@dvh", Usuario.dvh);
            
            Acceso nAcceso = new Acceso();

            return nAcceso.Escribir(Consulta, Parametros);
        }


        public void Editar(UsuarioBE Usuario)

        {
            string Consulta = "sp_EditarUsuario";
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Id", Usuario.Id);
            Parametros.Add("@Nombre", Usuario.Nombre);
            Parametros.Add("@Apellido", Usuario.Apellido);
            Parametros.Add("@Mail", Usuario.Mail);
            Parametros.Add("@Password", Usuario.Password);
            Parametros.Add("@Idioma", Usuario.Idioma.Id);
            Parametros.Add("@dvh", Usuario.dvh);

            Acceso nAcceso = new Acceso();

            nAcceso.Escribir(Consulta, Parametros);
        }

        public void Eliminar (UsuarioBE Usuario)

        {
            string Consulta = "sp_EliminarUsuario";
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", Usuario.Id);   

            Acceso nAcceso = new Acceso();

            nAcceso.Escribir(Consulta, Parametros);
        }


        public void GuardarPermisos(UsuarioBE Usuario)

        {
            Acceso nAcceso = new Acceso();
            string ConsultaDel = "sp_BorrarPermisosUsuario"; // Primero borro los permisos que tenía el usuario
            Hashtable ParametrosDel = new Hashtable();
            ParametrosDel.Add("IdUsuario", Usuario.Id);
            nAcceso.Escribir(ConsultaDel, ParametrosDel);

            string ConsultaAdd = "sp_GuardarPermisosUsuario"; // Luego guardo los nuevos permisos
            Hashtable ParametrosAdd = new Hashtable();
            ParametrosAdd.Add("IdUsuario", Usuario.Id);

            foreach (var item in Usuario.Permisos)
            {

                ParametrosAdd.Add("IdPermiso", item.Id);
                nAcceso.Escribir(ConsultaAdd, ParametrosAdd);
                ParametrosAdd.Remove("IdPermiso");

            }
        }
    }
}
