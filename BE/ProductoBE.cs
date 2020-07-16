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
        public decimal Precio { get; set; }
        public decimal Iva { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return "(Código: " + Id +") "+" "+Descripcion;
        }
    }
}
