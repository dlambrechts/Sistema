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

        public ProductoTipoBE tipo = new ProductoTipoBE();
        public ProductoTipoBE Tipo { get { return tipo; } }

        public ProductoUnidadMedidaBE um = new ProductoUnidadMedidaBE(); 
        public ProductoUnidadMedidaBE UnidadMedida { get { return um; } }
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
