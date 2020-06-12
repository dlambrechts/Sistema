using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BE;

namespace DAL
{
    public class PerfilPatenteDAL
    {
        public IList<PerfilPatenteBE> ObtenerPatentes()
        {
            List<PerfilPatenteBE> ListaPatentes = new List<PerfilPatenteBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListaPermisos", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    PerfilPatenteBE oPatente = new PerfilPatenteBE();

                    oPatente.Id = Convert.ToInt32(Item[0]);
                    oPatente.Permiso = (PerfilTipoPermisoBE)Enum.Parse(typeof(PerfilTipoPermisoBE), Convert.ToString(Item[1]));
                    oPatente.Descripcion = Item[2].ToString().Trim();

                    ListaPatentes.Add(oPatente);
                }

                return ListaPatentes;
            }
            else
            {
                return null;
            }
        }
    }
}
