
namespace PE22A_JAMZ
{
    partial class DlgPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnSaludo = new System.Windows.Forms.Button();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.CbxSexo = new System.Windows.Forms.ComboBox();
            this.DgvCarrito = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fragilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnLlenar = new System.Windows.Forms.Button();
            this.BtnCalcularEnvio = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.TxtPeso = new System.Windows.Forms.TextBox();
            this.TxtFragilidad = new System.Windows.Forms.TextBox();
            this.BtnDialogoProyecto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSaludo
            // 
            this.BtnSaludo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnSaludo.FlatAppearance.BorderSize = 0;
            this.BtnSaludo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaludo.ForeColor = System.Drawing.Color.White;
            this.BtnSaludo.Location = new System.Drawing.Point(807, 16);
            this.BtnSaludo.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSaludo.Name = "BtnSaludo";
            this.BtnSaludo.Size = new System.Drawing.Size(79, 41);
            this.BtnSaludo.TabIndex = 0;
            this.BtnSaludo.Text = "Hola";
            this.BtnSaludo.UseVisualStyleBackColor = false;
            this.BtnSaludo.Click += new System.EventHandler(this.BtnSaludo_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(305, 16);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(489, 27);
            this.TxtNombre.TabIndex = 1;
            this.TxtNombre.Text = "Escribe tu nombre";
            // 
            // CbxSexo
            // 
            this.CbxSexo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.CbxSexo.FormattingEnabled = true;
            this.CbxSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino",
            "Prefiero no decirlo",
            "No binario"});
            this.CbxSexo.Location = new System.Drawing.Point(14, 16);
            this.CbxSexo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CbxSexo.Name = "CbxSexo";
            this.CbxSexo.Size = new System.Drawing.Size(284, 28);
            this.CbxSexo.TabIndex = 2;
            // 
            // DgvCarrito
            // 
            this.DgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Producto,
            this.Cantidad,
            this.Peso,
            this.Fragilidad});
            this.DgvCarrito.Location = new System.Drawing.Point(14, 77);
            this.DgvCarrito.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgvCarrito.Name = "DgvCarrito";
            this.DgvCarrito.RowHeadersWidth = 51;
            this.DgvCarrito.RowTemplate.Height = 25;
            this.DgvCarrito.Size = new System.Drawing.Size(781, 651);
            this.DgvCarrito.TabIndex = 3;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.Width = 125;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.Width = 125;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 125;
            // 
            // Peso
            // 
            this.Peso.HeaderText = "Peso";
            this.Peso.MinimumWidth = 6;
            this.Peso.Name = "Peso";
            this.Peso.Width = 125;
            // 
            // Fragilidad
            // 
            this.Fragilidad.HeaderText = "Fragilidad";
            this.Fragilidad.MinimumWidth = 6;
            this.Fragilidad.Name = "Fragilidad";
            this.Fragilidad.Width = 125;
            // 
            // BtnLlenar
            // 
            this.BtnLlenar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnLlenar.FlatAppearance.BorderSize = 0;
            this.BtnLlenar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnLlenar.ForeColor = System.Drawing.Color.White;
            this.BtnLlenar.Location = new System.Drawing.Point(821, 132);
            this.BtnLlenar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnLlenar.Name = "BtnLlenar";
            this.BtnLlenar.Size = new System.Drawing.Size(271, 41);
            this.BtnLlenar.TabIndex = 4;
            this.BtnLlenar.Text = "Llenar datos";
            this.BtnLlenar.UseVisualStyleBackColor = false;
            this.BtnLlenar.Click += new System.EventHandler(this.BtnLlenar_Click);
            // 
            // BtnCalcularEnvio
            // 
            this.BtnCalcularEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnCalcularEnvio.FlatAppearance.BorderSize = 0;
            this.BtnCalcularEnvio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCalcularEnvio.ForeColor = System.Drawing.Color.White;
            this.BtnCalcularEnvio.Location = new System.Drawing.Point(821, 189);
            this.BtnCalcularEnvio.Margin = new System.Windows.Forms.Padding(0);
            this.BtnCalcularEnvio.Name = "BtnCalcularEnvio";
            this.BtnCalcularEnvio.Size = new System.Drawing.Size(271, 41);
            this.BtnCalcularEnvio.TabIndex = 5;
            this.BtnCalcularEnvio.Text = "Calcular envio";
            this.BtnCalcularEnvio.UseVisualStyleBackColor = false;
            this.BtnCalcularEnvio.Click += new System.EventHandler(this.BtnCalcularEnvio_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnNuevo.FlatAppearance.BorderSize = 0;
            this.BtnNuevo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnNuevo.ForeColor = System.Drawing.Color.White;
            this.BtnNuevo.Location = new System.Drawing.Point(821, 77);
            this.BtnNuevo.Margin = new System.Windows.Forms.Padding(0);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(271, 41);
            this.BtnNuevo.TabIndex = 6;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // TxtPeso
            // 
            this.TxtPeso.Location = new System.Drawing.Point(821, 256);
            this.TxtPeso.Name = "TxtPeso";
            this.TxtPeso.Size = new System.Drawing.Size(267, 27);
            this.TxtPeso.TabIndex = 7;
            // 
            // TxtFragilidad
            // 
            this.TxtFragilidad.Location = new System.Drawing.Point(821, 304);
            this.TxtFragilidad.Name = "TxtFragilidad";
            this.TxtFragilidad.Size = new System.Drawing.Size(267, 27);
            this.TxtFragilidad.TabIndex = 8;
            // 
            // BtnDialogoProyecto
            // 
            this.BtnDialogoProyecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnDialogoProyecto.FlatAppearance.BorderSize = 0;
            this.BtnDialogoProyecto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDialogoProyecto.ForeColor = System.Drawing.Color.White;
            this.BtnDialogoProyecto.Location = new System.Drawing.Point(886, 16);
            this.BtnDialogoProyecto.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDialogoProyecto.Name = "BtnDialogoProyecto";
            this.BtnDialogoProyecto.Size = new System.Drawing.Size(187, 41);
            this.BtnDialogoProyecto.TabIndex = 9;
            this.BtnDialogoProyecto.Text = "Dialogo Proyecto";
            this.BtnDialogoProyecto.UseVisualStyleBackColor = false;
            this.BtnDialogoProyecto.Click += new System.EventHandler(this.BtnDialogoProyecto_Click);
            // 
            // DlgPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 744);
            this.Controls.Add(this.BtnDialogoProyecto);
            this.Controls.Add(this.TxtFragilidad);
            this.Controls.Add(this.TxtPeso);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnCalcularEnvio);
            this.Controls.Add(this.BtnLlenar);
            this.Controls.Add(this.DgvCarrito);
            this.Controls.Add(this.CbxSexo);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.BtnSaludo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DlgPrincipal";
            this.Text = "JAMZ-PE";
            ((System.ComponentModel.ISupportInitialize)(this.DgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSaludo;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.ComboBox CbxSexo;
        private System.Windows.Forms.DataGridView DgvCarrito;
        private System.Windows.Forms.Button BtnLlenar;
        private System.Windows.Forms.Button BtnCalcularEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fragilidad;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.TextBox TxtPeso;
        private System.Windows.Forms.TextBox TxtFragilidad;
        private System.Windows.Forms.Button BtnDialogoProyecto;
    }
}

