namespace RecolectorEmail
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.lstNewMails = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUltimaActualizacion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.FileDialogExcel = new System.Windows.Forms.OpenFileDialog();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbUseInterval = new System.Windows.Forms.CheckBox();
            this.panelInterval = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelInterval.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(676, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "Comprobar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstNewMails
            // 
            this.lstNewMails.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstNewMails.FormattingEnabled = true;
            this.lstNewMails.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lstNewMails.ItemHeight = 18;
            this.lstNewMails.Location = new System.Drawing.Point(23, 168);
            this.lstNewMails.Name = "lstNewMails";
            this.lstNewMails.Size = new System.Drawing.Size(766, 526);
            this.lstNewMails.TabIndex = 8;
            this.lstNewMails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstNewMails_KeyPress);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(703, 700);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 24);
            this.button3.TabIndex = 9;
            this.button3.Text = "Añadir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SendToExcel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Última actualización:";
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.AutoSize = true;
            this.lblUltimaActualizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(177, 21);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(122, 24);
            this.lblUltimaActualizacion.TabIndex = 11;
            this.lblUltimaActualizacion.Text = "fecha ultima";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RecolectorEmail.Properties.Resources.lotestockLogo;
            this.pictureBox1.Location = new System.Drawing.Point(676, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(149, 99);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(139, 16);
            this.lblPath.TabIndex = 14;
            this.lblPath.Text = "selecciona archivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ubicación excel:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(152, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 19);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cambiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FileDialogExcel
            // 
            this.FileDialogExcel.FileName = "excelPath";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(23, 697);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(52, 24);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(18, 40);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 17;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(18, 99);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Hasta";
            // 
            // chkbUseInterval
            // 
            this.chkbUseInterval.AutoSize = true;
            this.chkbUseInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbUseInterval.Location = new System.Drawing.Point(61, 53);
            this.chkbUseInterval.Name = "chkbUseInterval";
            this.chkbUseInterval.Size = new System.Drawing.Size(176, 20);
            this.chkbUseInterval.TabIndex = 21;
            this.chkbUseInterval.Text = "Usar intervalo de  tiempo";
            this.chkbUseInterval.UseVisualStyleBackColor = true;
            this.chkbUseInterval.CheckedChanged += new System.EventHandler(this.chkbUseInterval_CheckedChanged);
            // 
            // panelInterval
            // 
            this.panelInterval.Controls.Add(this.button4);
            this.panelInterval.Controls.Add(this.label4);
            this.panelInterval.Controls.Add(this.label2);
            this.panelInterval.Controls.Add(this.dtpTo);
            this.panelInterval.Controls.Add(this.dtpFrom);
            this.panelInterval.Location = new System.Drawing.Point(362, 12);
            this.panelInterval.Name = "panelInterval";
            this.panelInterval.Size = new System.Drawing.Size(234, 132);
            this.panelInterval.TabIndex = 22;
            this.panelInterval.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button4.Location = new System.Drawing.Point(143, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "mes ->";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(801, 733);
            this.Controls.Add(this.panelInterval);
            this.Controls.Add(this.chkbUseInterval);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUltimaActualizacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lstNewMails);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Recolector email - LoteStock";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelInterval.ResumeLayout(false);
            this.panelInterval.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstNewMails;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUltimaActualizacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog FileDialogExcel;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkbUseInterval;
        private System.Windows.Forms.Panel panelInterval;
        private System.Windows.Forms.Button button4;
    }
}

