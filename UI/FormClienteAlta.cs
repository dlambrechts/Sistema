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
            CompletarTipos();
       
        }
        private BLL.ClienteBLL bllCli = new ClienteBLL();
        public void CompletarTipos() 
        
        {
            comboTipo.DataSource = null;
            comboTipo.DataSource = bllCli.ListarTipoCliente();
        }
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
                ClienteTipoBE ntipo = new ClienteTipoBE();
                ntipo = (ClienteTipoBE)comboTipo.SelectedItem;
                nCliente.tipo.Id = ntipo.Id;
                nCliente.Cuit = textCuit.Text;
                nCliente.Contacto = textContacto.Text;
                
                 
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
