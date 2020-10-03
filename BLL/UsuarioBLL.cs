using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Servicios;
using Servicios.DigitoVerificador;

namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL dUsuario = new UsuarioDAL();
        DigitoVerificador DigitoVerificador = new DigitoVerificador();
        

        public List<UsuarioBE> ListarUsuarios() // Traer Lista de usuarios para ABM
        {
            List<UsuarioBE> Lista = new List<UsuarioBE>();            
            return Lista = dUsuario.ListarUsuarios();
        }

        public UsuarioBE GetUsuarioLogin(string Mail) // Traer usuario para luego validar el login
        
        {
            UsuarioBE oUsuario = new UsuarioBE();
            oUsuario = dUsuario.LeerUsuario(Mail);
            return oUsuario;      
        }

        public UsuarioBE SeleccionarUsuarioPorId(int Id)
        {
            return dUsuario.SeleccionarUsuarioPorId(Id);
        }
        public ResultadoLogin Login (string Mail, string Password) 
        
        {
            if (SesionSingleton.Instancia.IsLogged())
                throw new Exception("La sesión ya está iniciada");

            UsuarioBE oUsuario = new UsuarioBE();
            PerfilComponenteBLL bllComp = new PerfilComponenteBLL();
            oUsuario = GetUsuarioLogin(Mail);
            bllComp.CargarPerfilUsuario(oUsuario);

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
            dUsuario.GuardarPermisos(Usuario);
        }
        public void Alta (UsuarioBE Usuario) 
        
        {            
            Usuario.dvh = DigitoVerificador.CalcularDigitoHorizontal(Usuario);
            string Id= dUsuario.Alta(Usuario);
            int dvv = DigitoVerificador.CalcularDigitoVertical(dUsuario.ListarUsuarios());
            DigitoVerificador.ActualizarDigitoVertical(dvv);            

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllBit = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se agregó el Usuario " + Id;
            bllBit.NuevaActividad(nActividad);

        }

        public void Editar(UsuarioBE Usuario)

        {
            Usuario.dvh = DigitoVerificador.CalcularDigitoHorizontal(Usuario);
            dUsuario.Editar(Usuario);
            int dvv = DigitoVerificador.CalcularDigitoVertical(dUsuario.ListarUsuarios());
            DigitoVerificador.ActualizarDigitoVertical(dvv);

            BitacoraActividadBE nActividad = new BitacoraActividadBE();
            BitacoraBLL bllBit = new BitacoraBLL();
            nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
            nActividad.Detalle = "Se modificó el Usuario " + Usuario.Id;
            bllBit.NuevaActividad(nActividad);

        }
   
        public void Logut ()
        
        {                 
                BitacoraActividadBE nAct = new BitacoraActividadBE();
                BitacoraBLL bllAct = new BitacoraBLL();
               
                nAct.Detalle = "Sesión cerrada con éxito";
                nAct.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje");
                bllAct.NuevaActividad(nAct);
                SesionSingleton.Instancia.Logout();
        }

    
    }
}
