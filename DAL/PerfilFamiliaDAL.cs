using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Collections;

namespace DAL
{
    public class PerfilFamiliaDAL
    {
        public IList<PerfilFamiliaBE> ObtenerFamilias()
        {
            List<PerfilFamiliaBE> ListaFamilias = new List<PerfilFamiliaBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListaFamilias", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    PerfilFamiliaBE oFamilia = new PerfilFamiliaBE();

                    oFamilia.Id = Convert.ToInt32(Item[0]);
                    oFamilia.Descripcion = Item[1].ToString().Trim();

                    ListaFamilias.Add(oFamilia);
                }

                return ListaFamilias;
            }
            else
            {
                return null;
            }
        }

        public void GuardarFamilia (PerfilFamiliaBE Fam)

        {
            Acceso nAcceso = new Acceso();
            string ConsultaDel = "sp_BorrarFamilia"; // Primero borro la Familia
            Hashtable ParametrosDel = new Hashtable();
            ParametrosDel.Add("Id", Fam.Id);
            nAcceso.Escribir(ConsultaDel, ParametrosDel);

            string ConsultaAdd = "sp_GuardarFamilia"; // Luego guardo la familia actualizada
            Hashtable ParametrosAdd = new Hashtable();
            ParametrosAdd.Add("IdPadre", Fam.Id);
           
            foreach (var item in Fam.Hijos)
            {

                ParametrosAdd.Add("IdHijo", item.Id);
                nAcceso.Escribir(ConsultaAdd, ParametrosAdd);
                ParametrosAdd.Remove("IdHijo");
            } 
        }
    }
}
