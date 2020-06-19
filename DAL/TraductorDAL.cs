using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class TraductorDAL
    {
  

        public List<IdiomaBE> ObtenerIdiomas()

        {
            List<IdiomaBE> ListaIdiomas = new List<IdiomaBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();       
            DS = AccesoDB.LeerDatos("sp_ListarIdiomas", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    IdiomaBE oIdioma = new IdiomaBE();
                    oIdioma.Id = Convert.ToInt32(Item[0]);                  
                    oIdioma.Nombre = Item[1].ToString().Trim();
                    oIdioma.Default = Convert.ToBoolean(Item[2]);
              
                    ListaIdiomas.Add(oIdioma);
                }

                return ListaIdiomas;
            }
            else
            {
                return null;
            }

        }

        public Dictionary<string,IdiomaTraduccionBE> ObtenerTraducciones (IdiomaBE Idioma)
        
        {
            Dictionary<string,IdiomaTraduccionBE> ListaTraducciones = new Dictionary<string,IdiomaTraduccionBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            Hashtable Param = new Hashtable();
            Param.Add("@Idioma", Idioma.Id);
            DS = AccesoDB.LeerDatos("sp_ListaTraducciones", Param);
                     
            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    
                    IdiomaTraduccionBE Traduccion = new IdiomaTraduccionBE();
                    IdiomaEtiquetaBE Etiqueta = new IdiomaEtiquetaBE();

                    Etiqueta.Id = Convert.ToInt32(Item[0]);
                    Etiqueta.Nombre = Item[1].ToString().Trim();
                    Traduccion.Etiqueta = Etiqueta;
                    Traduccion.Texto= Item[2].ToString().Trim();

                    ListaTraducciones.Add(Etiqueta.Nombre,Traduccion);
                }

                return ListaTraducciones;
            }
            else
            {
                return null;
            }
        }

        public List<IdiomaEtiquetaBE> ObtenerEtiquetas()

        {
            List<IdiomaEtiquetaBE> ListaEtiquetas = new List<IdiomaEtiquetaBE>();

            Acceso AccesoDB = new Acceso();
            DataSet DS = new DataSet();
            DS = AccesoDB.LeerDatos("sp_ListaEtiquetasIdioma", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    IdiomaEtiquetaBE oEtiqueta = new IdiomaEtiquetaBE();
                    oEtiqueta.Id = Convert.ToInt32(Item[0]);
                    oEtiqueta.Nombre = Item[1].ToString().Trim();
                    

                    ListaEtiquetas.Add(oEtiqueta);
                }

                return ListaEtiquetas;
            }
            else
            {
                return null;
            }

        }

        public void abmEtiqueta(IdiomaEtiquetaBE Etiqueta, int Operacion)
        {
            string Consulta;

            switch (Operacion)
            {
                case 1:
                    Consulta = "sp_InsertarEtiquetaIdioma";
                    break;
                case 2:
                    Consulta = "sp_EditarEtiquetaIdioma";
                    break;
                case 3:
                    Consulta = "sp_BorrarEtiquetaIdioma";
                    break;
                default:
                    Consulta = null;
                    break;
            }

            Hashtable Parametros = new Hashtable();

            if (Operacion != 3)
            {
                if (Etiqueta.Id != 0)
                {
                    Parametros.Add("@Id", Etiqueta.Id);
                }

                Parametros.Add("@Nombre", Etiqueta.Nombre);

            }
            else
            {
                Parametros.Add("@Id", Etiqueta.Id);
            }
            Acceso nAcceso = new Acceso();

            nAcceso.Escribir(Consulta, Parametros);

        }

        public void InsertarEditarTraduccion(IdiomaBE Idioma, IdiomaTraduccionBE Traduccion, int Operacion)
        {
            string Consulta;
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@IdEtiqueta", Traduccion.Etiqueta.Id);
            Parametros.Add("@Texto", Traduccion.Texto);
            Parametros.Add("@IdIdioma", Idioma.Id);
            switch (Operacion)
            {
                case 1:
                    Consulta = "sp_InsertarTraduccion";           
                    break;
                case 2:
                    Consulta = "sp_EditarTraduccion";
                    break;
                default:
                    Consulta = null;
                    break;
            }
         
            Acceso nAcceso = new Acceso();
            nAcceso.Escribir(Consulta, Parametros);

        }

        public void Insetaridioma (IdiomaBE Idioma,bool SetDefault) 
        
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Nombre", Idioma.Nombre);
            Parametros.Add("@Defecto", SetDefault);
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_InsertarIdioma",Parametros);
        }

        public void EditarIdioma(IdiomaBE Idioma,bool SetDefault)

        {
            
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", Idioma.Id);
            Acceso AccesoDB = new Acceso();

            if (SetDefault==true)

            {                
                AccesoDB.Escribir("sp_CambiarIdiomaDefecto",Parametros);
                
                Parametros.Add("@Nombre", Idioma.Nombre);
                AccesoDB.Escribir("sp_EditarIdioma", Parametros);
            }
            
            else
            {
                Parametros.Add("@Nombre", Idioma.Nombre);
                AccesoDB.Escribir("sp_EditarIdioma", Parametros);

            }         
        }

        public void EliminarIdioma (IdiomaBE Idioma)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", Idioma.Id);
            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_BorrarIdioma", Parametros);

        }

    }
}
