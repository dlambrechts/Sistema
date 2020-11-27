using BE;
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

namespace UI
{
    public partial class FormClienteEditar : Form
    {
        public FormClienteEditar()
        {
            InitializeComponent();
            CompletarTipos();      
        }

        private BLL.ClienteBLL bllCli = new ClienteBLL();

        public BE.ClienteBE Cli = new ClienteBE();

        public void CompletarTipos()

        {
            comboTipo.DataSource = null;
            comboTipo.DataSource = bllCli.ListarTipoCliente();
        }
        private void FormClienteEditar_Load(object sender, EventArgs e)
        {
            textRazon.Text = Cli.RazonSocial;
            textDireccion.Text = Cli.Direccion;
            textCP.Text = Convert.ToString(Cli.CodigoPostal);
            textTel.Text = Cli.Telefono;
            textMail.Text = Cli.Mail;
            comboTipo.SelectedIndex = comboTipo.FindStringExact(Cli.Tipo.Tipo);
            textCuit.Text = Cli.Cuit;
            textContacto.Text = Cli.Contacto;

            checkBox1.Checked = Cli.Activo;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {


            if (textRazon.Text == "" && textCuit.Text == "")

            {
                MessageBox.Show("Razón Social y CUIT son Obligatorios");
            }

            else

            {
                try { 
                ClienteBE eCli = new ClienteBE();

                eCli.Id = Cli.Id;
                eCli.RazonSocial = textRazon.Text;
                eCli.Direccion = textDireccion.Text;
                eCli.CodigoPostal = Convert.ToInt32(textCP.Text);
                eCli.Telefono = textTel.Text;
                eCli.Mail = textMail.Text;
                eCli.tipo = (ClienteTipoBE)comboTipo.SelectedItem;
                eCli.Cuit = textCuit.Text;
                eCli.Contacto = textContacto.Text;

                eCli.Activo = checkBox1.Checked;

                ClienteBLL bllCli = new ClienteBLL();
                bllCli.NuevaVersion(Cli,eCli);

                
                MessageBox.Show("Cliente Modificado Correctamente");
                }

                catch (Exception ex) 
                
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();

            }
        }
    }
}
