using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class FormProductoEditar : Form
    {
        public FormProductoEditar()
        {
            InitializeComponent();

        }

        public BE.ProductoBE eProd = new ProductoBE();
        private BLL.ProductoBLL bllProd = new ProductoBLL();



        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (textDescrip.Text == "") { MessageBox.Show("Por favor, ingrese una Descripción"); }

            else 
            
            {
                ProductoBE eProducto = new ProductoBE();

                eProducto.Id = eProd.Id;
                eProducto.Descripcion = textDescrip.Text;
                eProducto.Precio = Convert.ToDecimal(textPrecio.Text);
                eProducto.Iva = Convert.ToDecimal(comboIva.Text);
                eProducto.Activo = checkBox1.Checked;
          
                bllProd.EditarProducto(eProducto);

                MessageBox.Show("Producto Modificado Correctamente");
                this.Close();

            }
        }

        private void FormProductoEditar_Load(object sender, EventArgs e)
        {
            textDescrip.Text = eProd.Descripcion;
            textPrecio.Text = Convert.ToString(eProd.Precio);
            checkBox1.Checked = eProd.Activo;
            comboIva.Text = eProd.Iva.ToString(); ;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
