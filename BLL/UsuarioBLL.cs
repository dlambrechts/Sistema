using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Servicios;
using Servicios.DigitoVerificador;
using Servicios.Bitacora;

namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL dUsuario = new UsuarioDAL();
        DigitoVerificador DigitoVerificador = new DigitoVerificador();
        BitacoraActividadBE nActividad = new BitacoraActividadBE();
        BitacoraBLL bllBit = new BitacoraBLL();
        BitacoraTipoActividad tipo = new BitacoraTipoActividad();

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
            
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se agregó el Usuario " + Id;
            bllBit.NuevaActividad(nActividad);

        }

        public void Editar(UsuarioBE Usuario)

        {
            Usuario.dvh = DigitoVerificador.CalcularDigitoHorizontal(Usuario);
            dUsuario.Editar(Usuario);
            int dvv = DigitoVerificador.CalcularDigitoVertical(dUsuario.ListarUsuarios());
            DigitoVerificador.ActualizarDigitoVertical(dvv);

            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se modificó el Usuario " + Usuario.Id;
            bllBit.NuevaActividad(nActividad);

        }

        public void Eliminar(UsuarioBE Usuario)

        {     
            dUsuario.Eliminar(Usuario);
            int dvv = DigitoVerificador.CalcularDigitoVertical(dUsuario.ListarUsuarios());
            DigitoVerificador.ActualizarDigitoVertical(dvv);

            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            nActividad.Detalle = "Se Eliminó el Usuario " + Usuario.Id;
            bllBit.NuevaActividad(nActividad);
       
        }

        public void Logut ()
        
        {                             
            nActividad.Detalle = "Sesión cerrada con éxito";
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nActividad.SetTipo(tipo);
            bllBit.NuevaActividad(nActividad);
            SesionSingleton.Instancia.Logout();
        }

    
    }
}
