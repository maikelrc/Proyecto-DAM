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
    public partial class FormularioNuevaTabla : Form
    {
        public bool cerrarForm = true;

        public FormularioNuevaTabla()
        {
            InitializeComponent();
        }

        public void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioNuevaTabla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrarForm) e.Cancel = true;
            cerrarForm = true;
        }
    }
}
