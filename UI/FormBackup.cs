using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;
using Servicios.Backup;
using BE;
using BLL;

namespace UI
{
    public partial class FormBackup : Form, IIdiomaObserver
    {
        public FormBackup()
        {
            InitializeComponent();
            Traducir();
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

                if (buttonNuevo.Tag != null && Traducciones.ContainsKey(buttonNuevo.Tag.ToString()))
                    buttonNuevo.Text = Traducciones[buttonNuevo.Tag.ToString()].Texto;

                if (buttonRestaurar.Tag != null && Traducciones.ContainsKey(buttonRestaurar.Tag.ToString()))
                    buttonRestaurar.Text = Traducciones[buttonRestaurar.Tag.ToString()].Texto;

                if (buttonElim.Tag != null && Traducciones.ContainsKey(buttonElim.Tag.ToString()))
                    buttonElim.Text = Traducciones[buttonElim.Tag.ToString()].Texto;

                if (buttonCambiar.Tag != null && Traducciones.ContainsKey(buttonCambiar.Tag.ToString()))
                    buttonCambiar.Text = Traducciones[buttonCambiar.Tag.ToString()].Texto;

                if (groupBox2.Tag != null && Traducciones.ContainsKey(groupBox2.Tag.ToString()))
                    groupBox2.Text = Traducciones[groupBox2.Tag.ToString()].Texto;


            }

        }

        string Directorio = @"C:\Backup\"; // A futuro permitir al usuario seleccionar la carpeta
        private void FormBackup_Load(object sender, EventArgs e)
        {
            SesionSingleton.Instancia.SuscribirObs(this);
            CargarBackups();
            labelResp.Text= labelResp.Text + Directorio;
        }

        public void CargarBackups() 
        
        {
            listBox1.Items.Clear();

            DirectoryInfo Carpeta = new DirectoryInfo(Directorio);  
            FileInfo[] Backups = Carpeta.GetFiles("*.bak");

            foreach (FileInfo file in Backups)
            {
                 listBox1.Items.Add(file.Name);
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            try { 
            Backup bkp = new Backup();
            bkp.NuevoBackup(Directorio);
            CargarBackups();
                MessageBox.Show("Backup Realizado correctamente");
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void buttonRestaurar_Click(object sender, EventArgs e)
        {
            if (SesionSingleton.Instancia.Usuario.Mail != "admin") 
            
            {
                MessageBox.Show("Solo el usuario admin puede realzar esta operación");
            }

            else 
            
            { 
                if (listBox1.SelectedItem==null) 
                
                {

                    MessageBox.Show("Debe seleccionar un backup del listado");
                }

                else 
                
                {
                    DialogResult Respuesta = MessageBox.Show("Confirma retauración de Base de datos: "+listBox1.SelectedItem.ToString()+" ?", "Restaurar", MessageBoxButtons.YesNo);



                    if (Respuesta == DialogResult.Yes) 
                    
                    {
                        try {
                            Backup bkp = new Backup();
                            string Path = Directorio + listBox1.SelectedItem.ToString();
                            bkp.Restaurar(Path);
                            MessageBox.Show("Restauración completada");
                        }

                        catch (Exception ex) 
                        
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }


                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
