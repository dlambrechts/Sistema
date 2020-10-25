using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PedidoItemBE
    {
        private ProductoBE _Producto;
        private int _Cantidad;
        public PedidoItemBE(ProductoBE producto,int cantidad) 
        
        {
            _Producto = producto;
            _Cantidad = cantidad;
        }

        public ProductoBE Producto { get { return _Producto; } }

        public int Cantidad { get { return _Cantidad; } }
    }
}
