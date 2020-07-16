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
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        UsuarioBLL bUsuario = new UsuarioBLL();
        UsuarioBE oUsuario = new UsuarioBE();
       

        private void buttonCRE_Click(object sender, EventArgs e)
        {
            if(textMail.Text=="" || textPass1.Text=="" ||textPass2.Text=="" || textNombre.Text=="") 
            
            { MessageBox.Show("Complete lo campos obligatorios"); }

            else 
            
            { 
            
              if(textPass1.Text!=textPass2.Text) { MessageBox.Show("Las contraseñas no coinciden"); }

                else 
                { 
           
                    Asignar();
                    bUsuario.ABM(oUsuario, 1);
                    CargarGrilla();
                }
            }
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            List<IdiomaBE> Idiomas = new List<IdiomaBE>();
            Idiomas = TraductorBLL.ObtenerIdiomas();
            comboIdioma.DataSource = Idiomas;
        }

        public void Asignar() 
        
        {
            oUsuario.Nombre = textNombre.Text.Trim();
            oUsuario.Apellido = textApellido.Text.Trim();
            oUsuario.Mail = textMail.Text.Trim();
            oUsuario.Password = Encriptador.Hash(textPass1.Text);
            oUsuario.Idioma = (IdiomaBE)comboIdioma.SelectedItem;
        
        }

        public void CargarGrilla()
        
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bUsuario.ListarUsuarios();

        }

        private void buttonDEL_Click(object sender, EventArgs e)
        {

        }
    }
}
