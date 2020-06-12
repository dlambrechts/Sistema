using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormPerfilUsuario : Form
    {
        public UsuarioBLL bllUsuario;
        public UsuarioBE beUsuario;
        public PerfilComponenteBLL bllComp;
      
        public FormPerfilUsuario()
        {
            InitializeComponent();
            bllComp = new PerfilComponenteBLL();
        }


        private void FormPerfilUsuario_Load(object sender, EventArgs e)
        {
            bllUsuario = new UsuarioBLL();
            comboUsuario.DataSource = bllUsuario.ListarUsuarios();
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            beUsuario = (UsuarioBE)this.comboUsuario.SelectedItem;

            UsuarioBE tmpUs = new UsuarioBE();
            tmpUs.Id = beUsuario.Id;
            tmpUs.Nombre = beUsuario.Nombre;
            tmpUs.Apellido = beUsuario.Apellido;
            bllComp.CargarPerfilUsuario(tmpUs);
            MostrarPerfil(tmpUs);
        }
        public void MostrarPerfil(UsuarioBE Us)         
        {
            this.treeArbolPermisos.Nodes.Clear();
            TreeNode raiz = new TreeNode(beUsuario.ToString());
            
            foreach(var item in Us.Permisos)

            {
                LlenarTree(raiz, item);
            }

            this.treeArbolPermisos.Nodes.Add(raiz);
            this.treeArbolPermisos.ExpandAll();
        }

        public void LlenarTree (TreeNode Padre, PerfilComponenteBE Comp)
        {
            TreeNode Hijo = new TreeNode(Comp.Descripcion);
            Hijo.Tag = Comp;
            Padre.Nodes.Add(Hijo);

            foreach (var item in Comp.Hijos)
            {
                LlenarTree(Hijo, item);
            }
        }

    }
}
