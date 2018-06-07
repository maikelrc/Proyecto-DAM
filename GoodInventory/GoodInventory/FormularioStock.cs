using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Drawing;
using Access = Microsoft.Office.Interop.Access;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOX;
using System.Runtime.InteropServices;

namespace GoodInventory
{
    public partial class FormularioStock : Form
    {

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public FormularioStock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Formulario de inicio que se carga en el load de este formulario.
        /// </summary>
        private FormularioInicio fi;

        private Catalog cat;
        private OleDbCommand comando;
        private DataSet ds = new DataSet();
        private OleDbDataAdapter da;
        private ListViewItem lista;
        private FormularioNuevaTabla fnt;
        private FormularioEditarCampos fec;
        private FormularioEditarDato fed;
        private int fila;

        ListViewHitTestInfo info;
        int row;
        int col;
        string value;

        private string nombreColumna;
        private string columnaTipoDato;
        private string cp = "";
        private string valorFilaClavePrimaria;
        private int indiceCabeceraCP;
        private bool continuar;

        private bool orden;
        private bool reRenombrarTabla;
        private string ordenPor;
        private string tipoDato;
        private string tablaActual;
        private string cabecera = "";
        private string baseDeDatos;

        private string FECnombreCampo;

        /// <summary>
        /// Carga diferentes datos antes de ejecutar el formulario.
        /// </summary>
        /// <param name="sender">El formulario</param>
        /// <param name="e">El evento</param>
        private void FormularioStock_Load(object sender, EventArgs e)
        {
            fi = new FormularioInicio();
            fi.ShowDialog();
            if (fi.conexion == null)
            {
                this.Close();
                CerrarPrograma();
            }
            else
            {
                ActualizarListaTablas();
            }
            baseDeDatos = fi.baseDeDatos;
        }

        /// <summary>
        /// Pestaña del menú que crea una nueva base de datos.
        /// </summary>
        /// <param name="sender">El item del menú</param>
        /// <param name="e">El evento</param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fi.NuevoInventario(fi.saveFileDialog1);
            baseDeDatos = fi.baseDeDatos;
            ActualizarListaTablas();
            tablaActual = "";
            fila = int.MinValue;
            lvDatos.Clear();
        }

