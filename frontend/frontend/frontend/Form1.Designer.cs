namespace frontend
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Compressionbutt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.Decompressionbutt = new System.Windows.Forms.Button();
            this.DragDrop = new System.Windows.Forms.ToolTip(this.components);
            this.cancel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.cancel.SuspendLayout();
            this.clear.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(47, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 417);
            this.panel1.TabIndex = 0;
            // 
            // Compressionbutt
            // 
            this.Compressionbutt.BackColor = System.Drawing.Color.Transparent;
            this.Compressionbutt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Compressionbutt.BackgroundImage")));
            this.Compressionbutt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Compressionbutt.FlatAppearance.BorderSize = 0;
            this.Compressionbutt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Compressionbutt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Compressionbutt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Compressionbutt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Compressionbutt.Font = new System.Drawing.Font("Ink Free", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Compressionbutt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Compressionbutt.Location = new System.Drawing.Point(327, 39);
            this.Compressionbutt.Margin = new System.Windows.Forms.Padding(0);
            this.Compressionbutt.Name = "Compressionbutt";
            this.Compressionbutt.Size = new System.Drawing.Size(159, 64);
            this.Compressionbutt.TabIndex = 1;
            this.Compressionbutt.Text = "Compression ";
            this.Compressionbutt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Compressionbutt.UseVisualStyleBackColor = false;
            this.Compressionbutt.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.button6);
            this.panel2.Location = new System.Drawing.Point(327, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 232);
            this.panel2.TabIndex = 3;
            this.DragDrop.SetToolTip(this.panel2, "Drag and drop your file here");
            this.panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel2_DragDrop);
            this.panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel2_DragEnter);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Location = new System.Drawing.Point(83, 186);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(157, 41);
            this.button6.TabIndex = 9;
            this.button6.Text = "Buffer";
            this.DragDrop.SetToolTip(this.button6, "Set buffer size");
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(327, 116);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(324, 39);
            this.button4.TabIndex = 0;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(327, 103);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(324, 52);
            this.button5.TabIndex = 8;
            this.button5.Text = "Browse For File...";
            this.DragDrop.SetToolTip(this.button5, "Click to browse for file");
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Transparent;
            this.start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("start.BackgroundImage")));
            this.start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.start.FlatAppearance.BorderSize = 0;
            this.start.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.SystemColors.ControlText;
            this.start.Location = new System.Drawing.Point(327, 396);
            this.start.Margin = new System.Windows.Forms.Padding(0);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(324, 63);
            this.start.TabIndex = 9;
            this.start.Text = "Start";
            this.DragDrop.SetToolTip(this.start, "Start the selected process ");
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Decompressionbutt
            // 
            this.Decompressionbutt.BackColor = System.Drawing.Color.Transparent;
            this.Decompressionbutt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Decompressionbutt.BackgroundImage")));
            this.Decompressionbutt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Decompressionbutt.FlatAppearance.BorderSize = 0;
            this.Decompressionbutt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Decompressionbutt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Decompressionbutt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Decompressionbutt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Decompressionbutt.Font = new System.Drawing.Font("Ink Free", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Decompressionbutt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Decompressionbutt.Location = new System.Drawing.Point(492, 39);
            this.Decompressionbutt.Margin = new System.Windows.Forms.Padding(0);
            this.Decompressionbutt.Name = "Decompressionbutt";
            this.Decompressionbutt.Size = new System.Drawing.Size(159, 64);
            this.Decompressionbutt.TabIndex = 10;
            this.Decompressionbutt.Text = "Decompression";
            this.Decompressionbutt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Decompressionbutt.UseVisualStyleBackColor = false;
            this.Decompressionbutt.Click += new System.EventHandler(this.Decompressionbutt_Click);
            // 
            // DragDrop
            // 
            this.DragDrop.AutomaticDelay = 200;
            // 
            // cancel
            // 
            this.cancel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cancel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelProcessToolStripMenuItem});
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(177, 28);
            // 
            // cancelProcessToolStripMenuItem
            // 
            this.cancelProcessToolStripMenuItem.Name = "cancelProcessToolStripMenuItem";
            this.cancelProcessToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.cancelProcessToolStripMenuItem.Text = "Cancel process";
            this.cancelProcessToolStripMenuItem.Click += new System.EventHandler(this.cancelProcessToolStripMenuItem_Click);
            // 
            // clear
            // 
            this.clear.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.clear.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearProcessToolStripMenuItem});
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(167, 28);
            // 
            // clearProcessToolStripMenuItem
            // 
            this.clearProcessToolStripMenuItem.Name = "clearProcessToolStripMenuItem";
            this.clearProcessToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.clearProcessToolStripMenuItem.Text = "Clear process";
            this.clearProcessToolStripMenuItem.Click += new System.EventHandler(this.clearProcessToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(703, 502);
            this.Controls.Add(this.Decompressionbutt);
            this.Controls.Add(this.start);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Compressionbutt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "File Compression";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.cancel.ResumeLayout(false);
            this.clear.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Compressionbutt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button Decompressionbutt;
        private System.Windows.Forms.ToolTip DragDrop;
        private System.Windows.Forms.ContextMenuStrip cancel;
        private System.Windows.Forms.ToolStripMenuItem cancelProcessToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip clear;
        private System.Windows.Forms.ToolStripMenuItem clearProcessToolStripMenuItem;
    }
}

