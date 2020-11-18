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
using Servicios;

namespace UI
{
    public partial class FormProductoGestion : Form, IIdiomaObserver
    {
        public FormProductoGestion()
        {
            InitializeComponent();
            Traducir();
        }

        ProductoBLL bllProd = new ProductoBLL();
        ProductoBE beProd = new ProductoBE();
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            FormProductoAlta frmProdAlta = new FormProductoAlta();
            frmProdAlta.MdiParent = ParentForm;
            frmProdAlta.FormClosed += new FormClosedEventHandler(frmProdAlta_FormClosed);
            frmProdAlta.Show();
        }
        private void frmProdAlta_FormClosed(object sender, FormClosedEventArgs e)
        {
            LeerProductos();
        }
        private void FormProductoGestion_Load(object sender, EventArgs e)
        {
            LeerProductos();
            SesionSingleton.Instancia.SuscribirObs(this);
        }
        public void LeerProductos()

        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bllProd.ListarProductos();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (beProd.Descripcion == null) { MessageBox.Show("Debe seleccionar un Producto para Editar"); }

            else { 

            FormProductoEditar frmProdEd = new FormProductoEditar();
            frmProdEd.eProd = beProd;
            frmProdEd.MdiParent = this.ParentForm;
            frmProdEd.FormClosed += new FormClosedEventHandler(frmProdEd_FormClosed);
            frmProdEd.Show();

            }
        }

        private void frmProdEd_FormClosed(object sender, FormClosedEventArgs e)
        {
            LeerProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            beProd = (ProductoBE)dataGridView1.CurrentRow.DataBoundItem;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (beProd.Id == 0) { MessageBox.Show("Debe seleccionar un Producto para Eliminar"); }

            else
            {

             DialogResult Respuesta = MessageBox.Show("¿Eliminar Producto "+ beProd.Id +"?", "Eliminar Producto"  , MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)
                {

                    if (bllProd.ExisteProductoEnPresupuesto(beProd) == true)

                    {
                        MessageBox.Show("No es posible Eliminar. El Producto tiene Presupuestos asociados");
                    }
                    else
                    {
                        bllProd.EliminarProducto(beProd);
                        MessageBox.Show("Producto Eliminado");
                        LeerProductos();
                    }
                }  
                
            }
        }

        public void UpdateLanguage(IdiomaBE idioma)
        {
            Traducir();
        }
        private void Traducir()

        {
            IdiomaBE Idioma = null;

            if (SesionSingleton.Instancia.IsLogged()) Idioma = SesionSingleton.Instancia.Usuario.Idioma;

            var Traducciones = TraductorBLL.ObtenerTraducciones(Idioma);

            if (Traducciones != null) // Al crear un idioma nuevo y utilizarlo no habrá traducciones, por lo tanto es necesario consultar si es null
            {

                if (this.Tag != null && Traducciones.ContainsKey(this.Tag.ToString()))  // Título del form
                    this.Text = Traducciones[this.Tag.ToString()].Texto;

                if (groupBox2.Tag != null && Traducciones.ContainsKey(groupBox2.Tag.ToString()))  // Título del form
                    groupBox2.Text = Traducciones[groupBox2.Tag.ToString()].Texto;

                if (buttonNuevo.Tag != null && Traducciones.ContainsKey(buttonNuevo.Tag.ToString()))
                    buttonNuevo.Text = Traducciones[buttonNuevo.Tag.ToString()].Texto;

                if (buttonEliminar.Tag != null && Traducciones.ContainsKey(buttonEliminar.Tag.ToString()))
                    buttonEliminar.Text = Traducciones[buttonEliminar.Tag.ToString()].Texto;

                if (buttonEditar.Tag != null && Traducciones.ContainsKey(buttonEditar.Tag.ToString()))
                    buttonEditar.Text = Traducciones[buttonEditar.Tag.ToString()].Texto;



                if (groupBox1.Tag != null && Traducciones.ContainsKey(groupBox1.Tag.ToString()))
                    groupBox1.Text = Traducciones[groupBox1.Tag.ToString()].Texto;
            }

        }
    }
}
