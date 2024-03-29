﻿namespace ClickMe
{
    partial class PositionPopup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.positionDelay = new System.Windows.Forms.TextBox();
            this.positionLabel = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.popupBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.warningLabel = new System.Windows.Forms.Label();
            this.yValueLabel = new System.Windows.Forms.Label();
            this.xValueLabel = new System.Windows.Forms.Label();
            this.popupWarning = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.clickModifier = new System.Windows.Forms.ComboBox();
            this.rightClick = new System.Windows.Forms.CheckBox();
            this.doubleClick = new System.Windows.Forms.CheckBox();
            this.overrideGlobalDelay = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.popupProcessList = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sendToProcess = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position Label: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(91, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Delay: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(44, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Coordinates: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(159, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(273, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(91, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Move mouse to position and press F7";
            // 
            // positionDelay
            // 
            this.positionDelay.Location = new System.Drawing.Point(163, 89);
            this.positionDelay.Name = "positionDelay";
            this.positionDelay.Size = new System.Drawing.Size(93, 20);
            this.positionDelay.TabIndex = 2;
            this.toolTip1.SetToolTip(this.positionDelay, "Delay between clicks");
            // 
            // positionLabel
            // 
            this.positionLabel.Location = new System.Drawing.Point(163, 36);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(236, 20);
            this.positionLabel.TabIndex = 1;
            this.toolTip1.SetToolTip(this.positionLabel, "Click position label");
            this.positionLabel.TextChanged += new System.EventHandler(this.positionLabel_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.Location = new System.Drawing.Point(316, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.toolTip1.SetToolTip(this.button1, "Add to click position list");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // popupBackgroundWorker
            // 
            this.popupBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.popupBackgroundWorker_DoWork);
            // 
            // warningLabel
            // 
            this.warningLabel.Location = new System.Drawing.Point(0, 0);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(100, 23);
            this.warningLabel.TabIndex = 14;
            // 
            // yValueLabel
            // 
            this.yValueLabel.AutoSize = true;
            this.yValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.yValueLabel.Location = new System.Drawing.Point(298, 359);
            this.yValueLabel.Name = "yValueLabel";
            this.yValueLabel.Size = new System.Drawing.Size(0, 20);
            this.yValueLabel.TabIndex = 12;
            // 
            // xValueLabel
            // 
            this.xValueLabel.AutoSize = true;
            this.xValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.xValueLabel.Location = new System.Drawing.Point(185, 359);
            this.xValueLabel.Name = "xValueLabel";
            this.xValueLabel.Size = new System.Drawing.Size(0, 20);
            this.xValueLabel.TabIndex = 13;
            // 
            // popupWarning
            // 
            this.popupWarning.AutoSize = true;
            this.popupWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.popupWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.popupWarning.Location = new System.Drawing.Point(61, 411);
            this.popupWarning.Name = "popupWarning";
            this.popupWarning.Size = new System.Drawing.Size(0, 24);
            this.popupWarning.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label7.Location = new System.Drawing.Point(74, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Modifier: ";
            // 
            // clickModifier
            // 
            this.clickModifier.FormattingEnabled = true;
            this.clickModifier.Location = new System.Drawing.Point(163, 147);
            this.clickModifier.Name = "clickModifier";
            this.clickModifier.Size = new System.Drawing.Size(121, 21);
            this.clickModifier.TabIndex = 17;
            this.toolTip1.SetToolTip(this.clickModifier, "A key that will be held during the click action");
            // 
            // rightClick
            // 
            this.rightClick.AutoSize = true;
            this.rightClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.rightClick.Location = new System.Drawing.Point(81, 196);
            this.rightClick.Name = "rightClick";
            this.rightClick.Size = new System.Drawing.Size(109, 24);
            this.rightClick.TabIndex = 18;
            this.rightClick.Text = "Right Click";
            this.rightClick.UseVisualStyleBackColor = true;
            // 
            // doubleClick
            // 
            this.doubleClick.AutoSize = true;
            this.doubleClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.doubleClick.Location = new System.Drawing.Point(196, 196);
            this.doubleClick.Name = "doubleClick";
            this.doubleClick.Size = new System.Drawing.Size(123, 24);
            this.doubleClick.TabIndex = 19;
            this.doubleClick.Text = "Double Click";
            this.doubleClick.UseVisualStyleBackColor = true;
            // 
            // overrideGlobalDelay
            // 
            this.overrideGlobalDelay.AutoSize = true;
            this.overrideGlobalDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.overrideGlobalDelay.Location = new System.Drawing.Point(262, 87);
            this.overrideGlobalDelay.Name = "overrideGlobalDelay";
            this.overrideGlobalDelay.Size = new System.Drawing.Size(145, 24);
            this.overrideGlobalDelay.TabIndex = 20;
            this.overrideGlobalDelay.Text = "Override Global";
            this.toolTip1.SetToolTip(this.overrideGlobalDelay, "Override the global click delay if one is set");
            this.overrideGlobalDelay.UseVisualStyleBackColor = true;
            // 
            // popupProcessList
            // 
            this.popupProcessList.FormattingEnabled = true;
            this.popupProcessList.Location = new System.Drawing.Point(163, 267);
            this.popupProcessList.Name = "popupProcessList";
            this.popupProcessList.Size = new System.Drawing.Size(121, 21);
            this.popupProcessList.TabIndex = 21;
            this.toolTip1.SetToolTip(this.popupProcessList, "If using key modifier, you need to specify which application the key press will b" +
        "e sent to.");
            this.popupProcessList.SelectedIndexChanged += new System.EventHandler(this.popupProcessList_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label8.Location = new System.Drawing.Point(74, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Process:";
            // 
            // sendToProcess
            // 
            this.sendToProcess.AutoSize = true;
            this.sendToProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.sendToProcess.Location = new System.Drawing.Point(290, 264);
            this.sendToProcess.Name = "sendToProcess";
            this.sendToProcess.Size = new System.Drawing.Size(157, 24);
            this.sendToProcess.TabIndex = 23;
            this.sendToProcess.Text = "Send To Process";
            this.toolTip1.SetToolTip(this.sendToProcess, "Override the global click delay if one is set");
            this.sendToProcess.UseVisualStyleBackColor = true;
            // 
            // PositionPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 478);
            this.Controls.Add(this.sendToProcess);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.popupProcessList);
            this.Controls.Add(this.overrideGlobalDelay);
            this.Controls.Add(this.doubleClick);
            this.Controls.Add(this.rightClick);
            this.Controls.Add(this.clickModifier);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.popupWarning);
            this.Controls.Add(this.xValueLabel);
            this.Controls.Add(this.yValueLabel);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.positionDelay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PositionPopup";
            this.Text = "PositionPopup";
            this.Load += new System.EventHandler(this.PositionPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox positionDelay;
        private System.Windows.Forms.TextBox positionLabel;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker popupBackgroundWorker;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label yValueLabel;
        private System.Windows.Forms.Label xValueLabel;
        private System.Windows.Forms.Label popupWarning;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox clickModifier;
        private System.Windows.Forms.CheckBox rightClick;
        private System.Windows.Forms.CheckBox doubleClick;
        private System.Windows.Forms.CheckBox overrideGlobalDelay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox popupProcessList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox sendToProcess;
    }
}