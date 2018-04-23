using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
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
            if (fi.baseDeDatos == "")
            {
                CerrarPrograma();
            }
            else
            {
                baseDeDatos = fi.baseDeDatos;
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
            ComprobarCargarBaseDeDatos();
        }

        /// <summary>
        /// Pestaña del menú que abre una base de datos.
        /// </summary>
        /// <param name="sender">El item del menú</param>
        /// <param name="e">El evento</param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fi.AbrirInventario(fi.openFileDialog1);
            ComprobarCargarBaseDeDatos();
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
        /// Comprueba si se intenta crear/cargar una nueva base de datos, si no se crea/carga correctamente se
        /// reestablece el nombre de la base de datos.
        /// </summary>
        private void ComprobarCargarBaseDeDatos()
        {
            if (fi.baseDeDatos != "")
            {
                baseDeDatos = fi.baseDeDatos;
            }
            else
            {
                fi.baseDeDatos = baseDeDatos;
            }
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
    }
}
