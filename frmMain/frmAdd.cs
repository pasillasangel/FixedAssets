using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using TierEntities;
using TierCall;
using System.Text.RegularExpressions;
using System.Configuration;

namespace frmMain
{
    public partial class frmAdd : Form
    {
        Asset _a = new Asset();
        AssetsCalls _AssetsC = new AssetsCalls();

        string sourceFile = ConfigurationManager.AppSettings["PhotoTemp"];
        string destinationFile = ConfigurationManager.AppSettings["PhotoEnd"];


        public string namePhotoFinal = "";
        public int countFinal = 0;
        public bool PhotoTag = false;
        string previousInputMoney = "";
        string previousInputString = "";
        int intContadorCaracteres = 0;

        public int idSelelectAssetBook = 0;

        List<string> fillResp = new List<string>();
        List<string> fillLoc = new List<string>();

        string date = "";
        string year = "";
        string month = "";
        string day = "";
        DateTime enteredDate;

        int pos;
        
        public frmAdd()
        {
            InitializeComponent();
            FillCombo();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            txtpt.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtdescr.Text == "")
            {
                MessageBox.Show("Ingrese el campo DESCRIPCIÓN, por favor.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (cmbLoc.Text == "")
                {
                    MessageBox.Show("Ingrese el campo UBICACIÓN, por favor.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if(cmbResp.Text == "")
                    {
                        MessageBox.Show("Ingrese el campo RESPONSABLE, por favor.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if(checkBox1.Checked == true)
                        {
                            if(txtOrden.Text == "")
                            {
                                MessageBox.Show("Ingrese el campo PO por favor.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                if (cmbOwner.Text == "")
                                {
                                    MessageBox.Show("Ingrese el campo PROPIEDAD DE por favor.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    Insertdb();
                                }
                            }
                            
                        }
                        else
                        {
                            if (cmbOwner.Text == "")
                            {
                                MessageBox.Show("Ingrese el campo PROPIEDAD DE por favor.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                if (namePhotoFinal == "")
                                {
                                    MessageBox.Show("Tome una FOTO del activo fijo por favor.", "Foto Faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    if (txtinvoDate.MaskCompleted)
                                    {
                                        DateTime Validate;
                                        Regex rDate = new Regex(@"^\d{2}/\d{2}/\d{4}$");
                                        Regex rInvoFate = new Regex("^(MM/DD/YYYY)$");
                                        Match matchDate = rDate.Match(txtinvoDate.Text);
                                        Match matchinvoDate = rInvoFate.Match(txtinvoDate.Text);
                                        if (!matchDate.Success && !matchinvoDate.Success || !matchinvoDate.Success && !DateTime.TryParse(txtinvoDate.Text, out Validate))
                                        {
                                            MessageBox.Show("Ingrese el campo FECHA DE LA FACTURA correctamente, por favor.", "Campo Erróneo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        }
                                        else
                                        {
                                            Insertdb();
                                        }
                                    }
                                    else if (txtinvoDate.Text != "  /  /")
                                    {
                                        MessageBox.Show("Ingrese el campo FECHA DE LA FACTURA correctamente, por favor.", "Campo Erróneo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        Insertdb();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Insertdb()
        {
            if (checkBox1.Checked == true)
            {
                txtbrand.Text = "";
                txtdescr.Text = "";
                txtcost.Text = "";
                txtmodel.Text = "";
                txtpt.Text = "";
                txtserial.Text = "";
                txtNote.Text = "";
                cmbOwner.SelectedIndex = -1;
            }

            try
            {
                //Add
                if (txtcost.Text == "")
                    _a.cost = 0;
                else
                    _a.cost = Convert.ToDecimal(txtcost.Text);

                if (txtcostMx.Text == "")
                    _a.costmx = 0;
                else
                    _a.costmx = Convert.ToDecimal(txtcostMx.Text);

                _a.partNumber = txtpt.Text;
                _a.descrip = txtdescr.Text;
                _a.brand = txtbrand.Text;
                _a.model = txtmodel.Text;
                _a.serial = txtserial.Text;
                _a.picture = namePhotoFinal;
                _a.invoice = txtinvo.Text;
                _a.pedimento = txtped.Text;
                _a.codePedimento = txtpedcod.Text;
                _a.provider = txtprov.Text;
                _a.dateCreate = DateTime.Today;
                _a.idLocationfk = Convert.ToInt32(cmbLoc.SelectedIndex.ToString()) + 1;
                _a.idResponsiblefk = Convert.ToInt32(cmbResp.SelectedIndex.ToString()) + 1;
                _a.notes = txtNote.Text;
                _a.PO = txtOrden.Text;
                _a.owner = cmbOwner.Text;

                if (txtinvoDate.MaskCompleted)
                {
                    year = txtinvoDate.Text.Substring(6, 4);
                    day = txtinvoDate.Text.Substring(3, 2);
                    month = txtinvoDate.Text.Substring(0, 2);
                    date = year + "-" + month + "-" + day;
                    enteredDate = DateTime.Parse(date);
                    _a.invoiceDate = enteredDate;
                }
                else
                {
                    _a.invoiceDate = null;
                }

                int result = _AssetsC.AddAsset(_a);
                if (result == 1)
                {
                    
                    int lastId = _AssetsC.LastId();
                    string oldNamePhoto = namePhotoFinal + ".jpg";

                    if (countFinal >= 10)
                        namePhotoFinal = namePhotoFinal.Remove(namePhotoFinal.Length - 2);
                    else
                        namePhotoFinal = namePhotoFinal.Remove(namePhotoFinal.Length - 1);

                    namePhotoFinal = namePhotoFinal + lastId.ToString() + ".jpg";
                    string sourceFile2 = sourceFile + oldNamePhoto;
                    string destinationFile2 = destinationFile + namePhotoFinal;
                    Renamefile(sourceFile2, destinationFile2);

                    if (idSelelectAssetBook != 0)
                    {
                        int quantityResult = _AssetsC.SubtractAssetsBook(idSelelectAssetBook);
                        if (quantityResult != 1)
                        {
                            MessageBox.Show("Error en la base de datos al disminuir cantidad en el Activo Seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    _a.IdAssets = lastId;
                    _a.picture = namePhotoFinal;
                    int resultPic = _AssetsC.UpdatePicture(_a);
                    if (resultPic == 1)
                    {
                        Clear();
                        this.ActiveControl = txtpt;
                        frmShowQR frmQR = new frmShowQR(lastId);
                        frmQR.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error: En el momento de INSERTAR en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error: En el momento de INSERTAR en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Renamefile(string oldfile, string newfile)
        {
            if (File.Exists(oldfile))
            {
                File.Copy(oldfile, newfile, true);
            }
        }


        private void FillCombo()
        {
            pos = 0;
            fillLoc = _AssetsC.FillLocation();
            foreach (string name in fillLoc)
            {
                cmbLoc.Items.Insert(pos, name);
                pos++;
            }
            pos = 0;
            fillResp = _AssetsC.FillResponsible();
            foreach (string name in fillResp)
            {
                cmbResp.Items.Insert(pos, name);
                pos++;
            }
        }

        private void Clear()
        {
            txtbrand.Text = "";
            txtdescr.Text = "";
            txtcost.Text = "";
            txtmodel.Text = "";
            txtpt.Text = "";
            txtserial.Text = "";
            txtNote.Text = "";
            cmbOwner.SelectedIndex = -1;

            txtbrand.Text = "";
            txtdescr.Text = "";
            txtinvo.Text = "";
            txtped.Text = "";
            txtpedcod.Text = "";
            txtprov.Text = "";
            txtcost.Text = "";
            txtmodel.Text = "";
            txtpt.Text = "";
            txtserial.Text = "";
            txtinvoDate.Text = "";
            txtcostMx.Text = "";
            txtOrden.Text = "";

            countFinal = 0;
            namePhotoFinal = "";
            picPhotoTag.Visible = false;
            lblPhotoTag.Text = "Imagen NO Capturada";
            lblPhotoTag.ForeColor = Color.Black;
            lblPhotoTag.Font = new Font(lblPhotoTag.Font, FontStyle.Regular);
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            if (txtdescr.Text == "")
            {
                MessageBox.Show("Ingrese el campo DESCRIPCIÓN por favor. Es requerido para tomar la foto.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string namePhoto = txtdescr.Text;

                namePhoto = namePhoto.Replace(" ", "_");
                frmAddPhoto frmCC = new frmAddPhoto(namePhoto, this);
                frmCC.ShowDialog();
            }
        }

        public void ShogPhotoTag()
        {
            if (PhotoTag)
            {
                lblPhotoTag.Visible = true;
                picPhotoTag.Visible = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            
            cmbOwner.SelectedIndex = -1;
            cmbLoc.SelectedIndex = -1;
            cmbResp.SelectedIndex = -1;
            txtbrand.Text = "";
            txtdescr.Text = "";
            txtinvo.Text = "";
            txtped.Text = "";
            txtpedcod.Text = "";
            txtprov.Text = "";
            txtcost.Text = "";
            txtmodel.Text = "";
            txtpt.Text = "";
            txtserial.Text = "";

        }

        private void txtcost_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^-{0,1}\d+\.{0,1}\d*$");
            Match m = r.Match(txtcost.Text);
            if (m.Success)
            {
                previousInputMoney = txtcost.Text;
            }
            else if (txtcost.Text == "")
            {
                txtcost.Text = "";
            }
            else
            {
                txtcost.Text = previousInputMoney;
            }
        }

        private void txtdescr_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[a-zA-Z0-9\s]+$");
            Match m = r.Match(txtdescr.Text);
            if (m.Success)
            {
                previousInputString = txtdescr.Text;
            }
            else if (txtdescr.Text == "")
            {
                txtdescr.Text = "";
            }
            else
            {
                txtdescr.Text = previousInputString;
            }
        }



        private void txtcostMx_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^-{0,1}\d+\.{0,1}\d*$");
            Match m = r.Match(txtcostMx.Text);
            if (m.Success)
            {
                previousInputMoney = txtcostMx.Text;
            }
            else if (txtcost.Text == "")
            {
                txtcostMx.Text = "";
            }
            else
            {
                txtcostMx.Text = previousInputMoney;
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                //txtinvo.Text = "";
                //txtinvoDate.Text = "";
                //txtped.Text = "";
                //txtpedcod.Text = "";
                //txtprov.Text = "";
                //txtcost.Text = "";
                //txtcostMx.Text = "";
                //cmbOwner.Text = "";

                lblNotaObligatorios.Visible = true;

                txtinvo.Enabled = false;
                txtinvoDate.Enabled = false;
                txtped.Enabled = false;
                txtpedcod.Enabled = false;
                txtprov.Enabled = false;
                txtcost.Enabled = false;
                txtcostMx.Enabled = false;

                txtinvo.BackColor = Color.LightGray;
                txtinvoDate.BackColor = Color.LightGray;
                txtped.BackColor = Color.LightGray;
                txtpedcod.BackColor = Color.LightGray;
                txtprov.BackColor = Color.LightGray;
                txtcost.BackColor = Color.LightGray;
                txtcostMx.BackColor = Color.LightGray;
            }
            else
            {
                lblNotaObligatorios.Visible = false;

                txtinvo.Enabled = true;
                txtinvoDate.Enabled = true;
                txtped.Enabled = true;
                txtpedcod.Enabled = true;
                txtprov.Enabled = true;
                txtcost.Enabled = true;
                txtcostMx.Enabled = true;

                txtinvo.BackColor = Color.White;
                txtinvoDate.BackColor = Color.White;
                txtped.BackColor = Color.White;
                txtpedcod.BackColor = Color.White;
                txtprov.BackColor = Color.White;
                txtcost.BackColor = Color.White;
                txtcostMx.BackColor = Color.White;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmAssetsBook frmCC = new frmAssetsBook(this);
            frmCC.ShowDialog();
        }

        private void btnGroupsImage_Click(object sender, EventArgs e)
        {
            frmAddGroupPhotos frmCC = new frmAddGroupPhotos();
            frmCC.ShowDialog();
        }
    }
}

