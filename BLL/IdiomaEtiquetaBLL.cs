using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class IdiomaEtiquetaBLL
    {
        public List<IdiomaEtiquetaBE> ObtenerEtiquetas()
        {
            TraductorDAL dalTrad = new TraductorDAL();
            return dalTrad.ObtenerEtiquetas();
        }
   

    public void abmEtiqueta(IdiomaEtiquetaBE Etiqueta, int Operacion)
    
         {
             TraductorDAL dalTrad = new TraductorDAL();
              dalTrad.abmEtiqueta(Etiqueta, Operacion);
         }
    }
}
