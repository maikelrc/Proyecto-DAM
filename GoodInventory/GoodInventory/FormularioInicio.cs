using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using ADOX;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

        /// <summary>
        /// Nombre de la base de datos.
        /// </summary>
        public string baseDeDatos;

        /// <summary>
        /// Proveedor de la base de datos.
        /// </summary>
        private string proveedor = "Microsoft.ACE.OLEDB.12.0";

        /// <summary>
        /// Booleana que marca si se minimiza o no el formulario.
        /// </summary>
        private bool minimizarForm = true;

        /// <summary>
        /// Abre una nueva conexión a la base de datos de la ruta pasada por parámetro (nombre de la base de datos incluído en la ruta).
        /// </summary>
        /// <param name="bd">La ruta</param>
        public void AbrirConexion(string bd)
        {
            try
            {
                string strConnection = "Provider=" + proveedor + ";Data Source=" + bd + ";User ID=admin";
                conexion = new OleDbConnection(strConnection);
                conexion.Open();
                minimizarForm = true;
            }
            catch (OleDbException)
            {
                string mensaje = "No se reconoce el formato de la base de datos.";
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                minimizarForm = false;
                conexion = null;
            }
            catch (InvalidOperationException)
            {
                string mensaje = "El proveedor de base de datos'" + proveedor + "' no está registrado en el equipo local.";
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                minimizarForm = false;
                conexion = null;
            }
        }

        /// <summary>
        /// Crea una nueva base de datos en la ruta pasada por parámetro (nombre de la base de datos incluído en la ruta).
        /// </summary>
        /// <param name="bd">La ruta</param>
        public void CrearBaseDeDatos(string bd)
        {
            try
            {
                ADOX.Catalog cat = new Catalog();
                cat.Create("Provider=" + proveedor + ";Data Source=" + bd + ";");
                minimizarForm = true;
            }
            catch (COMException ex)
            {
                string mensaje = "El proveedor de base de datos'" + proveedor + "' no está registrado en el equipo local.";
                //BD existente -> -2147217897
                if (ex.ErrorCode.ToString() == "-2147217897")
                {
                    mensaje = "La base de datos que intenta crear ya existe.";
                }
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                minimizarForm = false;
                conexion = null;
            }
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
            this.saveFileDialog1.FileName = "";
            this.saveFileDialog1.ShowDialog();
            try
            {
                if (this.saveFileDialog1.FileName != "")
                {
                    baseDeDatos = (this.saveFileDialog1.FileName);
                    CrearBaseDeDatos(baseDeDatos);
                    if (minimizarForm)
                    {
                        AbrirConexion(baseDeDatos);
                        this.Hide();
                    }
                }
            }
            catch (ArgumentException) { }
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
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.FileName != "")
            {
                baseDeDatos = this.openFileDialog1.FileName;
                AbrirConexion(baseDeDatos);
                if (minimizarForm) this.Hide();
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
        private void FormularioInicio_Load(object sender, EventArgs e) { }
    }
}
