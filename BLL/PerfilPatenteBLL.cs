using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PerfilPatenteBLL
    {
        public IList<PerfilPatenteBE> ObtenerPatentes() // Traigo todas las patentes de Base de Datos    
        {
            PerfilPatenteDAL dPatente = new PerfilPatenteDAL();
            return dPatente.ObtenerPatentes();
        }

        public Array ObtenerPatentesAtomicas() // Traigo las Patentes Atómicas
        {
            return Enum.GetValues(typeof(PerfilTipoPermisoBE));
        }
    }
}
