namespace GoodInventory
{
    partial class FormularioEditarCampos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioEditarCampos));
            this.lblNombreCampo = new System.Windows.Forms.Label();
            this.lblTipoCampo = new System.Windows.Forms.Label();
            this.tbNombreCampo = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbTipos = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lvCampos = new System.Windows.Forms.ListView();
            this.chVacia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRenombrar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblNombreCampo
            // 
            this.lblNombreCampo.AutoSize = true;
            this.lblNombreCampo.Location = new System.Drawing.Point(87, 33);
            this.lblNombreCampo.Name = "lblNombreCampo";
            this.lblNombreCampo.Size = new System.Drawing.Size(80, 13);
            this.lblNombreCampo.TabIndex = 0;
            this.lblNombreCampo.Text = "Nombre Campo";
            // 
            // lblTipoCampo
            // 
            this.lblTipoCampo.AutoSize = true;
            this.lblTipoCampo.Location = new System.Drawing.Point(334, 33);
            this.lblTipoCampo.Name = "lblTipoCampo";
            this.lblTipoCampo.Size = new System.Drawing.Size(62, 13);
            this.lblTipoCampo.TabIndex = 1;
            this.lblTipoCampo.Text = "Tipo Campo";
            // 
            // tbNombreCampo
            // 
            this.tbNombreCampo.Location = new System.Drawing.Point(76, 62);
            this.tbNombreCampo.Name = "tbNombreCampo";
            this.tbNombreCampo.Size = new System.Drawing.Size(118, 20);
            this.tbNombreCampo.TabIndex = 0;
            this.tbNombreCampo.TabStop = false;
            // 
            // cbTipos
            // 
            this.cbTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTipos.FormattingEnabled = true;
            this.cbTipos.Items.AddRange(new object[] {
            "Cadena",
            "Número",
            "Número (PK)"});
            this.cbTipos.Location = new System.Drawing.Point(313, 62);
            this.cbTipos.Name = "cbTipos";
            this.cbTipos.Size = new System.Drawing.Size(121, 21);
            this.cbTipos.TabIndex = 1;
            this.cbTipos.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(12, 126);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 39);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "AGREGAR";
            this.toolTip1.SetToolTip(this.btnAgregar, "Agrega un nuevo campo a esta tabla.");
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(270, 126);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 39);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "ELIMINAR";
            this.toolTip1.SetToolTip(this.btnEliminar, "Elimina el campo deseado.");
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(402, 126);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 39);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "LIMPIAR";
            this.toolTip1.SetToolTip(this.btnLimpiar, "Elimina todos los campos y datos de la tabla a excepción de las claves primarias." +
        "");
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // lvCampos
            // 
            this.lvCampos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvCampos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chVacia,
            this.chNombre,
            this.chTipo});
            this.lvCampos.Location = new System.Drawing.Point(12, 180);
            this.lvCampos.Name = "lvCampos";
            this.lvCampos.Size = new System.Drawing.Size(490, 275);
            this.lvCampos.TabIndex = 7;
            this.lvCampos.TabStop = false;
            this.lvCampos.UseCompatibleStateImageBehavior = false;
            this.lvCampos.View = System.Windows.Forms.View.Details;
            // 
            // chVacia
            // 
            this.chVacia.Text = "";
            this.chVacia.Width = 0;
            // 
            // chNombre
            // 
            this.chNombre.Text = "Nombre";
            // 
            // chTipo
            // 
            this.chTipo.Text = "Tipo";
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(249, 62);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(0, 0);
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(52, 97);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 32;
            // 
            // btnRenombrar
            // 
            this.btnRenombrar.BackColor = System.Drawing.Color.White;
            this.btnRenombrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenombrar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenombrar.Location = new System.Drawing.Point(138, 126);
            this.btnRenombrar.Name = "btnRenombrar";
            this.btnRenombrar.Size = new System.Drawing.Size(100, 39);
            this.btnRenombrar.TabIndex = 3;
            this.btnRenombrar.Text = "RENOMBRAR";
            this.toolTip1.SetToolTip(this.btnRenombrar, "Renombra el campo deseado.");
            this.btnRenombrar.UseVisualStyleBackColor = false;
            // 
            // FormularioEditarCampos
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(514, 467);
            this.Controls.Add(this.btnRenombrar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lvCampos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cbTipos);
            this.Controls.Add(this.tbNombreCampo);
            this.Controls.Add(this.lblTipoCampo);
            this.Controls.Add(this.lblNombreCampo);
            this.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormularioEditarCampos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Campos";
            this.toolTip1.SetToolTip(this, "Agrega un nuevo campo a la tabla actual.");
            this.Load += new System.EventHandler(this.FormularioEditarCampos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreCampo;
        private System.Windows.Forms.Label lblTipoCampo;
        public System.Windows.Forms.TextBox tbNombreCampo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.ComboBox cbTipos;
        public System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.ListView lvCampos;
        private System.Windows.Forms.ColumnHeader chVacia;
        private System.Windows.Forms.ColumnHeader chNombre;
        private System.Windows.Forms.ColumnHeader chTipo;
        private System.Windows.Forms.Button btnCerrar;
        public System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.Button btnRenombrar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}