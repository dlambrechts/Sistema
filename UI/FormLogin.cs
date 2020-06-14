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
using Servicios;

namespace UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        PerfilComponenteBLL bllComp;
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //UsuarioBE oUsuario = new UsuarioBE();
            UsuarioBLL bllUsuario = new UsuarioBLL();

            try
            {
                var Resultado = bllUsuario.Login(textEmail.Text.Trim(), textPass.Text.Trim()) ;
                FormPrincipal Form = (FormPrincipal)this.MdiParent;                          
                Form.ValidarFormulario();
                this.Close();
            }

            catch (ExceptionLogin Error)

            {
                switch (Error.Result)
                {
                    case ResultadoLogin.UsuarioInvalido:
                        MessageBox.Show("Usuario incorrecto");
                        break;
                    case ResultadoLogin.PasswordInvalido:
                        MessageBox.Show("El Password ingresado es Incorrecto");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
