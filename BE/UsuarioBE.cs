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

        List<PerfilComponenteBE> permisos;
        public UsuarioBE() { permisos = new List<PerfilComponenteBE>(); }
        public List<PerfilComponenteBE> Permisos {  get { return permisos; }   }

        public void AgregarPermiso (PerfilComponenteBE Perm) { permisos.Add(Perm); }
        public void QuitarPermiso (PerfilComponenteBE Perm) { permisos.Remove(permisos.Where(permisos => permisos.Id == Perm.Id).First()); }
        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
