using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public IdiomaBE Idioma { get; set; }
        public int dvh { get; set; }

        List<PerfilComponenteBE> permisos;
        public UsuarioBE() { permisos = new List<PerfilComponenteBE>(); }
        public List<PerfilComponenteBE> Permisos {  get { return permisos; }   }
        public bool ExistePermisoExplisito (PerfilComponenteBE Perm){ if (permisos.Exists(permisos => permisos.Id == Perm.Id))  return true;  else return false; } // Verifico que el permiso esté de forma directa en el Usuario, para poder eliminarlo luego
        public void AgregarPermiso (PerfilComponenteBE Perm) { permisos.Add(Perm); }
        public void QuitarPermiso (PerfilComponenteBE Perm) { permisos.Remove(permisos.Where(permisos => permisos.Id == Perm.Id).First()); }
        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
