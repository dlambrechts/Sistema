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
    public partial class FormClienteVer : Form
    {
        public FormClienteVer()
        {
            InitializeComponent();
        }
        public ClienteBE cliente;
        ClienteBLL bllCli = new ClienteBLL();
        UsuarioBLL bllUs = new UsuarioBLL();

        private void FormClienteVer_Load(object sender, EventArgs e)
        {
            ActualziarDatos();
            CompletarDatos();
        }


        public void ActualziarDatos() 
        
        {
            cliente = bllCli.SeleccionarPorId(cliente.Id);
            cliente.UsuarioCreacion = bllUs.SeleccionarUsuarioPorId(cliente.UsuarioCreacion.Id);
            cliente.UsuarioModificacion = bllUs.SeleccionarUsuarioPorId(cliente.UsuarioModificacion.Id);
        }

        public void CompletarDatos()

        {
            groupBoxCli.Text = groupBoxCli.Text + " " + cliente.Id;
            labelRaz.Text = cliente.RazonSocial;
            labelMail.Text = cliente.Mail;
            labelCont.Text = cliente.Contacto;
            labelTel.Text = cliente.Telefono;
            labelCodPos.Text = Convert.ToString(cliente.CodigoPostal);
            labelDir.Text = cliente.Direccion;
            labelCuit.Text = cliente.Cuit;
            labelUsCre.Text = cliente.UsuarioCreacion.ToString();
            labelFeCre.Text = cliente.FechaCreacion.ToShortDateString();

            if (cliente.UsuarioModificacion.Id != 0) { 
            labelUsMod.Text = cliente.UsuarioModificacion.ToString();
            labelFeMod.Text = cliente.FechaModificacion.ToShortDateString();
            }
        }
    }
}
