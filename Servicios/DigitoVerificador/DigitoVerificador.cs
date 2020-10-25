using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios.Bitacora;


namespace Servicios.DigitoVerificador
{
    public class DigitoVerificador
    {
        public int CalcularDigitoHorizontal(UsuarioBE User)
        {
            int DVH = 0;

            DVH = GenerarAscii(User.Nombre, 1) + GenerarAscii(User.Apellido, 2 ) + GenerarAscii(User.Mail, 3) + GenerarAscii(User.Password, 4);
            return DVH;
        }

        public int CalcularDigitoVertical(List<UsuarioBE> Users)
        {
            int dvv = 0;
            
            foreach(UsuarioBE item in Users)
            
            {
                dvv = dvv + item.dvh;
            }

            return dvv;
        }

        public void ActualizarDigitoVertical(int Dv)
        {
                       
            DigitoVerificadorDAL dalDv = new DigitoVerificadorDAL();
            dalDv.ActualizarVertical(Dv);
        }

        public int GenerarAscii(string atributo, int pos)

        {
            int valor = 0;
            int flag = 1;
            byte[] ValoresASCII = Encoding.ASCII.GetBytes(atributo);
            foreach (byte b in ValoresASCII)
            {
                valor = valor + (b*flag);
                flag++;
            }

            return valor+pos;
        }

        public void VerificarIntegridadHorizonal(List<UsuarioBE> Users)
        {
            BitacoraBLL bllBit = new BitacoraBLL();

            BitacoraActividadBE nInicioVerificacionHorizontal = new BitacoraActividadBE();
            BitacoraTipoActividad tipo = new BitacoraTipoActividad();
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nInicioVerificacionHorizontal.SetTipo(tipo);
            nInicioVerificacionHorizontal.Detalle = "Se inició el porceso de verificación de Dígito Horizontal";
            bllBit.NuevaActividad(nInicioVerificacionHorizontal);

            foreach (UsuarioBE u in Users)
            {
                int dvh=CalcularDigitoHorizontal(u);

                if (u.dvh != dvh)
                {
                    BitacoraActividadBE nActividad = new BitacoraActividadBE();

                    tipo = bllBit.ListarTipos().First(item => item.Tipo == "Error");
                    nInicioVerificacionHorizontal.SetTipo(tipo);
                    nActividad.SetTipo(tipo);
                    nActividad.Detalle = "El Proceso de Verificación de DB detectó inconsistencias en el usuario: " + u.Id;
                    bllBit.NuevaActividad(nActividad);
                    
                }

            }

            BitacoraActividadBE nFinVerificacionHorizontal = new BitacoraActividadBE();
          
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nFinVerificacionHorizontal.SetTipo(tipo);
            nFinVerificacionHorizontal.Detalle = "Finalizó el porceso de verificación de Dígito Horizontal";
            bllBit.NuevaActividad(nFinVerificacionHorizontal);

        }

        public void VerificarIntegridadVertical(List<UsuarioBE> Users)
        {
            BitacoraBLL bllBit = new BitacoraBLL();

            BitacoraActividadBE nInicioVerificacionVertical = new BitacoraActividadBE();
            BitacoraTipoActividad tipo = new BitacoraTipoActividad();
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nInicioVerificacionVertical.SetTipo(tipo);
            nInicioVerificacionVertical.Detalle = "Se inició el porceso de verificación de Dígito Vertical";
            bllBit.NuevaActividad(nInicioVerificacionVertical);

            int dvv = CalcularDigitoVertical(Users);

            DigitoVerificadorDAL dvdal = new DigitoVerificadorDAL();
            int dvv_db = dvdal.ObtenerVertical();

            if (dvv != dvv_db) 
            {
                BitacoraActividadBE nError = new BitacoraActividadBE();
                tipo = bllBit.ListarTipos().First(item => item.Tipo == "Error");
                nError.SetTipo(tipo);
                nError.Detalle = "El Proceso de Verificación de DB detectó que se agregaron o quitaron Usuarios";
                bllBit.NuevaActividad(nError);

            }

            BitacoraActividadBE nFinVerificacionVertical = new BitacoraActividadBE();
            tipo = bllBit.ListarTipos().First(item => item.Tipo == "Mensaje");
            nFinVerificacionVertical.SetTipo(tipo);
            nFinVerificacionVertical.Detalle = "Finalizó el porceso de verificación de Dígito Vertical";
            bllBit.NuevaActividad(nFinVerificacionVertical);

        }
    }
}
