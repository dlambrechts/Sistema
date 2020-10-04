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
                    try
                    {
                        oUsuario.Nombre = textNombre.Text.Trim();
                        oUsuario.Apellido = textApellido.Text.Trim();
                        oUsuario.Mail = textMail.Text.Trim();
                        oUsuario.Password = Encriptador.Hash(textPass1.Text);
                        oUsuario.Idioma = (IdiomaBE)comboIdioma.SelectedItem;

                        bUsuario.Alta(oUsuario);
                    }

                    catch  (Exception ex) {MessageBox.Show(ex.Message);}

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


        public void CargarGrilla()
        
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bUsuario.ListarUsuarios();

        }

        private void buttonDEL_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textId.Text) == 0) { MessageBox.Show("Seleccione un usuario de la grilla"); }

            else

            {
                oUsuario.Id = Convert.ToInt32(textId.Text);
                oUsuario.Mail = textMail.Text.Trim();

                if (oUsuario.Mail == "admin") { MessageBox.Show("No se puede eliminar el Usuario admin"); }

                else 
                {                 
                  bUsuario.Eliminar(oUsuario);
                  CargarGrilla();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            UsuarioBE selU = new UsuarioBE();
            selU = (UsuarioBE)dataGridView1.CurrentRow.DataBoundItem;

            textId.Text = Convert.ToString(selU.Id);
            textNombre.Text = selU.Nombre;
            textApellido.Text = selU.Apellido;
            textMail.Text = selU.Mail;
            comboIdioma.SelectedItem = comboIdioma.Items.IndexOf(selU.Idioma.Id);
            
           
        }

        private void buttonUPD_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textId.Text) == 0) { MessageBox.Show("Seleccione un usuario de la grilla"); }

            else 
            
            {
                try
                {
                    oUsuario.Id = Convert.ToInt32(textId.Text);
                    oUsuario.Nombre = textNombre.Text.Trim();
                    oUsuario.Apellido = textApellido.Text.Trim();
                    oUsuario.Mail = textMail.Text.Trim();
                    oUsuario.Password = Encriptador.Hash(textPass1.Text);
                    oUsuario.Idioma = (IdiomaBE)comboIdioma.SelectedItem;

                    bUsuario.Editar(oUsuario);

                }

                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);

                }



                CargarGrilla();

            }
        }
    }
}
