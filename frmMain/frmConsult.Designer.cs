namespace frmMain
{
    partial class frmConsult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAsset = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbldescrip = new System.Windows.Forms.Label();
            this.cmbLoc = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtS = new System.Windows.Forms.TextBox();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.picLocation = new System.Windows.Forms.PictureBox();
            this.picDescrip = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDescrip)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAsset
            // 
            this.dgvAsset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAsset.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAsset.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.dgvAsset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAsset.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(27)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(27)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsset.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsset.ColumnHeadersHeight = 40;
            this.dgvAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAsset.EnableHeadersVisualStyles = false;
            this.dgvAsset.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.dgvAsset.Location = new System.Drawing.Point(39, 91);
            this.dgvAsset.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAsset.Name = "dgvAsset";
            this.dgvAsset.ReadOnly = true;
            this.dgvAsset.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAsset.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAsset.RowTemplate.Height = 24;
            this.dgvAsset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsset.Size = new System.Drawing.Size(775, 525);
            this.dgvAsset.TabIndex = 137;
            this.dgvAsset.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsset_CellDoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Candara", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(316, 7);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 33);
            this.lblTitle.TabIndex = 138;
            this.lblTitle.Text = "Buscar Activo";
            // 
            // lbldescrip
            // 
            this.lbldescrip.AutoSize = true;
            this.lbldescrip.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescrip.Location = new System.Drawing.Point(35, 47);
            this.lbldescrip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldescrip.Name = "lbldescrip";
            this.lbldescrip.Size = new System.Drawing.Size(121, 22);
            this.lbldescrip.TabIndex = 140;
            this.lbldescrip.Text = "Descripción:";
            // 
            // cmbLoc
            // 
            this.cmbLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoc.DropDownWidth = 320;
            this.cmbLoc.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoc.FormattingEnabled = true;
            this.cmbLoc.Location = new System.Drawing.Point(499, 45);
            this.cmbLoc.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLoc.Name = "cmbLoc";
            this.cmbLoc.Size = new System.Drawing.Size(167, 29);
            this.cmbLoc.TabIndex = 141;
            this.cmbLoc.SelectedIndexChanged += new System.EventHandler(this.cmbLoc_SelectedIndexChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(394, 47);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(107, 22);
            this.lblLocation.TabIndex = 142;
            this.lblLocation.Text = "Ubicación:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(21, 631);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(162, 23);
            this.lblCount.TabIndex = 143;
            this.lblCount.Text = "Total de Activos:";
            // 
            // txtS
            // 
            this.txtS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtS.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtS.Location = new System.Drawing.Point(155, 45);
            this.txtS.Margin = new System.Windows.Forms.Padding(2);
            this.txtS.Name = "txtS";
            this.txtS.Size = new System.Drawing.Size(184, 30);
            this.txtS.TabIndex = 145;
            this.txtS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtS_KeyPress);
            // 
            // picSearch
            // 
            this.picSearch.Image = global::frmMain.Properties.Resources.magnifier_black;
            this.picSearch.Location = new System.Drawing.Point(286, 10);
            this.picSearch.Margin = new System.Windows.Forms.Padding(2);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(26, 29);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearch.TabIndex = 148;
            this.picSearch.TabStop = false;
            // 
            // picLocation
            // 
            this.picLocation.Image = global::frmMain.Properties.Resources.maps_and_flags;
            this.picLocation.Location = new System.Drawing.Point(364, 44);
            this.picLocation.Margin = new System.Windows.Forms.Padding(2);
            this.picLocation.Name = "picLocation";
            this.picLocation.Size = new System.Drawing.Size(26, 29);
            this.picLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLocation.TabIndex = 147;
            this.picLocation.TabStop = false;
            // 
            // picDescrip
            // 
            this.picDescrip.Image = global::frmMain.Properties.Resources.align_to_left;
            this.picDescrip.Location = new System.Drawing.Point(9, 44);
            this.picDescrip.Margin = new System.Windows.Forms.Padding(2);
            this.picDescrip.Name = "picDescrip";
            this.picDescrip.Size = new System.Drawing.Size(26, 29);
            this.picDescrip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDescrip.TabIndex = 146;
            this.picDescrip.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Candara", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::frmMain.Properties.Resources.magnifier;
            this.btnSearch.Location = new System.Drawing.Point(712, 38);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 38);
            this.btnSearch.TabIndex = 144;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmConsult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(808, 685);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.picLocation);
            this.Controls.Add(this.picDescrip);
            this.Controls.Add(this.txtS);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.cmbLoc);
            this.Controls.Add(this.lbldescrip);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvAsset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmConsult";
            this.Text = "frmConsult";
            this.Load += new System.EventHandler(this.frmConsult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDescrip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsset;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lbldescrip;
        private System.Windows.Forms.ComboBox cmbLoc;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtS;
        private System.Windows.Forms.PictureBox picDescrip;
        private System.Windows.Forms.PictureBox picLocation;
        private System.Windows.Forms.PictureBox picSearch;
    }
}