namespace ATRActractive.Forms.Paneles
{
    partial class Panel_Retirar
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_Retirar));
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.tablaMovimientos = new System.Windows.Forms.DataGridView();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablaMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label15.Location = new System.Drawing.Point(279, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 20);
            this.label15.TabIndex = 78;
            this.label15.Text = "Monto";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label14.Location = new System.Drawing.Point(7, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 77;
            this.label14.Text = "Razón";
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMonto.Location = new System.Drawing.Point(339, 19);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(82, 26);
            this.txtMonto.TabIndex = 75;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // txtRazon
            // 
            this.txtRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRazon.Location = new System.Drawing.Point(69, 19);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(204, 26);
            this.txtRazon.TabIndex = 72;
            // 
            // tablaMovimientos
            // 
            this.tablaMovimientos.AllowUserToAddRows = false;
            this.tablaMovimientos.AllowUserToDeleteRows = false;
            this.tablaMovimientos.AllowUserToResizeColumns = false;
            this.tablaMovimientos.AllowUserToResizeRows = false;
            this.tablaMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaMovimientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaMovimientos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tablaMovimientos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaMovimientos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaMovimientos.ColumnHeadersHeight = 30;
            this.tablaMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaMovimientos.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablaMovimientos.EnableHeadersVisualStyles = false;
            this.tablaMovimientos.Location = new System.Drawing.Point(10, 111);
            this.tablaMovimientos.Name = "tablaMovimientos";
            this.tablaMovimientos.ReadOnly = true;
            this.tablaMovimientos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaMovimientos.RowHeadersVisible = false;
            this.tablaMovimientos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaMovimientos.Size = new System.Drawing.Size(411, 176);
            this.tablaMovimientos.TabIndex = 71;
            this.tablaMovimientos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaMovimientos_CellClick);
            this.tablaMovimientos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tablaMovimientos_KeyPress);
            // 
            // btnExtraer
            // 
            this.btnExtraer.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExtraer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtraer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExtraer.ForeColor = System.Drawing.Color.White;
            this.btnExtraer.Location = new System.Drawing.Point(10, 60);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(414, 36);
            this.btnExtraer.TabIndex = 79;
            this.btnExtraer.Text = "Extraer";
            this.btnExtraer.UseVisualStyleBackColor = false;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // Panel_Retirar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 295);
            this.Controls.Add(this.btnExtraer);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtRazon);
            this.Controls.Add(this.tablaMovimientos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Panel_Retirar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extraer dinero";
            this.Load += new System.EventHandler(this.Panel_Retirar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Panel_Retirar_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tablaMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.DataGridView tablaMovimientos;
        private System.Windows.Forms.Button btnExtraer;
        private System.Windows.Forms.ErrorProvider errorIcono;
    }
}