namespace BoxHorario
{
    partial class frmFichajeLector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFichajeLector));
            this.txtLector = new System.Windows.Forms.TextBox();
            this.lblmesaje = new System.Windows.Forms.Label();
            this.lblsalida = new System.Windows.Forms.Label();
            this.lblentrada = new System.Windows.Forms.Label();
            this.lblpausainicio = new System.Windows.Forms.Label();
            this.lblpausafin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.picrequena = new System.Windows.Forms.PictureBox();
            this.picathos = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picathosrail = new System.Windows.Forms.PictureBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picrequena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picathos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picathosrail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLector
            // 
            this.txtLector.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLector.Location = new System.Drawing.Point(344, 62);
            this.txtLector.Name = "txtLector";
            this.txtLector.PasswordChar = '*';
            this.txtLector.Size = new System.Drawing.Size(303, 71);
            this.txtLector.TabIndex = 0;
            // 
            // lblmesaje
            // 
            this.lblmesaje.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblmesaje.ForeColor = System.Drawing.Color.White;
            this.lblmesaje.Location = new System.Drawing.Point(28, 15);
            this.lblmesaje.Name = "lblmesaje";
            this.lblmesaje.Size = new System.Drawing.Size(705, 32);
            this.lblmesaje.TabIndex = 9;
            this.lblmesaje.Text = "¡Buenos días!  Op. Cristina Soriano";
            this.lblmesaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsalida
            // 
            this.lblsalida.AutoSize = true;
            this.lblsalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblsalida.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsalida.ForeColor = System.Drawing.Color.IndianRed;
            this.lblsalida.Location = new System.Drawing.Point(594, 124);
            this.lblsalida.Name = "lblsalida";
            this.lblsalida.Size = new System.Drawing.Size(150, 67);
            this.lblsalida.TabIndex = 18;
            this.lblsalida.Text = "00:00";
            this.lblsalida.Visible = false;
            // 
            // lblentrada
            // 
            this.lblentrada.AutoSize = true;
            this.lblentrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblentrada.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblentrada.ForeColor = System.Drawing.Color.Green;
            this.lblentrada.Location = new System.Drawing.Point(43, 124);
            this.lblentrada.Name = "lblentrada";
            this.lblentrada.Size = new System.Drawing.Size(150, 67);
            this.lblentrada.TabIndex = 15;
            this.lblentrada.Text = "00:00";
            this.lblentrada.Visible = false;
            // 
            // lblpausainicio
            // 
            this.lblpausainicio.AutoSize = true;
            this.lblpausainicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblpausainicio.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpausainicio.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblpausainicio.Location = new System.Drawing.Point(238, 124);
            this.lblpausainicio.Name = "lblpausainicio";
            this.lblpausainicio.Size = new System.Drawing.Size(150, 67);
            this.lblpausainicio.TabIndex = 16;
            this.lblpausainicio.Text = "00:00";
            this.lblpausainicio.Visible = false;
            // 
            // lblpausafin
            // 
            this.lblpausafin.AutoSize = true;
            this.lblpausafin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblpausafin.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpausafin.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblpausafin.Location = new System.Drawing.Point(394, 124);
            this.lblpausafin.Name = "lblpausafin";
            this.lblpausafin.Size = new System.Drawing.Size(150, 67);
            this.lblpausafin.TabIndex = 17;
            this.lblpausafin.Text = "00:00";
            this.lblpausafin.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(37, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Entrada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(333, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 32);
            this.label2.TabIndex = 20;
            this.label2.Text = "Descanso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(597, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 32);
            this.label3.TabIndex = 21;
            this.label3.Text = "Salida";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lblpausafin);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.lblmesaje);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.lblpausainicio);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.lblentrada);
            this.panel.Controls.Add(this.lblsalida);
            this.panel.Location = new System.Drawing.Point(12, 146);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(775, 214);
            this.panel.TabIndex = 22;
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Location = new System.Drawing.Point(653, 79);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(11, 15);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(13, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "v4";
            // 
            // picrequena
            // 
            this.picrequena.Image = ((System.Drawing.Image)(resources.GetObject("picrequena.Image")));
            this.picrequena.Location = new System.Drawing.Point(16, 17);
            this.picrequena.Name = "picrequena";
            this.picrequena.Size = new System.Drawing.Size(173, 93);
            this.picrequena.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picrequena.TabIndex = 25;
            this.picrequena.TabStop = false;
            // 
            // picathos
            // 
            this.picathos.Image = ((System.Drawing.Image)(resources.GetObject("picathos.Image")));
            this.picathos.Location = new System.Drawing.Point(16, 17);
            this.picathos.Name = "picathos";
            this.picathos.Size = new System.Drawing.Size(173, 74);
            this.picathos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picathos.TabIndex = 24;
            this.picathos.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(345, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 32);
            this.label5.TabIndex = 22;
            this.label5.Text = "Leer tarjeta";
            // 
            // picathosrail
            // 
            this.picathosrail.Image = ((System.Drawing.Image)(resources.GetObject("picathosrail.Image")));
            this.picathosrail.Location = new System.Drawing.Point(16, 17);
            this.picathosrail.Name = "picathosrail";
            this.picathosrail.Size = new System.Drawing.Size(173, 93);
            this.picathosrail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picathosrail.TabIndex = 26;
            this.picathosrail.TabStop = false;
            this.picathosrail.Visible = false;
            // 
            // frmFichajeLector
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(812, 390);
            this.Controls.Add(this.picathosrail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picrequena);
            this.Controls.Add(this.picathos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.txtLector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFichajeLector";
            this.Text = "Fichaje";
            this.Load += new System.EventHandler(this.frmFichajeLector_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picrequena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picathos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picathosrail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLector;
        private System.Windows.Forms.Label lblmesaje;
        private System.Windows.Forms.Label lblsalida;
        private System.Windows.Forms.Label lblentrada;
        private System.Windows.Forms.Label lblpausainicio;
        private System.Windows.Forms.Label lblpausafin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picrequena;
        private System.Windows.Forms.PictureBox picathos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picathosrail;
    }
}