using BE;
using BE.PresupuestoEstado;
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
using Servicios;
using Servicios.Bitacora;

namespace UI
{
    public partial class FormPresupuestoCierre : Form
    {
        public FormPresupuestoCierre()
        {
            InitializeComponent();
        }
        public enum Accion : int { Aprobar = 1, Rechazar = 2 }

        public BE.PresupuestoBE cPresup;
        private BLL.PresupuestoBLL bllP = new PresupuestoBLL();

        private void FormPresupuestoCierre_Load(object sender, EventArgs e)
        {
            textBoxPre.Text = Convert.ToString(cPresup.Id);
            comboBoxTipo.DataSource = Enum.GetValues(typeof(Accion));
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            cPresup = bllP.SeleccionarPresupuestoPorId(cPresup.Id);

            DialogResult Respuesta = MessageBox.Show("Confirma Cierre del Presupuesto?", comboBoxTipo.Text, MessageBoxButtons.YesNo);

            if (Respuesta == DialogResult.Yes)

            {
                PresupuestoTipoAprobacionBE Tipo = new PresupuestoTipoAprobacionBE();
                Tipo = bllP.SeleccionarAprobacionTipo("Cliente");
                PresupuestoAprobacionBE nAprob = new PresupuestoAprobacionBE(cPresup, Tipo, SesionSingleton.Instancia.Usuario);

                if (((comboBoxTipo.Text == "Aprobar" && cPresup.Estado.AprobacionCliente() == true)) || ((comboBoxTipo.Text == "Rechazar" && cPresup.Estado.RechazoCliente() == true)))
                {
                
                    nAprob.Fecha = DateTime.Now;
                    nAprob.Accion = comboBoxTipo.Text;
                    nAprob.Observaciones = textBoxObs.Text;
                    PresupuestoBLL bllAp = new PresupuestoBLL();

                    if (nAprob.Accion == "Aprobar")

                    {
                        PresupuestoEstadoBE nEstado = new ApCli();
                        bllAp.ActualizarEstado(cPresup, nEstado);
                    }
                    else
                    {
                        PresupuestoEstadoBE nEstado = new RechCli();
                        bllAp.ActualizarEstado(cPresup, nEstado);
                    }

                    bllAp.Cierre(nAprob);
                    MessageBox.Show("Operación realizada correctamente");
                    this.Close();
                }
                else 
                
                { 
                    
                    MessageBox.Show("No es posible realizar el Cierre en el Estado actual");

                    BitacoraActividadBE nActividad = new BitacoraActividadBE();
                    BitacoraBLL bllAct = new BitacoraBLL();

                    nActividad.Detalle = "El Cierre no es posible para el Presupuesto N° " + cPresup.Id + " en el estado actual";
                    bllAct.NuevaActividad(nActividad);

                }
            }
        }   
    }
}
