namespace ATRActractive.Forms
{
    partial class Panel_BuscarArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_BuscarArticulo));
            this.tablaArticulos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaArticulos)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaArticulos.ColumnHeadersHeight = 30;
            this.tablaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaArticulos.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablaArticulos.EnableHeadersVisualStyles = false;
            this.tablaArticulos.Location = new System.Drawing.Point(12, 12);
            this.tablaArticulos.Name = "tablaArticulos";
            this.tablaArticulos.ReadOnly = true;
            this.tablaArticulos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaArticulos.RowHeadersVisible = false;
            this.tablaArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaArticulos.Size = new System.Drawing.Size(692, 207);
            this.tablaArticulos.TabIndex = 31;
            this.tablaArticulos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListadoProductos_CellContentDoubleClick);
            this.tablaArticulos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tablaArticulos_CellFormatting);
            this.tablaArticulos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tablaArticulos_KeyDown);
            this.tablaArticulos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tablaArticulos_KeyPress);
            // 
            // Panel_BuscarArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(91)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(716, 231);
            this.Controls.Add(this.tablaArticulos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Panel_BuscarArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel_BuscarArticulo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Panel_BuscarArticulo_FormClosing);
            this.Load += new System.EventHandler(this.Panel_BuscarArticulo_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Panel_BuscarArticulo_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tablaArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaArticulos;
    }
}