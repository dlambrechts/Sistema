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
            ListaPresupuestos.Clear();
            ListaPresupuestos = bllPresup.ListarPresupuestos();     
            dataGridView1.DataSource = null;
            BindingList<PresupuestoBE> bList = new BindingList<PresupuestoBE>(ListaPresupuestos);
            dataGridView1.DataSource = bList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            selPres = (PresupuestoBE)dataGridView1.CurrentRow.DataBoundItem;
            
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

        private void buttonCierre_Click(object sender, EventArgs e)
        {
            if (selPres.Id != 0)

            {
                if(selPres.AprobacionTecnica==false || selPres.AprobacionComercial == false) { MessageBox.Show("El Presupuesto debe tener Aprobación Técnica y Comercial"); }

                else 
                { 

                        FormPresupuestoCierre FormC = new FormPresupuestoCierre();
                        FormC.cPresup = selPres;
                        FormC.MdiParent = this.ParentForm;
                        FormC.FormClosed += new FormClosedEventHandler(fNuevo_FormClosed);
                        FormC.Show();

                }
            }

            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (selPres.Id != 0) 
            
            { 
            FormPresupuestoEditar frmEd = new FormPresupuestoEditar();
            frmEd.MdiParent = this.ParentForm;
            frmEd.ePresupuesto = selPres;
            frmEd.FormClosed += new FormClosedEventHandler(fNuevo_FormClosed);       
            frmEd.Show();

            }
            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");
        }
    }
}
