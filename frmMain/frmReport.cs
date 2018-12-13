using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmMain
{
    public partial class frmReport : Form
    {
        int idLocation = 0;
        public frmReport(int Location)
        {
            InitializeComponent();
            this.idLocation = Location;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbreport.DataTable1' Puede moverla o quitarla según sea necesario.
            this.DataTable1TableAdapter.Fill(this.dbreport.DataTable1, idLocation);

            this.rv.RefreshReport();
        }
    }
}
