namespace ATRActractive.Forms.Paneles.Pedidos
{
    partial class Panel_Entregados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_Entregados));
            this.btnModificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tablaPedidosAsignados = new System.Windows.Forms.DataGridView();
            this.tablaArticulos = new System.Windows.Forms.DataGridView();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCBU = new System.Windows.Forms.Button();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPedidosAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Crimson;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(12, 430);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(218, 42);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar Estado";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(729, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Artículos del pedido";
            // 
            // tablaPedidosAsignados
            // 
            this.tablaPedidosAsignados.AllowUserToAddRows = false;
            this.tablaPedidosAsignados.AllowUserToDeleteRows = false;
            this.tablaPedidosAsignados.AllowUserToResizeColumns = false;
            this.tablaPedidosAsignados.AllowUserToResizeRows = false;
            this.tablaPedidosAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaPedidosAsignados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaPedidosAsignados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tablaPedidosAsignados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaPedidosAsignados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaPedidosAsignados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaPedidosAsignados.ColumnHeadersHeight = 30;
            this.tablaPedidosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaPedidosAsignados.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablaPedidosAsignados.EnableHeadersVisualStyles = false;
            this.tablaPedidosAsignados.Location = new System.Drawing.Point(12, 56);
            this.tablaPedidosAsignados.Name = "tablaPedidosAsignados";
            this.tablaPedidosAsignados.ReadOnly = true;
            this.tablaPedidosAsignados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaPedidosAsignados.RowHeadersVisible = false;
            this.tablaPedidosAsignados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaPedidosAsignados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaPedidosAsignados.Size = new System.Drawing.Size(711, 358);
            this.tablaPedidosAsignados.TabIndex = 35;
            this.tablaPedidosAsignados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaPedidosAsignados_CellClick);
            this.tablaPedidosAsignados.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tablaPedidosAsignados_KeyUp);
            // 
            // tablaArticulos
            // 
            this.tablaArticulos.AllowUserToAddRows = false;
            this.tablaArticulos.AllowUserToDeleteRows = false;
            this.tablaArticulos.AllowUserToResizeColumns = false;
            this.tablaArticulos.AllowUserToResizeRows = false;
            this.tablaArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaArticulos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tablaArticulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaArticulos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablaArticulos.ColumnHeadersHeight = 30;
            this.tablaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaArticulos.DefaultCellStyle = dataGridViewCellStyle4;
            this.tablaArticulos.EnableHeadersVisualStyles = false;
            this.tablaArticulos.Location = new System.Drawing.Point(729, 56);
            this.tablaArticulos.Name = "tablaArticulos";
            this.tablaArticulos.ReadOnly = true;
            this.tablaArticulos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaArticulos.RowHeadersVisible = false;
            this.tablaArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaArticulos.Size = new System.Drawing.Size(276, 358);
            this.tablaArticulos.TabIndex = 36;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(46, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(436, 22);
            this.txtCodigo.TabIndex = 41;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ATRActractive.Properties.Resources.search;
            this.pictureBox2.Location = new System.Drawing.Point(15, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            // 
            // btnCBU
            // 
            this.btnCBU.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCBU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCBU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCBU.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCBU.Image = global::ATRActractive.Properties.Resources.bank;
            this.btnCBU.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCBU.Location = new System.Drawing.Point(786, 430);
            this.btnCBU.Name = "btnCBU";
            this.btnCBU.Size = new System.Drawing.Size(218, 42);
            this.btnCBU.TabIndex = 42;
            this.btnCBU.Text = "Pagar por CBU";
            this.btnCBU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCBU.UseVisualStyleBackColor = false;
            this.btnCBU.Click += new System.EventHandler(this.btnCBU_Click);
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjeta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTarjeta.Image = global::ATRActractive.Properties.Resources.tarjeta_maestra__1_;
            this.btnTarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTarjeta.Location = new System.Drawing.Point(525, 430);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(218, 42);
            this.btnTarjeta.TabIndex = 43;
            this.btnTarjeta.Text = "Pagar x Tarjeta";
            this.btnTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTarjeta.UseVisualStyleBackColor = false;
            this.btnTarjeta.Click += new System.EventHandler(this.btnTarjeta_Click);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfectivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEfectivo.Image = global::ATRActractive.Properties.Resources.money;
            this.btnEfectivo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEfectivo.Location = new System.Drawing.Point(264, 430);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(218, 42);
            this.btnEfectivo.TabIndex = 44;
            this.btnEfectivo.Text = "Pagar con Efectivo";
            this.btnEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEfectivo.UseVisualStyleBackColor = false;
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click);
            // 
            // Panel_Entregados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 484);
            this.Controls.Add(this.btnEfectivo);
            this.Controls.Add(this.btnTarjeta);
            this.Controls.Add(this.btnCBU);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tablaArticulos);
            this.Controls.Add(this.tablaPedidosAsignados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnModificar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Panel_Entregados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Pane_Entregados_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Panel_Entregados_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tablaPedidosAsignados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tablaPedidosAsignados;
        private System.Windows.Forms.DataGridView tablaArticulos;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCBU;
        private System.Windows.Forms.Button btnTarjeta;
        private System.Windows.Forms.Button btnEfectivo;
    }
}