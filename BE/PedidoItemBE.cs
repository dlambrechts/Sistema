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
        private decimal _PrecioUnitario;
        private decimal _Impuestos;
        private decimal _TotalItem;
        public PedidoItemBE(ProductoBE producto,int cantidad,decimal unitario,decimal impuestos,decimal totalItem) 
        
        {
            _Producto = producto;
            _Cantidad = cantidad;
            _PrecioUnitario = unitario;
            _Impuestos = impuestos;
            _TotalItem = totalItem;
            
        }

        public ProductoBE Producto { get { return _Producto; } }
        public int Cantidad { get { return _Cantidad; } }
        public decimal PrecioUnitario { get { return _PrecioUnitario; } }
        public decimal Impuestos { get { return _Impuestos; } }
        public decimal TotalItem { get { return _TotalItem; } }
    }
}
