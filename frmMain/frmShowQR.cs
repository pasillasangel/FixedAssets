using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using Neodynamic.WinControls.BarcodeProfessional;
using Neodynamic.Windows.ThermalLabelEditor;
using Neodynamic.SDK.Printing;
using System.Management;

namespace frmMain
{
    public partial class frmShowQR : Form
    {
        int ID = 0;
        public static string _Printer = ConfigurationManager.AppSettings["Printer"];

        public frmShowQR(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            lblId.Text = "Código: " + ID.ToString();
            ThermalLabel.LicenseOwner = ConfigurationManager.AppSettings["ThermalOwner"];
            ThermalLabel.LicenseKey = ConfigurationManager.AppSettings["ThermalKey"];

            BarcodeProfessional.LicenseOwner = ConfigurationManager.AppSettings["BarcodeProOwner"];
            BarcodeProfessional.LicenseKey = ConfigurationManager.AppSettings["BarcodeProKey"];

            Generate2DBarcode();
        }


        public ThermalLabel GenerateBasicThermalLabel()
        {
            string IdPrint = ID.ToString();
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

        private BarcodeProfessional GetBarcodeProObj()
        {
            BarcodeProfessional bcp = new BarcodeProfessional();
            bcp.BarcodeUnit = BarcodeUnit.Inch;
            Symbology symb = Symbology.QRCode;
            bcp.QRCodeModuleSize = 0.0412;
            bcp.Symbology = symb;
            bcp.Code = ID.ToString();
            return bcp;
        }

        private void Generate2DBarcode()
        {
            using (BarcodeProfessional bcp = GetBarcodeProObj())
            {
                this.picQR.Image = bcp.GetBarcodeImage();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ThermalLabel _currentThermalLabel = null;
            _currentThermalLabel = this.GenerateBasicThermalLabel();

            //Neodynamic.SDK.Printing.PrinterSettings _printerSettings = new Neodynamic.SDK.Printing.PrinterSettings();
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
                MessageBox.Show("Impresora no conectada o apagada. Asegúrese de que la impresora esté conectada y que esté encendida. \nPuede imprimir la etiqueta en otro momento en el menú ACTUALIZAR.", "Conecte y encieda la impresora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    using (PrintJob pj = new PrintJob(_printerSettings))
                    {
                        pj.PrintOrientation = _printOrientation;
                        pj.ThermalLabel = _currentThermalLabel;
                        pj.Print();
                    }
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
