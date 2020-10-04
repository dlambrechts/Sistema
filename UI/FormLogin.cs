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
using Servicios.Bitacora;

namespace UI
{
    public partial class FormLogin : Form,IIdiomaObserver
    {
        public FormLogin()
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

                foreach (Control x in this.Controls) // Todos los controles

                {
                    if (x.Tag != null && Traducciones.ContainsKey(x.Tag.ToString()))
                        x.Text = Traducciones[x.Tag.ToString()].Texto;

                }

                
            }

        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            SesionSingleton.Instancia.SuscribirObs(this);
        }
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            SesionSingleton.Instancia.DesuscribirObs(this);
        }
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
                RegistroBitacora("Acceso Exitoso", (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Mensaje"));
                this.Close();
            }

            catch (ExceptionLogin Error)

            {
                switch (Error.Result)
                {
                    case ResultadoLogin.UsuarioInvalido:
                        MessageBox.Show("Usuario Incorrecto");

                        break;
                    case ResultadoLogin.PasswordInvalido:
                        MessageBox.Show("El Password ingresado es Incorrecto");
                        
                        break;

                    default:
                        break;
                }
            }
        }

        public void RegistroBitacora(string Detalle, BitacoraClasifActividad Clasificacion) 
        
        {
            BitacoraActividadBE nAct = new BitacoraActividadBE();
            BitacoraBLL bllAct = new BitacoraBLL();
            nAct.Detalle = Detalle;
            nAct.Clasificacion = Clasificacion;
            bllAct.NuevaActividad(nAct);
        }


    }
}
