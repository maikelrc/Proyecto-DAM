using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private OleDbCommand comando;
        private OleDbDataReader lector;
        private DataSet ds = new DataSet();
        private OleDbDataAdapter da;
        private ListViewItem lista;
        private FormularioNuevaTabla fnt;
        private FormularioEditarCampos fec;

        private bool orden;

        private string tipoDato;

        private string tablaActual;
        private string ordenPor;
        private string cabecera = "";
        private string baseDeDatos;

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

        /// <summary>
        /// Cierra la conexión a la base de datos.
        /// </summary>
        private void CerrarConexíon()
        {
            if (lector != null)
                lector.Close();
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
        }

        private void EstablecerTablaActual()
        {
            tablaActual = lbTablas.SelectedItem.ToString();
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
        /// Carga la tabla en el ListView.
        /// </summary>
        private void cargarTabla()
        {
            lvDatos.Clear();
            ordenPor = "";
            ds.Reset();
            da = new OleDbDataAdapter("select * from " + tablaActual, fi.conexion);
            try
            {
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
            catch (OleDbException)
            {
                lvDatos.Clear();
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
            fnt.btnGuardar.Click += new System.EventHandler(FNTbtnGuardar_Click);
            fnt.ShowDialog();
            if (fnt.tbNombreTabla.Text != "")
            {
                fec = new FormularioEditarCampos();
                fec.btnAgregar.Click += new System.EventHandler(FECbtnAgregar_Click);
                fec.btnEliminar.Click += new System.EventHandler(FECbtnEliminar_Click);
                fec.btnLimpiar.Click += new System.EventHandler(FECbtnLimpiar_Click);
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
                    }
                    catch (OleDbException)
                    {
                        MessageBox.Show("No se puede elminar la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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
                    comando = new OleDbCommand("create table " + fnt.tbNombreTabla.Text, fi.conexion);
                    comando.ExecuteNonQuery();
                    ActualizarListaTablas();
                    fnt.cerrarForm = true;
                    fnt.Close();
                }
                catch (OleDbException)
                {
                    fnt.lblError.Text = "La tabla que intenta crear ya existe.";
                    fnt.tbNombreTabla.Text = "";
                    fnt.cerrarForm = false;
                }
            }
            else
            {
                fnt.lblError.Text = "El nombre de la tabla no puede estar vacío.";
                fnt.cerrarForm = false;
            }
        }

        private void btnEditarCampos_Click(object sender, EventArgs e)
        {
            if (lbTablas.SelectedItem != null)
            {
                fec = new FormularioEditarCampos();
                fec.btnAgregar.Click += new System.EventHandler(FECbtnAgregar_Click);
                fec.btnEliminar.Click += new System.EventHandler(FECbtnEliminar_Click);
                fec.btnLimpiar.Click += new System.EventHandler(FECbtnLimpiar_Click);
                ActualizarListaCampos();
                fec.ShowDialog();

            }
        }

        private void FECbtnAgregar_Click(object sender, EventArgs e)
        {

            if (fec.tbNombreCampo.Text != "" && fec.cbTipos.Text != "")
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
                    ActualizarListaCampos();
                    cargarTabla();
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

        private void FECbtnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void FECbtnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar todos los campos de la tabla \"" + tablaActual + "\"?", "Vaciar campos de tabla",
    MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
    == DialogResult.OK)
            {
                try
                {
                    ds.Reset();
                    da = new OleDbDataAdapter("select * from " + tablaActual, fi.conexion);
                    da.Fill(ds, tablaActual);
                    foreach (DataTable t in ds.Tables)
                    {
                        foreach (DataColumn c in t.Columns)
                        {
                            //if (t.PrimaryKey[0].ToString()!=c.ColumnName)
                            //{
                                comando = new OleDbCommand("alter table " + tablaActual + " drop " + c.ColumnName, fi.conexion);
                                comando.ExecuteNonQuery();
                            //}
                        }
                    }
                    ActualizarListaCampos();
                    centrarPosicionCabeceraListView(fec.lvCampos, true);


                }
                catch (OleDbException)
                {
                    MessageBox.Show("No se pueden limpiar los campos de la tabla \"" + tablaActual + "\" porque la está utilizando otro proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Actualiza los campos de una tabla mostrados en un ListView.
        /// </summary>
        private void ActualizarListaCampos()
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
                        lista.SubItems.Add(c.DataType.ToString());
                        fec.lvCampos.Items.Add(lista);
                        lista = new ListViewItem();
                    }
                }
                centrarPosicionCabeceraListView(fec.lvCampos, true);
            }
            catch (OleDbException)
            {
                fec.lvCampos.Clear();
            }
        }
    }
}