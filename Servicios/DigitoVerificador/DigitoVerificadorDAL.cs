using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Collections;
using System.Data;
using BE;

namespace Servicios.DigitoVerificador
{
    public class DigitoVerificadorDAL
    {
        public void ActualizarVertical(int dv)

        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Valor", dv);
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_ActualizarDvUsuario", Parametros);
        }

        public int ObtenerVertical()

        {
                Acceso AccesoDB = new Acceso();
                Hashtable Param = new Hashtable();
                DataSet Ds = new DataSet();
               
                Ds = AccesoDB.LeerDatos("sp_ObtenerDigitoVerticalUsuario", null);

                int dvv = 0;

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Item in Ds.Tables[0].Rows)
                    {
                        dvv = Convert.ToInt32(Item[1]);                     
                    }
                }
                return dvv;
            }
        
    }
}
