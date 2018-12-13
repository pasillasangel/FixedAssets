using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Neodynamic.WinControls.BarcodeProfessional;
using Neodynamic.Windows.ThermalLabelEditor;
using Neodynamic.SDK.Printing;


using System.Drawing.Printing;
using System.Management;
using System.Printing;
using System.Reflection;


using TierCall;
using TierEntities;
using System.Text.RegularExpressions;

namespace frmMain
{
    public partial class frmUpdateAsset : Form
    {
        Asset _aObject = new Asset();
        AssetsCalls _AssetsC = new AssetsCalls();
        ChangeAssetsCalls _ChangeAC = new ChangeAssetsCalls();


        string sourceFile = ConfigurationManager.AppSettings["PhotoEnd"];
        public static string _Printer = ConfigurationManager.AppSettings["Printer"];

        string nameImage = "";

        Asset _aSearch;
        ChangeAssets _changeA;
        List<string> fillResp = new List<string>();
        List<string> fillLoc = new List<string>();
        bool noPhoto = true;
        
        int pos;

        int idloc;
        int idres;
        string ped;
        string codeped;
        string notes;
        string dateInvoi;
        string invoi;
        string prov;
        string po;
        string owner;

        string dateNew = "";
        string year = "";
        string day = "";
        string month = "";
        string date = "";
        bool booldate = false;
        bool booldateEdit = false;
        DateTime enteredDate;
        

        public frmUpdateAsset(string idS)
        {
            ThermalLabel.LicenseOwner = ConfigurationManager.AppSettings["ThermalOwner"];
            ThermalLabel.LicenseKey = ConfigurationManager.AppSettings["ThermalKey"];

            BarcodeProfessional.LicenseOwner = ConfigurationManager.AppSettings["BarcodeProOwner"];
            BarcodeProfessional.LicenseKey = ConfigurationManager.AppSettings["BarcodeProKey"];

            InitializeComponent();
            _aObject.IdAssets = 0;
            FillCombo();

            if(idS != "")
            {
                txtid.Text = idS;
                Search();
            }
        }

