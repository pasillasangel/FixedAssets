using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmMain
{
    public partial class frmMainProject : Form
    {
        string sourceFile = ConfigurationManager.AppSettings["PhotoTemp"];

        public string idConsult = "";

        public frmMainProject()
        {
            InitializeComponent();
            Deletesfiles(sourceFile);
            
        }

        private void OpenForm(object formSend)
        {
            if (this.pMainContainer.Controls.Count > 0)
                this.pMainContainer.Controls.RemoveAt(0);
            Form fs = formSend as Form;
            fs.TopLevel = false;
            fs.Dock = DockStyle.Fill;
            this.pMainContainer.Controls.Add(fs);
            this.pMainContainer.Tag = fs;
            fs.Show();
        }

        public static void Deletesfiles(string source)
        {
            if (Directory.Exists(source))
            {
                DirectoryInfo di = new DirectoryInfo(source);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
        }

        private void frmMainProject_Load(object sender, EventArgs e)
        {
            //Show Form Resume 
            btnAdd_Click(null, e);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(pColorRed2.BackColor == Color.FromArgb(214, 27, 62)) { }
            else
            {
                //Change Color Panels
                pColorRed2.BackColor = Color.FromArgb(214, 27, 62);
                pColorRed3.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed4.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed5.BackColor = Color.FromArgb(48, 50, 51);

                //show form
                OpenForm(new frmAdd());
            }
        }

        public void MinimizeForm()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pColorRed3.BackColor == Color.FromArgb(214, 27, 62)) { }
            else
            {
                //Change Color Panels
                pColorRed2.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed3.BackColor = Color.FromArgb(214, 27, 62);
                pColorRed4.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed5.BackColor = Color.FromArgb(48, 50, 51);

                //show form
                OpenForm(new frmUpdateAsset(idConsult));

                idConsult = "";
            }

        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            if (pColorRed4.BackColor == Color.FromArgb(214, 27, 62)) { }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                //Change Color Panels
                pColorRed2.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed3.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed4.BackColor = Color.FromArgb(214, 27, 62);
                pColorRed5.BackColor = Color.FromArgb(48, 50, 51);

                //show form
                OpenForm(new frmConsult(this));
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (pColorRed5.BackColor == Color.FromArgb(214, 27, 62)) { }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                //Change Color Panels
                pColorRed2.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed3.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed4.BackColor = Color.FromArgb(48, 50, 51);
                pColorRed5.BackColor = Color.FromArgb(214, 27, 62);

                //show form
                OpenForm(new frmReports());
            }
        }
    }
}