        /// <summary>
        /// Pestaña del menú que abre una base de datos.
        /// </summary>
        /// <param name="sender">El item del menú</param>
        /// <param name="e">El evento</param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fi.AbrirInventario(fi.openFileDialog1);
            if (fi.conexion == null)
            {
                fi.AbrirConexion(baseDeDatos);
            }
            else
            {
                baseDeDatos = fi.baseDeDatos;
            }
            tablaActual = "";
            fila = int.MinValue;
            ActualizarListaTablas();
            lvDatos.Clear();
        }

        /// <summary>
        /// Pestaña del menú que cierra el programa.
        /// </summary>
        /// <param name="sender">El item del menú</param>
        /// <param name="e">El evento</param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarPrograma();
        }

        private void acercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Una aplicación de:\nMRC Company\nTodos los derechos reservados", "Acerca de...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Cierra la conexión a la base de datos.
        /// </summary>
        private void CerrarConexíon()
        {
            if (fi.conexion != null)
                fi.conexion.Close();
        }

        /// <summary>
        /// Cierra la aplicación.
        /// </summary>
        private void CerrarPrograma()
        {
            fi.Dispose();
            fi.Close();
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// Actualiza la lista de tablas a las que existan en la base de datos.
        /// </summary>
        private void ActualizarListaTablas()
        {
            lbTablas.Items.Clear();
            DataTable dt = fi.conexion.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                if ((string)row[3] == "TABLE")
                    lbTablas.Items.Add((string)row[2]);
            }
        }

        private void lbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            EstablecerTablaActual();
            cargarTabla();
            if (cp == "")
            {
                if (lvDatos.Columns.Count == 0)
                {
                    MessageBox.Show("Tabla vacía", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Esta tabla no contiene clave primaria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EstablecerTablaActual()
        {
            try
            {
                tablaActual = lbTablas.SelectedItem.ToString();
            }
            catch (NullReferenceException) { }
        }

        /// <summary>
        /// Establece un tamaño automático a los campos dentro de la cabecera de un ListView pasado como parámetro.
        /// </summary>
        /// <param name="lvDatos">El ListView</param>
        /// <param name="IgnorarIndice">Indica si se ignora el índice</param>
        public void centrarPosicionCabeceraListView(ListView lvDatos, bool IgnorarIndice)
        {
            if (lvDatos.Columns.Count != 0)
            {
                if (IgnorarIndice)
                {
                    int tamañoColumna = lvDatos.Width / (lvDatos.Columns.Count - 1);
                    lvDatos.Columns[0].Width = 0;
                    for (int i = 1; i < lvDatos.Columns.Count; i++)
                    {
                        lvDatos.Columns[i].Width = tamañoColumna;
                        try
                        {
                            lvDatos.Columns[i].TextAlign = HorizontalAlignment.Center;
                        }
                        catch (InvalidOperationException) { }
                        //}
                    }
                }
                else
                {
                    int tamañoColumna = lvDatos.Width / lvDatos.Columns.Count;
                    for (int i = 0; i < lvDatos.Columns.Count; i++)
                    {
                        lvDatos.Columns[i].Width = tamañoColumna;
                        try
                        {
                            lvDatos.Columns[i].TextAlign = HorizontalAlignment.Center;
                        }
                        catch (InvalidOperationException) { }
                        //}
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene una lista con las claves primarias de una tabla que pasa cómo parámetro.
        /// </summary>
        /// <param name="tableName">La tabla</param>
        /// <param name="conn">La conexión</param>
        /// <returns>La lista con las claves primarias.</returns>
        public static List<string> getClavesPrimariasNombres(String tableName, OleDbConnection conn)
        {
            //Método 100% sacado de internet
            var returnList = new List<string>();
            DataTable mySchema = (conn as OleDbConnection).
                GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys,
                                    new Object[] { null, null, tableName });
            int columnOrdinalForName = mySchema.Columns["COLUMN_NAME"].Ordinal;
            foreach (DataRow r in mySchema.Rows)
            {
                returnList.Add(r.ItemArray[columnOrdinalForName].ToString());
            }
            return returnList;
        }

        /// <summary>
        /// Carga la tabla en el ListView.
        /// </summary>
        private void cargarTabla()
        {
            lvDatos.Clear();
            ordenPor = "";
            //se establece un valor nulo a lavariable
            indiceCabeceraCP = int.MinValue;
            fila = int.MinValue;
            ds.Reset();
            row = 0;
            col = 0;
            btnDelFila.Text = "borrar fila".ToUpper();
            //OleDbDataReader dr;
            //comando = new OleDbCommand("SELECT * FROM ALL_CONS_COLUMNS A JOIN ALL_CONSTRAINTS C ON A.CONSTRAINT_NAME = C.CONSTRAINT_NAME WHERE C.TABLE_NAME = < " + tablaActual + " > AND C.CONSTRAINT_TYPE = 'P'",fi.conexion);
            //dr = comando.ExecuteReader();
            //this.Text = dr.GetString(0);
            List<string> listaPK = getClavesPrimariasNombres(tablaActual, fi.conexion);
            cp = "";
            if (listaPK.Count() > 0)
            {
                cp = listaPK[0].ToString();
                da = new OleDbDataAdapter("select * from " + tablaActual + " order by " + cp, fi.conexion);
            }
            else
            {
                da = new OleDbDataAdapter("select * from " + tablaActual, fi.conexion);
            }

            if (tablaActual != "" && tablaActual != null)
            {
                try
                {
                    da.Fill(ds, tablaActual);
                    //Foreach que carga la cabecera
                    foreach (DataTable t in ds.Tables)
                    {
                        foreach (DataColumn c in t.Columns)
                        {
                            lvDatos.Columns.Add(c.ColumnName);
                            if (c.ColumnName == cp)
                            {
                                indiceCabeceraCP = c.Ordinal;
                            }
                        }
                    }
                    centrarPosicionCabeceraListView(lvDatos, false);
                    //Foreach que carga los datos
                    foreach (DataRow r in ds.Tables[tablaActual].Rows)
                    {
                        for (int i = 0; i < lvDatos.Columns.Count; i++)
                        {
                            if (i == 0)
                            {
                                lista = new ListViewItem(r.ItemArray[i].ToString());
                            }
                            else
                            {
                                lista.SubItems.Add(r.ItemArray[i].ToString());
                            }
                        }
                        lvDatos.Items.Add(lista);
                    }
                }
                catch (OleDbException)
                {
                    lvDatos.Clear();
                    reRenombrarTabla = true;
                }
            }
        }

        /// <summary>
        /// Carga la tabla en el ListView ordenada por la cabecera.
        /// </summary>
        private void cargarTablaOrdenadaPorCabeceraSeleccionada(string cabecera)
        {
            lvDatos.Clear();
            ds.Reset();
            //if que establecen el tipo de orden en el contrario al actual.
            if (this.cabecera == cabecera)
                orden = false;
            else
                orden = true;
            if (orden)
            {
                this.cabecera = cabecera;
                ordenPor = "asc";
            }
            else
            {
                ordenPor = "desc";
                this.cabecera = "";
            }
            da = new OleDbDataAdapter("select * from " + tablaActual + " order by " + cabecera + " " + ordenPor, fi.conexion);
            da.Fill(ds, tablaActual);
            //Foreach que carga la cabecera
            foreach (DataTable t in ds.Tables)
            {
                foreach (DataColumn c in t.Columns)
                {
                    lvDatos.Columns.Add(c.ColumnName);
                }
            }
            centrarPosicionCabeceraListView(lvDatos, false);
            //Foreach que carga los datos
            foreach (DataRow r in ds.Tables[tablaActual].Rows)
            {
                for (int i = 0; i < lvDatos.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        lista = new ListViewItem(r.ItemArray[i].ToString());
                    }
                    else
                    {
                        lista.SubItems.Add(r.ItemArray[i].ToString());
                    }
                }
                lvDatos.Items.Add(lista);
            }
        }

        /// <summary>
        /// Determina el índice de los subitems.
        /// </summary>
        /// <param name="sender">El sender</param>
        /// <param name="e">El evento</param>
        private void lvDatos_MouseDown(object sender, MouseEventArgs e)
        {
            //La parte del código de creación de evnto de click en subitem es sacado completamente de internet.
            try
            {
                info = lvDatos.HitTest(e.X, e.Y);
                row = info.Item.Index;
                col = info.Item.SubItems.IndexOf(info.SubItem);
                value = info.Item.SubItems[col].Text;
                try
                {
                    valorFilaClavePrimaria = info.Item.SubItems[indiceCabeceraCP].Text;
                }
                catch (ArgumentOutOfRangeException)
                {
                    valorFilaClavePrimaria = "";
                }
                if (valorFilaClavePrimaria == "")
                {
                    btnDelFila.Text = "borrar fila".ToUpper();
                }
                else
                {
                    btnDelFila.Text = ("borrar fila PK = " + valorFilaClavePrimaria).ToUpper();
                }
                if (col != indiceCabeceraCP)
                {
                    nombreColumna = lvDatos.Columns[col].Text;
                    da = new OleDbDataAdapter("select * from " + tablaActual, fi.conexion);
                    lista = new ListViewItem();
                    da.Fill(ds, tablaActual);
                    DataTable t = ds.Tables[tablaActual];
                    foreach (DataColumn c in t.Columns)
                    {
                        if (c.ColumnName == nombreColumna)
                        {
                            columnaTipoDato = c.DataType.ToString();
                        }
                    }
                    fed = new FormularioEditarDato();
                    fed.tbDato.Text = value;
                    fed.btnGuardar.Click += new EventHandler(this.FEDbtnGuardar_Click);
                    if (cp == "")
                    {
                        MessageBox.Show("No se puede editar el valor del dato porque esta tabla no contiene clave primaria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        fed.ShowDialog();
                    }
                }
            }
            catch (NullReferenceException) { }

        }

        /// <summary>
        /// Actualiza el tamaño de la cabecera cada vez que el listView cambie de tamaño.
        /// </summary>
        /// <param name="sender">El sender</param>
        /// <param name="e">El evento</param>
        private void lvDatos_SizeChanged(object sender, EventArgs e)
        {
            centrarPosicionCabeceraListView(lvDatos, false);
        }

        private void lvDatos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string nombre = lvDatos.Columns[e.Column].Text;
            cargarTablaOrdenadaPorCabeceraSeleccionada(nombre);
        }

        /// <summary>
        /// Guarda una nueva tabla abriendo un nuevo formulario.
        /// </summary>
        /// <param name="sender"></param>El sender
        /// <param name="e"></param>El evento
        private void btnAddTabla_Click(object sender, EventArgs e)
        {
            fnt = new FormularioNuevaTabla();
            fnt.btnGuardar.Click += new EventHandler(FNTbtnGuardar_Click);
            fnt.ShowDialog();
            if (fnt.tbNombreTabla.Text != "")
            {
                string nombreTabla = "";
                for (int i = 0; i < fnt.tbNombreTabla.Text.Length; i++)
                {
                    if (fnt.tbNombreTabla.Text[i] != ' ')
                    {
                        nombreTabla += fnt.tbNombreTabla.Text[i];
                    }
                    else
                    {
                        nombreTabla += '_';
                    }
                }
                tablaActual = nombreTabla;
                lvDatos.Clear();
                fec = new FormularioEditarCampos();
                fec.btnAgregar.Click += new EventHandler(FECbtnAgregar_Click);
                fec.btnEliminar.Click += new EventHandler(FECbtnEliminar_Click);
                fec.btnLimpiar.Click += new EventHandler(FECbtnLimpiar_Click);
                fec.lvCampos.MouseDown += new MouseEventHandler(FEClvCampos_MouseDown);
                fec.tbNombreCampo.TextChanged += new EventHandler(FECtbNombreCampo_TextChanged);
                fec.cbTipos.TextChanged += new System.EventHandler(this.FECcbTipos_TextChanged);
                lbTablas.SelectedIndex = lbTablas.Items.IndexOf(tablaActual);
                FECactualizarListaCampos();
                fec.ShowDialog();
            }
        }

        /// <summary>
        /// Elimina una tabla con previa confirmación.
        /// </summary>
        /// <param name="sender"></param>El sender
        /// <param name="e"></param>El evento
        private void btnDelTabla_Click(object sender, EventArgs e)
        {
            if (lbTablas.SelectedItem != null)
            {
                if (MessageBox.Show("¿Desea eliminar la tabla \"" + tablaActual + "\"?", "Eliminar tabla",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == DialogResult.OK)
                {
                    try
                    {
                        comando = new OleDbCommand("drop table " + tablaActual, fi.conexion);
                        comando.ExecuteNonQuery();
                        ActualizarListaTablas();
                        lvDatos.Clear();
                    }
                    catch (OleDbException)
                    {
                        MessageBox.Show("No se puede elminar la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnRenombrarTabla_Click(object sender, EventArgs e)
        {
            if (tablaActual != "")
            {
                fnt = new FormularioNuevaTabla();
                fnt.tbNombreTabla.Text = "";
                fnt.btnGuardar.Click += new EventHandler(renombrarTabla);
                fnt.Text = "Renombrar Tabla \"" + tablaActual + "\"";
                fnt.tbNombreTabla.Text = tablaActual;
                if (fnt.tbNombreTabla.Text != "")
                {
                    fnt.ShowDialog();
                }
            }
        }

        private void renombrarTabla(object sender, EventArgs e)
        {
            if (fnt.tbNombreTabla.Text != "")
            {
                reRenombrarTabla = false;
                string nombreTablaTemp = tablaActual;
                string nombreTabla = "";
                for (int i = 0; i < fnt.tbNombreTabla.Text.Length; i++)
                {
                    if (fnt.tbNombreTabla.Text[i] != ' ')
                    {
                        nombreTabla += fnt.tbNombreTabla.Text[i];
                    }
                    else
                    {
                        nombreTabla += '_';
                    }
                }
                if (tablaActual != nombreTabla)
                {
                    cat = new Catalog();
                    cat.let_ActiveConnection(fi.strConnection);
                    try
                    {
                        cat.Tables[tablaActual].Name = nombreTabla;
                        fi.AbrirConexion(fi.baseDeDatos);
                        ActualizarListaTablas();
                        lbTablas.SelectedIndex = lbTablas.Items.IndexOf(nombreTabla);
                        cargarTabla();
                        if (reRenombrarTabla)
                        {
                            reRenombrarTabla = true;
                            cat = new Catalog();
                            cat.let_ActiveConnection(fi.strConnection);
                            cat.Tables[fnt.tbNombreTabla.Text].Name = nombreTablaTemp;
                            fi.AbrirConexion(fi.baseDeDatos);
                            ActualizarListaTablas();
                            lbTablas.SelectedIndex = lbTablas.Items.IndexOf(nombreTablaTemp);
                            cargarTabla();
                            fnt.lblError.Text = "Caracteres no permitidos para el nombre de una tabla.";
                            fnt.lblError.Location = new Point(fnt.Width / 2 - fnt.lblError.Size.Width / 2, fnt.lblError.Location.Y);
                            fnt.cerrarForm = false;
                        }
                    }
                    catch (COMException ex)
                    {
                        if (ex.ErrorCode.ToString() == "-2147217856")
                        {
                            MessageBox.Show("No se puede renombrar la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error desconocido al renombrar la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (!reRenombrarTabla)
                {
                    fnt.cerrarForm = true;
                    fnt.Close();
                }
            }
            else
            {
                fnt.lblError.Text = "El nombre de la tabla no puede estar vacío.";
                fnt.lblError.Location = new Point(fnt.Width / 2 - fnt.lblError.Size.Width / 2, fnt.lblError.Location.Y); ;
                fnt.cerrarForm = false;
            }
        }

        private void btnAddFila_Click(object sender, EventArgs e)
        {
            valorFilaClavePrimaria = "";
            if (cp != "")
            {
                try
                {
                    fila = Int32.Parse(lvDatos.Items[lvDatos.Items.Count - 1].SubItems[indiceCabeceraCP].Text) + 1;
                    comando = new OleDbCommand("insert into " + tablaActual + " (" + cp + ") values (" + fila + ")", fi.conexion);
                    comando.ExecuteNonQuery();
                    cargarTabla();
                }
                catch (OleDbException) { }
                catch (ArgumentOutOfRangeException)
                {
                    try
                    {
                        fila = 1;
                        comando = new OleDbCommand("insert into " + tablaActual + " (" + cp + ") values (" + fila + ")", fi.conexion);
                        comando.ExecuteNonQuery();
                        cargarTabla();
                    }
                    catch (OleDbException) { }
                }
            }
            else
            {
                MessageBox.Show("No se añadir una fila porque esta tabla no contiene clave primaria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelFila_Click(object sender, EventArgs e)
        {
            if (cp != "")
            {
                try
                {
                    comando = new OleDbCommand("delete from " + tablaActual + " where " + cp + "=" + valorFilaClavePrimaria, fi.conexion);
                    comando.ExecuteNonQuery();
                    cargarTabla();
                    btnDelFila.Text = "borrar fila".ToUpper();
                }
                catch (OleDbException) { }
            }
        }

        private void btnDelTodo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar todos los datos de la tabla \"" + tablaActual + "\"?", "Vaciar datos",
      MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      == DialogResult.OK)
            {
                valorFilaClavePrimaria = "";
                if (cp != "")
                {
                    try
                    {
                        comando = new OleDbCommand("delete from " + tablaActual, fi.conexion);
                        comando.ExecuteNonQuery();
                        cargarTabla();
                        btnDelFila.Text = "borrar fila".ToUpper();
                    }
                    catch (OleDbException) { }
                }
                else
                {
                    MessageBox.Show("No se puede vaciar la tabla porque ésta no tiene clave primaria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditarCampos_Click(object sender, EventArgs e)
        {
            if (lbTablas.SelectedItem != null)
            {
                fec = new FormularioEditarCampos();
                fec.btnAgregar.Click += new EventHandler(FECbtnAgregar_Click);
                fec.btnEliminar.Click += new EventHandler(FECbtnEliminar_Click);
                fec.btnLimpiar.Click += new EventHandler(FECbtnLimpiar_Click);
                fec.btnRenombrar.Click += new EventHandler(FECbtnRenombrar_Click);
                fec.lvCampos.MouseDown += new MouseEventHandler(FEClvCampos_MouseDown);
                fec.tbNombreCampo.TextChanged += new EventHandler(FECtbNombreCampo_TextChanged);
                fec.cbTipos.TextChanged += new EventHandler(this.FECcbTipos_TextChanged);
                FECactualizarListaCampos();
                fec.ShowDialog();
            }
        }


        /// <summary>
        /// Guarda una nueva tabla cogiendo el nombre de un textbox del formulario "FormularioNuevaTabla"
        /// </summary>
        /// <param name="sender"></param> El sender
        /// <param name="e"></param>El evento
        private void FNTbtnGuardar_Click(object sender, EventArgs e)
        {
            if (fnt.tbNombreTabla.Text != "")
            {
                try
                {
                    string nombreTabla = "";
                    for (int i = 0; i < fnt.tbNombreTabla.Text.Length; i++)
                    {
                        if (fnt.tbNombreTabla.Text[i] != ' ')
                        {
                            nombreTabla += fnt.tbNombreTabla.Text[i];
                        }
                        else
                        {
                            nombreTabla += '_';
                        }
                    }
                    comando = new OleDbCommand("create table " + nombreTabla + "(Id int IDENTITY(1, 1) NOT NULL)", fi.conexion);
                    comando.ExecuteNonQuery();
                    comando = new OleDbCommand("alter table " + nombreTabla + " add primary key (Id)", fi.conexion);
                    comando.ExecuteNonQuery();
                    ActualizarListaTablas();
                    cargarTabla();
                    fnt.cerrarForm = true;
                    fnt.Close();
                }
                catch (OleDbException ex)
                {
                    //Mensaje error caracteres no permitidos -> Error de sintaxis en la instrucción CREATE TABLE.
                    if (ex.Message == "Error de sintaxis en la instrucción CREATE TABLE.")
                    {
                        fnt.lblError.Text = "Caracteres no permitidos para el nombre de una tabla.";
                    }
                    else
                    {
                        fnt.lblError.Text = "La tabla que intenta crear ya existe.";
                    }
                    fnt.tbNombreTabla.Text = "";
                    fnt.cerrarForm = false;
                    fnt.lblError.Location = new Point(fnt.Width / 2 - fnt.lblError.Size.Width / 2, fnt.lblError.Location.Y); ;
                }
            }
            else
            {
                fnt.lblError.Text = "El nombre de la tabla no puede estar vacío.";
                fnt.lblError.Location = new Point(fnt.Width / 2 - fnt.lblError.Size.Width / 2, fnt.lblError.Location.Y); ;
                fnt.cerrarForm = false;
            }
        }

        private void FEClvCampos_MouseDown(object sender, MouseEventArgs e)
        {
            //La parte del código de creación de evnto de click en subitem es sacado completamente de internet.
            try
            {
                info = fec.lvCampos.HitTest(e.X, e.Y);
                row = info.Item.Index;
                col = info.Item.SubItems.IndexOf(info.SubItem);
                value = info.Item.SubItems[col].Text;
                fec.tbNombreCampo.Text = "";
                if (col == 2)
                {
                    FECnombreCampo = info.Item.SubItems[col - 1].Text;
                }
                else
                {
                    FECnombreCampo = info.Item.SubItems[col].Text;
                }
                fec.lblInfo.Text = "Campo actual: " + FECnombreCampo;
                fec.lblInfo.Location = new Point(fec.Width / 2 - fec.lblInfo.Size.Width / 2, fec.lblInfo.Location.Y); ;
                //da = new OleDbDataAdapter("select * from " + tablaActual, fi.conexion);
                //lista = new ListViewItem();
                //da.Fill(ds, tablaActual);
                //DataTable t = ds.Tables[tablaActual];
                //foreach (DataColumn c in t.Columns)
                //{
                //    if (c.ColumnName == nombreColumna)
                //    {
                //        columnaTipoDato = c.DataType.ToString();
                //    }
                //}
                //fed = new FormularioEditarDato();
                //fed.tbDato.Text = value;
                //fed.btnGuardar.Click += new EventHandler(this.FEDbtnGuardar_Click);
                //fed.ShowDialog();

            }
            catch (NullReferenceException) { }
        }

        private void FECtbNombreCampo_TextChanged(object sender, EventArgs e)
        {
            fec.lblInfo.Text = "";
            FECnombreCampo = "";
        }

        private void FECcbTipos_TextChanged(object sender, EventArgs e)
        {
            if (fec.cbTipos.Text.ToLower() == "número (pk)")
            {
                fec.lblInfo.Text = "Va a introducir una clave primaria en la tabla\"" + tablaActual + "\"";
                fec.lblInfo.Location = new Point(fec.Width / 2 - fec.lblInfo.Size.Width / 2, fec.lblInfo.Location.Y); ;
            }
            else
            {
                fec.lblInfo.Text = "";
            }
        }

        /// <summary>
        /// Agrega un nueva campo a la tabla actual.
        /// </summary>
        /// <param name="sender">El sender</param>
        /// <param name="e">El evento</param>
        private void FECbtnAgregar_Click(object sender, EventArgs e)
        {
            if (fec.tbNombreCampo.Text != "" && fec.cbTipos.Text != "")
            {
                if (fec.cbTipos.Text.ToLower() == "número (pk)")
                {
                    try
                    {
                        comando = new OleDbCommand("alter table " + tablaActual + " add " + fec.tbNombreCampo.Text + " int IDENTITY(1, 1) NOT NULL", fi.conexion);
                        comando.ExecuteNonQuery();
                        comando = new OleDbCommand("alter table " + tablaActual + " add primary key (" + fec.tbNombreCampo.Text + ")", fi.conexion);
                        comando.ExecuteNonQuery();
                        cargarTabla();
                        FECactualizarListaCampos();
                        fec.lblInfo.Text = "";
                    }
                    catch (OleDbException ex)
                    {
                        //-2147217887 -> error campo existente.
                        //-2147217900 -> error tabla ocupada.
                        //-2147467259 -> error clave primaria ya existente.
                        string mensaje;
                        if (ex.ErrorCode.ToString() == "-2147217887")
                        {
                            mensaje = "El campo \"" + fec.tbNombreCampo.Text + "\" ya existe en esta tabla, por lo que no se puede añadir de nuevo.";
                        }
                        else
                        {
                            if (ex.ErrorCode.ToString() == "-2147467259")
                            {
                                mensaje = "No puede añadir el campo '" + fec.tbNombreCampo.Text + "' como clave primaria de la tabla \"" + tablaActual + "\" porque ésta ya tiene una clave primaria.";
                            }
                            else
                            {
                                mensaje = "No se pueden actualizar los campos de la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso";
                            }
                        }
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (fec.cbTipos.Text.ToLower() == "cadena")
                    {
                        tipoDato = "varchar";
                    }
                    else
                    {
                        tipoDato = "int";
                    }

                    try
                    {
                        comando = new OleDbCommand("alter table " + tablaActual + " add " + fec.tbNombreCampo.Text + " " + tipoDato, fi.conexion);
                        comando.ExecuteNonQuery();
                        cargarTabla();
                        FECactualizarListaCampos();
                        fec.lblInfo.Text = "";
                    }
                    catch (OleDbException ex)
                    {
                        //-2147217887 -> error campo existente
                        //-2147217900 -> error tabla ocupada
                        string mensaje;
                        if (ex.ErrorCode.ToString() == "-2147217887")
                        {
                            mensaje = "El campo \"" + fec.tbNombreCampo.Text + "\" ya existe en esta tabla, por lo que no se puede añadir de nuevo.";
                        }
                        else
                        {
                            mensaje = "No se pueden actualizar los campos de la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso";
                        }
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (fec.tbNombreCampo.Text == "" && fec.cbTipos.Text == "")
                {
                    fec.lblInfo.Text = "Estableza nombre y tipo de dato";
                }
                else
                {
                    if (fec.tbNombreCampo.Text == "")
                    {
                        fec.lblInfo.Text = "Estableza nombre para el dato";
                    }
                    else
                    {
                        fec.lblInfo.Text = "Estableza tipo de dato";
                    }
                }
                fec.lblInfo.Location = new Point(fec.Width / 2 - fec.lblInfo.Size.Width / 2, fec.lblInfo.Location.Y); ;
            }
        }

        /// <summary>
        /// Elimina el campo deseado de la tabla actual.
        /// </summary>
        /// <param name="sender">El sender</param>
        /// <param name="e">El evento</param>
        private void FECbtnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (fec.tbNombreCampo.Text == "")
                {
                    comando = new OleDbCommand("alter table " + tablaActual + " drop " + FECnombreCampo, fi.conexion);
                }
                else
                {
                    comando = new OleDbCommand("alter table " + tablaActual + " drop " + fec.tbNombreCampo.Text, fi.conexion);
                }
                fec.lblInfo.Text = "";
                comando.ExecuteNonQuery();
                cargarTabla();
                FECactualizarListaCampos();
                FECnombreCampo = "";
            }
            catch (OleDbException ex)
            {
                string mensaje;
                if (ex.Message != "Error de sintaxis en la instrucción ALTER TABLE.")
                {
                    if (ex.Message[3] == 'h')
                    {
                        mensaje = "El campo '" + fec.tbNombreCampo.Text + "' no existe en la tabla \"" + tablaActual + "\".";
                    }
                    else
                    {
                        if (ex.ErrorCode.ToString() == "-2147467259")
                        {
                            mensaje = "No se puede eliminar un campo que sea clave primaria de la tabla.";
                        }
                        else
                        {
                            mensaje = "No se puede eliminar este campo de la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso";
                        }
                    }
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Elimina todos los campos de la tabla actual a excepción de la clave primaria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FECbtnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar todos los campos de la tabla \"" + tablaActual + "\"?\nLas claves primarias se mantendrán.", "Vaciar campos",
    MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
    == DialogResult.OK)
            {
                try
                {
                    da = new OleDbDataAdapter("select * from " + tablaActual, fi.conexion);
                    da.Fill(ds, tablaActual);
                    foreach (DataTable t in ds.Tables)
                    {
                        foreach (DataColumn c in t.Columns)
                        {
                            try
                            {
                                comando = new OleDbCommand("alter table " + tablaActual + " drop " + c.ColumnName, fi.conexion);
                                comando.ExecuteNonQuery();
                                fec.lblInfo.Text = "";
                            }
                            catch (OleDbException ex)
                            {
                                // Error clave primaria -> -2147467259
                                if (ex.ErrorCode.ToString() == "-2147467259")
                                {
                                    continue;
                                }
                                else
                                {
                                    MessageBox.Show("No se pueden limpiar los campos de la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    FECactualizarListaCampos();
                }
                catch (OleDbException ex)
                {
                    // Error consulta vacía -> -2147467259
                    if (ex.ErrorCode.ToString() != "-2147467259")
                    {
                        MessageBox.Show("No se pueden limpiar los campos de la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void FECbtnRenombrar_Click(object sender, EventArgs e)
        {
            if (fec.tbNombreCampo.Text != "" || FECnombreCampo != "")
            {
                continuar = false;
                //try
                //{
                fed = new FormularioEditarDato();
                fed.Text = "Editar campo \"" + FECnombreCampo + "\"";
                if (fec.tbNombreCampo.Text != "")
                {
                    for (int i = 0; i < fec.lvCampos.Items.Count; i++)
                    {
                        if (fec.lvCampos.Items[i].SubItems[1].Text.ToLower() == fec.tbNombreCampo.Text.ToLower())
                        {
                            fec.tbNombreCampo.Text = fec.lvCampos.Items[i].SubItems[1].Text;
                            continuar = true;
                            break;
                        }
                    }
                }

                if (fec.tbNombreCampo.Text != "")
                {
                    fed.tbDato.Text = fec.tbNombreCampo.Text;
                }
                else
                {
                    fed.tbDato.Text = FECnombreCampo;
                }
                fed.btnGuardar.Click += new EventHandler(FECrenombrarCampo);
                if (fec.tbNombreCampo.Text != "")
                {
                    if (continuar)
                        fed.ShowDialog();
                    else
                    {
                        fec.lblInfo.Text = "El campo '" + fec.tbNombreCampo.Text + "' no existe en la tabla '" + tablaActual + "'.";
                        fec.lblInfo.Location = new Point(fec.Width / 2 - fec.lblInfo.Width / 2, fec.lblInfo.Location.Y);
                    }
                }
                else
                {
                    fed.ShowDialog();
                }
                ActualizarListaTablas();
                cargarTabla();
                lbTablas.SelectedIndex = lbTablas.Items.IndexOf(tablaActual);
                FECactualizarListaCampos();
                //}
                //catch (OleDbException ex)
                //{
                //    //-2147217887 -> error campo existente
                //    //-2147217900 -> error tabla ocupada
                //    string mensaje;
                //    if (ex.ErrorCode.ToString() == "-2147217887")
                //    {
                //        mensaje = "El campo \"" + fec.tbNombreCampo.Text + "\" ya existe en esta tabla, por lo que no se puede añadir de nuevo.";
                //    }
                //    else
                //    {
                //        mensaje = "No se pueden actualizar los campos de la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso";
                //    }
                //    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private void FECrenombrarCampo(object sender, EventArgs e)
        {
            if (fec.tbNombreCampo.Text != "")
            {
                try
                {
                    cat = new Catalog();
                    cat.let_ActiveConnection(fi.strConnection);
                    cat.Tables[tablaActual].Columns[fec.tbNombreCampo.Text].Name = fed.tbDato.Text;
                    fed.Close();
                    fi.AbrirConexion(fi.baseDeDatos);
                    fec.lblInfo.Text = "";
                }
                catch (COMException ex)
                {
                    if (ex.ErrorCode.ToString() == "-2147217858")
                    {
                        MessageBox.Show("El nombre que quiere establecer para el campo ya lo tiene otro campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ex.ErrorCode.ToString() == "-2147217856")
                        {
                            MessageBox.Show("No se puede renombrar este campo porque la tabla \"" + tablaActual + "\" está siendo utilizada por otro proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("El nombre que quiere establecer para el campo contiene caracteres no válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                if (FECnombreCampo != "")
                {
                    try
                    {
                        cat = new Catalog();
                        cat.let_ActiveConnection(fi.strConnection);
                        cat.Tables[tablaActual].Columns[FECnombreCampo].Name = fed.tbDato.Text;
                        fed.Close();
                        fi.AbrirConexion(fi.baseDeDatos);
                        fec.lblInfo.Text = "";
                    }
                    catch (COMException ex)
                    {
                        if (ex.ErrorCode.ToString() == "-2147217858")
                        {
                            MessageBox.Show("El nombre que quiere establecer para el campo ya lo tiene otro campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (ex.ErrorCode.ToString() == "-2147217856")
                            {
                                MessageBox.Show("No se puede renombrar este campo porque la tabla \"" + tablaActual + "\" está siendo utilizada por otro proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("El nombre que quiere establecer para el campo contiene caracteres no válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza los campos de una tabla mostrados en un ListView.
        /// </summary>
        private void FECactualizarListaCampos()
        {
            fec.lvCampos.Items.Clear();
            ds.Reset();
            da = new OleDbDataAdapter("select * from " + tablaActual, fi.conexion);
            lista = new ListViewItem();
            try
            {
                da.Fill(ds, tablaActual);
                //Foreach que carga los campos de la tabla en el ListView.
                foreach (DataTable t in ds.Tables)
                {
                    foreach (DataColumn c in t.Columns)
                    {
                        lista.SubItems.Add(c.ColumnName);
                        switch (c.DataType.ToString())
                        {
                            case "System.String":
                                lista.SubItems.Add("Cadena");
                                break;
                            case "System.Int32":
                                lista.SubItems.Add("Número");
                                break;
                            default:
                                lista.SubItems.Add("Otro");
                                break;
                        }
                        fec.lvCampos.Items.Add(lista);
                        lista = new ListViewItem();
                    }
                }
                centrarPosicionCabeceraListView(fec.lvCampos, true);
            }
            catch (OleDbException)
            {
                fec.lvCampos.Items.Clear();
            }
            finally
            {
                FECactivarDesactivarBotones();
            }
        }

        /// <summary>
        /// Activa o desactiva "btnEliminar" y "btnLimpiar" dependiendo de si hay datos o no respectivamente en el ListView de los campos.
        /// </summary>
        private void FECactivarDesactivarBotones()
        {
            if (fec.lvCampos.Items.Count == 0)
            {
                fec.btnEliminar.Enabled = false;
                fec.btnLimpiar.Enabled = false;
                fec.btnRenombrar.Enabled = false;
            }
            else
            {
                fec.btnEliminar.Enabled = true;
                fec.btnLimpiar.Enabled = true;
                fec.btnRenombrar.Enabled = true;
            }
        }

        /// <summary>
        /// Lanza un formulario para cambiar el valor que esta seleccionado previamente.
        /// </summary>
        /// <param name="sender">El sender</param>
        /// <param name="e">El evento</param>
        private void FEDbtnGuardar_Click(object sender, EventArgs e)
        {
            if (value != fed.tbDato.Text)
            {
                //Intento de actualizar los datos de otra manera, pero este no funciona porque el la tabla del dataset no reconoce la clave primaria.
                //for (int i = 0; i < ds.Tables[tablaActual].Rows.Count; i++)
                //{
                //    if (i == row)
                //    {
                //        if (columnaTipoDato == "System.Int32")
                //        {
                //            ds.Tables[tablaActual].Rows[i].SetField(col, Int32.Parse(fed.tbDato.Text));
                //        }
                //        else
                //        {
                //            ds.Tables[tablaActual].Rows[i].SetField(col, fed.tbDato.Text);
                //        }
                //    }
                //}
                //da.Update(ds, tablaActual);
                //fed.Close();
                //cargarTabla();
                try
                {
                    if (columnaTipoDato == "System.Int32")
                    {
                        if (fed.tbDato.Text == "")
                        {
                            comando = new OleDbCommand("update " + tablaActual + " SET " + nombreColumna + "=" + "null" + " where " + cp + "=" + valorFilaClavePrimaria, fi.conexion);
                        }
                        else
                        {
                            comando = new OleDbCommand("update " + tablaActual + " SET " + nombreColumna + "=" + fed.tbDato.Text + " where " + cp + "=" + valorFilaClavePrimaria, fi.conexion);
                        }
                    }
                    else
                    {
                        comando = new OleDbCommand("update " + tablaActual + " set " + nombreColumna + "=" + "'" + fed.tbDato.Text + "'" + " where " + cp + "=" + valorFilaClavePrimaria, fi.conexion);
                    }
                    comando.ExecuteNonQuery();
                    cargarTabla();
                    fed.Close();
                }
                catch (OleDbException ex)
                {
                    // Error dato no válido -> -2147217900
                    // Error clave primaria no encontrada. -> -2147217904
                    // Error tipos distintos al actualizar -> -2147217913
                    string mensaje;
                    if (ex.ErrorCode.ToString() == "-2147217900" || ex.Message[9] == 's' || ex.Message[10] == 'e')
                    {
                        mensaje = "El valor no es correcto para el tipo de dato del campo.";
                    }
                    else
                    {
                        if (ex.ErrorCode.ToString() == "-2147217904" || ex.ErrorCode.ToString() == "-2147217913")
                        {
                            mensaje = "La tabla no contiene ninguna clave primaria, agregue una clave primaria.";
                        }
                        else
                        {
                            mensaje = "No se puede actualizar el dato seleccionado de la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso";

                        }
                    }
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    valorFilaClavePrimaria = "";
                }
            }
            else
            {
                fed.Close();
            }
        }
    }
}