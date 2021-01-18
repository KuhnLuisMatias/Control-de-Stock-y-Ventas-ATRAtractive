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

namespace ATRActractive
{
    public partial class Panel_BuscarCliente : Form
    {
        private CN_Cliente cliente = new CN_Cliente();

        private Cliente cliente2 = new Cliente();

        private bool selectedB;

        private int selected;

        public int Selected { get => selected; set => selected = value; }

        public bool SelectedB { get => selectedB; set => selectedB = value; }

        public Cliente Cliente2 { get => cliente2; set => cliente2 = value; }

        public Panel_BuscarCliente()
        {
            InitializeComponent();
        }

        private void radioApellido_CheckedChanged(object sender, EventArgs e)
        {
            Selected = 1;
        }

        private void tablaClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaClientes.Rows.Count != 0 && tablaClientes.Rows != null)
            {
                SelectedB = true;

                Cliente2.Id_cliente = tablaClientes.CurrentRow.Cells[0].Value.ToString();

                Cliente2.Apellido = tablaClientes.CurrentRow.Cells[1].Value.ToString();

                Cliente2.Nombre = tablaClientes.CurrentRow.Cells[2].Value.ToString();

                Cliente2.Direccion = tablaClientes.CurrentRow.Cells[3].Value.ToString();

                Cliente2.Telefono = tablaClientes.CurrentRow.Cells[4].Value.ToString();

                Cliente2.Celular = tablaClientes.CurrentRow.Cells[5].Value.ToString();

                this.Dispose();
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void Panel_BuscarCliente_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            Selected = 1;
            nuevoCliente();   
        }

        private void nuevoCliente()
        {
            tablaClientes.Rows.Clear();

            tablaClientes.DataSource = cliente.mostrar();

            tablaClientes.ReadOnly = true;

            tablaClientes.Columns[0].Visible = false;

            tablaClientes.Columns[1].Width = 100;

            tablaClientes.Columns[2].Width = 100;

            tablaClientes.Columns[3].Width = 348;

            tablaClientes.Columns[4].Width = 137;

            tablaClientes.Columns[5].Width = 137;

            tablaClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tablaClientes.RowHeadersVisible = false;
        }

        private void filtrarTabla(int opcion)
        {
            tablaClientes.DataSource = cliente.filtrar(opcion, txtBusqueda.Text);

            tablaClientes.Columns[0].Visible = false;
        }

        private void tablaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (tablaClientes.Rows.Count != 0 && tablaClientes.Rows != null)
            {
                SelectedB = true;

                Cliente2.Id_cliente = tablaClientes.CurrentRow.Cells[0].Value.ToString();

                Cliente2.Apellido = tablaClientes.CurrentRow.Cells[1].Value.ToString();

                Cliente2.Nombre = tablaClientes.CurrentRow.Cells[2].Value.ToString();

                Cliente2.Direccion = tablaClientes.CurrentRow.Cells[3].Value.ToString();

                Cliente2.Telefono = tablaClientes.CurrentRow.Cells[4].Value.ToString();

                Cliente2.Celular = tablaClientes.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void tablaClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (tablaClientes.Rows.Count != 0 && tablaClientes.Rows != null)
                {
                    this.Dispose();
                }
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
