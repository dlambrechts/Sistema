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

namespace UI
{
    public partial class FormClienteAlta : Form
    {
        public FormClienteAlta()
        {
            InitializeComponent();
            comboTipo.DataSource = Enum.GetValues(typeof(TipoCli));
            comboCondPago.DataSource = Enum.GetValues(typeof(CondPago));
        }

        enum TipoCli:int { Inscripto=1,ConsumidorFinal=2,Exento=3}
        enum CondPago:int { Contado,Anticipado}
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textRazon.Text=="" || textCuit.Text=="" || textCP.Text=="" || textMail.Text=="")

            {
                MessageBox.Show("Complete los campos obligatorios");

            }

            else 
            
            {
                try { 
                ClienteBE nCliente = new ClienteBE();

                nCliente.RazonSocial = textRazon.Text;
                nCliente.Direccion = textDireccion.Text;
                nCliente.CodigoPostal = Convert.ToInt32(textCP.Text);
                nCliente.Telefono = textTel.Text;
                nCliente.Mail = textMail.Text;
                nCliente.Tipo = comboTipo.Text;
                nCliente.Cuit = textCuit.Text;
                nCliente.Contacto = textContacto.Text;
                nCliente.CondicionPago = comboCondPago.Text;
                 ClienteBLL bllCli = new ClienteBLL();
                bllCli.InsertarCliente(nCliente);

                MessageBox.Show("Cliente Creado Correctamente");
                this.Close();
                }

                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);

                }
              
                
            }


        }

        private void FormClienteAlta_Load(object sender, EventArgs e)
        {

        }
    }
}
