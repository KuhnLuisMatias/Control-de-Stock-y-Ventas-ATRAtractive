using FirebirdSql.Data.FirebirdClient;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATRActractive
{
    public partial class Inicio : Form
    {
        private CN_Inicio cn_inicio = new CN_Inicio();
        private string user, pass;
        private Thread th;

        public Inicio()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            
              if (cn_inicio.iniciarSesion(txtUser.Text,txtPass.Text))
                {
                    user = txtUser.Text;
                    pass = txtPass.Text;
                    th = new Thread(iniciar_programa);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrectos", "Atención");
                }
            }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Ingresar();
            }
        }

        private void iniciar_programa(object obj)
        {
            Application.Run(new Panel_Principal(cn_inicio.retornarUsuario(user, pass)));
        }
    }
}
