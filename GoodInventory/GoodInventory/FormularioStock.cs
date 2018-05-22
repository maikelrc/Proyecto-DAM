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

        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
        private string baseDeDatos;
        private string tablaActual;

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
        }

        private void EstablecerTablaActual()
        {
            tablaActual = lbTablas.SelectedItem.ToString();
        }
    }
}
