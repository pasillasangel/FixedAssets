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
using DarrenLee.Media;
using System.Configuration;

namespace frmMain
{
    public partial class frmAddPhoto : Form
    {
        Camera myCamera = new Camera();
        public static string _pathTemp = ConfigurationManager.AppSettings["PhotoTemp"];
        string namePhoto;
        bool takePhoto = false;
        int count = 0;

        private frmAdd f1;

        public frmAddPhoto(string nameP, frmAdd FormADD)
        {
            InitializeComponent();

            this.f1 = FormADD;
            namePhoto = nameP;
            GetInfo();
            myCamera.OnFrameArrived += MyCamera_OnFrameArrived;

            try
            {
                cmbCameraDevices.SelectedIndex = 0;
            }
            catch (Exception)
            {
                cmbCameraDevices.SelectedIndex = 1;
            }

        }

        private void MyCamera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            picCamera.Image = img;
        }

        private void GetInfo()
        {
            var CameraDevices = myCamera.GetCameraSources();
            var CameraResolutions = myCamera.GetSupportedResolutions();

            foreach (var d in CameraDevices)
                cmbCameraDevices.Items.Add(d);

            foreach (var r in CameraResolutions)
                cmbCameraResolutions.Items.Add(r);

            cmbCameraDevices.SelectedIndex = 0;
            cmbCameraResolutions.SelectedIndex = 0;
        }

        private void cmbCameraDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCamera.ChangeCamera(cmbCameraDevices.SelectedIndex);
        }

        private void cmbCameraResolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCamera.Start(cmbCameraResolutions.SelectedIndex);
        }

        private void frmAddPhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            myCamera.Stop();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            count++;
            string filename = _pathTemp + namePhoto + "_" + count.ToString();
            myCamera.Capture(filename);
            picPreview.Image = Image.FromFile(filename + ".jpg");
            takePhoto = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (takePhoto)
            {
                f1.namePhotoFinal = namePhoto + "_" + count.ToString();
                f1.countFinal = count;
                f1.PhotoTag = true;
                f1.btnAdd.Enabled = true;
                f1.lblPhotoTag.Text = "IMAGEN CAPTURADA";
                f1.lblPhotoTag.ForeColor = Color.FromArgb(214, 27, 62);
                f1.lblPhotoTag.Font = new Font(f1.lblPhotoTag.Font, FontStyle.Bold);
                f1.ShogPhotoTag();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tome una FOTO del activo fijo, por favor.", "Tomo una foto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
