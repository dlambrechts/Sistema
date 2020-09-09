using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    public class BitacoraBLL
    {
        public void NuevaActividad(BitacoraActividadBE nAct )
        {
            BitacoraDAL bDal = new BitacoraDAL();
            nAct.Fecha = DateTime.Now;
            nAct.Usuario.Id = SesionSingleton.Instancia.Usuario.Id;         
            bDal.NuevaActividad(nAct);
        }

        public List<BitacoraActividadBE> ListarEventos() 
        
        {
            BitacoraDAL dBitacora = new BitacoraDAL();

            return dBitacora.ListarEventos();
        }

    }
}
