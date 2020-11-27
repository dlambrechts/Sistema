using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class IdiomaBE
    {
       public int Id { get; set; }
       public string Nombre { get; set; }
       public bool Default { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    public interface IIdiomaObserver 
    {
        void UpdateLanguage(IdiomaBE idioma);
    }
}
