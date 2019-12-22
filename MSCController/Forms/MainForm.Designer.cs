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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MonitorPanel = new System.Windows.Forms.Panel();
            this.ControllerGroup = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ControlerPanel = new System.Windows.Forms.Panel();
            this.TakeFileName = new System.Windows.Forms.TextBox();
            this.TakeFrameButton = new System.Windows.Forms.Button();
            this.AdjustButton = new System.Windows.Forms.Button();
            this.MoveNextButton = new System.Windows.Forms.Button();
            this.MoveBackButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.FilterControllProgress = new System.Windows.Forms.ProgressBar();
            this.ControllStatusLabel = new System.Windows.Forms.Label();
            this.CanceleButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MonitorFrameBox = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LimitValueLabel = new System.Windows.Forms.Label();
            this.LimitValue = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReconnectButton = new System.Windows.Forms.Button();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.FpsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.SpectrumChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RenameButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLocationLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripPointRedLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripPointBlueLabel = new System.Windows.Forms.ToolStripLabel();
            this.TargetLabel = new System.Windows.Forms.ToolStripTextBox();
            this.AlignmentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MinBrightnessLabel = new System.Windows.Forms.ToolStripTextBox();
            this.MaxBrightnessLabel = new System.Windows.Forms.ToolStripTextBox();
            this.StretchButton = new System.Windows.Forms.ToolStripButton();
            this.SpectrumList = new System.Windows.Forms.ListBox();
            this.FilterList = new System.Windows.Forms.ListBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.MainviewPanel = new System.Windows.Forms.PictureBox();
            this.BackgroundviewPanel = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ImageList = new System.Windows.Forms.ListBox();
            this.ExtructButton = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.LoadOption = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveFileName = new System.Windows.Forms.TextBox();
            this.OptionColorBox = new System.Windows.Forms.CheckBox();
            this.ContorollTimer = new System.Windows.Forms.Timer(this.components);
            this.MonitorPanel.SuspendLayout();
            this.ControllerGroup.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.ControlerPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonitorFrameBox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LimitValue)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumChart)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainviewPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundviewPanel)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.LoadOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // MonitorPanel
            // 
            this.MonitorPanel.Controls.Add(this.ControllerGroup);
            this.MonitorPanel.Controls.Add(this.groupBox1);
            this.MonitorPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MonitorPanel.Location = new System.Drawing.Point(783, 0);
            this.MonitorPanel.Name = "MonitorPanel";
            this.MonitorPanel.Size = new System.Drawing.Size(326, 701);
            this.MonitorPanel.TabIndex = 0;
            // 
            // ControllerGroup
            // 
            this.ControllerGroup.Controls.Add(this.panel5);
            this.ControllerGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControllerGroup.Location = new System.Drawing.Point(0, 318);
            this.ControllerGroup.Name = "ControllerGroup";
            this.ControllerGroup.Size = new System.Drawing.Size(326, 383);
            this.ControllerGroup.TabIndex = 1;
            this.ControllerGroup.TabStop = false;
            this.ControllerGroup.Text = "Controller";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.CanceleButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(320, 116);
            this.panel5.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ControlerPanel);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 116);
            this.panel4.TabIndex = 6;
            // 
            // ControlerPanel
            // 
            this.ControlerPanel.Controls.Add(this.TakeFileName);
            this.ControlerPanel.Controls.Add(this.TakeFrameButton);
            this.ControlerPanel.Controls.Add(this.AdjustButton);
            this.ControlerPanel.Controls.Add(this.MoveNextButton);
            this.ControlerPanel.Controls.Add(this.MoveBackButton);
            this.ControlerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlerPanel.Location = new System.Drawing.Point(0, 30);
            this.ControlerPanel.Name = "ControlerPanel";
            this.ControlerPanel.Size = new System.Drawing.Size(245, 86);
            this.ControlerPanel.TabIndex = 4;
            // 
            // TakeFileName
            // 
            this.TakeFileName.Location = new System.Drawing.Point(3, 32);
            this.TakeFileName.Name = "TakeFileName";
            this.TakeFileName.Size = new System.Drawing.Size(235, 19);
            this.TakeFileName.TabIndex = 6;
            // 
            // TakeFrameButton
            // 
            this.TakeFrameButton.Location = new System.Drawing.Point(2, 57);
            this.TakeFrameButton.Name = "TakeFrameButton";
            this.TakeFrameButton.Size = new System.Drawing.Size(236, 23);
            this.TakeFrameButton.TabIndex = 4;
            this.TakeFrameButton.Text = "[  [   ［//］   ]  ]";
            this.TakeFrameButton.UseVisualStyleBackColor = true;
            this.TakeFrameButton.Click += new System.EventHandler(this.TakeFrameButton_Click);
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
            // panel6
            // 
            this.panel6.Controls.Add(this.FilterControllProgress);
            this.panel6.Controls.Add(this.ControllStatusLabel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(245, 30);
            this.panel6.TabIndex = 0;
            // 
            // FilterControllProgress
            // 
            this.FilterControllProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterControllProgress.Location = new System.Drawing.Point(0, 12);
            this.FilterControllProgress.Name = "FilterControllProgress";
            this.FilterControllProgress.Size = new System.Drawing.Size(245, 18);
            this.FilterControllProgress.TabIndex = 2;
            // 
            // ControllStatusLabel
            // 
            this.ControllStatusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControllStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.ControllStatusLabel.Name = "ControllStatusLabel";
            this.ControllStatusLabel.Size = new System.Drawing.Size(245, 12);
            this.ControllStatusLabel.TabIndex = 0;
            this.ControllStatusLabel.Text = "Message";
            // 
            // CanceleButton
            // 
            this.CanceleButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CanceleButton.Location = new System.Drawing.Point(245, 0);
            this.CanceleButton.Name = "CanceleButton";
            this.CanceleButton.Size = new System.Drawing.Size(75, 116);
            this.CanceleButton.TabIndex = 2;
            this.CanceleButton.Text = "x";
            this.CanceleButton.UseVisualStyleBackColor = true;
            this.CanceleButton.Click += new System.EventHandler(this.CanceleButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MonitorFrameBox);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 318);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.LimitValueLabel);
            this.panel3.Controls.Add(this.LimitValue);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.SizeLabel);
            this.panel3.Controls.Add(this.FpsLabel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 255);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 60);
            this.panel3.TabIndex = 1;
            // 
            // LimitValueLabel
            // 
            this.LimitValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LimitValueLabel.AutoSize = true;
            this.LimitValueLabel.Location = new System.Drawing.Point(282, 24);
            this.LimitValueLabel.Name = "LimitValueLabel";
            this.LimitValueLabel.Size = new System.Drawing.Size(0, 12);
            this.LimitValueLabel.TabIndex = 7;
            // 
            // LimitValue
            // 
            this.LimitValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LimitValue.AutoSize = false;
            this.LimitValue.Location = new System.Drawing.Point(213, 0);
            this.LimitValue.Maximum = 255;
            this.LimitValue.Name = "LimitValue";
            this.LimitValue.Size = new System.Drawing.Size(104, 17);
            this.LimitValue.TabIndex = 6;
            this.LimitValue.Scroll += new System.EventHandler(this.LimitValue_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ReconnectButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 21);
            this.panel1.TabIndex = 4;
            // 
            // ReconnectButton
            // 
            this.ReconnectButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ReconnectButton.Location = new System.Drawing.Point(245, 0);
            this.ReconnectButton.Name = "ReconnectButton";
            this.ReconnectButton.Size = new System.Drawing.Size(75, 21);
            this.ReconnectButton.TabIndex = 3;
            this.ReconnectButton.Text = "Reconnect";
            this.ReconnectButton.UseVisualStyleBackColor = true;
            this.ReconnectButton.Click += new System.EventHandler(this.ReconnectButton_Click);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 701);
            this.panel2.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(118, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(665, 701);
            this.panel8.TabIndex = 5;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.SpectrumList);
            this.panel9.Controls.Add(this.FilterList);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 505);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(665, 196);
            this.panel9.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.SpectrumChart);
            this.panel11.Controls.Add(this.toolStrip1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(178, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(487, 196);
            this.panel11.TabIndex = 3;
            // 
            // SpectrumChart
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Interval = 50D;
            chartArea1.AxisY.Maximum = 255D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "SelectionArea";
            this.SpectrumChart.ChartAreas.Add(chartArea1);
            this.SpectrumChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpectrumChart.Location = new System.Drawing.Point(0, 25);
            this.SpectrumChart.Name = "SpectrumChart";
            series1.BorderColor = System.Drawing.Color.Red;
            series1.ChartArea = "SelectionArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "RedSelection";
            series2.BorderColor = System.Drawing.Color.Blue;
            series2.ChartArea = "SelectionArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.Name = "BlueSelection";
            this.SpectrumChart.Series.Add(series1);
            this.SpectrumChart.Series.Add(series2);
            this.SpectrumChart.Size = new System.Drawing.Size(487, 171);
            this.SpectrumChart.TabIndex = 0;
            this.SpectrumChart.Text = "chart1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameButton,
            this.toolStripSeparator4,
            this.ToolStripLocationLabel,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.ToolStripPointRedLabel,
            this.toolStripSeparator2,
            this.toolStripLabel5,
            this.ToolStripPointBlueLabel,
            this.TargetLabel,
            this.AlignmentButton,
            this.toolStripSeparator3,
            this.MinBrightnessLabel,
            this.MaxBrightnessLabel,
            this.StretchButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(487, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RenameButton
            // 
            this.RenameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RenameButton.Image = ((System.Drawing.Image)(resources.GetObject("RenameButton.Image")));
            this.RenameButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(23, 22);
            this.RenameButton.Text = "Rename";
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripLocationLabel
            // 
            this.ToolStripLocationLabel.AutoSize = false;
            this.ToolStripLocationLabel.Name = "ToolStripLocationLabel";
            this.ToolStripLocationLabel.Size = new System.Drawing.Size(50, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel3.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(18, 22);
            this.toolStripLabel3.Text = "Pt";
            // 
            // ToolStripPointRedLabel
            // 
            this.ToolStripPointRedLabel.AutoSize = false;
            this.ToolStripPointRedLabel.Name = "ToolStripPointRedLabel";
            this.ToolStripPointRedLabel.Size = new System.Drawing.Size(50, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel5.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(18, 22);
            this.toolStripLabel5.Text = "Pt";
            // 
            // ToolStripPointBlueLabel
            // 
            this.ToolStripPointBlueLabel.AutoSize = false;
            this.ToolStripPointBlueLabel.Name = "ToolStripPointBlueLabel";
            this.ToolStripPointBlueLabel.Size = new System.Drawing.Size(50, 22);
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = false;
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(50, 25);
            this.TargetLabel.Text = "100";
            this.TargetLabel.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AlignmentButton
            // 
            this.AlignmentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AlignmentButton.Image = ((System.Drawing.Image)(resources.GetObject("AlignmentButton.Image")));
            this.AlignmentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AlignmentButton.Name = "AlignmentButton";
            this.AlignmentButton.Size = new System.Drawing.Size(23, 22);
            this.AlignmentButton.Text = "Alignment";
            this.AlignmentButton.Click += new System.EventHandler(this.AlignmentButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // MinBrightnessLabel
            // 
            this.MinBrightnessLabel.AutoSize = false;
            this.MinBrightnessLabel.Name = "MinBrightnessLabel";
            this.MinBrightnessLabel.Size = new System.Drawing.Size(50, 25);
            this.MinBrightnessLabel.Text = "0";
            this.MinBrightnessLabel.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MaxBrightnessLabel
            // 
            this.MaxBrightnessLabel.AutoSize = false;
            this.MaxBrightnessLabel.Name = "MaxBrightnessLabel";
            this.MaxBrightnessLabel.Size = new System.Drawing.Size(50, 25);
            this.MaxBrightnessLabel.Text = "255";
            this.MaxBrightnessLabel.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StretchButton
            // 
            this.StretchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StretchButton.Image = ((System.Drawing.Image)(resources.GetObject("StretchButton.Image")));
            this.StretchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StretchButton.Name = "StretchButton";
            this.StretchButton.Size = new System.Drawing.Size(23, 22);
            this.StretchButton.Text = "Stretch";
            this.StretchButton.Click += new System.EventHandler(this.StretchButton_Click);
            // 
            // SpectrumList
            // 
            this.SpectrumList.Dock = System.Windows.Forms.DockStyle.Left;
            this.SpectrumList.FormattingEnabled = true;
            this.SpectrumList.ItemHeight = 12;
            this.SpectrumList.Location = new System.Drawing.Point(89, 0);
            this.SpectrumList.Name = "SpectrumList";
            this.SpectrumList.Size = new System.Drawing.Size(89, 196);
            this.SpectrumList.TabIndex = 1;
            this.SpectrumList.SelectedIndexChanged += new System.EventHandler(this.SpectrumList_SelectedIndexChanged);
            // 
            // FilterList
            // 
            this.FilterList.Dock = System.Windows.Forms.DockStyle.Left;
            this.FilterList.FormattingEnabled = true;
            this.FilterList.ItemHeight = 12;
            this.FilterList.Items.AddRange(new object[] {
            "IRCut",
            "DC-R",
            "DC-G",
            "DC-B",
            "VcCut",
            "Infragram",
            "700nm",
            "740nm",
            "770nm",
            "810nm",
            "850nm",
            "870nm",
            "890nm",
            "910nm",
            "940nm",
            "970nm"});
            this.FilterList.Location = new System.Drawing.Point(0, 0);
            this.FilterList.Name = "FilterList";
            this.FilterList.Size = new System.Drawing.Size(89, 196);
            this.FilterList.TabIndex = 4;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.MainviewPanel);
            this.panel12.Controls.Add(this.BackgroundviewPanel);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(665, 505);
            this.panel12.TabIndex = 5;
            // 
            // MainviewPanel
            // 
            this.MainviewPanel.Location = new System.Drawing.Point(25, 25);
            this.MainviewPanel.Name = "MainviewPanel";
            this.MainviewPanel.Size = new System.Drawing.Size(640, 480);
            this.MainviewPanel.TabIndex = 3;
            this.MainviewPanel.TabStop = false;
            this.MainviewPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainviewPanel_MouseMove);
            this.MainviewPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainviewPanel_MouseUp);
            // 
            // BackgroundviewPanel
            // 
            this.BackgroundviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundviewPanel.Location = new System.Drawing.Point(0, 0);
            this.BackgroundviewPanel.Name = "BackgroundviewPanel";
            this.BackgroundviewPanel.Size = new System.Drawing.Size(665, 505);
            this.BackgroundviewPanel.TabIndex = 4;
            this.BackgroundviewPanel.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ImageList);
            this.panel7.Controls.Add(this.ExtructButton);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(118, 701);
            this.panel7.TabIndex = 4;
            // 
            // ImageList
            // 
            this.ImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageList.FormattingEnabled = true;
            this.ImageList.ItemHeight = 12;
            this.ImageList.Location = new System.Drawing.Point(0, 144);
            this.ImageList.Name = "ImageList";
            this.ImageList.Size = new System.Drawing.Size(118, 557);
            this.ImageList.TabIndex = 0;
            this.ImageList.DoubleClick += new System.EventHandler(this.ImageList_DoubleClick);
            // 
            // ExtructButton
            // 
            this.ExtructButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExtructButton.Location = new System.Drawing.Point(0, 108);
            this.ExtructButton.Name = "ExtructButton";
            this.ExtructButton.Size = new System.Drawing.Size(118, 36);
            this.ExtructButton.TabIndex = 2;
            this.ExtructButton.Text = "Extruct";
            this.ExtructButton.UseVisualStyleBackColor = true;
            this.ExtructButton.Click += new System.EventHandler(this.ExtructButton_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.LoadOption);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(118, 108);
            this.panel10.TabIndex = 3;
            // 
            // LoadOption
            // 
            this.LoadOption.Controls.Add(this.SaveButton);
            this.LoadOption.Controls.Add(this.SaveFileName);
            this.LoadOption.Controls.Add(this.OptionColorBox);
            this.LoadOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadOption.Location = new System.Drawing.Point(0, 0);
            this.LoadOption.Name = "LoadOption";
            this.LoadOption.Size = new System.Drawing.Size(118, 108);
            this.LoadOption.TabIndex = 0;
            this.LoadOption.TabStop = false;
            this.LoadOption.Text = "Option";
            // 
            // SaveButton
            // 
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveButton.Location = new System.Drawing.Point(3, 50);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 36);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveFileName
            // 
            this.SaveFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveFileName.Location = new System.Drawing.Point(3, 31);
            this.SaveFileName.Name = "SaveFileName";
            this.SaveFileName.Size = new System.Drawing.Size(112, 19);
            this.SaveFileName.TabIndex = 4;
            // 
            // OptionColorBox
            // 
            this.OptionColorBox.AutoSize = true;
            this.OptionColorBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionColorBox.Location = new System.Drawing.Point(3, 15);
            this.OptionColorBox.Name = "OptionColorBox";
            this.OptionColorBox.Size = new System.Drawing.Size(112, 16);
            this.OptionColorBox.TabIndex = 0;
            this.OptionColorBox.Text = "Color";
            this.OptionColorBox.UseVisualStyleBackColor = true;
            // 
            // ContorollTimer
            // 
            this.ContorollTimer.Enabled = true;
            this.ContorollTimer.Interval = 20;
            this.ContorollTimer.Tick += new System.EventHandler(this.ContorollTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 701);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MonitorPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "raspMSC-Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MonitorPanel.ResumeLayout(false);
            this.ControllerGroup.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ControlerPanel.ResumeLayout(false);
            this.ControlerPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MonitorFrameBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LimitValue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumChart)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainviewPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundviewPanel)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.LoadOption.ResumeLayout(false);
            this.LoadOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MonitorPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox MonitorFrameBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer ContorollTimer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FpsLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.GroupBox ControllerGroup;
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
        private System.Windows.Forms.ListBox ImageList;
        private System.Windows.Forms.ListBox SpectrumList;
        private System.Windows.Forms.ProgressBar FilterControllProgress;
        private System.Windows.Forms.Button ReconnectButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ExtructButton;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox MainviewPanel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.GroupBox LoadOption;
        private System.Windows.Forms.CheckBox OptionColorBox;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataVisualization.Charting.Chart SpectrumChart;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel ToolStripLocationLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel ToolStripPointRedLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel ToolStripPointBlueLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton AlignmentButton;
        private System.Windows.Forms.ToolStripTextBox TargetLabel;
        private System.Windows.Forms.ToolStripTextBox MinBrightnessLabel;
        private System.Windows.Forms.ToolStripTextBox MaxBrightnessLabel;
        private System.Windows.Forms.ToolStripButton StretchButton;
        private System.Windows.Forms.PictureBox BackgroundviewPanel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox SaveFileName;
        private System.Windows.Forms.ListBox FilterList;
        private System.Windows.Forms.ToolStripButton RenameButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TrackBar LimitValue;
        private System.Windows.Forms.Label LimitValueLabel;
    }
}