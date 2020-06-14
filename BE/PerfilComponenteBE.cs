using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class PerfilComponenteBE
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public abstract IList<PerfilComponenteBE> Hijos { get; }
        public abstract void AgregarHijo(PerfilComponenteBE Comp);
        public abstract void QuitarHijo(PerfilComponenteBE Comp);
        public abstract void VaciarHijos();
        public PerfilTipoPermisoBE Permiso { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
