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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.globalDelay = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.globalDelayLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.positionList = new System.Windows.Forms.ListBox();
            this.randomizeDelays = new System.Windows.Forms.CheckBox();
            this.delayPercentModifier = new System.Windows.Forms.ComboBox();
            this.randomizePositions = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.positionModifier = new System.Windows.Forms.NumericUpDown();
            this.randomPositionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.randomDelayToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.globalDelayToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.beginMouseRecording = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.xPosition = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yPosition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.positionModifier)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(53, 134);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enable F6 Start / Stop";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // globalDelay
            // 
            this.globalDelay.Location = new System.Drawing.Point(53, 61);
            this.globalDelay.Name = "globalDelay";
            this.globalDelay.Size = new System.Drawing.Size(100, 20);
            this.globalDelay.TabIndex = 1;
            this.globalDelayToolTip.SetToolTip(this.globalDelay, "Apply this delay (ms) to all clicks, can be overridden for individual positions.");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // globalDelayLabel
            // 
            this.globalDelayLabel.AutoSize = true;
            this.globalDelayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.globalDelayLabel.Location = new System.Drawing.Point(50, 34);
            this.globalDelayLabel.Name = "globalDelayLabel";
            this.globalDelayLabel.Size = new System.Drawing.Size(145, 20);
            this.globalDelayLabel.TabIndex = 3;
            this.globalDelayLabel.Text = "Global Delay (ms)";
            this.globalDelayLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Use F6 to start and stop";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.addRowBtn.Location = new System.Drawing.Point(501, 94);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(76, 34);
            this.addRowBtn.TabIndex = 7;
            this.addRowBtn.Text = "New +";
            this.addRowBtn.UseVisualStyleBackColor = true;
            this.addRowBtn.Click += new System.EventHandler(this.addRowBtn_Click);
            // 
            // positionList
            // 
            this.positionList.FormattingEnabled = true;
            this.positionList.Location = new System.Drawing.Point(290, 134);
            this.positionList.Name = "positionList";
            this.positionList.Size = new System.Drawing.Size(287, 368);
            this.positionList.TabIndex = 8;
            this.positionList.SelectedIndexChanged += new System.EventHandler(this.positionList_SelectedIndexChanged_1);
            // 
            // randomizeDelays
            // 
            this.randomizeDelays.AutoSize = true;
            this.randomizeDelays.Location = new System.Drawing.Point(53, 179);
            this.randomizeDelays.Name = "randomizeDelays";
            this.randomizeDelays.Size = new System.Drawing.Size(114, 17);
            this.randomizeDelays.TabIndex = 9;
            this.randomizeDelays.Text = "Randomize Delays";
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
            this.delayPercentModifier.Location = new System.Drawing.Point(186, 175);
            this.delayPercentModifier.Name = "delayPercentModifier";
            this.delayPercentModifier.Size = new System.Drawing.Size(61, 21);
            this.delayPercentModifier.TabIndex = 12;
            this.randomDelayToolTip.SetToolTip(this.delayPercentModifier, "Delays are modified by this percentage.");
            // 
            // randomizePositions
            // 
            this.randomizePositions.AutoSize = true;
            this.randomizePositions.Location = new System.Drawing.Point(53, 222);
            this.randomizePositions.Name = "randomizePositions";
            this.randomizePositions.Size = new System.Drawing.Size(124, 17);
            this.randomizePositions.TabIndex = 11;
            this.randomizePositions.Text = "Randomize Positions";
            this.randomizePositions.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "Remove selected item";
            this.button2.Location = new System.Drawing.Point(454, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // positionModifier
            // 
            this.positionModifier.Location = new System.Drawing.Point(186, 219);
            this.positionModifier.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.positionModifier.Name = "positionModifier";
            this.positionModifier.Size = new System.Drawing.Size(61, 20);
            this.positionModifier.TabIndex = 14;
            this.randomPositionToolTip.SetToolTip(this.positionModifier, "Click positions are modified by a max of this many pixels.");
            this.positionModifier.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // beginMouseRecording
            // 
            this.beginMouseRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.beginMouseRecording.Location = new System.Drawing.Point(53, 276);
            this.beginMouseRecording.Name = "beginMouseRecording";
            this.beginMouseRecording.Size = new System.Drawing.Size(142, 29);
            this.beginMouseRecording.TabIndex = 15;
            this.beginMouseRecording.Text = "Record Mouse";
            this.beginMouseRecording.UseVisualStyleBackColor = true;
            this.beginMouseRecording.Click += new System.EventHandler(this.beginMouseRecording_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(54, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "X: ";
            // 
            // xPosition
            // 
            this.xPosition.AutoSize = true;
            this.xPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.xPosition.Location = new System.Drawing.Point(95, 331);
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
            this.label5.Location = new System.Drawing.Point(160, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y: ";
            // 
            // yPosition
            // 
            this.yPosition.AutoSize = true;
            this.yPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.yPosition.Location = new System.Drawing.Point(195, 331);
            this.yPosition.Name = "yPosition";
            this.yPosition.Size = new System.Drawing.Size(49, 20);
            this.yPosition.TabIndex = 19;
            this.yPosition.Text = "y pos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 535);
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
            this.Controls.Add(this.positionList);
            this.Controls.Add(this.addRowBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.globalDelayLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.globalDelay);
            this.Controls.Add(this.checkBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.positionModifier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox globalDelay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label globalDelayLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addRowBtn;
        private System.Windows.Forms.ListBox positionList;
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
    }
}

