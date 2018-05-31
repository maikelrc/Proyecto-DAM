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
    public partial class FormularioEditarCampos : Form
    {
        public FormularioEditarCampos()
        {
            InitializeComponent();
        }

        private void FormularioEditarCampos_Load(object sender, EventArgs e)
        {
            FormularioStock fs = new FormularioStock();
            fs.centrarPosicionCabeceraListView(lvCampos, true);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
