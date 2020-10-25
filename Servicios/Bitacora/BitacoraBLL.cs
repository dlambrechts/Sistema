using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Servicios;
using Servicios.Bitacora;

namespace Servicios.Bitacora
{
    public class BitacoraBLL
    {
        BitacoraDAL bDal = new BitacoraDAL();
        public void NuevaActividad(BitacoraActividadBE nAct )
        {
            
            nAct.Fecha = DateTime.Now;

            if (SesionSingleton.Instancia.Usuario != null) 
            { 
            nAct.Usuario.Id = SesionSingleton.Instancia.Usuario.Id;
            }
            bDal.NuevaActividad(nAct);
        }

        public List<BitacoraActividadBE> ListarEventos() 
        
        {         
            return bDal.ListarEventos();
        }

        public List<BitacoraTipoActividad> ListarTipos()

        {
            return bDal.ListarTipos();
        }

    }
}
