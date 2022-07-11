namespace ClickMe
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
            this.enableStartStopBtn = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.topLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.randomizeDelays = new System.Windows.Forms.CheckBox();
            this.delayPercentModifier = new System.Windows.Forms.ComboBox();
            this.randomizePositions = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.positionModifier = new System.Windows.Forms.NumericUpDown();
            this.randomPositionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.globalDelay = new System.Windows.Forms.NumericUpDown();
            this.randomDelayToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.repeatFor = new System.Windows.Forms.ComboBox();
            this.globalDelayToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.beginMouseRecording = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.xPosition = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yPosition = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clearAllBtn = new System.Windows.Forms.Button();
            this.repeatSelection = new System.Windows.Forms.Label();
            this.repeatCount = new System.Windows.Forms.NumericUpDown();
            this.hrSelect = new System.Windows.Forms.NumericUpDown();
            this.mnSelect = new System.Windows.Forms.NumericUpDown();
            this.scSelect = new System.Windows.Forms.NumericUpDown();
            this.hrLbl = new System.Windows.Forms.Label();
            this.mnLbl = new System.Windows.Forms.Label();
            this.scLbl = new System.Windows.Forms.Label();
            this.startStopBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.startStopSelect = new System.Windows.Forms.ComboBox();
            this.customRecordBtn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalModifierKey = new System.Windows.Forms.ComboBox();
            this.useGlobalModifier = new System.Windows.Forms.CheckBox();
            this.positionList = new System.Windows.Forms.ListView();
            this.Label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.X = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Y = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Delay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.enableRecordBtn = new System.Windows.Forms.CheckBox();
            this.randomizeOrder = new System.Windows.Forms.CheckBox();
            this.randomizeOrderTT = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.repeatTT = new System.Windows.Forms.ToolTip(this.components);
            this.repeatCountTT = new System.Windows.Forms.ToolTip(this.components);
            this.repeatLoopCount = new System.Windows.Forms.NumericUpDown();
            this.repeatLoopCountLabel = new System.Windows.Forms.Label();
            this.globalDelayCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.positionModifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scSelect)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatLoopCount)).BeginInit();
            this.SuspendLayout();
            // 
            // enableStartStopBtn
            // 
            this.enableStartStopBtn.AutoSize = true;
            this.enableStartStopBtn.Checked = true;
            this.enableStartStopBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableStartStopBtn.Location = new System.Drawing.Point(48, 134);
            this.enableStartStopBtn.Name = "enableStartStopBtn";
            this.enableStartStopBtn.Size = new System.Drawing.Size(166, 17);
            this.enableStartStopBtn.TabIndex = 0;
            this.enableStartStopBtn.Text = "Enable F6 Start / Stop Button";
            this.enableStartStopBtn.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLabel.Location = new System.Drawing.Point(286, 34);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(167, 24);
            this.topLabel.TabIndex = 4;
            this.topLabel.Text = "F6 to start and stop";
            this.topLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(286, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mouse Positions";
            // 
            // addRowBtn
            // 
            this.addRowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.addRowBtn.Location = new System.Drawing.Point(677, 94);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(53, 34);
            this.addRowBtn.TabIndex = 7;
            this.addRowBtn.Text = "New";
            this.addRowBtn.UseVisualStyleBackColor = true;
            this.addRowBtn.Click += new System.EventHandler(this.addRowBtn_Click);
            // 
            // randomizeDelays
            // 
            this.randomizeDelays.AutoSize = true;
            this.randomizeDelays.Location = new System.Drawing.Point(48, 257);
            this.randomizeDelays.Name = "randomizeDelays";
            this.randomizeDelays.Size = new System.Drawing.Size(114, 17);
            this.randomizeDelays.TabIndex = 9;
            this.randomizeDelays.Text = "Randomize Delays";
            this.randomDelayToolTip.SetToolTip(this.randomizeDelays, "Delays are modified by this percentage.");
            this.randomizeDelays.UseVisualStyleBackColor = true;
            // 
            // delayPercentModifier
            // 
            this.delayPercentModifier.FormattingEnabled = true;
            this.delayPercentModifier.Items.AddRange(new object[] {
            "1%",
            "5%",
            "10%",
            "25%",
            "50%",
            "100%"});
            this.delayPercentModifier.Location = new System.Drawing.Point(181, 253);
            this.delayPercentModifier.Name = "delayPercentModifier";
            this.delayPercentModifier.Size = new System.Drawing.Size(65, 21);
            this.delayPercentModifier.TabIndex = 12;
            this.randomDelayToolTip.SetToolTip(this.delayPercentModifier, "Delays are modified by this percentage.");
            // 
            // randomizePositions
            // 
            this.randomizePositions.AutoSize = true;
            this.randomizePositions.Location = new System.Drawing.Point(48, 290);
            this.randomizePositions.Name = "randomizePositions";
            this.randomizePositions.Size = new System.Drawing.Size(124, 17);
            this.randomizePositions.TabIndex = 11;
            this.randomizePositions.Text = "Randomize Positions";
            this.randomPositionToolTip.SetToolTip(this.randomizePositions, "Randomize click position by a max of the specified amount of pixels");
            this.randomizePositions.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "Remove selected item";
            this.button2.Location = new System.Drawing.Point(634, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // positionModifier
            // 
            this.positionModifier.Location = new System.Drawing.Point(181, 287);
            this.positionModifier.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.positionModifier.Name = "positionModifier";
            this.positionModifier.Size = new System.Drawing.Size(65, 20);
            this.positionModifier.TabIndex = 14;
            this.randomPositionToolTip.SetToolTip(this.positionModifier, "Randomize click position by a max of the specified amount of pixels");
            this.positionModifier.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // globalDelay
            // 
            this.globalDelay.Location = new System.Drawing.Point(166, 223);
            this.globalDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.globalDelay.Name = "globalDelay";
            this.globalDelay.Size = new System.Drawing.Size(80, 20);
            this.globalDelay.TabIndex = 35;
            this.globalDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.globalDelay.ValueChanged += new System.EventHandler(this.globalDelay_ValueChanged);
            // 
            // repeatFor
            // 
            this.repeatFor.FormattingEnabled = true;
            this.repeatFor.Items.AddRange(new object[] {
            "Until Stopped (F6)",
            "For number of loops",
            "For number of clicks",
            "Until specified time"});
            this.repeatFor.Location = new System.Drawing.Point(123, 375);
            this.repeatFor.Name = "repeatFor";
            this.repeatFor.Size = new System.Drawing.Size(119, 21);
            this.repeatFor.TabIndex = 24;
            this.repeatTT.SetToolTip(this.repeatFor, "Repeat loop modifiers");
            this.repeatFor.SelectedIndexChanged += new System.EventHandler(this.repeatFor_SelectedIndexChanged);
            // 
            // beginMouseRecording
            // 
            this.beginMouseRecording.BackColor = System.Drawing.Color.Plum;
            this.beginMouseRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.beginMouseRecording.Location = new System.Drawing.Point(50, 511);
            this.beginMouseRecording.Name = "beginMouseRecording";
            this.beginMouseRecording.Size = new System.Drawing.Size(194, 29);
            this.beginMouseRecording.TabIndex = 15;
            this.beginMouseRecording.Text = "Record Mouse (F7)";
            this.beginMouseRecording.UseVisualStyleBackColor = false;
            this.beginMouseRecording.Click += new System.EventHandler(this.beginMouseRecording_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(52, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "X: ";
            // 
            // xPosition
            // 
            this.xPosition.AutoSize = true;
            this.xPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.xPosition.Location = new System.Drawing.Point(93, 543);
            this.xPosition.Name = "xPosition";
            this.xPosition.Size = new System.Drawing.Size(49, 20);
            this.xPosition.TabIndex = 17;
            this.xPosition.Text = "x pos";
            this.xPosition.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(158, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y: ";
            // 
            // yPosition
            // 
            this.yPosition.AutoSize = true;
            this.yPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.yPosition.Location = new System.Drawing.Point(193, 543);
            this.yPosition.Name = "yPosition";
            this.yPosition.Size = new System.Drawing.Size(49, 20);
            this.yPosition.TabIndex = 19;
            this.yPosition.Text = "y pos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Repeat Loop:";
            this.repeatTT.SetToolTip(this.label4, "Repeat loop modifiers");
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.AccessibleDescription = "Remove selected item";
            this.clearAllBtn.Location = new System.Drawing.Point(591, 94);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(37, 34);
            this.clearAllBtn.TabIndex = 25;
            this.clearAllBtn.Text = "XX";
            this.clearAllBtn.UseVisualStyleBackColor = true;
            this.clearAllBtn.Click += new System.EventHandler(this.clearAllBtn_Click);
            // 
            // repeatSelection
            // 
            this.repeatSelection.AutoSize = true;
            this.repeatSelection.Location = new System.Drawing.Point(47, 429);
            this.repeatSelection.Name = "repeatSelection";
            this.repeatSelection.Size = new System.Drawing.Size(35, 13);
            this.repeatSelection.TabIndex = 26;
            this.repeatSelection.Text = "Clicks";
            this.repeatCountTT.SetToolTip(this.repeatSelection, "Repeat loop this many times");
            this.repeatSelection.Visible = false;
            // 
            // repeatCount
            // 
            this.repeatCount.Location = new System.Drawing.Point(125, 427);
            this.repeatCount.Name = "repeatCount";
            this.repeatCount.Size = new System.Drawing.Size(119, 20);
            this.repeatCount.TabIndex = 27;
            this.repeatCountTT.SetToolTip(this.repeatCount, "Repeat loop this many times");
            this.repeatCount.Visible = false;
            // 
            // hrSelect
            // 
            this.hrSelect.Location = new System.Drawing.Point(69, 453);
            this.hrSelect.Name = "hrSelect";
            this.hrSelect.Size = new System.Drawing.Size(44, 20);
            this.hrSelect.TabIndex = 28;
            this.hrSelect.Visible = false;
            // 
            // mnSelect
            // 
            this.mnSelect.Location = new System.Drawing.Point(141, 453);
            this.mnSelect.Name = "mnSelect";
            this.mnSelect.Size = new System.Drawing.Size(45, 20);
            this.mnSelect.TabIndex = 29;
            this.mnSelect.Visible = false;
            this.mnSelect.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // scSelect
            // 
            this.scSelect.Location = new System.Drawing.Point(214, 453);
            this.scSelect.Name = "scSelect";
            this.scSelect.Size = new System.Drawing.Size(48, 20);
            this.scSelect.TabIndex = 30;
            this.scSelect.Visible = false;
            // 
            // hrLbl
            // 
            this.hrLbl.AutoSize = true;
            this.hrLbl.Location = new System.Drawing.Point(47, 455);
            this.hrLbl.Name = "hrLbl";
            this.hrLbl.Size = new System.Drawing.Size(18, 13);
            this.hrLbl.TabIndex = 31;
            this.hrLbl.Text = "H:";
            this.hrLbl.Visible = false;
            // 
            // mnLbl
            // 
            this.mnLbl.AutoSize = true;
            this.mnLbl.Location = new System.Drawing.Point(119, 455);
            this.mnLbl.Name = "mnLbl";
            this.mnLbl.Size = new System.Drawing.Size(19, 13);
            this.mnLbl.TabIndex = 32;
            this.mnLbl.Text = "M:";
            this.mnLbl.Visible = false;
            // 
            // scLbl
            // 
            this.scLbl.AutoSize = true;
            this.scLbl.Location = new System.Drawing.Point(192, 455);
            this.scLbl.Name = "scLbl";
            this.scLbl.Size = new System.Drawing.Size(17, 13);
            this.scLbl.TabIndex = 33;
            this.scLbl.Text = "S:";
            this.scLbl.Visible = false;
            // 
            // startStopBtn
            // 
            this.startStopBtn.BackColor = System.Drawing.Color.Green;
            this.startStopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.startStopBtn.ForeColor = System.Drawing.Color.White;
            this.startStopBtn.Location = new System.Drawing.Point(517, 27);
            this.startStopBtn.Name = "startStopBtn";
            this.startStopBtn.Size = new System.Drawing.Size(213, 36);
            this.startStopBtn.TabIndex = 34;
            this.startStopBtn.Text = "Start (F6)";
            this.startStopBtn.UseVisualStyleBackColor = false;
            this.startStopBtn.Click += new System.EventHandler(this.startStopBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(47, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Custom Start / Stop Button:";
            // 
            // startStopSelect
            // 
            this.startStopSelect.FormattingEnabled = true;
            this.startStopSelect.Location = new System.Drawing.Point(49, 61);
            this.startStopSelect.Name = "startStopSelect";
            this.startStopSelect.Size = new System.Drawing.Size(133, 21);
            this.startStopSelect.TabIndex = 37;
            this.startStopSelect.SelectedIndexChanged += new System.EventHandler(this.startStopSelect_SelectedIndexChanged);
            // 
            // customRecordBtn
            // 
            this.customRecordBtn.FormattingEnabled = true;
            this.customRecordBtn.Location = new System.Drawing.Point(48, 101);
            this.customRecordBtn.Name = "customRecordBtn";
            this.customRecordBtn.Size = new System.Drawing.Size(133, 21);
            this.customRecordBtn.TabIndex = 39;
            this.customRecordBtn.SelectedIndexChanged += new System.EventHandler(this.customRecordBtn_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(46, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Custom RecordButton:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // globalModifierKey
            // 
            this.globalModifierKey.FormattingEnabled = true;
            this.globalModifierKey.Location = new System.Drawing.Point(164, 194);
            this.globalModifierKey.Name = "globalModifierKey";
            this.globalModifierKey.Size = new System.Drawing.Size(82, 21);
            this.globalModifierKey.TabIndex = 43;
            this.globalModifierKey.SelectedIndexChanged += new System.EventHandler(this.globalModifierKey_SelectedIndexChanged);
            // 
            // useGlobalModifier
            // 
            this.useGlobalModifier.AutoSize = true;
            this.useGlobalModifier.Location = new System.Drawing.Point(48, 196);
            this.useGlobalModifier.Name = "useGlobalModifier";
            this.useGlobalModifier.Size = new System.Drawing.Size(96, 17);
            this.useGlobalModifier.TabIndex = 44;
            this.useGlobalModifier.Text = "Global Modifier";
            this.useGlobalModifier.UseVisualStyleBackColor = true;
            this.useGlobalModifier.CheckedChanged += new System.EventHandler(this.useGlobalModifier_CheckedChanged);
            // 
            // positionList
            // 
            this.positionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Label,
            this.X,
            this.Y,
            this.Delay,
            this.Type,
            this.Mod});
            this.positionList.HideSelection = false;
            this.positionList.Location = new System.Drawing.Point(290, 134);
            this.positionList.Name = "positionList";
            this.positionList.Size = new System.Drawing.Size(440, 429);
            this.positionList.TabIndex = 45;
            this.positionList.UseCompatibleStateImageBehavior = false;
            this.positionList.View = System.Windows.Forms.View.Details;
            // 
            // Label
            // 
            this.Label.Tag = "label";
            this.Label.Text = "Label";
            // 
            // X
            // 
            this.X.Text = "X";
            this.X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Y
            // 
            this.Y.Text = "Y";
            this.Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Delay
            // 
            this.Delay.Text = "Delay";
            this.Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Mod
            // 
            this.Mod.Text = "Mod";
            this.Mod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Mod.Width = 87;
            // 
            // enableRecordBtn
            // 
            this.enableRecordBtn.AutoSize = true;
            this.enableRecordBtn.Checked = true;
            this.enableRecordBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableRecordBtn.Location = new System.Drawing.Point(48, 157);
            this.enableRecordBtn.Name = "enableRecordBtn";
            this.enableRecordBtn.Size = new System.Drawing.Size(146, 17);
            this.enableRecordBtn.TabIndex = 46;
            this.enableRecordBtn.Text = "Enable F7 Record Button";
            this.enableRecordBtn.UseVisualStyleBackColor = true;
            this.enableRecordBtn.CheckedChanged += new System.EventHandler(this.enableRecordBtn_CheckedChanged);
            // 
            // randomizeOrder
            // 
            this.randomizeOrder.AutoSize = true;
            this.randomizeOrder.Location = new System.Drawing.Point(48, 322);
            this.randomizeOrder.Name = "randomizeOrder";
            this.randomizeOrder.Size = new System.Drawing.Size(108, 17);
            this.randomizeOrder.TabIndex = 47;
            this.randomizeOrder.Text = "Randomize Order";
            this.randomizeOrderTT.SetToolTip(this.randomizeOrder, "Randomize the order the clicks");
            this.randomizeOrder.UseVisualStyleBackColor = true;
            // 
            // repeatLoopCount
            // 
            this.repeatLoopCount.Location = new System.Drawing.Point(125, 402);
            this.repeatLoopCount.Name = "repeatLoopCount";
            this.repeatLoopCount.Size = new System.Drawing.Size(119, 20);
            this.repeatLoopCount.TabIndex = 49;
            this.repeatCountTT.SetToolTip(this.repeatLoopCount, "Repeat loop this many times");
            this.repeatLoopCount.Visible = false;
            // 
            // repeatLoopCountLabel
            // 
            this.repeatLoopCountLabel.AutoSize = true;
            this.repeatLoopCountLabel.Location = new System.Drawing.Point(47, 404);
            this.repeatLoopCountLabel.Name = "repeatLoopCountLabel";
            this.repeatLoopCountLabel.Size = new System.Drawing.Size(36, 13);
            this.repeatLoopCountLabel.TabIndex = 48;
            this.repeatLoopCountLabel.Text = "Loops";
            this.repeatCountTT.SetToolTip(this.repeatLoopCountLabel, "Repeat loop this many times");
            this.repeatLoopCountLabel.Visible = false;
            // 
            // globalDelayCheckBox
            // 
            this.globalDelayCheckBox.AutoSize = true;
            this.globalDelayCheckBox.Location = new System.Drawing.Point(48, 224);
            this.globalDelayCheckBox.Name = "globalDelayCheckBox";
            this.globalDelayCheckBox.Size = new System.Drawing.Size(86, 17);
            this.globalDelayCheckBox.TabIndex = 50;
            this.globalDelayCheckBox.Text = "Global Delay";
            this.globalDelayCheckBox.UseVisualStyleBackColor = true;
            this.globalDelayCheckBox.CheckedChanged += new System.EventHandler(this.globalDelayCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 601);
            this.Controls.Add(this.globalDelayCheckBox);
            this.Controls.Add(this.repeatLoopCount);
            this.Controls.Add(this.repeatLoopCountLabel);
            this.Controls.Add(this.randomizeOrder);
            this.Controls.Add(this.enableRecordBtn);
            this.Controls.Add(this.positionList);
            this.Controls.Add(this.useGlobalModifier);
            this.Controls.Add(this.globalModifierKey);
            this.Controls.Add(this.customRecordBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startStopSelect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.globalDelay);
            this.Controls.Add(this.startStopBtn);
            this.Controls.Add(this.scLbl);
            this.Controls.Add(this.mnLbl);
            this.Controls.Add(this.hrLbl);
            this.Controls.Add(this.scSelect);
            this.Controls.Add(this.mnSelect);
            this.Controls.Add(this.hrSelect);
            this.Controls.Add(this.repeatCount);
            this.Controls.Add(this.repeatSelection);
            this.Controls.Add(this.clearAllBtn);
            this.Controls.Add(this.repeatFor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yPosition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xPosition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.beginMouseRecording);
            this.Controls.Add(this.positionModifier);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.delayPercentModifier);
            this.Controls.Add(this.randomizePositions);
            this.Controls.Add(this.randomizeDelays);
            this.Controls.Add(this.addRowBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.enableStartStopBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.positionModifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scSelect)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatLoopCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox enableStartStopBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addRowBtn;
        private System.Windows.Forms.CheckBox randomizeDelays;
        private System.Windows.Forms.ComboBox delayPercentModifier;
        private System.Windows.Forms.CheckBox randomizePositions;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown positionModifier;
        private System.Windows.Forms.ToolTip randomPositionToolTip;
        private System.Windows.Forms.ToolTip randomDelayToolTip;
        private System.Windows.Forms.ToolTip globalDelayToolTip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button beginMouseRecording;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label xPosition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label yPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox repeatFor;
        private System.Windows.Forms.Button clearAllBtn;
        private System.Windows.Forms.Label repeatSelection;
        private System.Windows.Forms.NumericUpDown repeatCount;
        private System.Windows.Forms.NumericUpDown hrSelect;
        private System.Windows.Forms.NumericUpDown mnSelect;
        private System.Windows.Forms.NumericUpDown scSelect;
        private System.Windows.Forms.Label hrLbl;
        private System.Windows.Forms.Label mnLbl;
        private System.Windows.Forms.Label scLbl;
        private System.Windows.Forms.Button startStopBtn;
        private System.Windows.Forms.NumericUpDown globalDelay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox startStopSelect;
        private System.Windows.Forms.ComboBox customRecordBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ComboBox globalModifierKey;
        private System.Windows.Forms.CheckBox useGlobalModifier;
        private System.Windows.Forms.ListView positionList;
        private System.Windows.Forms.ColumnHeader Label;
        private System.Windows.Forms.ColumnHeader X;
        private System.Windows.Forms.ColumnHeader Y;
        private System.Windows.Forms.ColumnHeader Delay;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Mod;
        private System.Windows.Forms.CheckBox enableRecordBtn;
        private System.Windows.Forms.CheckBox randomizeOrder;
        private System.Windows.Forms.ToolTip randomizeOrderTT;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip repeatTT;
        private System.Windows.Forms.ToolTip repeatCountTT;
        private System.Windows.Forms.NumericUpDown repeatLoopCount;
        private System.Windows.Forms.Label repeatLoopCountLabel;
        private System.Windows.Forms.CheckBox globalDelayCheckBox;
    }
}

