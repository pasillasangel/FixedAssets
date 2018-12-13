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
    public partial class frmConsult : Form
    {
        AssetsCalls _AssetsC = new AssetsCalls();
        
        List<string> fillLoc = new List<string>();

        private frmMainProject f;
        
        int pos;
        string searchWord;
        int posSelected;
        int CountRows;

        public frmConsult(frmMainProject frmM)
        {
            
            InitializeComponent();
            this.f = frmM;
            FillCombo();
            cmbLoc.SelectedIndex = 0;
            dgvAsset.DataSource = _AssetsC.ConsultAssetTop100();
            dgvAssetInitial();
            CountInitialize();
            Cursor.Current = Cursors.Default;
            this.ActiveControl = txtS;
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

        public void CountInitialize()
        {
            int totalAssets = _AssetsC.ConsultAssetsTotal();
            lblCount.Text = "Total de Activos: " + totalAssets.ToString();
        }

        private void CountAssets()
        {
            CountRows = dgvAsset.Rows.Count;
            lblCount.Text = "Total de Activos: " + CountRows.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            posSelected = Convert.ToInt32(cmbLoc.SelectedIndex.ToString());

            if (txtS.Text == "" && Convert.ToInt32(cmbLoc.SelectedIndex.ToString()) == 0)
            {
                dgvAsset.DataSource = _AssetsC.ConsultAllAssetVisible();
                CountAssets();
            }
            else if (txtS.Text == "")
            {
                dgvAsset.DataSource = _AssetsC.ConsultAssetNormalLocationOnly(posSelected);
                CountAssets();
            }
            else
            {
                if (searchWord == txtS.Text && posSelected == Convert.ToInt32(cmbLoc.SelectedIndex.ToString())) { }
                else
                {
                    searchWord = txtS.Text;

                    if (posSelected == 0)
                    {
                        dgvAsset.DataSource = _AssetsC.ConsultAssetNormal(searchWord);
                    }
                    else
                    {
                        dgvAsset.DataSource = _AssetsC.ConsultAssetNormalLocation(searchWord, posSelected);
                    }
                    CountAssets();
                }
            }
            
        }


        private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            posSelected = Convert.ToInt32(cmbLoc.SelectedIndex.ToString());
            if (txtS.Text == "")
            {
                if(posSelected != 0)
                {
                    dgvAsset.DataSource = _AssetsC.ConsultAssetNormalLocationOnly(posSelected);
                }
                else
                {
                    dgvAsset.DataSource = _AssetsC.ConsultAllAssetVisible();
                }
                CountAssets();
            }
            else
            {
                searchWord = txtS.Text;
                if (posSelected == 0)
                {
                    dgvAsset.DataSource = _AssetsC.ConsultAssetNormal(searchWord);
                }
                else
                {
                    dgvAsset.DataSource = _AssetsC.ConsultAssetNormalLocation(searchWord, posSelected);
                }
                CountAssets();
            }
        }

        private void dgvAsset_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvAsset.Rows[e.RowIndex];
                string id = row.Cells[0].Value.ToString();

                f.idConsult = id;
                f.btnUpdate.PerformClick();
            }
            catch (Exception)
            {

            }
        }

        private void dgvAssetInitial()
        {
            dgvAsset.Columns[0].HeaderText = "Id";
            dgvAsset.Columns[1].HeaderText = "Descripción";
            dgvAsset.Columns[2].HeaderText = "Ubicación";
            dgvAsset.Columns[3].HeaderText = "Responsable";
            dgvAsset.Columns[4].HeaderText = "CostoUS";
            dgvAsset.Columns[5].HeaderText = "CostoMX";
            dgvAsset.Columns[6].HeaderText = "Marca";
            dgvAsset.Columns[7].HeaderText = "Modelo";
            dgvAsset.Columns[8].HeaderText = "Serie";
            dgvAsset.Columns[9].HeaderText = "Factura";
            dgvAsset.Columns[10].HeaderText = "Fecha Factura";
            dgvAsset.Columns[11].HeaderText = "Pedimento";
            dgvAsset.Columns[12].HeaderText = "Código Pedimento";
            dgvAsset.Columns[13].HeaderText = "Proveedor";
            dgvAsset.Columns[14].HeaderText = "Creado";
            dgvAsset.Columns[15].HeaderText = "PO";
            dgvAsset.Columns[16].HeaderText = "Propiedad de";
            dgvAsset.Columns[17].HeaderText = "Notas";

            dgvAsset.Columns[0].Visible = false;
        }

        private void txtS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnSearch.PerformClick();
            }
        }

        private void frmConsult_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtS;
        }
    }
}
