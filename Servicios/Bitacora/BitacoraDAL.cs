using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections;
using System.Data;
using DAL;



namespace Servicios.Bitacora
{
    public class BitacoraDAL
    {
        public void NuevaActividad(BitacoraActividadBE nAct)

        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Usuario", nAct.Usuario.Id);
            Parametros.Add("@Fecha", nAct.Fecha);
            Parametros.Add("@Clasificacion", nAct.Clasificacion.ToString()) ;
            Parametros.Add("@Detalle", nAct.Detalle);
           
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_InsertarActividadBitacora", Parametros);
        }

   

    public List<BitacoraActividadBE> ListarEventos() 
    
    {
        List<BitacoraActividadBE> ListaEventos = new List<BitacoraActividadBE>();

        Acceso AccesoDB = new Acceso();
        DataSet DS = new DataSet();
        DS = AccesoDB.LeerDatos("sp_ListaBitacoraEventos", null);

        if (DS.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Item in DS.Tables[0].Rows)
            {
                BitacoraActividadBE oEvento = new BitacoraActividadBE();
                oEvento.Id = Convert.ToInt32(Item[0]);
                oEvento.Usuario.Id= Convert.ToInt32(Item[1]);
                oEvento.Usuario.Nombre = Convert.ToString(Item[2]).Trim();
                oEvento.Usuario.Apellido = Convert.ToString(Item[3]).Trim();
                oEvento.Fecha = Convert.ToDateTime(Item[4]);
                oEvento.Clasificacion = (BitacoraClasifActividad)Enum.Parse(typeof(BitacoraClasifActividad), Convert.ToString(Item[5]).Trim());
                oEvento.Detalle = Convert.ToString(Item[6]).Trim();

                ListaEventos.Add(oEvento);
            }

        }
        return ListaEventos;
    }
    }
}
