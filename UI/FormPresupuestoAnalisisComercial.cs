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
using Servicios.Bitacora;

namespace UI
{
    public partial class FormPresupuestoAnalisisComercial : Form
    {
        public FormPresupuestoAnalisisComercial()
        {
            InitializeComponent();

        }

        private BLL.PresupuestoBLL bllPresup = new PresupuestoBLL();
        List<PresupuestoBE> ListaPresupuestos = new List<PresupuestoBE>();
        private BE.PresupuestoBE selPres;
        private void FormPresupuestoAnalisisComercial_Load(object sender, EventArgs e)
        {
            ObtenerPresupuestos();
            CargarGrilla();
        }
        public void ObtenerPresupuestos()

        {
            ListaPresupuestos = bllPresup.ListarPresupuestos();
            ClienteBLL bllCli = new ClienteBLL();
            UsuarioBLL bllUs = new UsuarioBLL();

        }
        public void CargarGrilla()

        {
            dataGridViewPresup.DataSource = null;

            if (radioPendientes.Checked == true)
            {
                List<PresupuestoBE> ListaFiltrada = new List<PresupuestoBE>();
               ListaFiltrada = ListaPresupuestos.Where(x => x.Estado.GetType().Name=="ApComPend").ToList();
                BindingList<PresupuestoBE> bList = new BindingList<PresupuestoBE>(ListaFiltrada);
                dataGridViewPresup.DataSource = bList;
            }

            else

            {
                BindingList<PresupuestoBE> bList = new BindingList<PresupuestoBE>(ListaPresupuestos);
                dataGridViewPresup.DataSource = bList;
            }

        }

        private void radioPendientes_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void radioButtonTodos_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void buttonAp_Click_1(object sender, EventArgs e)
        {
            if (selPres ==null) 
                
            {
                MessageBox.Show("Por favor, seleccione un Presupuesto"); 
            
            }
           
            else 
                {
                if (selPres.Estado.AprobacionComercial() == true || selPres.Estado.RechazoComercial() == true)
                {
                    FormPresupuestoAnalisisComercialEjecutar frPreAprob = new FormPresupuestoAnalisisComercialEjecutar();
                    frPreAprob.oPresup = selPres;
                    frPreAprob.MdiParent = this.ParentForm;
                    frPreAprob.FormClosed += new FormClosedEventHandler(frPreAprob_FormClosed);
                    frPreAprob.Show();
                    
                }
                else
                {
                    MessageBox.Show("No es posible realizar Analisis Comercial en el Estado Actual");

                    BitacoraActividadBE nActividad = new BitacoraActividadBE();
                    BitacoraBLL bllAct = new BitacoraBLL();
                    nActividad.Detalle = "Análisis Comercial no es posible para el Presupuesto N° " + selPres.Id + " en el estado actual";
                    bllAct.NuevaActividad(nActividad);
                }
            }
        }

        private void frPreAprob_FormClosed(object sender,EventArgs e) 
        
        {
            ObtenerPresupuestos();
            CargarGrilla();
        }
        private void dataGridViewPresup_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            selPres=(PresupuestoBE)dataGridViewPresup.CurrentRow.DataBoundItem;
        }

        private void radioPendientes_CheckedChanged_1(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void radioButtonTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void buttonVis_Click(object sender, EventArgs e)
        {

            if (selPres!=null)

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

