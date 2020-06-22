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
using Servicios;

namespace UI
{
    public partial class FormPerfiles : Form,IIdiomaObserver
    {
        PerfilPatenteBLL bllPat;
        PerfilFamilaBLL bllFam;
        PerfilFamiliaBE beFamSeleccion;
        PerfilComponenteBLL bllComp;
        
        public FormPerfiles()
        {
            InitializeComponent();
            Traducir();
            bllPat = new PerfilPatenteBLL();
            bllFam = new PerfilFamilaBLL();
            bllComp = new PerfilComponenteBLL();
            comboPermAtom.DataSource = bllPat.ObtenerPatentesAtomicas();
        }

        public void UpdateLanguage(IdiomaBE idioma)
        {
            Traducir();
        }

        private void Traducir()

        {
            IdiomaBE Idioma = null;

            if (SesionSingleton.Instancia.IsLogged()) Idioma = SesionSingleton.Instancia.Usuario.Idioma;

            var Traducciones = TraductorBLL.ObtenerTraducciones(Idioma);

            if (Traducciones != null) // Al crear un idioma nuevo y utilizarlo no habrá traducciones, por lo tanto es necesario consultar si es null
            {

                if (this.Tag != null && Traducciones.ContainsKey(this.Tag.ToString()))  // Título del form
                    this.Text = Traducciones[this.Tag.ToString()].Texto;

                if (buttonConfig.Tag != null && Traducciones.ContainsKey(buttonConfig.Tag.ToString()))
                    buttonConfig.Text = Traducciones[buttonConfig.Tag.ToString()].Texto;

                if(groupBox2.Tag != null && Traducciones.ContainsKey(groupBox2.Tag.ToString()))
                    groupBox2.Text = Traducciones[groupBox2.Tag.ToString()].Texto;

                if(buttonAgrgarGrupo.Tag != null && Traducciones.ContainsKey(buttonAgrgarGrupo.Tag.ToString()))
                    buttonAgrgarGrupo.Text = Traducciones[buttonAgrgarGrupo.Tag.ToString()].Texto;

                if(buttonQuitarGrupo.Tag != null && Traducciones.ContainsKey(buttonQuitarGrupo.Tag.ToString()))
                    buttonQuitarGrupo.Text = Traducciones[buttonQuitarGrupo.Tag.ToString()].Texto;
           
                if(groupBox3.Tag != null && Traducciones.ContainsKey(groupBox3.Tag.ToString()))
                    groupBox3.Text = Traducciones[groupBox3.Tag.ToString()].Texto;

                if (groupBox5.Tag != null && Traducciones.ContainsKey(groupBox5.Tag.ToString()))
                    groupBox5.Text = Traducciones[groupBox5.Tag.ToString()].Texto;

                if (label3.Tag != null && Traducciones.ContainsKey(label3.Tag.ToString()))
                    label3.Text = Traducciones[label3.Tag.ToString()].Texto;

                if (buttonGuardarGrupo.Tag != null && Traducciones.ContainsKey(buttonGuardarGrupo.Tag.ToString()))
                    buttonGuardarGrupo.Text = Traducciones[buttonGuardarGrupo.Tag.ToString()].Texto;

                if (groupBox1.Tag != null && Traducciones.ContainsKey(groupBox1.Tag.ToString()))
                    groupBox1.Text = Traducciones[groupBox1.Tag.ToString()].Texto;

                if (buttonAgregarPermiso.Tag != null && Traducciones.ContainsKey(buttonAgregarPermiso.Tag.ToString()))
                    buttonAgregarPermiso.Text = Traducciones[buttonAgregarPermiso.Tag.ToString()].Texto;

                if (buttonPermisoQuitar.Tag != null && Traducciones.ContainsKey(buttonPermisoQuitar.Tag.ToString()))
                    buttonPermisoQuitar.Text = Traducciones[buttonPermisoQuitar.Tag.ToString()].Texto;

                if (groupBox4.Tag != null && Traducciones.ContainsKey(groupBox4.Tag.ToString()))
                    groupBox4.Text = Traducciones[groupBox4.Tag.ToString()].Texto;

                if (label1.Tag != null && Traducciones.ContainsKey(label1.Tag.ToString()))
                    label1.Text = Traducciones[label1.Tag.ToString()].Texto;

                if (label2.Tag != null && Traducciones.ContainsKey(label2.Tag.ToString()))
                    label2.Text = Traducciones[label2.Tag.ToString()].Texto;

                if (buttonGuardarPermiso.Tag != null && Traducciones.ContainsKey(buttonGuardarPermiso.Tag.ToString()))
                    buttonGuardarPermiso.Text = Traducciones[buttonGuardarPermiso.Tag.ToString()].Texto;

                if (button1.Tag != null && Traducciones.ContainsKey(button1.Tag.ToString()))
                    button1.Text = Traducciones[button1.Tag.ToString()].Texto;

            }

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
            SesionSingleton.Instancia.SuscribirObs(this);
            CargarCombos();

        }

        private void FormPerfiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            SesionSingleton.Instancia.DesuscribirObs(this);
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
