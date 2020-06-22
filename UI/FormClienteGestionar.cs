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
    public partial class FormClienteGestionar : Form
    {
        public FormClienteGestionar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FormClienteAlta frmCliAlta = new FormClienteAlta();
            frmCliAlta.MdiParent = this.ParentForm;
            frmCliAlta.Show();
        }
    }
}
