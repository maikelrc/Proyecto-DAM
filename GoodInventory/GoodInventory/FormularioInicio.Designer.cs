namespace GoodInventory
{
    partial class FormularioInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioInicio));
            this.btnNuevoInventario = new System.Windows.Forms.Button();
            this.btnAbrirInventario = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcionTitulo = new System.Windows.Forms.Label();
            this.lblOpcion = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnNuevoInventario
            // 
            this.btnNuevoInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoInventario.AutoEllipsis = true;
            this.btnNuevoInventario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNuevoInventario.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoInventario.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoInventario.Location = new System.Drawing.Point(50, 165);
            this.btnNuevoInventario.Name = "btnNuevoInventario";
            this.btnNuevoInventario.Size = new System.Drawing.Size(148, 76);
            this.btnNuevoInventario.TabIndex = 0;
            this.btnNuevoInventario.Text = "&NUEVO INVENTARIO";
            this.toolTip1.SetToolTip(this.btnNuevoInventario, "Crea un inventario nuevo (Base de datos) en la ruta deseada.");
            this.btnNuevoInventario.UseVisualStyleBackColor = true;
            this.btnNuevoInventario.Click += new System.EventHandler(this.btnNuevoInventario_Click);
            // 
            // btnAbrirInventario
            // 
            this.btnAbrirInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirInventario.AutoEllipsis = true;
            this.btnAbrirInventario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbrirInventario.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirInventario.ForeColor = System.Drawing.Color.Black;
            this.btnAbrirInventario.Location = new System.Drawing.Point(314, 165);
            this.btnAbrirInventario.Name = "btnAbrirInventario";
            this.btnAbrirInventario.Size = new System.Drawing.Size(148, 76);
            this.btnAbrirInventario.TabIndex = 1;
            this.btnAbrirInventario.Text = "&ABRIR INVENTARIO";
            this.toolTip1.SetToolTip(this.btnAbrirInventario, "Abre un inventario existente (Base de datos).");
            this.btnAbrirInventario.UseVisualStyleBackColor = true;
            this.btnAbrirInventario.Click += new System.EventHandler(this.btnAbrirInventario_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(161, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(197, 29);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "GOOD INVENTORY";
            // 
            // lblDescripcionTitulo
            // 
            this.lblDescripcionTitulo.AutoSize = true;
            this.lblDescripcionTitulo.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionTitulo.Location = new System.Drawing.Point(176, 52);
            this.lblDescripcionTitulo.Name = "lblDescripcionTitulo";
            this.lblDescripcionTitulo.Size = new System.Drawing.Size(168, 17);
            this.lblDescripcionTitulo.TabIndex = 3;
            this.lblDescripcionTitulo.Text = "SU GESTOR DE INVENTARIO";
            // 
            // lblOpcion
            // 
            this.lblOpcion.AutoSize = true;
            this.lblOpcion.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcion.Location = new System.Drawing.Point(162, 119);
            this.lblOpcion.Name = "lblOpcion";
            this.lblOpcion.Size = new System.Drawing.Size(198, 21);
            this.lblOpcion.TabIndex = 4;
            this.lblOpcion.Text = "SELECCIONE UNA OPCIÓN:";
            // 
            // FormularioInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(526, 335);
            this.Controls.Add(this.lblOpcion);
            this.Controls.Add(this.lblDescripcionTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnAbrirInventario);
            this.Controls.Add(this.btnNuevoInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormularioInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FormularioInicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoInventario;
        private System.Windows.Forms.Button btnAbrirInventario;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcionTitulo;
        private System.Windows.Forms.Label lblOpcion;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

