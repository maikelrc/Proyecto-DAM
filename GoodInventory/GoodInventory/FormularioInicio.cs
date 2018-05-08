using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodInventory
{
    public partial class FormularioInicio : Form
    {

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public FormularioInicio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Conexión al proveedor de datos OLE DB. NET.
        /// </summary>
        public OleDbConnection conexion;

        private void AbrirConexion(string bd)
        {
            try
            {
                string strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + bd + ";";
                conexion = new OleDbConnection(strConnection);
                btnAbrirInventario.Text = conexion.Database;
                conexion.Open();
            }
            catch (OleDbException) { }
        }

        /// <summary>
        /// Establece a la variable "baseDeDatos" el nombre de una nueva base de datos que deseamos crear y además la crea.
        /// </summary>
        /// <param name="saveFileDialog1"></param>
        public void NuevoInventario(SaveFileDialog saveFileDialog1)
        {
            this.saveFileDialog1.Title = "Selección de directorio para almacenar inventario (base de datos .accdb)";
            this.saveFileDialog1.InitialDirectory = "C:\\";
            this.saveFileDialog1.Filter = "access(*.accdb) | *.accdb";
            this.saveFileDialog1.ValidateNames = true;
            this.saveFileDialog1.ShowDialog();
            StreamWriter s = null;
            try
            {
                s = new StreamWriter(this.saveFileDialog1.FileName);
                AbrirConexion(this.saveFileDialog1.FileName);
                this.Hide();
            }
            catch (ArgumentException) { }
            finally
            {
                if (s != null) s.Close();
            }
        }

        /// <summary>
        /// Establece a la variable "baseDeDatos" el nombre de una base de datos existente.
        /// </summary>
        /// <param name="openFileDialog1"></param>
        public void AbrirInventario(OpenFileDialog openFileDialog1)
        {
            this.openFileDialog1.Title = "Selección de inventario (base de datos .accdb) para mostrar su contenido.";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Filter = "access(*.accdb) | *.accdb";
            this.openFileDialog1.ShowDialog();
            AbrirConexion(this.openFileDialog1.FileName);
            if (conexion.Database == "openFileDialog1")
            {
                conexion.ChangeDatabase("");
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Código que se ejecuta cuándo se pulsa el botón
        /// </summary>
        /// <param name="sender">El botón</param>
        /// <param name="e">El evento</param>
        private void btnNuevoInventario_Click(object sender, EventArgs e)
        {
            NuevoInventario(this.saveFileDialog1);
        }

        /// <summary>
        /// Código que se ejecuta cuándo se pulsa el botón
        /// </summary>
        /// <param name="sender">El botón</param>
        /// <param name="e">El evento</param>
        private void btnAbrirInventario_Click(object sender, EventArgs e)
        {
            AbrirInventario(this.openFileDialog1);
        }

        /// <summary>
        /// Carga diferentes datos antes de ejecutar el formulario.
        /// </summary>
        /// <param name="sender">El formulario</param>
        /// <param name="e">El evento</param>
        private void FormularioInicio_Load(object sender, EventArgs e)
        {
            AbrirConexion("C:\\Users\\maike\\OneDrive\\Documentos\\GitHub\\Proyecto-DAM\\GoodInventory\\bd.accdb");
        }
    }
}
