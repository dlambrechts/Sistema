using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class PerfilFamilaBLL
    {
        public IList<PerfilFamiliaBE> ObtenerFamilias() // Traigo todas las Familias de Base de Datos    
        {
            PerfilFamiliaDAL dFamilia = new PerfilFamiliaDAL();
            return dFamilia.ObtenerFamilias();
        }

    

    public void GuardarFamilia(PerfilFamiliaBE Fam)

      {
        PerfilFamiliaDAL dFamilia = new PerfilFamiliaDAL();
        dFamilia.GuardarFamilia(Fam);

        }
    }
}
