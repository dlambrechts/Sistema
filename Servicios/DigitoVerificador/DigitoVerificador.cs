using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios.DigitoVerificador
{
    public class DigitoVerificador
    {
        public int CalcularDigitoHorizontal(UsuarioBE User)
        {
            int DVH = 0;

            DVH = GenerarAscii(User.Nombre) + GenerarAscii(User.Apellido) + GenerarAscii(User.Mail) + GenerarAscii(User.Password);
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

        public int GenerarAscii(string atributo)

        {
            int valor = 0;

            byte[] ValoresASCII = Encoding.ASCII.GetBytes(atributo);
            foreach (byte b in ValoresASCII)
            {
                valor = valor + b;
            }

            return valor;
        }

        public void VerificarIntegridadHorizonal(List<UsuarioBE> Users)
        {

            foreach (UsuarioBE u in Users)
            {
                int dvh=CalcularDigitoHorizontal(u);

                if (u.dvh != dvh)
                {

                    MessageBox.Show("Inconsistencia en usuario " + u + dvh + "  " + u.dvh);
                }

            }

        }

        public void VerificarIntegridadVertical(List<UsuarioBE> Users)
        {
            int dvv = CalcularDigitoVertical(Users);

            DigitoVerificadorDAL dvdal = new DigitoVerificadorDAL();
            int dvv_db = dvdal.ObtenerVertical();

            if (dvv != dvv_db) { MessageBox.Show("Inconsistencia horizontal"+dvv+" " + dvv_db); }

        }
    }
}
