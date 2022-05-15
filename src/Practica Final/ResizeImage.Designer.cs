namespace PE22A_JAMZ.src.TabRenderer
{
    partial class ResizeImage
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
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.ScpResizer = new System.Windows.Forms.SplitContainer();
            this.PnlSideBar = new System.Windows.Forms.Panel();
            this.GbxPhotoOldProp = new System.Windows.Forms.GroupBox();
            this.BtnSaveImages = new System.Windows.Forms.Button();
            this.LblAspectRatio = new System.Windows.Forms.Label();
            this.LblQuantity = new System.Windows.Forms.Label();
            this.CmbAspectRatio = new System.Windows.Forms.ComboBox();
            this.BtnSelectImages = new System.Windows.Forms.Button();
            this.LblWidth = new System.Windows.Forms.Label();
            this.TxtWidth = new System.Windows.Forms.TextBox();
            this.LblFormat = new System.Windows.Forms.Label();
            this.CbxAspectRatio = new System.Windows.Forms.CheckBox();
            this.CbxFormat = new System.Windows.Forms.ComboBox();
            this.LblHeight = new System.Windows.Forms.Label();
            this.TxtHeight = new System.Windows.Forms.TextBox();
            this.FlpImages = new System.Windows.Forms.FlowLayoutPanel();
            this.LblInfo = new System.Windows.Forms.Label();
            this.PnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScpResizer)).BeginInit();
            this.ScpResizer.Panel1.SuspendLayout();
            this.ScpResizer.Panel2.SuspendLayout();
            this.ScpResizer.SuspendLayout();
            this.PnlSideBar.SuspendLayout();
            this.GbxPhotoOldProp.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlContainer
            // 
            this.PnlContainer.Controls.Add(this.ScpResizer);
            this.PnlContainer.Controls.Add(this.LblInfo);
            this.PnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContainer.Location = new System.Drawing.Point(0, 0);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(1264, 729);
            this.PnlContainer.TabIndex = 0;
            // 
            // ScpResizer
            // 
            this.ScpResizer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScpResizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScpResizer.Location = new System.Drawing.Point(0, 39);
            this.ScpResizer.Name = "ScpResizer";
            // 
            // ScpResizer.Panel1
            // 
            this.ScpResizer.Panel1.Controls.Add(this.PnlSideBar);
            this.ScpResizer.Panel1MinSize = 300;
            // 
            // ScpResizer.Panel2
            // 
            this.ScpResizer.Panel2.Controls.Add(this.FlpImages);
            this.ScpResizer.Panel2MinSize = 900;
            this.ScpResizer.Size = new System.Drawing.Size(1264, 690);
            this.ScpResizer.SplitterDistance = 300;
            this.ScpResizer.TabIndex = 12;
            // 
            // PnlSideBar
            // 
            this.PnlSideBar.Controls.Add(this.GbxPhotoOldProp);
            this.PnlSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.PnlSideBar.Name = "PnlSideBar";
            this.PnlSideBar.Size = new System.Drawing.Size(296, 686);
            this.PnlSideBar.TabIndex = 11;
            // 
            // GbxPhotoOldProp
            // 
            this.GbxPhotoOldProp.Controls.Add(this.BtnSaveImages);
            this.GbxPhotoOldProp.Controls.Add(this.LblAspectRatio);
            this.GbxPhotoOldProp.Controls.Add(this.LblQuantity);
            this.GbxPhotoOldProp.Controls.Add(this.CmbAspectRatio);
            this.GbxPhotoOldProp.Controls.Add(this.BtnSelectImages);
            this.GbxPhotoOldProp.Controls.Add(this.LblWidth);
            this.GbxPhotoOldProp.Controls.Add(this.TxtWidth);
            this.GbxPhotoOldProp.Controls.Add(this.LblFormat);
            this.GbxPhotoOldProp.Controls.Add(this.CbxAspectRatio);
            this.GbxPhotoOldProp.Controls.Add(this.CbxFormat);
            this.GbxPhotoOldProp.Controls.Add(this.LblHeight);
            this.GbxPhotoOldProp.Controls.Add(this.TxtHeight);
            this.GbxPhotoOldProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxPhotoOldProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GbxPhotoOldProp.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GbxPhotoOldProp.Location = new System.Drawing.Point(0, 0);
            this.GbxPhotoOldProp.Name = "GbxPhotoOldProp";
            this.GbxPhotoOldProp.Size = new System.Drawing.Size(296, 686);
            this.GbxPhotoOldProp.TabIndex = 11;
            this.GbxPhotoOldProp.TabStop = false;
            this.GbxPhotoOldProp.Text = "Propiedades de imagen(es):";
            // 
            // BtnSaveImages
            // 
            this.BtnSaveImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.BtnSaveImages.FlatAppearance.BorderSize = 0;
            this.BtnSaveImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveImages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveImages.ForeColor = System.Drawing.Color.White;
            this.BtnSaveImages.Location = new System.Drawing.Point(10, 638);
            this.BtnSaveImages.Name = "BtnSaveImages";
            this.BtnSaveImages.Size = new System.Drawing.Size(280, 38);
            this.BtnSaveImages.TabIndex = 13;
            this.BtnSaveImages.Text = "Redimensionar imagen(es)";
            this.BtnSaveImages.UseVisualStyleBackColor = false;
            this.BtnSaveImages.Click += new System.EventHandler(this.BtnSaveImages_Click);
            // 
            // LblAspectRatio
            // 
            this.LblAspectRatio.AutoSize = true;
            this.LblAspectRatio.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAspectRatio.Location = new System.Drawing.Point(10, 140);
            this.LblAspectRatio.Name = "LblAspectRatio";
            this.LblAspectRatio.Size = new System.Drawing.Size(155, 19);
            this.LblAspectRatio.TabIndex = 12;
            this.LblAspectRatio.Text = "Relación de aspecto:";
            // 
            // LblQuantity
            // 
            this.LblQuantity.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblQuantity.Location = new System.Drawing.Point(10, 304);
            this.LblQuantity.Name = "LblQuantity";
            this.LblQuantity.Size = new System.Drawing.Size(280, 30);
            this.LblQuantity.TabIndex = 10;
            this.LblQuantity.Text = "Imagen(es) seleccionada(s):";
            this.LblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbAspectRatio
            // 
            this.CmbAspectRatio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAspectRatio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CmbAspectRatio.FormattingEnabled = true;
            this.CmbAspectRatio.Items.AddRange(new object[] {
            "16:9",
            "4:3",
            "1:1"});
            this.CmbAspectRatio.Location = new System.Drawing.Point(10, 171);
            this.CmbAspectRatio.Name = "CmbAspectRatio";
            this.CmbAspectRatio.Size = new System.Drawing.Size(280, 29);
            this.CmbAspectRatio.TabIndex = 12;
            // 
            // BtnSelectImages
            // 
            this.BtnSelectImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.BtnSelectImages.FlatAppearance.BorderSize = 0;
            this.BtnSelectImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectImages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectImages.Location = new System.Drawing.Point(10, 250);
            this.BtnSelectImages.Name = "BtnSelectImages";
            this.BtnSelectImages.Size = new System.Drawing.Size(280, 38);
            this.BtnSelectImages.TabIndex = 8;
            this.BtnSelectImages.Text = "Escoger imagen(es)";
            this.BtnSelectImages.UseVisualStyleBackColor = false;
            this.BtnSelectImages.Click += new System.EventHandler(this.BtnSelectImages_Click);
            // 
            // LblWidth
            // 
            this.LblWidth.AutoSize = true;
            this.LblWidth.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblWidth.Location = new System.Drawing.Point(10, 26);
            this.LblWidth.Name = "LblWidth";
            this.LblWidth.Size = new System.Drawing.Size(58, 19);
            this.LblWidth.TabIndex = 1;
            this.LblWidth.Text = "Ancho:";
            // 
            // TxtWidth
            // 
            this.TxtWidth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtWidth.Location = new System.Drawing.Point(71, 23);
            this.TxtWidth.Name = "TxtWidth";
            this.TxtWidth.Size = new System.Drawing.Size(219, 29);
            this.TxtWidth.TabIndex = 3;
            this.TxtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtWidth_KeyPress);
            this.TxtWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtWidth_KeyUp);
            // 
            // LblFormat
            // 
            this.LblFormat.AutoSize = true;
            this.LblFormat.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblFormat.Location = new System.Drawing.Point(10, 219);
            this.LblFormat.Name = "LblFormat";
            this.LblFormat.Size = new System.Drawing.Size(73, 19);
            this.LblFormat.TabIndex = 6;
            this.LblFormat.Text = "Formato:";
            // 
            // CbxAspectRatio
            // 
            this.CbxAspectRatio.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbxAspectRatio.Location = new System.Drawing.Point(10, 94);
            this.CbxAspectRatio.Name = "CbxAspectRatio";
            this.CbxAspectRatio.Size = new System.Drawing.Size(280, 30);
            this.CbxAspectRatio.TabIndex = 5;
            this.CbxAspectRatio.Text = "Mantener relación de aspecto";
            this.CbxAspectRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxAspectRatio.UseVisualStyleBackColor = true;
            this.CbxAspectRatio.Click += new System.EventHandler(this.CbxAspectRatio_Click);
            // 
            // CbxFormat
            // 
            this.CbxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxFormat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbxFormat.FormattingEnabled = true;
            this.CbxFormat.Items.AddRange(new object[] {
            "PNG",
            "JPG"});
            this.CbxFormat.Location = new System.Drawing.Point(89, 215);
            this.CbxFormat.Name = "CbxFormat";
            this.CbxFormat.Size = new System.Drawing.Size(201, 29);
            this.CbxFormat.TabIndex = 7;
            // 
            // LblHeight
            // 
            this.LblHeight.AutoSize = true;
            this.LblHeight.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblHeight.Location = new System.Drawing.Point(10, 64);
            this.LblHeight.Name = "LblHeight";
            this.LblHeight.Size = new System.Drawing.Size(41, 19);
            this.LblHeight.TabIndex = 2;
            this.LblHeight.Text = "Alto:";
            // 
            // TxtHeight
            // 
            this.TxtHeight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtHeight.Location = new System.Drawing.Point(57, 59);
            this.TxtHeight.Name = "TxtHeight";
            this.TxtHeight.Size = new System.Drawing.Size(233, 29);
            this.TxtHeight.TabIndex = 4;
            this.TxtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHeight_KeyPress);
            this.TxtHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtHeight_KeyUp);
            // 
            // FlpImages
            // 
            this.FlpImages.AutoScroll = true;
            this.FlpImages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlpImages.BackColor = System.Drawing.Color.White;
            this.FlpImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlpImages.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlpImages.Location = new System.Drawing.Point(0, 0);
            this.FlpImages.Name = "FlpImages";
            this.FlpImages.Size = new System.Drawing.Size(956, 686);
            this.FlpImages.TabIndex = 0;
            // 
            // LblInfo
            // 
            this.LblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblInfo.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblInfo.Location = new System.Drawing.Point(0, 0);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(1264, 39);
            this.LblInfo.TabIndex = 0;
            this.LblInfo.Text = "Redimensionar imagen(es)";
            this.LblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResizeImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.PnlContainer);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ResizeImage";
            this.Text = "ResizeImage";
            this.PnlContainer.ResumeLayout(false);
            this.ScpResizer.Panel1.ResumeLayout(false);
            this.ScpResizer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScpResizer)).EndInit();
            this.ScpResizer.ResumeLayout(false);
            this.PnlSideBar.ResumeLayout(false);
            this.GbxPhotoOldProp.ResumeLayout(false);
            this.GbxPhotoOldProp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlContainer;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Label LblHeight;
        private System.Windows.Forms.Label LblWidth;
        private System.Windows.Forms.TextBox TxtWidth;
        private System.Windows.Forms.TextBox TxtHeight;
        private System.Windows.Forms.CheckBox CbxAspectRatio;
        private System.Windows.Forms.Label LblFormat;
        private System.Windows.Forms.Button BtnSelectImages;
        private System.Windows.Forms.FlowLayoutPanel FlpImages;
        private System.Windows.Forms.Label LblQuantity;
        private System.Windows.Forms.Panel PnlSideBar;
        private System.Windows.Forms.SplitContainer ScpResizer;
        private System.Windows.Forms.GroupBox GbxPhotoOldProp;
        private System.Windows.Forms.ComboBox CmbAspectRatio;
        private System.Windows.Forms.ComboBox CbxFormat;
        private System.Windows.Forms.Label LblAspectRatio;
        private System.Windows.Forms.Button BtnSaveImages;
    }
}