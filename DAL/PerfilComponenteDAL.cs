using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;


namespace DAL
{
    public class PerfilComponenteDAL
    {
        public void GuardarComponente(PerfilComponenteBE Comp, bool EsFamilia)

        {
            Acceso nAcceso = new Acceso();

            string Consulta = "sp_InsertarComponente";
            Hashtable Parametros = new Hashtable();

            Parametros.Add("Descripcion", Comp.Descripcion);

            if (EsFamilia) Parametros.Add("Permiso", DBNull.Value);

            else Parametros.Add("Permiso", Comp.Permiso.ToString()); ;

            nAcceso.Escribir(Consulta, Parametros);

        }

        public IList<PerfilComponenteBE> ObtenerTodo(PerfilFamiliaBE Familia)
        {
            Acceso nAcceso = new Acceso();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("Fam", Familia.Id);
            DataSet DS = new DataSet();
            DS = nAcceso.LeerDatos("sp_ObtenerTodoFamilia", Parametros);

            var Lista = new List<PerfilComponenteBE>();

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {

                    int id_padre = 0;
                    if (Item["IdPadre"] != DBNull.Value)
                    {

                        id_padre = Convert.ToInt32(Item["IdPadre"]);
                    }

                    var id = Convert.ToInt32(Item["Id"]);
                    var nombre = Convert.ToString(Item["Descripcion"]);

                    var permiso = string.Empty;
                    if (Item["Permiso"] != DBNull.Value)
                        permiso = Convert.ToString(Item["Permiso"]);


                    PerfilComponenteBE c;

                    if (string.IsNullOrEmpty(permiso))
                        c = new PerfilFamiliaBE();

                    else
                        c = new PerfilPatenteBE();

                    c.Id = id;
                    c.Descripcion = nombre;
                    if (!string.IsNullOrEmpty(permiso))
                        c.Permiso = (PerfilTipoPermisoBE)Enum.Parse(typeof(PerfilTipoPermisoBE), permiso);

                    var padre = ObtenerComponente(id_padre, Lista);

                    if (padre == null)
                    {
                        Lista.Add(c);
                    }
                    else
                    {
                        padre.AgregarHijo(c);
                    }

                }
            }

            return Lista;
        }

        public void CompletarComponentesFamilia(PerfilFamiliaBE familia)
        {
            familia.VaciarHijos();
            foreach (var item in ObtenerTodo(familia))
            {
                familia.AgregarHijo(item);
            }
        }

        private PerfilComponenteBE ObtenerComponente(int id, IList<PerfilComponenteBE> lista)
        {

            PerfilComponenteBE Componente = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (Componente == null && lista != null)
            {
                foreach (var c in lista)
                {

                    var l = ObtenerComponente(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return ObtenerComponente(id, l.Hijos);
                }
            }

            return Componente;
        }

        public void CargarPerfilUsuario(UsuarioBE Us)

        {
            Acceso nAcceso = new Acceso();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("IdUsuario", Us.Id);
            DataSet DS = new DataSet();
            DS = nAcceso.LeerDatos("sp_ListaPermisosUsuario", Parametros);

            Us.Permisos.Clear();
            if (DS.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    var IdPermiso = Convert.ToInt32(Item["Id"]);
                    var DescPermiso = Convert.ToString(Item["Descripcion"]);
                    var Permiso = string.Empty;

                    if (Item["Permiso"]!=DBNull.Value) { Permiso = Convert.ToString(Item["Permiso"]); }

                    

                    if(!String.IsNullOrEmpty(Permiso)) 
                    
                        {
                        PerfilPatenteBE Patente= new PerfilPatenteBE();
                        Patente.Id = IdPermiso;
                        Patente.Descripcion = DescPermiso;
                        Us.Permisos.Add(Patente);
                        }

                    else

                        {
                            PerfilFamiliaBE Familia = new PerfilFamiliaBE();
                            Familia.Id = IdPermiso;
                            Familia.Descripcion = DescPermiso;

                            var Arbol = ObtenerTodo(Familia);
                            
                            foreach (var hijo in Arbol)

                            {
                            Familia.AgregarHijo(hijo);
                            }

                            Us.Permisos.Add(Familia);
                        }
                }
            }

        }
    }
}
