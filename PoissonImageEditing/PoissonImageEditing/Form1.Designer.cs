namespace PoissonImageEditing
{
    partial class FormImageEditing
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelImg1 = new System.Windows.Forms.Panel();
            this.panelImg2 = new System.Windows.Forms.Panel();
            this.panelBtn1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxA = new System.Windows.Forms.PictureBox();
            this.pictureBoxB = new System.Windows.Forms.PictureBox();
            this.buttonLoadA = new System.Windows.Forms.Button();
            this.buttonLoadB = new System.Windows.Forms.Button();
            this.panelImg1.SuspendLayout();
            this.panelImg2.SuspendLayout();
            this.panelBtn1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).BeginInit();
            this.SuspendLayout();
            // 
            // panelImg1
            // 
            this.panelImg1.Controls.Add(this.pictureBoxA);
            this.panelImg1.Location = new System.Drawing.Point(20, 20);
            this.panelImg1.Name = "panelImg1";
            this.panelImg1.Size = new System.Drawing.Size(600, 450);
            this.panelImg1.TabIndex = 0;
            // 
            // panelImg2
            // 
            this.panelImg2.Controls.Add(this.pictureBoxB);
            this.panelImg2.Location = new System.Drawing.Point(20, 490);
            this.panelImg2.Name = "panelImg2";
            this.panelImg2.Size = new System.Drawing.Size(600, 450);
            this.panelImg2.TabIndex = 1;
            // 
            // panelBtn1
            // 
            this.panelBtn1.BackColor = System.Drawing.Color.LimeGreen;
            this.panelBtn1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBtn1.Controls.Add(this.buttonLoadA);
            this.panelBtn1.Location = new System.Drawing.Point(650, 20);
            this.panelBtn1.Name = "panelBtn1";
            this.panelBtn1.Size = new System.Drawing.Size(200, 450);
            this.panelBtn1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonLoadB);
            this.panel1.Location = new System.Drawing.Point(650, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Aquamarine;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(880, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 450);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Turquoise;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(880, 490);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 450);
            this.panel3.TabIndex = 5;
            // 
            // pictureBoxA
            // 
            this.pictureBoxA.BackColor = System.Drawing.Color.LightGreen;
            this.pictureBoxA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxA.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxA.Name = "pictureBoxA";
            this.pictureBoxA.Size = new System.Drawing.Size(600, 450);
            this.pictureBoxA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxA.TabIndex = 0;
            this.pictureBoxA.TabStop = false;
            // 
            // pictureBoxB
            // 
            this.pictureBoxB.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxB.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxB.Name = "pictureBoxB";
            this.pictureBoxB.Size = new System.Drawing.Size(600, 450);
            this.pictureBoxB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxB.TabIndex = 0;
            this.pictureBoxB.TabStop = false;
            // 
            // buttonLoadA
            // 
            this.buttonLoadA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLoadA.Location = new System.Drawing.Point(0, 0);
            this.buttonLoadA.Name = "buttonLoadA";
            this.buttonLoadA.Size = new System.Drawing.Size(196, 50);
            this.buttonLoadA.TabIndex = 0;
            this.buttonLoadA.Text = "Load Source Image";
            this.buttonLoadA.UseVisualStyleBackColor = true;
            this.buttonLoadA.Click += new System.EventHandler(this.buttonLoadA_Click);
            // 
            // buttonLoadB
            // 
            this.buttonLoadB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLoadB.Location = new System.Drawing.Point(0, 0);
            this.buttonLoadB.Name = "buttonLoadB";
            this.buttonLoadB.Size = new System.Drawing.Size(196, 50);
            this.buttonLoadB.TabIndex = 0;
            this.buttonLoadB.Text = "Load Target Image";
            this.buttonLoadB.UseVisualStyleBackColor = true;
            this.buttonLoadB.Click += new System.EventHandler(this.buttonLoadB_Click);
            // 
            // FormImageEditing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 953);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBtn1);
            this.Controls.Add(this.panelImg2);
            this.Controls.Add(this.panelImg1);
            this.Name = "FormImageEditing";
            this.Text = "Image Editing - Zhen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelImg1.ResumeLayout(false);
            this.panelImg2.ResumeLayout(false);
            this.panelBtn1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelImg1;
        private System.Windows.Forms.Panel panelImg2;
        private System.Windows.Forms.Panel panelBtn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBoxA;
        private System.Windows.Forms.PictureBox pictureBoxB;
        private System.Windows.Forms.Button buttonLoadA;
        private System.Windows.Forms.Button buttonLoadB;
    }
}

