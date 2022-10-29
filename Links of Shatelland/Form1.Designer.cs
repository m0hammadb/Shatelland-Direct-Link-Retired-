namespace Links_of_Shatelland
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.tmrChecker = new System.Windows.Forms.Timer(this.components);
            this.tmrShatel = new System.Windows.Forms.Timer(this.components);
            this.txtFolderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.txtTorrentCookie = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.txtRenameDirectory = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Links";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 83);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(295, 289);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(409, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add to download list";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(409, 83);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(237, 289);
            this.textBox2.TabIndex = 3;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(12, 378);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(295, 20);
            this.txtToken.TabIndex = 4;
            this.txtToken.Text = resources.GetString("txtToken.Text");
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 404);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(295, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Parsaspace Remote";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(12, 433);
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(295, 142);
            this.txtURL.TabIndex = 6;
            // 
            // tmrChecker
            // 
            this.tmrChecker.Interval = 2000;
            this.tmrChecker.Tick += new System.EventHandler(this.tmrChecker_Tick);
            // 
            // tmrShatel
            // 
            this.tmrShatel.Interval = 3000;
            this.tmrShatel.Tick += new System.EventHandler(this.tmrShatel_Tick);
            // 
            // txtFolderID
            // 
            this.txtFolderID.Location = new System.Drawing.Point(326, 262);
            this.txtFolderID.Name = "txtFolderID";
            this.txtFolderID.Size = new System.Drawing.Size(68, 20);
            this.txtFolderID.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name";
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(326, 171);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(68, 20);
            this.txtFolderName.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(326, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Create";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(409, 443);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(238, 142);
            this.textBox3.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(409, 414);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(238, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Get Torrent Files";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtTorrentCookie
            // 
            this.txtTorrentCookie.Location = new System.Drawing.Point(409, 388);
            this.txtTorrentCookie.Name = "txtTorrentCookie";
            this.txtTorrentCookie.Size = new System.Drawing.Size(238, 20);
            this.txtTorrentCookie.TabIndex = 12;
            this.txtTorrentCookie.Text = resources.GetString("txtTorrentCookie.Text");
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 581);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(65, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "Browse...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtRenameDirectory
            // 
            this.txtRenameDirectory.Location = new System.Drawing.Point(12, 609);
            this.txtRenameDirectory.Name = "txtRenameDirectory";
            this.txtRenameDirectory.Size = new System.Drawing.Size(295, 20);
            this.txtRenameDirectory.TabIndex = 16;
            this.txtRenameDirectory.Text = "I:\\others\\Torrent";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(313, 609);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(133, 20);
            this.button7.TabIndex = 17;
            this.button7.Text = "Rename ALL";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(571, 591);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 18;
            this.button8.Text = "Get Splits";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(468, 588);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(80, 26);
            this.button9.TabIndex = 19;
            this.button9.Text = "Delete All";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(124, 581);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 20;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(634, 23);
            this.progressBar1.TabIndex = 21;
            // 
            // timer3
            // 
            this.timer3.Interval = 3000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 646);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtRenameDirectory);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtTorrentCookie);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolderID);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Timer tmrChecker;
        private System.Windows.Forms.Timer tmrShatel;
        private System.Windows.Forms.TextBox txtFolderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtTorrentCookie;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtRenameDirectory;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer3;
    }
}

