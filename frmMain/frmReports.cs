using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TierCall;
using TierEntities;

namespace frmMain
{
    public partial class frmReports : Form
    {
        AssetsCalls _AssetsC = new AssetsCalls();

        List<string> fillLoc = new List<string>();

        int pos;
        int posSelected;
        int CountRows;

        public frmReports()
        {
            InitializeComponent();
            FillCombo();
            cmbLoc.SelectedIndex = 0;
        }

        private void FillCombo()
        {
            pos = 0;
            cmbLoc.Items.Insert(pos, "ALL");
            pos++;
            fillLoc = _AssetsC.FillLocation();
            foreach (string name in fillLoc)
            {
                cmbLoc.Items.Insert(pos, name);
                pos++;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            posSelected = Convert.ToInt32(cmbLoc.SelectedIndex.ToString());

            if (posSelected != 0)
            {
                frmReport frmQR = new frmReport(posSelected);
                frmQR.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione una ubicación.");
            }
        }
    }
}
