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


        private bool orden;

        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
        private string baseDeDatos;
        private string tablaActual;
        private string ordenPor;
        private string cabecera = "";

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
        }

        /// <summary>
        /// Pestaña del menú que crea una nueva base de datos.
        /// </summary>
        /// <param name="sender">El item del menú</param>
        /// <param name="e">El evento</param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fi.NuevoInventario(fi.saveFileDialog1);
            ActualizarListaTablas();
        }

        /// <summary>
        /// Pestaña del menú que abre una base de datos.
        /// </summary>
        /// <param name="sender">El item del menú</param>
        /// <param name="e">El evento</param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fi.AbrirInventario(fi.openFileDialog1);
            ActualizarListaTablas();
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

        ///// <summary>
        ///// Comprueba si se intenta crear/cargar una nueva base de datos, si no se crea/carga correctamente se
        ///// reestablece el nombre de la base de datos.
        ///// </summary>
        //private void ComprobarCargarBaseDeDatos()
        //{
        //    if (fi.conexion.Database != "")
        //    {
        //        baseDeDatos = fi.conexion.Database;
        //    }
        //    else
        //    {
        //        fi.conexion.ChangeDatabase(baseDeDatos);
        //    }
        //}

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
        /// Establece un tamaño automático a los campos dentro de la cabecera.
        /// </summary>
        private void centrarPosicionCabeceraListView()
        {
            if (lvDatos.Columns.Count != 0)
            {
                int tamañoColumna = lvDatos.Width / lvDatos.Columns.Count;
                for (int i = 0; i < lvDatos.Columns.Count; i++)
                {
                    lvDatos.Columns[i].Width = tamañoColumna;
                    //if (i == 0)
                    //    lvDatos.Columns[i].TextAlign = HorizontalAlignment.Right;
                    //else
                    try
                    {
                        lvDatos.Columns[i].TextAlign = HorizontalAlignment.Center;
                    }
                    catch (InvalidOperationException) { }
                    //}
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
            da.Fill(ds, tablaActual);
            //Foreach que carga la cabecera
            foreach (DataTable t in ds.Tables)
            {
                foreach (DataColumn c in t.Columns)
                {
                    lvDatos.Columns.Add(c.ColumnName);
                }
            }
            centrarPosicionCabeceraListView();
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
            centrarPosicionCabeceraListView();
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
            centrarPosicionCabeceraListView();
        }

        private void lvDatos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string nombre = lvDatos.Columns[e.Column].Text;
            cargarTablaOrdenadaPorCabeceraSeleccionada(nombre);
        }
    }
}
