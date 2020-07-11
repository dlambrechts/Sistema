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
            comboTipo.DataSource = Enum.GetValues(typeof(TipoCli));
            comboCondPago.DataSource = Enum.GetValues(typeof(CondPago));
        }
        enum TipoCli : int { Inscripto = 1, ConsumidorFinal = 2, Exento = 3 }
        enum CondPago : int { Contado, Anticipado }

        public ClienteBE Cli = new ClienteBE();
        private void FormClienteEditar_Load(object sender, EventArgs e)
        {
            textRazon.Text = Cli.RazonSocial;
            textDireccion.Text = Cli.Direccion;
            textCP.Text = Convert.ToString(Cli.CodigoPostal);
            textTel.Text = Cli.Telefono;
            textMail.Text = Cli.Mail;
            comboTipo.Text = Cli.Tipo;
            textCuit.Text = Cli.Cuit;
            textContacto.Text = Cli.Contacto;
            comboCondPago.Text = Cli.CondicionPago;
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
                ClienteBE eCli = new ClienteBE();

                eCli.Id = Cli.Id;
                eCli.RazonSocial = textRazon.Text;
                eCli.Direccion = textDireccion.Text;
                eCli.CodigoPostal = Convert.ToInt32(textCP.Text);
                eCli.Telefono = textTel.Text;
                eCli.Mail = textMail.Text;
                eCli.Tipo = comboTipo.Text;
                eCli.Cuit = textCuit.Text;
                eCli.Contacto = textContacto.Text;
                eCli.CondicionPago = comboCondPago.Text;
                eCli.Activo = checkBox1.Checked;

                ClienteBLL bllCli = new ClienteBLL();
                bllCli.EditarCliente(eCli);

                MessageBox.Show("Cliente Modificado Correctamente");
                this.Close();

            }
        }
    }
}
