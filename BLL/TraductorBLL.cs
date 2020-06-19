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

      public static void InsertarEditarTraduccion(IdiomaBE Idioma, IdiomaTraduccionBE Traduccion, int Operacion)

        {
            TraductorDAL dalTraduc = new TraductorDAL();

            dalTraduc.InsertarEditarTraduccion(Idioma, Traduccion, Operacion);
        }

        public static void EditarIdioma(IdiomaBE Idioma, bool SetDefault) 
        
        {
            TraductorDAL dalTrad = new TraductorDAL();
            dalTrad.EditarIdioma(Idioma, SetDefault);    
        }
        public static void Insetaridioma(IdiomaBE Idioma, bool SetDefault)

        {
            TraductorDAL dalTrad = new TraductorDAL();
            dalTrad.Insetaridioma(Idioma, SetDefault);
        }

        public static void EliminarIdioma(IdiomaBE Idioma)

        {
            TraductorDAL dalTrad = new TraductorDAL();
            dalTrad.EliminarIdioma(Idioma);
        }

    }
}
