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
    public class UsuarioBLL
    {
        public List<UsuarioBE> ListarUsuarios() // Traer Lista de usuarios para ABM
        {
            List<UsuarioBE> Lista = new List<UsuarioBE>();
            UsuarioDAL dUsuario= new UsuarioDAL();
            return Lista = dUsuario.ListarUsuarios();
        }

        public UsuarioBE GetUsuarioLogin(string Mail) // Traer usuario para luego validar el login
        
        {
            UsuarioBE oUsuario = new UsuarioBE();
            UsuarioDAL dUsuario = new UsuarioDAL();
            oUsuario = dUsuario.LeerUsuario(Mail);
            return oUsuario;
        
        }
        public ResultadoLogin Login (string Mail, string Password) 
        
        {
            if (SesionSingleton.Instancia.IsLogged())
                throw new Exception("La sesión ya está iniciada");

            UsuarioBE oUsuario = new UsuarioBE();
            oUsuario = GetUsuarioLogin(Mail);

            if (oUsuario.Mail == null) throw new ExceptionLogin(ResultadoLogin.UsuarioInvalido);



            if (!oUsuario.Password.Equals(Encriptador.Hash(Password)))
                throw new ExceptionLogin(ResultadoLogin.PasswordInvalido);
            else

            {
                SesionSingleton.Instancia.Login(oUsuario);
                return ResultadoLogin.UsuarioValido;
            }
 
        }

        public void GuardarPermisos(UsuarioBE Usuario)

        {
            UsuarioDAL uDal = new UsuarioDAL();
            uDal.GuardarPermisos(Usuario);
        }

        public void ABM (UsuarioBE Usuario, int Operacion) //  1- Alta, Baja o Modificación
        {
            UsuarioDAL dUsuario = new UsuarioDAL();
            dUsuario.ABM(Usuario, Operacion);

        }

        public void Logut ()
        
        {
            SesionSingleton.Instancia.Logout();
        }
    }
}
