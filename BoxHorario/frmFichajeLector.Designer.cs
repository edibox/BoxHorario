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
            this.txtLector = new System.Windows.Forms.TextBox();
            this.lblmesaje = new System.Windows.Forms.Label();
            this.lblsalida = new System.Windows.Forms.Label();
            this.lblentrada = new System.Windows.Forms.Label();
            this.lblsalidadescanso = new System.Windows.Forms.Label();
            this.lblentradadescando = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLector
            // 
            this.txtLector.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLector.Location = new System.Drawing.Point(265, 32);
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
            // lblsalidadescanso
            // 
            this.lblsalidadescanso.AutoSize = true;
            this.lblsalidadescanso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblsalidadescanso.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsalidadescanso.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblsalidadescanso.Location = new System.Drawing.Point(238, 124);
            this.lblsalidadescanso.Name = "lblsalidadescanso";
            this.lblsalidadescanso.Size = new System.Drawing.Size(150, 67);
            this.lblsalidadescanso.TabIndex = 16;
            this.lblsalidadescanso.Text = "00:00";
            this.lblsalidadescanso.Visible = false;
            // 
            // lblentradadescando
            // 
            this.lblentradadescando.AutoSize = true;
            this.lblentradadescando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblentradadescando.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblentradadescando.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblentradadescando.Location = new System.Drawing.Point(394, 124);
            this.lblentradadescando.Name = "lblentradadescando";
            this.lblentradadescando.Size = new System.Drawing.Size(150, 67);
            this.lblentradadescando.TabIndex = 17;
            this.lblentradadescando.Text = "00:00";
            this.lblentradadescando.Visible = false;
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
            this.panel.Controls.Add(this.lblentradadescando);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.lblmesaje);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.lblsalidadescanso);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.lblentrada);
            this.panel.Controls.Add(this.lblsalida);
            this.panel.Location = new System.Drawing.Point(13, 121);
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
            // frmFichajeLector
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 357);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.txtLector);
            this.Name = "frmFichajeLector";
            this.Text = "Fichaje";
            this.Load += new System.EventHandler(this.frmFichajeLector_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLector;
        private System.Windows.Forms.Label lblmesaje;
        private System.Windows.Forms.Label lblsalida;
        private System.Windows.Forms.Label lblentrada;
        private System.Windows.Forms.Label lblsalidadescanso;
        private System.Windows.Forms.Label lblentradadescando;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Timer timer2;
    }
}