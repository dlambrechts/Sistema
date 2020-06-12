using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class PerfilComponenteBLL
    {
        public void GuardarComponente(PerfilComponenteBE Comp, bool EsFamilia)

        {
            PerfilComponenteDAL nComp = new PerfilComponenteDAL();
            nComp.GuardarComponente(Comp, EsFamilia);
        }

        public IList<PerfilComponenteBE> ObtenerTodo (PerfilFamiliaBE Fam)

        {
            PerfilComponenteDAL nComp = new PerfilComponenteDAL();
            return nComp.ObtenerTodo(Fam);
        }

        public void CompletarComponentesFamilia(PerfilFamiliaBE Familia)

        {
            PerfilComponenteDAL nComp = new PerfilComponenteDAL();
            nComp.CompletarComponentesFamilia(Familia);
        }

        public void CargarPerfilUsuario(UsuarioBE Us)

        {
            PerfilComponenteDAL nComp = new PerfilComponenteDAL();
            nComp.CargarPerfilUsuario(Us);
        }

        public bool Existe(PerfilComponenteBE Comp, int id)
        {
            bool existe = false;

            if (Comp.Id.Equals(id))
                existe = true;
            else

                foreach (var item in Comp.Hijos)
                {

                    existe = Existe(item, id);
                    if (existe) return true;
                }

            return existe;

        }


    }
}
