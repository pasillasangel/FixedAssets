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
    public partial class frmViewPicture : Form
    {
        public frmViewPicture(string photo)
        {
            InitializeComponent();
            picImage.Image = Image.FromFile(photo);
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
