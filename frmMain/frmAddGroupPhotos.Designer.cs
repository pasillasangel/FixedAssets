namespace frmMain
{
    partial class frmAddGroupPhotos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtpath = new System.Windows.Forms.TextBox();
            this.lblpt = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblcountFiles = new System.Windows.Forms.Label();
            this.picCodePed = new System.Windows.Forms.PictureBox();
            this.lblnameFiles = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picDescrip = new System.Windows.Forms.PictureBox();
            this.lbltype = new System.Windows.Forms.Label();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.cb2 = new System.Windows.Forms.CheckBox();
            this.cb3 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblalert = new System.Windows.Forms.Label();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCodePed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDescrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtpath
            // 
            this.txtpath.BackColor = System.Drawing.Color.White;
            this.txtpath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpath.Enabled = false;
            this.txtpath.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpath.Location = new System.Drawing.Point(239, 243);
            this.txtpath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(618, 26);
            this.txtpath.TabIndex = 1;
            // 
            // lblpt
            // 
            this.lblpt.AutoSize = true;
            this.lblpt.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpt.Location = new System.Drawing.Point(114, 237);
            this.lblpt.Name = "lblpt";
            this.lblpt.Size = new System.Drawing.Size(119, 30);
            this.lblpt.TabIndex = 70;
            this.lblpt.Text = "Carpeta:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::frmMain.Properties.Resources.filesearch;
            this.pictureBox3.Location = new System.Drawing.Point(73, 237);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 168;
            this.pictureBox3.TabStop = false;
            // 
            // lblcountFiles
            // 
            this.lblcountFiles.AutoSize = true;
            this.lblcountFiles.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountFiles.Location = new System.Drawing.Point(114, 296);
            this.lblcountFiles.Name = "lblcountFiles";
            this.lblcountFiles.Size = new System.Drawing.Size(261, 30);
            this.lblcountFiles.TabIndex = 169;
            this.lblcountFiles.Text = "Cantidad de Fotos: 0";
            // 
            // picCodePed
            // 
            this.picCodePed.Image = global::frmMain.Properties.Resources.numbering_signs;
            this.picCodePed.Location = new System.Drawing.Point(73, 290);
            this.picCodePed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picCodePed.Name = "picCodePed";
            this.picCodePed.Size = new System.Drawing.Size(35, 36);
            this.picCodePed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCodePed.TabIndex = 170;
            this.picCodePed.TabStop = false;
            // 
            // lblnameFiles
            // 
            this.lblnameFiles.AutoSize = true;
            this.lblnameFiles.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnameFiles.Location = new System.Drawing.Point(114, 350);
            this.lblnameFiles.Name = "lblnameFiles";
            this.lblnameFiles.Size = new System.Drawing.Size(226, 30);
            this.lblnameFiles.TabIndex = 172;
            this.lblnameFiles.Text = "Nombre Archivos:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::frmMain.Properties.Resources.photo_camera;
            this.pictureBox1.Location = new System.Drawing.Point(73, 350);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 173;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btnCancel.Image = global::frmMain.Properties.Resources.logout;
            this.btnCancel.Location = new System.Drawing.Point(538, 568);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(225, 55);
            this.btnCancel.TabIndex = 175;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(27)))), ((int)(((byte)(62)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Image = global::frmMain.Properties.Resources.cursor;
            this.btnSelect.Location = new System.Drawing.Point(292, 568);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(225, 55);
            this.btnSelect.TabIndex = 174;
            this.btnSelect.Text = "&Guardar";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Candara", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::frmMain.Properties.Resources.magnifier;
            this.btnSearch.Location = new System.Drawing.Point(883, 229);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 47);
            this.btnSearch.TabIndex = 176;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(27)))), ((int)(((byte)(62)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 10);
            this.panel1.TabIndex = 177;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(27)))), ((int)(((byte)(62)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(991, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 658);
            this.panel2.TabIndex = 178;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(27)))), ((int)(((byte)(62)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 658);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(991, 10);
            this.panel3.TabIndex = 179;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(27)))), ((int)(((byte)(62)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 648);
            this.panel4.TabIndex = 180;
            // 
            // picDescrip
            // 
            this.picDescrip.Image = global::frmMain.Properties.Resources.align_to_left;
            this.picDescrip.Location = new System.Drawing.Point(73, 103);
            this.picDescrip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picDescrip.Name = "picDescrip";
            this.picDescrip.Size = new System.Drawing.Size(35, 36);
            this.picDescrip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDescrip.TabIndex = 181;
            this.picDescrip.TabStop = false;
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltype.Location = new System.Drawing.Point(125, 109);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(69, 60);
            this.lbltype.TabIndex = 183;
            this.lbltype.Text = "Tipo:\r\n\r\n";
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb1.Location = new System.Drawing.Point(210, 142);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(548, 29);
            this.cb1.TabIndex = 184;
            this.cb1.Text = "nombre_del_archivo_1325.jpg (Nombre con guiones bajos)";
            this.cb1.UseVisualStyleBackColor = true;
            this.cb1.CheckedChanged += new System.EventHandler(this.cb1_CheckedChanged);
            // 
            // cb2
            // 
            this.cb2.AutoSize = true;
            this.cb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb2.Location = new System.Drawing.Point(210, 170);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(498, 29);
            this.cb2.TabIndex = 185;
            this.cb2.Text = "nombre del archivo 1325.jpeg (Nombre con espacios)";
            this.cb2.UseVisualStyleBackColor = true;
            this.cb2.CheckedChanged += new System.EventHandler(this.cb2_CheckedChanged);
            this.cb2.CheckStateChanged += new System.EventHandler(this.cb2_CheckStateChanged);
            // 
            // cb3
            // 
            this.cb3.AutoSize = true;
            this.cb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb3.Location = new System.Drawing.Point(210, 198);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(357, 29);
            this.cb3.TabIndex = 186;
            this.cb3.Text = "1325.jpeg (Nombre con solo número)";
            this.cb3.UseVisualStyleBackColor = true;
            this.cb3.CheckedChanged += new System.EventHandler(this.cb3_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 30);
            this.label1.TabIndex = 187;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 21);
            this.label2.TabIndex = 188;
            this.label2.Text = "(todos los archivos deben ser del mismo tipo)";
            // 
            // lblalert
            // 
            this.lblalert.AutoSize = true;
            this.lblalert.BackColor = System.Drawing.Color.Transparent;
            this.lblalert.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(27)))), ((int)(((byte)(62)))));
            this.lblalert.Location = new System.Drawing.Point(28, 602);
            this.lblalert.Name = "lblalert";
            this.lblalert.Size = new System.Drawing.Size(235, 21);
            this.lblalert.TabIndex = 189;
            this.lblalert.Text = "*Solo archivos .JPG o .JPEG";
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.ItemHeight = 16;
            this.listFiles.Location = new System.Drawing.Point(346, 350);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(511, 196);
            this.listFiles.TabIndex = 190;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = global::frmMain.Properties.Resources.image__1_;
            this.pictureBox2.Image = global::frmMain.Properties.Resources.image__1_;
            this.pictureBox2.Location = new System.Drawing.Point(321, 31);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 191;
            this.pictureBox2.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(382, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(279, 35);
            this.lblTitle.TabIndex = 192;
            this.lblTitle.Text = "Actualización de fotos";
            // 
            // frmAddGroupPhotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1001, 668);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.lblalert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb3);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.lbltype);
            this.Controls.Add(this.picDescrip);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblnameFiles);
            this.Controls.Add(this.picCodePed);
            this.Controls.Add(this.lblcountFiles);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblpt);
            this.Controls.Add(this.txtpath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddGroupPhotos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddGroupPhotos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCodePed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDescrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label lblpt;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblcountFiles;
        private System.Windows.Forms.PictureBox picCodePed;
        private System.Windows.Forms.Label lblnameFiles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picDescrip;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.CheckBox cb1;
        private System.Windows.Forms.CheckBox cb2;
        private System.Windows.Forms.CheckBox cb3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblalert;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTitle;
    }
}