using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class FormPresupuestoGestion : Form
    {
        public FormPresupuestoGestion()
        {
            InitializeComponent();
            CargarGrilla();
        }

        PresupuestoBE selPres = new PresupuestoBE();

        PresupuestoBLL bllPresup = new PresupuestoBLL();
        List<PresupuestoBE> ListaPresupuestos = new List<PresupuestoBE>();
        
        private void button1_Click(object sender, EventArgs e)
        {
            FormPresupuestoAlta fNuevo = new FormPresupuestoAlta();
            fNuevo.MdiParent = this.ParentForm;
            fNuevo.FormClosed += new FormClosedEventHandler(fNuevo_FormClosed);           
            fNuevo.Show();
        }

        private void fNuevo_FormClosed (object sender,EventArgs e) 
        {
            CargarGrilla();
        }
        private void FormPresupuestoGestion_Load(object sender, EventArgs e)
        {

        }

        public void CargarGrilla()
        
        {
            ListaPresupuestos = bllPresup.ListarPresupuestos();
            ClienteBLL bllCli = new ClienteBLL();
            UsuarioBLL bllUs = new UsuarioBLL();
            foreach (PresupuestoBE item in ListaPresupuestos)
            {
                item.Cliente = bllCli.SeleccionarPorId(item.Cliente.Id);
                item.Vendedor = bllUs.SeleccionarUsuarioPorId(item.Vendedor.Id);
            }

            dataGridView1.DataSource = null;
            BindingList<PresupuestoBE> bList = new BindingList<PresupuestoBE>(ListaPresupuestos);
            dataGridView1.DataSource = bList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            selPres.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (selPres.Id!=0)

            {
                FormPresupuestoVisualizar FormV = new FormPresupuestoVisualizar();
                FormV.vPresup = selPres;
                FormV.MdiParent = this.ParentForm;
                FormV.Show();
            }

            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");
        }
    }
}
