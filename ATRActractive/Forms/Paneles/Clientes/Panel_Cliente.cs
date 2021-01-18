using Negocio;
using Negocio.Clases;
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
    public partial class Panel_Cliente : Form
    {
        private CN_Cliente cliente = new CN_Cliente();

        private Cliente cliente2 = new Cliente();

        private string usuario;

        private bool selectedB,clienteSeleccionado;

        private int selected;

        public int Selected { get => selected; set => selected = value; }

        public bool SelectedB { get => selectedB; set => selectedB = value; }

        public string Usuario { get => usuario; set => usuario = value; }

        public Panel_Cliente()
        {
            InitializeComponent();
        }

        private void mostrarClientes()
        {
            tablaClientes.DataSource = cliente.mostrar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaClientes.Rows.Count != 0 && tablaClientes.Rows != null)
            {
                if (clienteSeleccionado)
                {
                    DialogResult resultado;

                    resultado = MessageBox.Show("¿ Esta seguro que desea eliminar : " + tablaClientes.CurrentRow.Cells[1].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);

                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show(cliente.eliminar(tablaClientes.CurrentRow.Cells[0].Value.ToString()), "Atención");

                        mostrarClientes();
                    }
                    clienteSeleccionado = false;
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tablaClientes.Rows.Count != 0 && tablaClientes.Rows != null)
            {
                if (clienteSeleccionado)
                {
                    ABM_Persona p = new ABM_Persona();

                    p.Tipo_persona = 1;

                    p.Modificar = true;

                    p.Id_persona = tablaClientes.CurrentRow.Cells[0].Value.ToString();

                    p.Apellido = tablaClientes.CurrentRow.Cells[1].Value.ToString();

                    p.Nombre = tablaClientes.CurrentRow.Cells[2].Value.ToString();

                    p.Direccion = tablaClientes.CurrentRow.Cells[3].Value.ToString();

                    p.Telefono = tablaClientes.CurrentRow.Cells[4].Value.ToString();

                    p.Celular = tablaClientes.CurrentRow.Cells[5].Value.ToString();

                    p.ShowDialog();

                    mostrarClientes();

                    clienteSeleccionado = false;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ABM_Persona cliente = new ABM_Persona();

            cliente.Id_usuario = usuario;

            cliente.Tipo_persona = 1;

            cliente.ShowDialog();

            mostrarClientes();
        }

        private void Panel_Cliente_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            Selected = 1;

            mostrarClientes();

            tablaClientes.Columns[0].Visible = false;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            switch (Selected)
            {
                case 1:
                    filtrarTabla(1);
                    break;

                case 2:
                    filtrarTabla(2);
                    break;

                case 3:
                    filtrarTabla(3);
                    break;

                case 4:
                    filtrarTabla(4);
                    break;

                case 5:
                    filtrarTabla(5);
                    break;
            }
        }

        private void filtrarTabla(int opcion)
        {
            tablaClientes.DataSource = cliente.filtrar(opcion, txtBusqueda.Text);
        }

        private void radioApellido_CheckedChanged(object sender, EventArgs e)
        {
            Selected = 1;
        }

        private void radioNombre_CheckedChanged(object sender, EventArgs e)
        {
            Selected = 2;
        }

        private void radioTelefono_CheckedChanged(object sender, EventArgs e)
        {
            Selected = 3;
        }

        private void radioCelular_CheckedChanged(object sender, EventArgs e)
        {
            Selected = 4;
        }

        private void radioDomicilio_CheckedChanged(object sender, EventArgs e)
        {
            Selected = 5;
        }

        private void tablaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaClientes.Rows.Count != 0 && tablaClientes.Rows != null)
            {
                clienteSeleccionado = true;
            }
        }

        private void tablaClientes_KeyUp(object sender, KeyEventArgs e)
        {
            if (tablaClientes.Rows.Count != 0 && tablaClientes.Rows != null)
            {
                clienteSeleccionado = true;
            }
        }

        private void Panel_BuscarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedB = false;

                this.Dispose();
            }
        }

    }
}
