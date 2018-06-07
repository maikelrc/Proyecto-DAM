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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblEnlace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNuevoInventario
            // 
            this.btnNuevoInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoInventario.AutoEllipsis = true;
            this.btnNuevoInventario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNuevoInventario.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoInventario.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoInventario.Location = new System.Drawing.Point(38, 134);
            this.btnNuevoInventario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNuevoInventario.Name = "btnNuevoInventario";
            this.btnNuevoInventario.Size = new System.Drawing.Size(111, 62);
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
            this.btnAbrirInventario.Location = new System.Drawing.Point(236, 134);
            this.btnAbrirInventario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAbrirInventario.Name = "btnAbrirInventario";
            this.btnAbrirInventario.Size = new System.Drawing.Size(111, 62);
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
            this.lblTitulo.Location = new System.Drawing.Point(121, 7);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(157, 23);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "GOOD INVENTORY";
            // 
            // lblDescripcionTitulo
            // 
            this.lblDescripcionTitulo.AutoSize = true;
            this.lblDescripcionTitulo.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionTitulo.Location = new System.Drawing.Point(132, 42);
            this.lblDescripcionTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcionTitulo.Name = "lblDescripcionTitulo";
            this.lblDescripcionTitulo.Size = new System.Drawing.Size(128, 13);
            this.lblDescripcionTitulo.TabIndex = 3;
            this.lblDescripcionTitulo.Text = "SU GESTOR DE INVENTARIO";
            // 
            // lblOpcion
            // 
            this.lblOpcion.AutoSize = true;
            this.lblOpcion.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcion.Location = new System.Drawing.Point(122, 97);
            this.lblOpcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpcion.Name = "lblOpcion";
            this.lblOpcion.Size = new System.Drawing.Size(159, 17);
            this.lblOpcion.TabIndex = 4;
            this.lblOpcion.Text = "SELECCIONE UNA OPCIÓN:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(35, 244);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(354, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.microsoft.com/es-es/download/confirmation.aspx?id=50040";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblEnlace
            // 
            this.lblEnlace.AutoSize = true;
            this.lblEnlace.Location = new System.Drawing.Point(35, 226);
            this.lblEnlace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEnlace.Name = "lblEnlace";
            this.lblEnlace.Size = new System.Drawing.Size(264, 13);
            this.lblEnlace.TabIndex = 6;
            this.lblEnlace.Text = "Enlace del plugin Access necesario para la aplicación:";
            this.lblEnlace.Visible = false;
            // 
            // FormularioInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(394, 272);
            this.Controls.Add(this.lblEnlace);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblOpcion);
            this.Controls.Add(this.lblDescripcionTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnAbrirInventario);
            this.Controls.Add(this.btnNuevoInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormularioInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
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
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblEnlace;
    }
}

