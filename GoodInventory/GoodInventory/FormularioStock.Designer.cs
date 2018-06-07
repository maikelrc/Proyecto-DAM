namespace GoodInventory
{
    partial class FormularioStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioStock));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.InfoText, System.Drawing.Color.Empty, null);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTablas = new System.Windows.Forms.ListBox();
            this.lvDatos = new System.Windows.Forms.ListView();
            this.btnDelTabla = new System.Windows.Forms.Button();
            this.btnAddTabla = new System.Windows.Forms.Button();
            this.btnEditarCampos = new System.Windows.Forms.Button();
            this.btnRenombrarTabla = new System.Windows.Forms.Button();
            this.btnAddFila = new System.Windows.Forms.Button();
            this.btnDelFila = new System.Windows.Forms.Button();
            this.btnDelTodo = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.acercadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.acercadeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.nuevoToolStripMenuItem.Text = "&Nuevo Inventario";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripMenuItem.Image")));
            this.abrirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.abrirToolStripMenuItem.Text = "&Abrir Inventario";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(257, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tablas";
            // 
            // lbTablas
            // 
            this.lbTablas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbTablas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTablas.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTablas.FormattingEnabled = true;
            this.lbTablas.ItemHeight = 15;
            this.lbTablas.Location = new System.Drawing.Point(16, 89);
            this.lbTablas.Name = "lbTablas";
            this.lbTablas.Size = new System.Drawing.Size(199, 510);
            this.lbTablas.TabIndex = 2;
            this.lbTablas.SelectedIndexChanged += new System.EventHandler(this.lbTablas_SelectedIndexChanged);
            // 
            // lvDatos
            // 
            this.lvDatos.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDatos.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lvDatos.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvDatos.LabelEdit = true;
            this.lvDatos.Location = new System.Drawing.Point(310, 46);
            this.lvDatos.Name = "lvDatos";
            this.lvDatos.Size = new System.Drawing.Size(853, 553);
            this.lvDatos.TabIndex = 3;
            this.lvDatos.UseCompatibleStateImageBehavior = false;
            this.lvDatos.View = System.Windows.Forms.View.Details;
            this.lvDatos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDatos_ColumnClick);
            this.lvDatos.SizeChanged += new System.EventHandler(this.lvDatos_SizeChanged);
            this.lvDatos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvDatos_MouseDown);
            // 
            // btnDelTabla
            // 
            this.btnDelTabla.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDelTabla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelTabla.BackgroundImage")));
            this.btnDelTabla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelTabla.FlatAppearance.BorderSize = 0;
            this.btnDelTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelTabla.Location = new System.Drawing.Point(162, 49);
            this.btnDelTabla.Name = "btnDelTabla";
            this.btnDelTabla.Size = new System.Drawing.Size(20, 20);
            this.btnDelTabla.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnDelTabla, "Elimina la tabla actualmente seleccionada de la base de datos con previa confirma" +
        "ción.");
            this.btnDelTabla.UseVisualStyleBackColor = false;
            this.btnDelTabla.Click += new System.EventHandler(this.btnDelTabla_Click);
            // 
            // btnAddTabla
            // 
            this.btnAddTabla.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAddTabla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddTabla.BackgroundImage")));
            this.btnAddTabla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTabla.FlatAppearance.BorderSize = 0;
            this.btnAddTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTabla.Location = new System.Drawing.Point(130, 49);
            this.btnAddTabla.Name = "btnAddTabla";
            this.btnAddTabla.Size = new System.Drawing.Size(20, 20);
            this.btnAddTabla.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnAddTabla, "Añade una nueva tabla a la base de datos.");
            this.btnAddTabla.UseVisualStyleBackColor = false;
            this.btnAddTabla.Click += new System.EventHandler(this.btnAddTabla_Click);
            // 
            // btnEditarCampos
            // 
            this.btnEditarCampos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditarCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCampos.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCampos.Location = new System.Drawing.Point(229, 46);
            this.btnEditarCampos.Name = "btnEditarCampos";
            this.btnEditarCampos.Size = new System.Drawing.Size(75, 53);
            this.btnEditarCampos.TabIndex = 6;
            this.btnEditarCampos.Text = "EDITAR CAMPOS";
            this.btnEditarCampos.UseVisualStyleBackColor = false;
            this.btnEditarCampos.Click += new System.EventHandler(this.btnEditarCampos_Click);
            // 
            // btnRenombrarTabla
            // 
            this.btnRenombrarTabla.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRenombrarTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenombrarTabla.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenombrarTabla.Location = new System.Drawing.Point(229, 105);
            this.btnRenombrarTabla.Name = "btnRenombrarTabla";
            this.btnRenombrarTabla.Size = new System.Drawing.Size(75, 70);
            this.btnRenombrarTabla.TabIndex = 7;
            this.btnRenombrarTabla.Text = "CAMBIAR NOMBRE TABLA";
            this.btnRenombrarTabla.UseVisualStyleBackColor = false;
            this.btnRenombrarTabla.Click += new System.EventHandler(this.btnRenombrarTabla_Click);
            // 
            // btnAddFila
            // 
            this.btnAddFila.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddFila.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFila.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFila.Location = new System.Drawing.Point(229, 181);
            this.btnAddFila.Name = "btnAddFila";
            this.btnAddFila.Size = new System.Drawing.Size(75, 53);
            this.btnAddFila.TabIndex = 8;
            this.btnAddFila.Text = "AÑADIR FILA";
            this.btnAddFila.UseVisualStyleBackColor = false;
            this.btnAddFila.Click += new System.EventHandler(this.btnAddFila_Click);
            // 
            // btnDelFila
            // 
            this.btnDelFila.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelFila.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelFila.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelFila.Location = new System.Drawing.Point(229, 240);
            this.btnDelFila.Name = "btnDelFila";
            this.btnDelFila.Size = new System.Drawing.Size(75, 70);
            this.btnDelFila.TabIndex = 9;
            this.btnDelFila.Text = "BORRAR FILA";
            this.btnDelFila.UseVisualStyleBackColor = false;
            this.btnDelFila.Click += new System.EventHandler(this.btnDelFila_Click);
            // 
            // btnDelTodo
            // 
            this.btnDelTodo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelTodo.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelTodo.Location = new System.Drawing.Point(229, 316);
            this.btnDelTodo.Name = "btnDelTodo";
            this.btnDelTodo.Size = new System.Drawing.Size(75, 53);
            this.btnDelTodo.TabIndex = 10;
            this.btnDelTodo.Text = "BORRAR TODO";
            this.btnDelTodo.UseVisualStyleBackColor = false;
            this.btnDelTodo.Click += new System.EventHandler(this.btnDelTodo_Click);
            // 
            // acercadeToolStripMenuItem
            // 
            this.acercadeToolStripMenuItem.Name = "acercadeToolStripMenuItem";
            this.acercadeToolStripMenuItem.Size = new System.Drawing.Size(101, 25);
            this.acercadeToolStripMenuItem.Text = "Acerca &de...";
            this.acercadeToolStripMenuItem.Click += new System.EventHandler(this.acercadeToolStripMenuItem_Click);
            // 
            // FormularioStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1175, 617);
            this.Controls.Add(this.btnDelTodo);
            this.Controls.Add(this.btnDelFila);
            this.Controls.Add(this.btnAddFila);
            this.Controls.Add(this.btnRenombrarTabla);
            this.Controls.Add(this.btnEditarCampos);
            this.Controls.Add(this.btnAddTabla);
            this.Controls.Add(this.btnDelTabla);
            this.Controls.Add(this.lvDatos);
            this.Controls.Add(this.lbTablas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormularioStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.FormularioStock_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbTablas;
        private System.Windows.Forms.ListView lvDatos;
        private System.Windows.Forms.Button btnDelTabla;
        private System.Windows.Forms.Button btnAddTabla;
        private System.Windows.Forms.Button btnEditarCampos;
        private System.Windows.Forms.Button btnRenombrarTabla;
        private System.Windows.Forms.Button btnAddFila;
        private System.Windows.Forms.Button btnDelFila;
        private System.Windows.Forms.Button btnDelTodo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem acercadeToolStripMenuItem;
    }
}