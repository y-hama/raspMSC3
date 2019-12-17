namespace MSCController.Forms
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MonitorFrameBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ImageUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.FpsLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MoveNextButton = new System.Windows.Forms.Button();
            this.MoveBackButton = new System.Windows.Forms.Button();
            this.CanceleButton = new System.Windows.Forms.Button();
            this.AdjustButton = new System.Windows.Forms.Button();
            this.ControlerPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ControllStatusLabel = new System.Windows.Forms.Label();
            this.TakeFrameButton = new System.Windows.Forms.Button();
            this.TakeFileName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonitorFrameBox)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ControlerPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(658, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 561);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MonitorFrameBox);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monitor";
            // 
            // MonitorFrameBox
            // 
            this.MonitorFrameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitorFrameBox.Location = new System.Drawing.Point(3, 15);
            this.MonitorFrameBox.Name = "MonitorFrameBox";
            this.MonitorFrameBox.Size = new System.Drawing.Size(320, 240);
            this.MonitorFrameBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MonitorFrameBox.TabIndex = 0;
            this.MonitorFrameBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 561);
            this.panel2.TabIndex = 1;
            // 
            // ImageUpdateTimer
            // 
            this.ImageUpdateTimer.Enabled = true;
            this.ImageUpdateTimer.Interval = 20;
            this.ImageUpdateTimer.Tick += new System.EventHandler(this.ImageUpdateTimer_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SizeLabel);
            this.panel3.Controls.Add(this.FpsLabel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 255);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 50);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status";
            // 
            // FpsLabel
            // 
            this.FpsLabel.AutoSize = true;
            this.FpsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FpsLabel.Location = new System.Drawing.Point(0, 12);
            this.FpsLabel.Name = "FpsLabel";
            this.FpsLabel.Size = new System.Drawing.Size(26, 12);
            this.FpsLabel.TabIndex = 1;
            this.FpsLabel.Text = "FPS";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SizeLabel.Location = new System.Drawing.Point(0, 24);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(26, 12);
            this.SizeLabel.TabIndex = 2;
            this.SizeLabel.Text = "Size";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 253);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller";
            // 
            // MoveNextButton
            // 
            this.MoveNextButton.Location = new System.Drawing.Point(84, 3);
            this.MoveNextButton.Name = "MoveNextButton";
            this.MoveNextButton.Size = new System.Drawing.Size(75, 23);
            this.MoveNextButton.TabIndex = 0;
            this.MoveNextButton.Text = "<-";
            this.MoveNextButton.UseVisualStyleBackColor = true;
            this.MoveNextButton.Click += new System.EventHandler(this.MoveNextButton_Click);
            // 
            // MoveBackButton
            // 
            this.MoveBackButton.Location = new System.Drawing.Point(165, 3);
            this.MoveBackButton.Name = "MoveBackButton";
            this.MoveBackButton.Size = new System.Drawing.Size(75, 23);
            this.MoveBackButton.TabIndex = 1;
            this.MoveBackButton.Text = "->";
            this.MoveBackButton.UseVisualStyleBackColor = true;
            this.MoveBackButton.Click += new System.EventHandler(this.MoveBackButton_Click);
            // 
            // CanceleButton
            // 
            this.CanceleButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CanceleButton.Location = new System.Drawing.Point(245, 0);
            this.CanceleButton.Name = "CanceleButton";
            this.CanceleButton.Size = new System.Drawing.Size(75, 113);
            this.CanceleButton.TabIndex = 2;
            this.CanceleButton.Text = "x";
            this.CanceleButton.UseVisualStyleBackColor = true;
            this.CanceleButton.Click += new System.EventHandler(this.CanceleButton_Click);
            // 
            // AdjustButton
            // 
            this.AdjustButton.Location = new System.Drawing.Point(3, 3);
            this.AdjustButton.Name = "AdjustButton";
            this.AdjustButton.Size = new System.Drawing.Size(75, 23);
            this.AdjustButton.TabIndex = 3;
            this.AdjustButton.Text = "< 〇 >";
            this.AdjustButton.UseVisualStyleBackColor = true;
            this.AdjustButton.Click += new System.EventHandler(this.AdjustButton_Click);
            // 
            // ControlerPanel
            // 
            this.ControlerPanel.Controls.Add(this.TakeFileName);
            this.ControlerPanel.Controls.Add(this.TakeFrameButton);
            this.ControlerPanel.Controls.Add(this.AdjustButton);
            this.ControlerPanel.Controls.Add(this.MoveNextButton);
            this.ControlerPanel.Controls.Add(this.MoveBackButton);
            this.ControlerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlerPanel.Location = new System.Drawing.Point(0, 25);
            this.ControlerPanel.Name = "ControlerPanel";
            this.ControlerPanel.Size = new System.Drawing.Size(245, 88);
            this.ControlerPanel.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.CanceleButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(320, 113);
            this.panel5.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ControlerPanel);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 113);
            this.panel4.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ControllStatusLabel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(245, 25);
            this.panel6.TabIndex = 0;
            // 
            // ControllStatusLabel
            // 
            this.ControllStatusLabel.AutoSize = true;
            this.ControllStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControllStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.ControllStatusLabel.Name = "ControllStatusLabel";
            this.ControllStatusLabel.Size = new System.Drawing.Size(50, 12);
            this.ControllStatusLabel.TabIndex = 0;
            this.ControllStatusLabel.Text = "Message";
            // 
            // TakeFrameButton
            // 
            this.TakeFrameButton.Location = new System.Drawing.Point(2, 62);
            this.TakeFrameButton.Name = "TakeFrameButton";
            this.TakeFrameButton.Size = new System.Drawing.Size(236, 23);
            this.TakeFrameButton.TabIndex = 4;
            this.TakeFrameButton.Text = "[  [   ［//］   ]  ]";
            this.TakeFrameButton.UseVisualStyleBackColor = true;
            this.TakeFrameButton.Click += new System.EventHandler(this.TakeFrameButton_Click);
            // 
            // TakeFileName
            // 
            this.TakeFileName.Location = new System.Drawing.Point(3, 37);
            this.TakeFileName.Name = "TakeFileName";
            this.TakeFileName.Size = new System.Drawing.Size(235, 19);
            this.TakeFileName.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MonitorFrameBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ControlerPanel.ResumeLayout(false);
            this.ControlerPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox MonitorFrameBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer ImageUpdateTimer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FpsLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button MoveNextButton;
        private System.Windows.Forms.Button MoveBackButton;
        private System.Windows.Forms.Button CanceleButton;
        private System.Windows.Forms.Button AdjustButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel ControlerPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label ControllStatusLabel;
        private System.Windows.Forms.Button TakeFrameButton;
        private System.Windows.Forms.TextBox TakeFileName;
    }
}