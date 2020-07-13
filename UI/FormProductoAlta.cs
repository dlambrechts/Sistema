using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormProductoAlta : Form
    {
        public FormProductoAlta()
        {
            InitializeComponent();
            comboTipo.DataSource = Enum.GetValues(typeof(TipoProd));
            comboUnMedi.DataSource = Enum.GetValues(typeof(UnidadMedida));
        }

        enum TipoProd:int {Terminado=1,Repuesto=2,Insumo=3,SemiElaborado=4,Servicio=5 }
        enum UnidadMedida : int { Unidad=1,Metro=2,Kg=3,Litro=4}

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (textDescrip.Text=="") { MessageBox.Show("Por favor, ingrese una Descripción"); }

            else 
            
            {
                ProductoBE nProducto = new ProductoBE();

                nProducto.Descripcion = textDescrip.Text;
                nProducto.Tipo = comboTipo.Text;
                nProducto.UnidadMedida = comboUnMedi.Text;
                nProducto.Stock = Convert.ToInt32(numericStock.Value);
                nProducto.Precio = (float)Convert.ToDouble(textPrecio.Text);

                ProductoBLL bllProd = new ProductoBLL();
                bllProd.AltaProducto(nProducto);

                MessageBox.Show("Producto Creado Correctamente");
                this.Close();

            }
        }

        private void FormProductoAlta_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
