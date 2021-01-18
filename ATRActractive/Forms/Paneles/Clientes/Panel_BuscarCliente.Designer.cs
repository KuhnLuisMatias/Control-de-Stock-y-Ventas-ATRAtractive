namespace ATRActractive
{
    partial class Panel_BuscarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_BuscarCliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioCelular = new System.Windows.Forms.RadioButton();
            this.radioApellido = new System.Windows.Forms.RadioButton();
            this.radioDomicilio = new System.Windows.Forms.RadioButton();
            this.radioTelefono = new System.Windows.Forms.RadioButton();
            this.radioNombre = new System.Windows.Forms.RadioButton();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.tablaClientes = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCelular);
            this.groupBox1.Controls.Add(this.radioApellido);
            this.groupBox1.Controls.Add(this.radioDomicilio);
            this.groupBox1.Controls.Add(this.radioTelefono);
            this.groupBox1.Controls.Add(this.radioNombre);
            this.groupBox1.Controls.Add(this.txtBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 82);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // radioCelular
            // 
            this.radioCelular.AutoSize = true;
            this.radioCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioCelular.Location = new System.Drawing.Point(269, 19);
            this.radioCelular.Name = "radioCelular";
            this.radioCelular.Size = new System.Drawing.Size(75, 20);
            this.radioCelular.TabIndex = 7;
            this.radioCelular.Text = "Celular";
            this.radioCelular.UseVisualStyleBackColor = true;
            this.radioCelular.CheckedChanged += new System.EventHandler(this.radioCelular_CheckedChanged);
            // 
            // radioApellido
            // 
            this.radioApellido.AutoSize = true;
            this.radioApellido.Checked = true;
            this.radioApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioApellido.Location = new System.Drawing.Point(16, 19);
            this.radioApellido.Name = "radioApellido";
            this.radioApellido.Size = new System.Drawing.Size(84, 20);
            this.radioApellido.TabIndex = 6;
            this.radioApellido.TabStop = true;
            this.radioApellido.Text = "Apellido";
            this.radioApellido.UseVisualStyleBackColor = true;
            this.radioApellido.CheckedChanged += new System.EventHandler(this.radioApellido_CheckedChanged);
            // 
            // radioDomicilio
            // 
            this.radioDomicilio.AutoSize = true;
            this.radioDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioDomicilio.Location = new System.Drawing.Point(344, 19);
            this.radioDomicilio.Name = "radioDomicilio";
            this.radioDomicilio.Size = new System.Drawing.Size(91, 20);
            this.radioDomicilio.TabIndex = 3;
            this.radioDomicilio.Text = "Domicilio";
            this.radioDomicilio.UseVisualStyleBackColor = true;
            this.radioDomicilio.CheckedChanged += new System.EventHandler(this.radioDomicilio_CheckedChanged);
            // 
            // radioTelefono
            // 
            this.radioTelefono.AutoSize = true;
            this.radioTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioTelefono.Location = new System.Drawing.Point(181, 19);
            this.radioTelefono.Name = "radioTelefono";
            this.radioTelefono.Size = new System.Drawing.Size(88, 20);
            this.radioTelefono.TabIndex = 2;
            this.radioTelefono.Text = "Telefono";
            this.radioTelefono.UseVisualStyleBackColor = true;
            this.radioTelefono.CheckedChanged += new System.EventHandler(this.radioTelefono_CheckedChanged);
            // 
            // radioNombre
            // 
            this.radioNombre.AutoSize = true;
            this.radioNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioNombre.Location = new System.Drawing.Point(100, 19);
            this.radioNombre.Name = "radioNombre";
            this.radioNombre.Size = new System.Drawing.Size(81, 20);
            this.radioNombre.TabIndex = 1;
            this.radioNombre.Text = "Nombre";
            this.radioNombre.UseVisualStyleBackColor = true;
            this.radioNombre.CheckedChanged += new System.EventHandler(this.radioNombre_CheckedChanged);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(16, 47);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(778, 22);
            this.txtBusqueda.TabIndex = 5;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tablaClientes
            // 
            this.tablaClientes.AllowUserToAddRows = false;
            this.tablaClientes.AllowUserToDeleteRows = false;
            this.tablaClientes.AllowUserToResizeColumns = false;
            this.tablaClientes.AllowUserToResizeRows = false;
            this.tablaClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaClientes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tablaClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaClientes.ColumnHeadersHeight = 30;
            this.tablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablaClientes.EnableHeadersVisualStyles = false;
            this.tablaClientes.Location = new System.Drawing.Point(12, 103);
            this.tablaClientes.Name = "tablaClientes";
            this.tablaClientes.ReadOnly = true;
            this.tablaClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaClientes.RowHeadersVisible = false;
            this.tablaClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClientes.Size = new System.Drawing.Size(825, 251);
            this.tablaClientes.TabIndex = 32;
            this.tablaClientes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaClientes_CellContentDoubleClick);
            this.tablaClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tablaClientes_KeyDown);
            this.tablaClientes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tablaClientes_KeyPress);
            this.tablaClientes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Panel_BuscarCliente_KeyUp);
            // 
            // Panel_BuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(849, 366);
            this.Controls.Add(this.tablaClientes);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Panel_BuscarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Panel_BuscarCliente_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Panel_BuscarCliente_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioCelular;
        private System.Windows.Forms.RadioButton radioApellido;
        private System.Windows.Forms.RadioButton radioDomicilio;
        private System.Windows.Forms.RadioButton radioTelefono;
        private System.Windows.Forms.RadioButton radioNombre;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView tablaClientes;
    }
}