using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATRActractive.Forms
{
    public partial class ABM_Persona : Form
    {
        private CN_Cadete cadete = new CN_Cadete();

        private CN_Cliente cliente = new CN_Cliente();

        private int tipo_persona;

        private bool modificar;

        private string id_persona, nombre, apellido, direccion, telefono, celular, patente,id_usuario;

        public int Tipo_persona { get => tipo_persona; set => tipo_persona = value; }

        public bool Modificar { get => modificar; set => modificar = value; }

        public string Id_persona { get => id_persona; set => id_persona = value; }

        public string Nombre { get => nombre; set => nombre = value; }

        public string Apellido { get => apellido; set => apellido = value; }

        public string Direccion { get => direccion; set => direccion = value; }

        public string Telefono { get => telefono; set => telefono = value; }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtTelefono.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtCelular.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void ABM_Persona_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        public string Celular { get => celular; set => celular = value; }

        public string Patente { get => patente; set => patente = value; }

        public string Id_usuario { get => id_usuario; set => id_usuario = value; }

        public ABM_Persona()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtApellido, "Ingrese Apellido");
                txtApellido.Focus();
            }
            else if (txtNombre.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtNombre, "Ingrese Nombre");
                txtNombre.Focus();
            }
            else if (txtDireccion.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtDireccion, "Ingrese Dirección");
                txtDireccion.Focus();
            }
            else
            {
                switch (Tipo_persona)
                {
                    case 1:
                        if (Modificar == true)
                        {
                            MessageBox.Show(cliente.modificar(Id_persona, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text), "Atención");
                            this.Dispose();
                        }
                        else
                        {
                            cliente.insertar(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, Id_usuario);
                            this.Dispose();
                            txtNombre.Text = "";
                            txtApellido.Text = "";
                            txtDireccion.Text = "";
                            txtTelefono.Text = "";
                            txtCelular.Text = "";
                        }
                        break;

                    case 2:
                        if (Modificar == true)
                        {
                            MessageBox.Show(cadete.modificar(Id_persona, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, txtPatente.Text), "Atención");
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show(cadete.insertar(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, txtPatente.Text));
                            txtNombre.Text = "";
                            txtApellido.Text = "";
                            txtDireccion.Text = "";
                            txtTelefono.Text = "";
                            txtCelular.Text = "";
                            txtPatente.Text = "Patente";
                        }
                        break;
                }
            }

            
        }

        private void ABM_Persona_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            if (Tipo_persona == 2)
            {
                lblTitulo.Text = "Panel Cadete";
                txtPatente.Visible = true;
            }
            else
            {
                lblTitulo.Text = "Panel Cliente";
                txtPatente.Visible = false;
            }

            if (Modificar == true)
            {
                btnSave.Text = "Modificar";
                txtNombre.Text = Nombre;
                txtApellido.Text = Apellido;
                txtDireccion.Text = Direccion;
                txtTelefono.Text = Telefono;
                txtCelular.Text = Celular;

                if (Tipo_persona == 2)
                {
                    txtPatente.Text = Patente;
                }
            }
        }

    }
}
