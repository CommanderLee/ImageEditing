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
            this.pictureBoxA = new System.Windows.Forms.PictureBox();
            this.panelImg2 = new System.Windows.Forms.Panel();
            this.pictureBoxB = new System.Windows.Forms.PictureBox();
            this.panelBtn1 = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonLoadA = new System.Windows.Forms.Button();
            this.panelBtn2 = new System.Windows.Forms.Panel();
            this.buttonLoadB = new System.Windows.Forms.Button();
            this.panelImgResult = new System.Windows.Forms.Panel();
            this.buttonPlace = new System.Windows.Forms.Button();
            this.buttonClone = new System.Windows.Forms.Button();
            this.buttonClear2 = new System.Windows.Forms.Button();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.panelImg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA)).BeginInit();
            this.panelImg2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).BeginInit();
            this.panelBtn1.SuspendLayout();
            this.panelBtn2.SuspendLayout();
            this.panelImgResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panelImg1
            // 
            this.panelImg1.AutoScroll = true;
            this.panelImg1.Controls.Add(this.pictureBoxA);
            this.panelImg1.Location = new System.Drawing.Point(20, 20);
            this.panelImg1.Name = "panelImg1";
            this.panelImg1.Size = new System.Drawing.Size(600, 450);
            this.panelImg1.TabIndex = 0;
            // 
            // pictureBoxA
            // 
            this.pictureBoxA.BackColor = System.Drawing.Color.LightGreen;
            this.pictureBoxA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxA.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxA.Name = "pictureBoxA";
            this.pictureBoxA.Size = new System.Drawing.Size(600, 450);
            this.pictureBoxA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxA.TabIndex = 0;
            this.pictureBoxA.TabStop = false;
            this.pictureBoxA.Click += new System.EventHandler(this.pictureBoxA_Click);
            // 
            // panelImg2
            // 
            this.panelImg2.AutoScroll = true;
            this.panelImg2.Controls.Add(this.pictureBoxB);
            this.panelImg2.Location = new System.Drawing.Point(20, 490);
            this.panelImg2.Name = "panelImg2";
            this.panelImg2.Size = new System.Drawing.Size(600, 450);
            this.panelImg2.TabIndex = 1;
            // 
            // pictureBoxB
            // 
            this.pictureBoxB.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxB.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxB.Name = "pictureBoxB";
            this.pictureBoxB.Size = new System.Drawing.Size(600, 450);
            this.pictureBoxB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxB.TabIndex = 0;
            this.pictureBoxB.TabStop = false;
            this.pictureBoxB.Click += new System.EventHandler(this.pictureBoxB_Click);
            // 
            // panelBtn1
            // 
            this.panelBtn1.BackColor = System.Drawing.Color.LimeGreen;
            this.panelBtn1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBtn1.Controls.Add(this.buttonClear);
            this.panelBtn1.Controls.Add(this.buttonDraw);
            this.panelBtn1.Controls.Add(this.buttonLoadA);
            this.panelBtn1.Location = new System.Drawing.Point(650, 20);
            this.panelBtn1.Name = "panelBtn1";
            this.panelBtn1.Size = new System.Drawing.Size(200, 450);
            this.panelBtn1.TabIndex = 2;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClear.Location = new System.Drawing.Point(0, 150);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(196, 50);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDraw
            // 
            this.buttonDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDraw.Location = new System.Drawing.Point(0, 75);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(196, 50);
            this.buttonDraw.TabIndex = 1;
            this.buttonDraw.Text = "Draw Boundry";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
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
            // panelBtn2
            // 
            this.panelBtn2.BackColor = System.Drawing.Color.SkyBlue;
            this.panelBtn2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBtn2.Controls.Add(this.buttonClear2);
            this.panelBtn2.Controls.Add(this.buttonClone);
            this.panelBtn2.Controls.Add(this.buttonPlace);
            this.panelBtn2.Controls.Add(this.buttonLoadB);
            this.panelBtn2.Location = new System.Drawing.Point(650, 490);
            this.panelBtn2.Name = "panelBtn2";
            this.panelBtn2.Size = new System.Drawing.Size(200, 450);
            this.panelBtn2.TabIndex = 3;
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
            // panelImgResult
            // 
            this.panelImgResult.AutoScroll = true;
            this.panelImgResult.BackColor = System.Drawing.Color.Turquoise;
            this.panelImgResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelImgResult.Controls.Add(this.pictureBoxResult);
            this.panelImgResult.Location = new System.Drawing.Point(880, 20);
            this.panelImgResult.Name = "panelImgResult";
            this.panelImgResult.Size = new System.Drawing.Size(870, 920);
            this.panelImgResult.TabIndex = 5;
            // 
            // buttonPlace
            // 
            this.buttonPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPlace.Location = new System.Drawing.Point(0, 75);
            this.buttonPlace.Name = "buttonPlace";
            this.buttonPlace.Size = new System.Drawing.Size(196, 50);
            this.buttonPlace.TabIndex = 1;
            this.buttonPlace.Text = "Place Image";
            this.buttonPlace.UseVisualStyleBackColor = true;
            this.buttonPlace.Click += new System.EventHandler(this.buttonPlace_Click);
            // 
            // buttonClone
            // 
            this.buttonClone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClone.Location = new System.Drawing.Point(0, 225);
            this.buttonClone.Name = "buttonClone";
            this.buttonClone.Size = new System.Drawing.Size(196, 50);
            this.buttonClone.TabIndex = 3;
            this.buttonClone.Text = "Clone";
            this.buttonClone.UseVisualStyleBackColor = true;
            this.buttonClone.Click += new System.EventHandler(this.buttonClone_Click);
            // 
            // buttonClear2
            // 
            this.buttonClear2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClear2.Location = new System.Drawing.Point(0, 150);
            this.buttonClear2.Name = "buttonClear2";
            this.buttonClear2.Size = new System.Drawing.Size(196, 50);
            this.buttonClear2.TabIndex = 2;
            this.buttonClear2.Text = "Clear";
            this.buttonClear2.UseVisualStyleBackColor = true;
            this.buttonClear2.Click += new System.EventHandler(this.buttonClear2_Click);
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(870, 920);
            this.pictureBoxResult.TabIndex = 0;
            this.pictureBoxResult.TabStop = false;
            // 
            // FormImageEditing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 953);
            this.Controls.Add(this.panelImgResult);
            this.Controls.Add(this.panelBtn2);
            this.Controls.Add(this.panelBtn1);
            this.Controls.Add(this.panelImg2);
            this.Controls.Add(this.panelImg1);
            this.Name = "FormImageEditing";
            this.Text = "Image Editing - Zhen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelImg1.ResumeLayout(false);
            this.panelImg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA)).EndInit();
            this.panelImg2.ResumeLayout(false);
            this.panelImg2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).EndInit();
            this.panelBtn1.ResumeLayout(false);
            this.panelBtn2.ResumeLayout(false);
            this.panelImgResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelImg1;
        private System.Windows.Forms.Panel panelImg2;
        private System.Windows.Forms.Panel panelBtn1;
        private System.Windows.Forms.Panel panelBtn2;
        private System.Windows.Forms.Panel panelImgResult;
        private System.Windows.Forms.PictureBox pictureBoxA;
        private System.Windows.Forms.PictureBox pictureBoxB;
        private System.Windows.Forms.Button buttonLoadA;
        private System.Windows.Forms.Button buttonLoadB;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonClone;
        private System.Windows.Forms.Button buttonPlace;
        private System.Windows.Forms.Button buttonClear2;
        private System.Windows.Forms.PictureBox pictureBoxResult;
    }
}

