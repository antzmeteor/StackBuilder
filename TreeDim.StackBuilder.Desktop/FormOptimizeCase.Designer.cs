﻿namespace TreeDim.StackBuilder.Desktop
{
    partial class FormOptimizeCase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptimizeCase));
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbBoxDimensions = new System.Windows.Forms.Label();
            this.cbBoxes = new System.Windows.Forms.ComboBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.btSetMaximum = new System.Windows.Forms.Button();
            this.btSetMinimum = new System.Windows.Forms.Button();
            this.nudWallThickness = new System.Windows.Forms.NumericUpDown();
            this.lbWallThickness = new System.Windows.Forms.Label();
            this.nudWallsHeightDir = new System.Windows.Forms.NumericUpDown();
            this.nudWallsWidthDir = new System.Windows.Forms.NumericUpDown();
            this.nudWallsLengthDir = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCaseHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCaseWidth = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCaseLength = new System.Windows.Forms.NumericUpDown();
            this.nudMinCaseHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMinCaseWidth = new System.Windows.Forms.NumericUpDown();
            this.nudMinCaseLength = new System.Windows.Forms.NumericUpDown();
            this.lbHeight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbWalls = new System.Windows.Forms.Label();
            this.lbMaxCaseDimensions = new System.Windows.Forms.Label();
            this.lbMinCaseDimensions = new System.Windows.Forms.Label();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.nudPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.lbPalletHeight = new System.Windows.Forms.Label();
            this.lbPalletDimensions = new System.Windows.Forms.Label();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.btOptimize = new System.Windows.Forms.Button();
            this.gridSolutions = new SourceGrid.Grid();
            this.btAddSolution = new System.Windows.Forms.Button();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbBoxesLayout = new System.Windows.Forms.PictureBox();
            this.pbPallet = new System.Windows.Forms.PictureBox();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.gbCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsHeightDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsWidthDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsLengthDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseLength)).BeginInit();
            this.gbPallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletHeight)).BeginInit();
            this.statusStripDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxesLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Name = "btClose";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Controls.Add(this.nudNumber);
            this.groupBox.Controls.Add(this.lbNumber);
            this.groupBox.Controls.Add(this.lbBoxDimensions);
            this.groupBox.Controls.Add(this.cbBoxes);
            this.groupBox.Controls.Add(this.lbBox);
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // nudNumber
            // 
            resources.ApplyResources(this.nudNumber, "nudNumber");
            this.nudNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lbNumber
            // 
            resources.ApplyResources(this.lbNumber, "lbNumber");
            this.lbNumber.Name = "lbNumber";
            // 
            // lbBoxDimensions
            // 
            resources.ApplyResources(this.lbBoxDimensions, "lbBoxDimensions");
            this.lbBoxDimensions.Name = "lbBoxDimensions";
            // 
            // cbBoxes
            // 
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.FormattingEnabled = true;
            resources.ApplyResources(this.cbBoxes, "cbBoxes");
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.cbBoxes_SelectedIndexChanged);
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // gbCase
            // 
            resources.ApplyResources(this.gbCase, "gbCase");
            this.gbCase.Controls.Add(this.btSetMaximum);
            this.gbCase.Controls.Add(this.btSetMinimum);
            this.gbCase.Controls.Add(this.nudWallThickness);
            this.gbCase.Controls.Add(this.lbWallThickness);
            this.gbCase.Controls.Add(this.nudWallsHeightDir);
            this.gbCase.Controls.Add(this.nudWallsWidthDir);
            this.gbCase.Controls.Add(this.nudWallsLengthDir);
            this.gbCase.Controls.Add(this.nudMaxCaseHeight);
            this.gbCase.Controls.Add(this.nudMaxCaseWidth);
            this.gbCase.Controls.Add(this.nudMaxCaseLength);
            this.gbCase.Controls.Add(this.nudMinCaseHeight);
            this.gbCase.Controls.Add(this.nudMinCaseWidth);
            this.gbCase.Controls.Add(this.nudMinCaseLength);
            this.gbCase.Controls.Add(this.lbHeight);
            this.gbCase.Controls.Add(this.label3);
            this.gbCase.Controls.Add(this.lbLength);
            this.gbCase.Controls.Add(this.lbWalls);
            this.gbCase.Controls.Add(this.lbMaxCaseDimensions);
            this.gbCase.Controls.Add(this.lbMinCaseDimensions);
            this.gbCase.Name = "gbCase";
            this.gbCase.TabStop = false;
            // 
            // btSetMaximum
            // 
            resources.ApplyResources(this.btSetMaximum, "btSetMaximum");
            this.btSetMaximum.Name = "btSetMaximum";
            this.btSetMaximum.UseVisualStyleBackColor = true;
            this.btSetMaximum.Click += new System.EventHandler(this.btSetMaximum_Click);
            // 
            // btSetMinimum
            // 
            resources.ApplyResources(this.btSetMinimum, "btSetMinimum");
            this.btSetMinimum.Name = "btSetMinimum";
            this.btSetMinimum.UseVisualStyleBackColor = true;
            this.btSetMinimum.Click += new System.EventHandler(this.btSetMinimum_Click);
            // 
            // nudWallThickness
            // 
            resources.ApplyResources(this.nudWallThickness, "nudWallThickness");
            this.nudWallThickness.Name = "nudWallThickness";
            // 
            // lbWallThickness
            // 
            resources.ApplyResources(this.lbWallThickness, "lbWallThickness");
            this.lbWallThickness.Name = "lbWallThickness";
            // 
            // nudWallsHeightDir
            // 
            resources.ApplyResources(this.nudWallsHeightDir, "nudWallsHeightDir");
            this.nudWallsHeightDir.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsHeightDir.Name = "nudWallsHeightDir";
            this.nudWallsHeightDir.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudWallsWidthDir
            // 
            resources.ApplyResources(this.nudWallsWidthDir, "nudWallsWidthDir");
            this.nudWallsWidthDir.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsWidthDir.Name = "nudWallsWidthDir";
            this.nudWallsWidthDir.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudWallsLengthDir
            // 
            resources.ApplyResources(this.nudWallsLengthDir, "nudWallsLengthDir");
            this.nudWallsLengthDir.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsLengthDir.Name = "nudWallsLengthDir";
            this.nudWallsLengthDir.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudMaxCaseHeight
            // 
            resources.ApplyResources(this.nudMaxCaseHeight, "nudMaxCaseHeight");
            this.nudMaxCaseHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxCaseHeight.Name = "nudMaxCaseHeight";
            // 
            // nudMaxCaseWidth
            // 
            resources.ApplyResources(this.nudMaxCaseWidth, "nudMaxCaseWidth");
            this.nudMaxCaseWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxCaseWidth.Name = "nudMaxCaseWidth";
            // 
            // nudMaxCaseLength
            // 
            resources.ApplyResources(this.nudMaxCaseLength, "nudMaxCaseLength");
            this.nudMaxCaseLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxCaseLength.Name = "nudMaxCaseLength";
            // 
            // nudMinCaseHeight
            // 
            resources.ApplyResources(this.nudMinCaseHeight, "nudMinCaseHeight");
            this.nudMinCaseHeight.Name = "nudMinCaseHeight";
            // 
            // nudMinCaseWidth
            // 
            resources.ApplyResources(this.nudMinCaseWidth, "nudMinCaseWidth");
            this.nudMinCaseWidth.Name = "nudMinCaseWidth";
            // 
            // nudMinCaseLength
            // 
            resources.ApplyResources(this.nudMinCaseLength, "nudMinCaseLength");
            this.nudMinCaseLength.Name = "nudMinCaseLength";
            // 
            // lbHeight
            // 
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Name = "lbHeight";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lbLength
            // 
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Name = "lbLength";
            // 
            // lbWalls
            // 
            resources.ApplyResources(this.lbWalls, "lbWalls");
            this.lbWalls.Name = "lbWalls";
            // 
            // lbMaxCaseDimensions
            // 
            resources.ApplyResources(this.lbMaxCaseDimensions, "lbMaxCaseDimensions");
            this.lbMaxCaseDimensions.Name = "lbMaxCaseDimensions";
            // 
            // lbMinCaseDimensions
            // 
            resources.ApplyResources(this.lbMinCaseDimensions, "lbMinCaseDimensions");
            this.lbMinCaseDimensions.Name = "lbMinCaseDimensions";
            // 
            // gbPallet
            // 
            resources.ApplyResources(this.gbPallet, "gbPallet");
            this.gbPallet.Controls.Add(this.nudPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletDimensions);
            this.gbPallet.Controls.Add(this.cbPallet);
            this.gbPallet.Controls.Add(this.lbPallet);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.TabStop = false;
            // 
            // nudPalletHeight
            // 
            resources.ApplyResources(this.nudPalletHeight, "nudPalletHeight");
            this.nudPalletHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletHeight.Name = "nudPalletHeight";
            // 
            // lbPalletHeight
            // 
            resources.ApplyResources(this.lbPalletHeight, "lbPalletHeight");
            this.lbPalletHeight.Name = "lbPalletHeight";
            // 
            // lbPalletDimensions
            // 
            resources.ApplyResources(this.lbPalletDimensions, "lbPalletDimensions");
            this.lbPalletDimensions.Name = "lbPalletDimensions";
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.SelectedIndexChanged += new System.EventHandler(this.cbPallet_SelectedIndexChanged);
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // btOptimize
            // 
            resources.ApplyResources(this.btOptimize, "btOptimize");
            this.btOptimize.Name = "btOptimize";
            this.btOptimize.UseVisualStyleBackColor = true;
            this.btOptimize.Click += new System.EventHandler(this.btOptimize_Click);
            // 
            // gridSolutions
            // 
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // btAddSolution
            // 
            resources.ApplyResources(this.btAddSolution, "btAddSolution");
            this.btAddSolution.Name = "btAddSolution";
            this.btAddSolution.UseVisualStyleBackColor = true;
            this.btAddSolution.Click += new System.EventHandler(this.btAddSolution_Click);
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Name = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // pbBoxesLayout
            // 
            resources.ApplyResources(this.pbBoxesLayout, "pbBoxesLayout");
            this.pbBoxesLayout.Name = "pbBoxesLayout";
            this.pbBoxesLayout.TabStop = false;
            // 
            // pbPallet
            // 
            resources.ApplyResources(this.pbPallet, "pbPallet");
            this.pbPallet.Name = "pbPallet";
            this.pbPallet.TabStop = false;
            // 
            // FormOptimizeCase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbPallet);
            this.Controls.Add(this.pbBoxesLayout);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.btAddSolution);
            this.Controls.Add(this.gridSolutions);
            this.Controls.Add(this.btOptimize);
            this.Controls.Add(this.gbPallet);
            this.Controls.Add(this.gbCase);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptimizeCase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormOptimizeCase_Load);
            this.SizeChanged += new System.EventHandler(this.FormOptimizeCase_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptimizeCase_FormClosing);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.gbCase.ResumeLayout(false);
            this.gbCase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsHeightDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsWidthDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsLengthDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseLength)).EndInit();
            this.gbPallet.ResumeLayout(false);
            this.gbPallet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletHeight)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxesLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox cbBoxes;
        private System.Windows.Forms.Label lbBox;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbBoxDimensions;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.GroupBox gbCase;
        private System.Windows.Forms.Label lbWalls;
        private System.Windows.Forms.Label lbMaxCaseDimensions;
        private System.Windows.Forms.Label lbMinCaseDimensions;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.NumericUpDown nudWallsHeightDir;
        private System.Windows.Forms.NumericUpDown nudWallsWidthDir;
        private System.Windows.Forms.NumericUpDown nudWallsLengthDir;
        private System.Windows.Forms.NumericUpDown nudMaxCaseHeight;
        private System.Windows.Forms.NumericUpDown nudMaxCaseWidth;
        private System.Windows.Forms.NumericUpDown nudMaxCaseLength;
        private System.Windows.Forms.NumericUpDown nudMinCaseHeight;
        private System.Windows.Forms.NumericUpDown nudMinCaseWidth;
        private System.Windows.Forms.NumericUpDown nudMinCaseLength;
        private System.Windows.Forms.NumericUpDown nudWallThickness;
        private System.Windows.Forms.Label lbWallThickness;
        private System.Windows.Forms.GroupBox gbPallet;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.Label lbPalletDimensions;
        private System.Windows.Forms.NumericUpDown nudPalletHeight;
        private System.Windows.Forms.Label lbPalletHeight;
        private System.Windows.Forms.Button btOptimize;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.Button btAddSolution;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.Button btSetMaximum;
        private System.Windows.Forms.Button btSetMinimum;
        private System.Windows.Forms.PictureBox pbBoxesLayout;
        private System.Windows.Forms.PictureBox pbPallet;
    }
}