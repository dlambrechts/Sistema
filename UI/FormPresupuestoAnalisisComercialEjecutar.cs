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
using Servicios;
using BLL;
using BE.PresupuestoEstado;

namespace UI
{
    public partial class FormPresupuestoAnalisisComercialEjecutar : Form
    {
        public FormPresupuestoAnalisisComercialEjecutar()
        {
            InitializeComponent();
            comboBoxAccion.DataSource = Enum.GetValues(typeof(Accion));

        }

        enum Accion : int { Aprobar = 1, Rechazar = 2 }
        public PresupuestoBE oPresup;
        PresupuestoBLL bllP = new PresupuestoBLL();


        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            oPresup = bllP.SeleccionarPresupuestoPorId(oPresup.Id); // Actualizo datos del presupuesto
        
            DialogResult Respuesta = MessageBox.Show("Confirma " + comboBoxAccion.Text + "Presupuesto?", comboBoxAccion.Text, MessageBoxButtons.YesNo);

            if (Respuesta == DialogResult.Yes)

            {
                PresupuestoTipoAprobacionBE Tipo = new PresupuestoTipoAprobacionBE();
                Tipo= bllP.SeleccionarAprobacionTipo("Comercial");

                PresupuestoAprobacionBE nAprob = new PresupuestoAprobacionBE(oPresup,Tipo, SesionSingleton.Instancia.Usuario);

                if (((comboBoxAccion.Text == "Aprobar" && oPresup.Estado.AprobacionComercial() == true)) || ((comboBoxAccion.Text == "Rechazar" && oPresup.Estado.RechazoComercial() == true)))
                {

                    nAprob.Fecha = DateTime.Now;                   
                    nAprob.Accion = comboBoxAccion.Text;
                    nAprob.Observaciones = textBoxObs.Text;
                    PresupuestoBLL bllAp = new PresupuestoBLL();


                    if (nAprob.Accion == "Aprobar")

                    {
                        PresupuestoEstadoBE nEstado = new EnviarCli();
                        bllAp.ActualizarEstado(oPresup, nEstado);

                    }
                    else
                    {
                        PresupuestoEstadoBE nEstado = new ApComRech();
                        bllAp.ActualizarEstado(oPresup, nEstado);
                    }


                    bllAp.AnalisisComercial(nAprob);
                    MessageBox.Show("Operación realizada correctamente");
                    this.Close();
                }
                else { MessageBox.Show("No es posible realizar la acción en el Estado actual"); ; }
            }
        }

        private void FormPresupuestoAnalisisComercialEjecutar_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormPresupuestoAnalisisComercialEjecutar_Load(object sender, EventArgs e)
        {
            textBoxPresup.Text = Convert.ToString(oPresup.Id);
           
        }
    }
}