        private void Search()
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Ingrese el campo CÓDIGO QR por favor.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                _aObject.IdAssets = 0;
            }
            else
            {
                if (Convert.ToInt32(txtid.Text) == _aObject.IdAssets) {  }
                else
                {
                    try
                    {
                        _aObject.IdAssets = Convert.ToInt32(txtid.Text);
                        _aSearch = new Asset();
                        _aSearch = _AssetsC.SearchAsset(_aObject);
                        bool show = _aSearch.visible;
                        if (!_aSearch.visible)
                        {
                            MessageBox.Show("El activo que usted busca no existe.", "Activo no encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (_aSearch.visible)
                            {
                                txtpt.Text = _aSearch.partNumber;
                                txtdescr.Text = _aSearch.descrip;
                                txtbrand.Text = _aSearch.brand;
                                txtmodel.Text = _aSearch.model;
                                invoi = txtinvo.Text = _aSearch.invoice;
                                ped = txtped.Text = _aSearch.pedimento;
                                codeped = txtpedcod.Text = _aSearch.codePedimento;
                                prov = txtprov.Text = _aSearch.provider;
                                txtcost.Text = Convert.ToString(_aSearch.cost);
                                txtcostMx.Text = Convert.ToString(_aSearch.costmx);
                                txtserial.Text = _aSearch.serial;
                                idloc = cmbLoc.SelectedIndex = _aSearch.idLocationfk - 1;
                                idres = cmbResp.SelectedIndex = _aSearch.idResponsiblefk - 1;
                                notes = txtNote.Text = _aSearch.notes;
                                owner = cmbCond.Text = _aSearch.owner;
                                po = txtOrden.Text = _aSearch.PO;
                                
                                if (_aSearch.invoiceDate != null)
                                {
                                    dateInvoi = txtinvoD.Text = String.Format("{0:MM/dd/yyyy}", _aSearch.invoiceDate);
                                }
                                else
                                {
                                    txtinvoD.Text = "";
                                    dateInvoi = "";
                                }

                                if (_aSearch.picture != "")
                                {
                                    nameImage = _aSearch.picture;
                                    picAsset.Image = Image.FromFile(sourceFile + nameImage);
                                    noPhoto = true;
                                }
                                else
                                {
                                    picAsset.Image = Image.FromFile(sourceFile + "image_not_available.jpg");
                                    noPhoto = false;
                                }

                                dgvAsset.DataSource = _ChangeAC.ConsultAllAssetChange(_aObject);

                                //Name Columns Headers
                                dgvAsset.Columns[0].HeaderText = "Id";
                                dgvAsset.Columns[1].HeaderText = "Ubicación";
                                dgvAsset.Columns[2].HeaderText = "Responsable";
                                dgvAsset.Columns[4].HeaderText = "Clave Pedimento";
                                dgvAsset.Columns[5].HeaderText = "Factura";
                                dgvAsset.Columns[6].HeaderText = "Fecha Factura";
                                dgvAsset.Columns[7].HeaderText = "PO";
                                dgvAsset.Columns[8].HeaderText = "Proveedor";
                                dgvAsset.Columns[9].HeaderText = "Propiedad de";
                                dgvAsset.Columns[10].HeaderText = "Fecha de Cambio";
                                dgvAsset.Columns[11].HeaderText = "Notas";
                                dgvAsset.Columns[0].Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Este activo fijo ya no existe en la base de datos.", "Activo se dado de baja", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_aObject.IdAssets == 0)
            {
                MessageBox.Show("Busque primero un Activo Fijo.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkDateEdit())
                    booldateEdit = true;
                else
                    booldateEdit = false;

                if (invoi != txtinvo.Text ||ped != txtped.Text || codeped != txtpedcod.Text || idloc != cmbLoc.SelectedIndex || idres != cmbResp.SelectedIndex || notes != txtNote.Text || po != txtOrden.Text || owner != cmbCond.Text || prov != txtprov.Text || booldateEdit)
                {


                    if (booldateEdit)
                    {
                        try
                        {
                            year = txtinvoD.Text.Substring(6, 4);
                            day = txtinvoD.Text.Substring(3, 2);
                            month = txtinvoD.Text.Substring(0, 2);

                            if (txtinvoD.MaskCompleted)
                            {
                                DateTime Validate;
                                Regex rDate = new Regex(@"^\d{2}/\d{2}/\d{4}$");
                                Regex rInvoFate = new Regex("^(MM/DD/YYYY)$");
                                Match matchDate = rDate.Match(txtinvoD.Text);
                                Match matchinvoDate = rInvoFate.Match(txtinvoD.Text);

                                booldate = true;

                                if (!matchDate.Success && !matchinvoDate.Success || !matchinvoDate.Success && !DateTime.TryParse(txtinvoD.Text, out Validate))
                                {
                                    booldate = false;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show("Ingrese una FECHA DE FACTURA CORRECTA, por favor.", "Campo Erróneo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        if (booldate)
                        {
                            UpdateBd();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese una FECHA DE FACTURA CORRECTA, por favor.", "Campo Erróneo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        UpdateBd();
                    }
                }
                else
                {
                    MessageBox.Show("Realize por lo menos un cambio en la información por favor.", "Faltan Cambios", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void UpdateBd()
        {
            try
            {
                //Update
                _aObject.pedimento = txtped.Text;
                _aObject.codePedimento = txtpedcod.Text;
                _aObject.idLocationfk = Convert.ToInt32(cmbLoc.SelectedIndex.ToString()) + 1;
                _aObject.idResponsiblefk = Convert.ToInt32(cmbResp.SelectedIndex.ToString()) + 1;
                _aObject.notes = txtNote.Text;
                _aObject.PO = txtOrden.Text;
                _aObject.costmx = Convert.ToDecimal(txtcostMx.Text);
                _aObject.invoice = txtinvo.Text;
                _aObject.owner = cmbCond.Text;
                _aObject.provider = txtprov.Text;

                if (txtinvoD.Text != "  /  /")
                {
                    date = "";
                    day = "";
                    year = "";
                    month = "";
                    year = txtinvoD.Text.Substring(6, 4);
                    day = txtinvoD.Text.Substring(3, 2);
                    month = txtinvoD.Text.Substring(0, 2);
                    date = year + "-" + month + "-" + day;

                    enteredDate = DateTime.Parse(date);
                    _aObject.invoiceDate = enteredDate;
                }
                else
                {
                    _aObject.invoiceDate = null;
                }
                if (_AssetsC.UpdateAsset(_aObject) == 1)
                {
                    //Add change
                    _changeA = new ChangeAssets();
                    _changeA.idAssetsfk = _aSearch.IdAssets;
                    _changeA.idLocationfkch = _aSearch.idLocationfk;
                    _changeA.idResponsiblefkch = _aSearch.idResponsiblefk;
                    _changeA.pedimento = _aSearch.pedimento;
                    _changeA.codePedimento = _aSearch.codePedimento;
                    _changeA.visible = _aSearch.visible;
                    _changeA.dateChange = DateTime.Now;
                    _changeA.notes = _aSearch.notes;
                    _changeA.invoice = _aSearch.invoice;
                    _changeA.PO = _aSearch.PO;
                    _changeA.provider = _aSearch.provider;
                    _changeA.owner = _aSearch.owner;

                    if (txtinvoD.Text != "")
                        _changeA.invoiceDate = _aObject.invoiceDate;
                    else
                        _changeA.invoiceDate = null;

                    if (_ChangeAC.AddChangeAsset(_changeA) == 1)
                    {
                        Clear();
                        MessageBox.Show("Información Actualizada.", "Operación exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Error: En el momento de ACTUALIZAR en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR 1: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //error al actulizar
        private bool checkDateEdit()
        {
            if (txtinvoD.Text != "  /  /")
            {
                if (dateInvoi == "")
                {
                    if (txtinvoD.MaskCompleted)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (txtinvoD.MaskCompleted)
                    {
                        date = "";
                        day = "";
                        year = "";
                        month = "";
                        year = txtinvoD.Text.Substring(6, 4);
                        day = txtinvoD.Text.Substring(3, 2);
                        month = txtinvoD.Text.Substring(0, 2);
                        date = month + "/" + day + "/" + year;
                    }

                    if (date == txtinvoD.Text)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            
        }

        private void Clear()
        {
            txtNote.Text = "";
            txtid.Text = "";
            txtbrand.Text = "";
            txtcost.Text = "";
            txtdescr.Text = "";
            txtinvo.Text = "";
            txtmodel.Text = "";
            txtped.Text = "";
            txtpedcod.Text = "";
            txtprov.Text = "";
            txtpt.Text = "";
            txtserial.Text = "";
            cmbCond.SelectedIndex = -1;
            cmbLoc.SelectedIndex = -1;
            cmbResp.SelectedIndex = -1;
            picAsset.Image = null;
            _aObject.IdAssets = 0;
            dgvAsset.DataSource = null;

            txtinvoD.Text = "";
            txtOrden.Text = "";
            txtcostMx.Text = "";

            this.ActiveControl = txtid;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (_aObject.IdAssets == 0)
            {
                MessageBox.Show("Busque primero un Activo Fijo.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este activo?", "Confirmación", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {

                    if (_AssetsC.RemoveAsset(_aObject) == 1)
                    {
                        Clear();
                        MessageBox.Show("Información Actualizada. \nActivo Eliminado", "Operación exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    } else
                    {
                        MessageBox.Show("Error al Eliminar el Activo Fijo", "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (result == DialogResult.No)
                {
                    //...
                }
                else
                {
                    //...
                }
            }

        }

        private void frmUpdateAsset_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtid;
        }

        public ThermalLabel GenerateBasicThermalLabel()
        {
            string IdPrint = Convert.ToString(_aObject.IdAssets);
            //Define a ThermalLabel object and set unit to inch and label size
            ThermalLabel tLabel = new ThermalLabel(UnitType.Inch, 4, 2);
            tLabel.GapLength = 0.2;

            //Right, Down
            BarcodeItem bcID = new BarcodeItem(1.422, 0.2462, 2.5, 0.5083, BarcodeSymbology.QRCode, IdPrint);
            bcID.AddChecksum = false;
            bcID.DisplayCode = false;
            bcID.BarHeight = 0.4;
            bcID.BarWidth = 0.0104;
            TextItem txtNumber = new TextItem(1.83000, 1.0922, 1.0938, 0.2083, IdPrint);
            txtNumber.Font.Name = "Calibri";
            txtNumber.Font.Size = 14;
            txtNumber.Font.Bold = true;

            tLabel.Items.Add(bcID);
            tLabel.Items.Add(txtNumber);

            return tLabel;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_aObject.IdAssets == 0)
            {
                MessageBox.Show("Busque primero un Activo Fijo.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ThermalLabel _currentThermalLabel = null;
                _currentThermalLabel = this.GenerateBasicThermalLabel();
                
                Neodynamic.SDK.Printing.PrinterSettings _printerSettings = new Neodynamic.SDK.Printing.PrinterSettings();
                _printerSettings.Communication.CommunicationType = CommunicationType.USB;
                _printerSettings.PrinterName = _Printer;
                _printerSettings.Dpi = 203;
                _printerSettings.ProgrammingLanguage = (ProgrammingLanguage)Enum.Parse(typeof(ProgrammingLanguage), "ZPL");
                PrintOrientation _printOrientation = PrintOrientation.Portrait;

                int x = 0;
                bool isPrinterValid = false;
                string printerName = _Printer;
                string query = string.Format("SELECT * from Win32_Printer "
                                                + "WHERE Name LIKE '%{0}'",
                                             printerName);

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection coll = searcher.Get();

                foreach (ManagementObject printer in coll)
                {
                    foreach (PropertyData property in printer.Properties)
                    {
                        //Console.WriteLine(string.Format("{0}: {1}",
                        //                                property.Name,
                        //                                property.Value));
                        if (x == 85)
                        {
                            isPrinterValid = (bool)property.Value;
                        }
                        x++;
                    }
                }

                if (isPrinterValid)
                {
                    MessageBox.Show("Impresora no conectada o apagada. Asegúrese de que la impresora esté conectada y que esté encendida para poder imprimir.", "Conecte y encieda la impresora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        using (PrintJob pj = new PrintJob(_printerSettings))
                        {
                            pj.PrintOrientation = _printOrientation;
                            pj.ThermalLabel = _currentThermalLabel;
                            pj.Print();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                    
                }

            }
        }

        private void lblid_Click(object sender, EventArgs e)
        {

        }

        private void btnPQ_Click(object sender, EventArgs e)
        {
            int intStart = 1564;
            int intEnd = 1564;






            int countInside = intStart;
            
            for (int j = 0; countInside <= intEnd; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    ThermalLabel _currentThermalLabel = null;
                    _currentThermalLabel = this.GenerateBasicThermalLabel222(countInside);

                    //Neodynamic.SDK.Printing.PrinterSettings _printerSettings = new Neodynamic.SDK.Printing.PrinterSettings();
                    Neodynamic.SDK.Printing.PrinterSettings _printerSettings = new Neodynamic.SDK.Printing.PrinterSettings();
                    _printerSettings.Communication.CommunicationType = CommunicationType.USB;
                    _printerSettings.PrinterName = _Printer;
                    _printerSettings.Dpi = 203;
                    _printerSettings.ProgrammingLanguage = (ProgrammingLanguage)Enum.Parse(typeof(ProgrammingLanguage), "ZPL");
                    PrintOrientation _printOrientation = PrintOrientation.Portrait;

                    using (PrintJob pj = new PrintJob(_printerSettings))
                    {
                        pj.PrintOrientation = _printOrientation;
                        pj.ThermalLabel = _currentThermalLabel;
                        pj.Print();
                    }
                }
                countInside++;
            }
        }

        // Para imprimir muchas etiquetas
        public ThermalLabel GenerateBasicThermalLabel222(int number)
        {
            string IdPrint = Convert.ToString(number);
            //Define a ThermalLabel object and set unit to inch and label size
            ThermalLabel tLabel = new ThermalLabel(UnitType.Inch, 4, 2);
            tLabel.GapLength = 0.2;

            //Right, Down
            BarcodeItem bcID = new BarcodeItem(1.422, 0.2462, 2.5, 0.5083, BarcodeSymbology.QRCode, IdPrint);
            bcID.AddChecksum = false;
            bcID.DisplayCode = false;
            bcID.BarHeight = 0.4;
            bcID.BarWidth = 0.0104;
            TextItem txtNumber = new TextItem(1.83000, 1.0922, 1.0938, 0.2083, IdPrint);
            txtNumber.Font.Name = "Calibri";
            txtNumber.Font.Size = 14;
            txtNumber.Font.Bold = true;

            tLabel.Items.Add(bcID);
            tLabel.Items.Add(txtNumber);

            return tLabel;
        }

        private void picAsset_Click(object sender, EventArgs e)
        {
            if (_aObject.IdAssets != 0 && noPhoto)
            {
                string photo = sourceFile + _aSearch.picture;
                frmViewPicture frmviewPhoto = new frmViewPicture(photo);
                frmviewPhoto.ShowDialog();
            }
        }

    }
}
