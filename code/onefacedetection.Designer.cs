namespace MultiFaceRec
{
    partial class onefacedetection
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
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_decrec = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.browsevideo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labcounter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnfolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labresult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(16, 36);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(320, 243);
            this.imageBoxFrameGrabber.TabIndex = 2;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_decrec);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.browsevideo);
            this.groupBox1.Location = new System.Drawing.Point(16, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 108);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Go back to selection Page";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // btn_decrec
            // 
            this.btn_decrec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_decrec.Location = new System.Drawing.Point(160, 56);
            this.btn_decrec.Name = "btn_decrec";
            this.btn_decrec.Size = new System.Drawing.Size(151, 22);
            this.btn_decrec.TabIndex = 7;
            this.btn_decrec.Text = "Detect and recognize";
            this.btn_decrec.UseVisualStyleBackColor = true;
            this.btn_decrec.Click += new System.EventHandler(this.btn_decrec_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 13);
            this.label16.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(132, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // browsevideo
            // 
            this.browsevideo.Location = new System.Drawing.Point(12, 60);
            this.browsevideo.Name = "browsevideo";
            this.browsevideo.Size = new System.Drawing.Size(106, 22);
            this.browsevideo.TabIndex = 4;
            this.browsevideo.Text = "browse Video";
            this.browsevideo.UseVisualStyleBackColor = true;
            this.browsevideo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.browsevideo_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labcounter);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.imageBox2);
            this.groupBox2.Location = new System.Drawing.Point(348, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 244);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FaceDetected";
            // 
            // labcounter
            // 
            this.labcounter.AutoSize = true;
            this.labcounter.Location = new System.Drawing.Point(224, 212);
            this.labcounter.Name = "labcounter";
            this.labcounter.Size = new System.Drawing.Size(0, 13);
            this.labcounter.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "selected character not fount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(16, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Number of faces detected: ";
            // 
            // imageBox2
            // 
            this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox2.Location = new System.Drawing.Point(52, 20);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(168, 134);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.btnfolder);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(352, 308);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 108);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Browse Face";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 124);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 13);
            this.label26.TabIndex = 6;
            // 
            // btnfolder
            // 
            this.btnfolder.Location = new System.Drawing.Point(12, 84);
            this.btnfolder.Name = "btnfolder";
            this.btnfolder.Size = new System.Drawing.Size(106, 22);
            this.btnfolder.TabIndex = 5;
            this.btnfolder.Text = "browse Folder";
            this.btnfolder.UseVisualStyleBackColor = true;
            this.btnfolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnfolder_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Select a Folderwith set of faces of a movie character\r\nto  be recognised (" +
                "folder should contain a set of images \r\nwith different expressions of character)" +
                "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labresult
            // 
            this.labresult.AutoSize = true;
            this.labresult.Location = new System.Drawing.Point(16, 8);
            this.labresult.Name = "labresult";
            this.labresult.Size = new System.Drawing.Size(0, 13);
            this.labresult.TabIndex = 6;
            // 
            // onefacedetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(670, 457);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labresult);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Name = "onefacedetection";
            this.Text = "Onefacedetection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onefacedetection_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button browsevideo;
        private System.Windows.Forms.GroupBox groupBox2;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnfolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_decrec;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label labresult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labcounter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;

        public System.EventHandler onefacedetection_Load_1 { get; set; }
    }
}