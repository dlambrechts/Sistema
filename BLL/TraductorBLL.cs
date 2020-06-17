using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public static class TraductorBLL
    {
        public static IdiomaBE ObtenerIdiomaPorDefecto()

        {
            return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();

        }
        public static List<IdiomaBE> ObtenerIdiomas()

        {
            TraductorDAL dalTraduc = new TraductorDAL();
            return dalTraduc.ObtenerIdiomas();
        }

        public static Dictionary<string, IdiomaTraduccionBE> ObtenerTraducciones(IdiomaBE Idioma)
        {
            if (Idioma == null) Idioma = ObtenerIdiomaPorDefecto();

            TraductorDAL dalTraduc = new TraductorDAL();

            return dalTraduc.ObtenerTraducciones(Idioma);

        }



    }
}
