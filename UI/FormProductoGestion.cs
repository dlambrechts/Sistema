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
    public partial class FormProductoGestion : Form
    {
        public FormProductoGestion()
        {
            InitializeComponent();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            FormProductoAlta frmProdAlta = new FormProductoAlta();
            frmProdAlta.MdiParent = ParentForm;
            frmProdAlta.Show();
        }
    }
}
