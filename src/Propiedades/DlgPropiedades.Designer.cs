namespace PE22A_JAMZ
{
    partial class DlgPropiedades
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
            this.PnlContenedor = new System.Windows.Forms.Panel();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.GbxColores = new System.Windows.Forms.GroupBox();
            this.LblAnchoContorno = new System.Windows.Forms.Label();
            this.TxtContorno = new System.Windows.Forms.TextBox();
            this.LblColorPuntos = new System.Windows.Forms.Label();
            this.LblColorContenido = new System.Windows.Forms.Label();
            this.LblColorContorno = new System.Windows.Forms.Label();
            this.TxtColorPuntos = new System.Windows.Forms.TextBox();
            this.TxtColorContenido = new System.Windows.Forms.TextBox();
            this.TxtColorContorno = new System.Windows.Forms.TextBox();
            this.PbxColorPuntos = new System.Windows.Forms.PictureBox();
            this.PbxColorContenido = new System.Windows.Forms.PictureBox();
            this.PbxColorContorno = new System.Windows.Forms.PictureBox();
            this.GbxEscala = new System.Windows.Forms.GroupBox();
            this.TxtEscalaY = new System.Windows.Forms.TextBox();
            this.TxtEscalaX = new System.Windows.Forms.TextBox();
            this.LblY = new System.Windows.Forms.Label();
            this.LblX = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.PnlContenedor.SuspendLayout();
            this.GbxColores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColorPuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColorContenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColorContorno)).BeginInit();
            this.GbxEscala.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlContenedor
            // 
            this.PnlContenedor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PnlContenedor.Controls.Add(this.BtnGuardar);
            this.PnlContenedor.Controls.Add(this.GbxColores);
            this.PnlContenedor.Controls.Add(this.GbxEscala);
            this.PnlContenedor.Controls.Add(this.LblTitulo);
            this.PnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContenedor.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.PnlContenedor.Name = "PnlContenedor";
            this.PnlContenedor.Size = new System.Drawing.Size(809, 523);
            this.PnlContenedor.TabIndex = 0;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnGuardar.Location = new System.Drawing.Point(0, 485);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(809, 38);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "Guardar propiedades";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // GbxColores
            // 
            this.GbxColores.Controls.Add(this.LblAnchoContorno);
            this.GbxColores.Controls.Add(this.TxtContorno);
            this.GbxColores.Controls.Add(this.LblColorPuntos);
            this.GbxColores.Controls.Add(this.LblColorContenido);
            this.GbxColores.Controls.Add(this.LblColorContorno);
            this.GbxColores.Controls.Add(this.TxtColorPuntos);
            this.GbxColores.Controls.Add(this.TxtColorContenido);
            this.GbxColores.Controls.Add(this.TxtColorContorno);
            this.GbxColores.Controls.Add(this.PbxColorPuntos);
            this.GbxColores.Controls.Add(this.PbxColorContenido);
            this.GbxColores.Controls.Add(this.PbxColorContorno);
            this.GbxColores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxColores.Location = new System.Drawing.Point(0, 174);
            this.GbxColores.Name = "GbxColores";
            this.GbxColores.Size = new System.Drawing.Size(809, 349);
            this.GbxColores.TabIndex = 1;
            this.GbxColores.TabStop = false;
            this.GbxColores.Text = "Colores de polígono";
            // 
            // LblAnchoContorno
            // 
            this.LblAnchoContorno.AutoSize = true;
            this.LblAnchoContorno.Location = new System.Drawing.Point(353, 29);
            this.LblAnchoContorno.Name = "LblAnchoContorno";
            this.LblAnchoContorno.Size = new System.Drawing.Size(193, 25);
            this.LblAnchoContorno.TabIndex = 10;
            this.LblAnchoContorno.Text = "Tamaño del contorno";
            // 
            // TxtContorno
            // 
            this.TxtContorno.Location = new System.Drawing.Point(353, 57);
            this.TxtContorno.Name = "TxtContorno";
            this.TxtContorno.Size = new System.Drawing.Size(281, 33);
            this.TxtContorno.TabIndex = 9;
            this.TxtContorno.Text = "1";
            // 
            // LblColorPuntos
            // 
            this.LblColorPuntos.AutoSize = true;
            this.LblColorPuntos.Location = new System.Drawing.Point(12, 180);
            this.LblColorPuntos.Name = "LblColorPuntos";
            this.LblColorPuntos.Size = new System.Drawing.Size(148, 25);
            this.LblColorPuntos.TabIndex = 8;
            this.LblColorPuntos.Text = "Color de puntos";
            // 
            // LblColorContenido
            // 
            this.LblColorContenido.AutoSize = true;
            this.LblColorContenido.Location = new System.Drawing.Point(12, 105);
            this.LblColorContenido.Name = "LblColorContenido";
            this.LblColorContenido.Size = new System.Drawing.Size(175, 25);
            this.LblColorContenido.TabIndex = 7;
            this.LblColorContenido.Text = "Color de contenido";
            // 
            // LblColorContorno
            // 
            this.LblColorContorno.AutoSize = true;
            this.LblColorContorno.Location = new System.Drawing.Point(12, 29);
            this.LblColorContorno.Name = "LblColorContorno";
            this.LblColorContorno.Size = new System.Drawing.Size(167, 25);
            this.LblColorContorno.TabIndex = 6;
            this.LblColorContorno.Text = "Color de contorno";
            // 
            // TxtColorPuntos
            // 
            this.TxtColorPuntos.Location = new System.Drawing.Point(50, 208);
            this.TxtColorPuntos.Name = "TxtColorPuntos";
            this.TxtColorPuntos.Size = new System.Drawing.Size(281, 33);
            this.TxtColorPuntos.TabIndex = 5;
            // 
            // TxtColorContenido
            // 
            this.TxtColorContenido.Location = new System.Drawing.Point(50, 133);
            this.TxtColorContenido.Name = "TxtColorContenido";
            this.TxtColorContenido.Size = new System.Drawing.Size(281, 33);
            this.TxtColorContenido.TabIndex = 4;
            // 
            // TxtColorContorno
            // 
            this.TxtColorContorno.Location = new System.Drawing.Point(50, 57);
            this.TxtColorContorno.Name = "TxtColorContorno";
            this.TxtColorContorno.Size = new System.Drawing.Size(281, 33);
            this.TxtColorContorno.TabIndex = 3;
            this.TxtColorContorno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtColorContorno_KeyPress);
            // 
            // PbxColorPuntos
            // 
            this.PbxColorPuntos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxColorPuntos.Location = new System.Drawing.Point(12, 208);
            this.PbxColorPuntos.Name = "PbxColorPuntos";
            this.PbxColorPuntos.Size = new System.Drawing.Size(32, 32);
            this.PbxColorPuntos.TabIndex = 2;
            this.PbxColorPuntos.TabStop = false;
            this.PbxColorPuntos.Click += new System.EventHandler(this.PbxColorContenido_Click);
            // 
            // PbxColorContenido
            // 
            this.PbxColorContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxColorContenido.Location = new System.Drawing.Point(12, 133);
            this.PbxColorContenido.Name = "PbxColorContenido";
            this.PbxColorContenido.Size = new System.Drawing.Size(32, 32);
            this.PbxColorContenido.TabIndex = 1;
            this.PbxColorContenido.TabStop = false;
            this.PbxColorContenido.Click += new System.EventHandler(this.PbxColorContenido_Click);
            // 
            // PbxColorContorno
            // 
            this.PbxColorContorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxColorContorno.Location = new System.Drawing.Point(12, 57);
            this.PbxColorContorno.Name = "PbxColorContorno";
            this.PbxColorContorno.Size = new System.Drawing.Size(32, 32);
            this.PbxColorContorno.TabIndex = 0;
            this.PbxColorContorno.TabStop = false;
            this.PbxColorContorno.Click += new System.EventHandler(this.PbxColorContenido_Click);
            // 
            // GbxEscala
            // 
            this.GbxEscala.Controls.Add(this.TxtEscalaY);
            this.GbxEscala.Controls.Add(this.TxtEscalaX);
            this.GbxEscala.Controls.Add(this.LblY);
            this.GbxEscala.Controls.Add(this.LblX);
            this.GbxEscala.Dock = System.Windows.Forms.DockStyle.Top;
            this.GbxEscala.Location = new System.Drawing.Point(0, 43);
            this.GbxEscala.Name = "GbxEscala";
            this.GbxEscala.Size = new System.Drawing.Size(809, 131);
            this.GbxEscala.TabIndex = 2;
            this.GbxEscala.TabStop = false;
            this.GbxEscala.Text = "Escala";
            // 
            // TxtEscalaY
            // 
            this.TxtEscalaY.Location = new System.Drawing.Point(41, 78);
            this.TxtEscalaY.Name = "TxtEscalaY";
            this.TxtEscalaY.Size = new System.Drawing.Size(756, 33);
            this.TxtEscalaY.TabIndex = 3;
            this.TxtEscalaY.Text = "1";
            // 
            // TxtEscalaX
            // 
            this.TxtEscalaX.Location = new System.Drawing.Point(41, 26);
            this.TxtEscalaX.Name = "TxtEscalaX";
            this.TxtEscalaX.Size = new System.Drawing.Size(756, 33);
            this.TxtEscalaX.TabIndex = 2;
            this.TxtEscalaX.Text = "1";
            // 
            // LblY
            // 
            this.LblY.AutoSize = true;
            this.LblY.Location = new System.Drawing.Point(7, 78);
            this.LblY.Name = "LblY";
            this.LblY.Size = new System.Drawing.Size(28, 25);
            this.LblY.TabIndex = 1;
            this.LblY.Text = "Y:";
            // 
            // LblX
            // 
            this.LblX.AutoSize = true;
            this.LblX.Location = new System.Drawing.Point(6, 29);
            this.LblX.Name = "LblX";
            this.LblX.Size = new System.Drawing.Size(29, 25);
            this.LblX.TabIndex = 0;
            this.LblX.Text = "X:";
            // 
            // LblTitulo
            // 
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(809, 43);
            this.LblTitulo.TabIndex = 0;
            this.LblTitulo.Text = "Propiedades del lienzo";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DlgPropiedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 523);
            this.Controls.Add(this.PnlContenedor);
            this.Name = "DlgPropiedades";
            this.Text = "Propiedades de lienzo";
            this.Load += new System.EventHandler(this.DlgPropiedades_Load);
            this.PnlContenedor.ResumeLayout(false);
            this.GbxColores.ResumeLayout(false);
            this.GbxColores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColorPuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColorContenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColorContorno)).EndInit();
            this.GbxEscala.ResumeLayout(false);
            this.GbxEscala.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlContenedor;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.GroupBox GbxEscala;
        private System.Windows.Forms.Label LblY;
        private System.Windows.Forms.Label LblX;
        private System.Windows.Forms.TextBox TxtEscalaX;
        private System.Windows.Forms.TextBox TxtEscalaY;
        private System.Windows.Forms.GroupBox GbxColores;
        private System.Windows.Forms.PictureBox PbxColorContorno;
        private System.Windows.Forms.PictureBox PbxColorContenido;
        private System.Windows.Forms.PictureBox PbxColorPuntos;
        private System.Windows.Forms.TextBox TxtColorContorno;
        private System.Windows.Forms.TextBox TxtColorContenido;
        private System.Windows.Forms.TextBox TxtColorPuntos;
        private System.Windows.Forms.Label LblColorContorno;
        private System.Windows.Forms.Label LblColorContenido;
        private System.Windows.Forms.Label LblColorPuntos;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label LblAnchoContorno;
        private System.Windows.Forms.TextBox TxtContorno;
    }
}