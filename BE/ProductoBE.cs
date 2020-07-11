using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductoBE
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string UnidadMedida { get; set; }
        public int Stock { get; set; }
        public float Precio { get; set; }
        public bool Activo { get; set; }
    }
}
