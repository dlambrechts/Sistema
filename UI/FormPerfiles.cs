using BLL;
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

namespace UI
{
    public partial class FormPerfiles : Form
    {
        PerfilPatenteBLL bllPat;
        PerfilFamilaBLL bllFam;
        PerfilFamiliaBE beFamSeleccion;
        PerfilComponenteBLL bllComp;
        
        public FormPerfiles()
        {
            InitializeComponent();
            bllPat = new PerfilPatenteBLL();
            bllFam = new PerfilFamilaBLL();
            bllComp = new PerfilComponenteBLL();
            comboPermAtom.DataSource = bllPat.ObtenerPatentesAtomicas();
        }

        private void CargarCombos() 
        
        {
            comboPermisos.DataSource = bllPat.ObtenerPatentes();
            comboGrupos.DataSource = bllFam.ObtenerFamilias();
        }
        private void buttonGuardarPermiso_Click(object sender, EventArgs e)
        {
            PerfilPatenteBE nPatente = new PerfilPatenteBE()
            {
                Descripcion = this.textDescripcionPerm.Text,
                Permiso=(PerfilTipoPermisoBE)this.comboPermAtom.SelectedItem
            };

            bllComp.GuardarComponente(nPatente, false);
            CargarCombos();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerfilFamiliaBE nFamilia = new PerfilFamiliaBE()
            {
                Descripcion = textBoxNombreGrupo.Text,
            };

            bllComp.GuardarComponente(nFamilia, true);
            CargarCombos();

        }

        private void FormPerfiles_Load(object sender, EventArgs e)
        {
            CargarCombos();

        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            var tmp = (PerfilFamiliaBE)this.comboGrupos.SelectedItem;
            beFamSeleccion = new PerfilFamiliaBE();
            beFamSeleccion.Id = tmp.Id;
            beFamSeleccion.Descripcion = tmp.Descripcion;

            MostrarFamilia(true);
        }

        void MostrarFamilia(bool init)
        {
            if (beFamSeleccion == null) return;

            IList<PerfilComponenteBE> flia = null;

            if (init)
            {                
                flia = bllComp.ObtenerTodo(beFamSeleccion);  // Traer de la DB
                foreach (var i in flia)
                    beFamSeleccion.AgregarHijo(i);
            }
            else
            {
                flia = beFamSeleccion.Hijos;
            }

            this.treeFam.Nodes.Clear();

            TreeNode root = new TreeNode(beFamSeleccion.Descripcion);
            root.Tag = beFamSeleccion;
            this.treeFam.Nodes.Add(root);

            foreach (var item in flia)
            {
                MostrarEnTree(root, item);
            }

            treeFam.ExpandAll();
        }
        void MostrarEnTree(TreeNode tn, PerfilComponenteBE c)
        {
            TreeNode n = new TreeNode(c.Descripcion);
            tn.Tag = c;
            tn.Nodes.Add(n);
            if (c.Hijos != null)
                foreach (var item in c.Hijos)
                {
                    MostrarEnTree(n, item);
                }

        }

        private void buttonAgrgarGrupo_Click(object sender, EventArgs e)
        {
            if (beFamSeleccion != null)
            {
                var familia = (PerfilFamiliaBE)comboGrupos.SelectedItem;
                if (familia != null)
                {

                    var esta = bllComp.Existe(beFamSeleccion, familia.Id);
                    if (esta)
                        MessageBox.Show("Ya exsite el Grupo");
                    else
                    {
                        bllComp.CompletarComponentesFamilia(familia);
                        beFamSeleccion.AgregarHijo(familia);
                        MostrarFamilia(false);
                    }


                }
            }
        }

        private void buttonQuitarGrupo_Click(object sender, EventArgs e)
        {
            if (beFamSeleccion != null)
            {
                var familia = (PerfilFamiliaBE)comboGrupos.SelectedItem;
                if (familia != null)
                {

                    var esta = bllComp.Existe(beFamSeleccion, familia.Id);
                    if (!esta)
                        MessageBox.Show("El Grupo No está Agregado");
                    else
                    {

                        bllComp.CompletarComponentesFamilia(familia);
                        beFamSeleccion.QuitarHijo(familia);
                        MostrarFamilia(false);
                    }


                }
            }
        }

        private void buttonAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (beFamSeleccion != null)
            {
                var patente = (PerfilPatenteBE)comboPermisos.SelectedItem;
                if (patente != null)
                {
                    var esta = bllComp.Existe(beFamSeleccion, patente.Id);
                    if (esta)
                        MessageBox.Show("Ya exsite el Permiso");
                    else
                    {

                        {
                            beFamSeleccion.AgregarHijo(patente);
                            MostrarFamilia(false);
                        }
                    }
                }
            }
        }

        private void buttonPermisoQuitar_Click(object sender, EventArgs e)
        {
            if (beFamSeleccion != null)
            {
                var patente = (PerfilPatenteBE)comboPermisos.SelectedItem;
                if (patente != null)
                {
                    var esta = bllComp.Existe(beFamSeleccion, patente.Id);
                    if (!esta)
                        MessageBox.Show("El permiso no pertenece al Grupo");
                    else
                    {
                        {
                            beFamSeleccion.QuitarHijo(patente);
                            MostrarFamilia(false);
                        }
                    }
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                bllFam.GuardarFamilia(beFamSeleccion);
                MessageBox.Show("El Grupo se Guardó correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Se produjo un Error al Guarda el Grupo");
            }

        }


    }
}
