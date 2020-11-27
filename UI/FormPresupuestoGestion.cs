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
using Servicios;

namespace UI
{
    public partial class FormPresupuestoGestion : Form, IIdiomaObserver
    {
        public FormPresupuestoGestion()
        {
            InitializeComponent();
            Traducir();
            CargarGrilla();
            Helper();
        }


        private BE.PresupuestoBE selPres;

        private BLL.PresupuestoBLL bllPresup = new PresupuestoBLL();
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
            SesionSingleton.Instancia.SuscribirObs(this);
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

            if (selPres!=null)

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
            if (selPres!=null)

            {
                if(selPres.Estado.AprobacionCliente()==true || selPres.Estado.RechazoCliente()==true) 
                
                {
                    FormPresupuestoCierre FormC = new FormPresupuestoCierre();
                    FormC.cPresup = selPres;
                    FormC.MdiParent = this.ParentForm;
                    FormC.FormClosed += new FormClosedEventHandler(fNuevo_FormClosed);
                    FormC.Show();
                }

                else 
                { 
                    MessageBox.Show("No es posible realizar el Cierre en el Estado actual");
                }
            }

            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");

        }

        private void buttonEditar_Click(object sender, EventArgs e) // Editar
        {
            if (selPres!=null)

            {
              
                if (selPres.Estado.Edicion()==false) { MessageBox.Show("No es posible Editar en el Estado Actual"); }

                else
                { 
                    FormPresupuestoEditar frmEd = new FormPresupuestoEditar();
                    frmEd.MdiParent = this.ParentForm;
                    frmEd.ePresupuesto = selPres;
                    frmEd.FormClosed += new FormClosedEventHandler(fNuevo_FormClosed);       
                    frmEd.Show();

                }

               
            }
            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");
        }

        private void button4_Click(object sender, EventArgs e) // Eliminar
        {
            if (selPres!=null)

            {
                if (selPres.Estado.Eliminar()==false) { MessageBox.Show("No es posible Elminar en el Estado actual"); }
                else
                {
                    DialogResult Respuesta = MessageBox.Show("¿Eliminar Presupuesto " + selPres.Id + "?", "Eliminar Presupuesto", MessageBoxButtons.YesNo);

                    if (Respuesta == DialogResult.Yes) 
                        {                         
                        bllPresup.Eliminar(selPres);
                        CargarGrilla();
                    }
                }
            }

            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");
        }

        private void buttonLayout_Click(object sender, EventArgs e)
        {

            if (selPres!=null)

            {
                DialogResult Respuesta = MessageBox.Show("¿Generar PDF Presupuesto " + selPres.Id + "?", "Generar PDF", MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)

                {
                    ClienteBLL bllCli = new ClienteBLL();
                    UsuarioBLL bllVen = new UsuarioBLL();
             
                    selPres = bllPresup.SeleccionarPresupuestoPorId(selPres.Id);
                    selPres.Vendedor = bllVen.SeleccionarUsuarioPorId(selPres.Vendedor.Id);
                    GenerarLayoutPresupuesto Pdf = new GenerarLayoutPresupuesto();

                    Pdf.GenerarPresupuestoPdf(selPres);
                }
            }

            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");
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

                if (button1.Tag != null && Traducciones.ContainsKey(button1.Tag.ToString()))  
                    button1.Text = Traducciones[button1.Tag.ToString()].Texto;

                if (button3.Tag != null && Traducciones.ContainsKey(button3.Tag.ToString()))  
                    button3.Text = Traducciones[button3.Tag.ToString()].Texto;

                if (buttonEditar.Tag != null && Traducciones.ContainsKey(buttonEditar.Tag.ToString())) 
                    buttonEditar.Text = Traducciones[buttonEditar.Tag.ToString()].Texto;

                if (buttonCierre.Tag != null && Traducciones.ContainsKey(buttonCierre.Tag.ToString()))
                    buttonCierre.Text = Traducciones[buttonCierre.Tag.ToString()].Texto;

                if (button4.Tag != null && Traducciones.ContainsKey(button4.Tag.ToString()))
                    button4.Text = Traducciones[button4.Tag.ToString()].Texto;

                if (buttonLayout.Tag != null && Traducciones.ContainsKey(buttonLayout.Tag.ToString()))
                    buttonLayout.Text = Traducciones[buttonLayout.Tag.ToString()].Texto;

                if (groupBox1.Tag != null && Traducciones.ContainsKey(groupBox1.Tag.ToString()))  
                    groupBox1.Text = Traducciones[groupBox1.Tag.ToString()].Texto;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta = MessageBox.Show("¿Generar Serialización XML de Presupuestos?", "Generar XML", MessageBoxButtons.YesNo);

            if (Respuesta == DialogResult.Yes)

            {
                bllPresup.Serializar();
            }
       
        
        }

        public void Helper() 
        
        {
            toolTipGestion.SetToolTip(button1, "Haga clic aquí para Crear un Nuevo Presupuesto");
            toolTipGestion.SetToolTip(button3, "Haga clic aquí para Visualizar el Presupuesto seleccionado");
            toolTipGestion.SetToolTip(buttonEditar, "Haga clic aquí para Editar el Presupuesto seleccionado");
            toolTipGestion.SetToolTip(button4, "Haga clic aquí para Eliminar el Presupuesto seleccionado");
            toolTipGestion.SetToolTip(buttonCierre, "Haga clic aquí para informar Respuesta del Cliente para el Presupuesto seleccionado");
            toolTipGestion.SetToolTip(buttonEditar, "Haga clic aquí para Editar para el Presupuesto seleccionado");
            toolTipGestion.SetToolTip(buttonLayout, "Haga clic aquí para generar PDF del Presupuesto seleccionado");
            toolTipGestion.SetToolTip(button2, "Haga clic aquí para realizar una serialización XML de todos los Presupuestos");
        }
    }
}
