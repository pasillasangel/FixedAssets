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
    public partial class frmAssetsBook : Form
    {
        AssetsCalls _AssetsC = new AssetsCalls();

        private frmAdd f1;
        
        string searchWord;
        int CountRows;

        string idAssetBook = "";
        string partnumber;
        string descrip;
        string brand;
        string model;
        string serial;
        string invoice;
        string invoiceDate;
        string pedimento;
        string codePedimento;
        string provider;
        string cost;
        string costMX;
        string po;
        string notes;
        string owner;
        string total;
        string quantity;

        string prevDate;
        string subDate;


        public frmAssetsBook(frmAdd frmAdd)
        {
            InitializeComponent();
            this.f1 = frmAdd;
            dgvAsset.DataSource = _AssetsC.ConsultAssetsBookAll();
            dgvAssetInitial();
            CountAssets();
            Cursor.Current = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAsset_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                DataGridViewRow row = dgvAsset.Rows[e.RowIndex];
                idAssetBook = row.Cells[0].Value.ToString();
                partnumber = row.Cells[1].Value.ToString();
                descrip = row.Cells[2].Value.ToString();
                brand = row.Cells[3].Value.ToString();
                model = row.Cells[4].Value.ToString();
                serial = row.Cells[5].Value.ToString();
                invoice = row.Cells[6].Value.ToString();
                invoiceDate = row.Cells[7].Value.ToString();
                pedimento = row.Cells[8].Value.ToString();
                codePedimento = row.Cells[9].Value.ToString();
                provider = row.Cells[10].Value.ToString();
                cost = row.Cells[11].Value.ToString();
                costMX = row.Cells[12].Value.ToString();
                po = row.Cells[13].Value.ToString();
                notes = row.Cells[14].Value.ToString();
                owner = row.Cells[15].Value.ToString();
                total = row.Cells[16].Value.ToString();
                quantity = row.Cells[17].Value.ToString();
            }
            catch (Exception)
            {
                
            }

            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(idAssetBook == "")
            {
                MessageBox.Show("Seleccione una Activo.", "Acción requerida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                ClearTxt();

                f1.txtpt.Text = partnumber;
                f1.txtdescr.Text = descrip;
                f1.txtbrand.Text = brand;
                f1.txtmodel.Text = model;
                f1.txtserial.Text = serial;
                f1.txtinvo.Text = invoice;

                if (invoiceDate != "")
                {
                    char mychar = invoiceDate[1];
                    if (mychar == '/')
                        invoiceDate = "0" + invoiceDate;

                    if (invoiceDate[2] == '/' && invoiceDate[4] == '/')
                    {
                        prevDate = invoiceDate.Substring(0,3);
                        subDate = invoiceDate.Substring(3);
                        subDate = "0" + subDate;
                        prevDate = prevDate + subDate;

                        f1.txtinvoDate.Text = prevDate;
                    }
                    else
                    {
                        f1.txtinvoDate.Text = invoiceDate;
                    }
                    
                }
                else
                {
                    f1.txtinvoDate.Text = "";
                }

                f1.txtped.Text = pedimento;
                f1.txtpedcod.Text = codePedimento;
                f1.txtprov.Text = provider;
                f1.txtcost.Text = cost;
                f1.txtcostMx.Text = costMX;
                f1.txtOrden.Text = po;
                f1.txtNote.Text = notes;

                if(owner == "RicohUS")
                {
                    f1.cmbOwner.SelectedIndex = 0;
                }
                else if (owner == "RicohBaja")
                {
                    f1.cmbOwner.SelectedIndex = 1;
                }
                else if (owner == "REI")
                {
                    f1.cmbOwner.SelectedIndex = 2;
                }

                f1.idSelelectAssetBook = Convert.ToInt32(idAssetBook);
                
                this.Close();
            }
        }

        private void CountAssets()
        {
            CountRows = dgvAsset.Rows.Count;
            lblCount.Text = "Total de Activos en Bitácora: " + CountRows.ToString();
        }



        private void ClearTxt()
        {
            var strRemove = new string[] { "@", ",", ".", ";", "'", "\\",
                "/", ":", "*", "?", "\"", "<", ">", "|", "(", ")", "[",
                "]", "{", "}", "#", "$", "%", "^", "&", "-", "_", "=",
                "+", "\t", "\n"};

            foreach (var c in strRemove)
            {
                descrip = descrip.Replace(c, string.Empty);
            }

            f1.txtpt.Text = "";
            f1.txtdescr.Text = "";
            f1.txtbrand.Text = "";
            f1.txtmodel.Text = "";
            f1.txtserial.Text = "";
            f1.txtinvo.Text = "";
            f1.txtinvoDate.Text = "";
            f1.txtped.Text = "";
            f1.txtpedcod.Text = "";
            f1.txtprov.Text = "";
            f1.txtcost.Text = "";
            f1.txtcostMx.Text = "";
            f1.txtOrden.Text = "";
            f1.txtNote.Text = "";
            f1.cmbOwner.Text = "";
        }

        private void dgvAssetInitial()
        {
            dgvAsset.Columns[0].HeaderText = "Id";
            dgvAsset.Columns[1].HeaderText = "Número de Parte";
            dgvAsset.Columns[2].HeaderText = "Descripción";
            dgvAsset.Columns[3].HeaderText = "Marca";
            dgvAsset.Columns[4].HeaderText = "Modelo";
            dgvAsset.Columns[5].HeaderText = "Serie";
            dgvAsset.Columns[6].HeaderText = "Factura";
            dgvAsset.Columns[7].HeaderText = "Fecha Factura";
            dgvAsset.Columns[8].HeaderText = "Pedimento";
            dgvAsset.Columns[9].HeaderText = "Código Pedimento";
            dgvAsset.Columns[10].HeaderText = "Proveedor";
            dgvAsset.Columns[11].HeaderText = "CostoUS";
            dgvAsset.Columns[12].HeaderText = "CostoMx";
            dgvAsset.Columns[13].HeaderText = "PO";
            dgvAsset.Columns[14].HeaderText = "Notas";
            dgvAsset.Columns[15].HeaderText = "Propiedad de";
            dgvAsset.Columns[16].HeaderText = "Cantidad";
            dgvAsset.Columns[17].HeaderText = "Total";

            dgvAsset.Columns[0].Visible = false;
            dgvAsset.Columns[1].Visible = false;
            dgvAsset.Columns[10].Visible = false;
            //dgvAsset.Columns[11].Visible = false;
            //dgvAsset.Columns[12].Visible = false;
            //dgvAsset.Columns[13].Visible = false;
            dgvAsset.Columns[14].Visible = false;
            dgvAsset.Columns[15].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (txtS.Text == "")
            {
                dgvAsset.DataSource = _AssetsC.ConsultAssetsBookAll();
            }
            else
            {
                if (searchWord == txtS.Text) { }
                else
                {
                    searchWord = txtS.Text;
                    
                    dgvAsset.DataSource = _AssetsC.ConsultAssetsBooksSearch(searchWord);
                    dgvAssetInitial();
                    CountAssets();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void txtS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
