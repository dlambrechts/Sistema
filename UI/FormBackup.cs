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

namespace UI
{
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();
        }

        string Directorio = @"C:\Backup\"; // A futuro permitir al usuario seleccionar la carpeta
        private void FormBackup_Load(object sender, EventArgs e)
        {
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
            Backup bkp = new Backup();

            bkp.NuevoBackup(Directorio);
            CargarBackups();

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
                        Backup bkp = new Backup();
                        string Path = Directorio + listBox1.SelectedItem.ToString();
                        bkp.Restaurar(Path);
                        

                    }


                }
            }
        }
    }
}
