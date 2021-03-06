﻿namespace Client
{
    partial class AppForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.historyGrid = new MetroFramework.Controls.MetroGrid();
            this.buyBtn = new MetroFramework.Controls.MetroButton();
            this.nameText = new MetroFramework.Controls.MetroLabel();
            this.diginotesLabel = new MetroFramework.Controls.MetroLabel();
            this.balanceLabel = new MetroFramework.Controls.MetroLabel();
            this.diginotesText = new MetroFramework.Controls.MetroLabel();
            this.balanceText = new MetroFramework.Controls.MetroLabel();
            this.buyText = new MetroFramework.Controls.MetroTextBox();
            this.sellText = new MetroFramework.Controls.MetroTextBox();
            this.sellBtn = new MetroFramework.Controls.MetroButton();
            this.buyError = new MetroFramework.Controls.MetroLabel();
            this.diginotesAvailableLabel = new MetroFramework.Controls.MetroLabel();
            this.diginotesAvailableText = new MetroFramework.Controls.MetroLabel();
            this.balanceAvailableLabel = new MetroFramework.Controls.MetroLabel();
            this.balanceAvailableText = new MetroFramework.Controls.MetroLabel();
            this.quotationLabel = new MetroFramework.Controls.MetroLabel();
            this.quotationUpdateText = new MetroFramework.Controls.MetroLabel();
            this.quotationText = new MetroFramework.Controls.MetroLabel();
            this.sellError = new MetroFramework.Controls.MetroLabel();
            this.generalError = new MetroFramework.Controls.MetroLabel();
            this.quotationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.quotationTimer = new System.Windows.Forms.Timer(this.components);
            this.quotationChartLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.historyGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotationChart)).BeginInit();
            this.SuspendLayout();
            // 
            // historyGrid
            // 
            this.historyGrid.AllowUserToAddRows = false;
            this.historyGrid.AllowUserToDeleteRows = false;
            this.historyGrid.AllowUserToResizeRows = false;
            this.historyGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.historyGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.historyGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.historyGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.historyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.historyGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.historyGrid.EnableHeadersVisualStyles = false;
            this.historyGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.historyGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.historyGrid.Location = new System.Drawing.Point(389, 119);
            this.historyGrid.Name = "historyGrid";
            this.historyGrid.ReadOnly = true;
            this.historyGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.historyGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.historyGrid.RowHeadersVisible = false;
            this.historyGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.historyGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historyGrid.Size = new System.Drawing.Size(377, 416);
            this.historyGrid.Style = MetroFramework.MetroColorStyle.Green;
            this.historyGrid.TabIndex = 0;
            this.historyGrid.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.historyGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.historyGrid_CellValueChanged);
            // 
            // buyBtn
            // 
            this.buyBtn.Location = new System.Drawing.Point(187, 213);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(101, 23);
            this.buyBtn.TabIndex = 1;
            this.buyBtn.Text = "BUY";
            this.buyBtn.UseSelectable = true;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // nameText
            // 
            this.nameText.AutoSize = true;
            this.nameText.Location = new System.Drawing.Point(23, 52);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(71, 19);
            this.nameText.Style = MetroFramework.MetroColorStyle.Green;
            this.nameText.TabIndex = 2;
            this.nameText.Text = "Welcome, ";
            this.nameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // diginotesLabel
            // 
            this.diginotesLabel.AutoSize = true;
            this.diginotesLabel.Location = new System.Drawing.Point(23, 119);
            this.diginotesLabel.Name = "diginotesLabel";
            this.diginotesLabel.Size = new System.Drawing.Size(66, 19);
            this.diginotesLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.diginotesLabel.TabIndex = 3;
            this.diginotesLabel.Text = "Diginotes:";
            this.diginotesLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(172, 119);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(57, 19);
            this.balanceLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.balanceLabel.TabIndex = 4;
            this.balanceLabel.Text = "Balance:";
            this.balanceLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // diginotesText
            // 
            this.diginotesText.AutoSize = true;
            this.diginotesText.Location = new System.Drawing.Point(95, 119);
            this.diginotesText.Name = "diginotesText";
            this.diginotesText.Size = new System.Drawing.Size(16, 19);
            this.diginotesText.TabIndex = 5;
            this.diginotesText.Text = "0";
            this.diginotesText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // balanceText
            // 
            this.balanceText.Location = new System.Drawing.Point(235, 119);
            this.balanceText.Name = "balanceText";
            this.balanceText.Size = new System.Drawing.Size(53, 19);
            this.balanceText.TabIndex = 6;
            this.balanceText.Text = "0.0€";
            this.balanceText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.balanceText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // buyText
            // 
            this.buyText.Lines = new string[] {
        "0"};
            this.buyText.Location = new System.Drawing.Point(24, 213);
            this.buyText.MaxLength = 32767;
            this.buyText.Name = "buyText";
            this.buyText.PasswordChar = '\0';
            this.buyText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.buyText.SelectedText = "";
            this.buyText.Size = new System.Drawing.Size(141, 23);
            this.buyText.Style = MetroFramework.MetroColorStyle.Green;
            this.buyText.TabIndex = 7;
            this.buyText.Text = "0";
            this.buyText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buyText.UseSelectable = true;
            this.buyText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buyText_KeyPress);
            // 
            // sellText
            // 
            this.sellText.Lines = new string[] {
        "0"};
            this.sellText.Location = new System.Drawing.Point(24, 271);
            this.sellText.MaxLength = 32767;
            this.sellText.Name = "sellText";
            this.sellText.PasswordChar = '\0';
            this.sellText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sellText.SelectedText = "";
            this.sellText.Size = new System.Drawing.Size(141, 23);
            this.sellText.Style = MetroFramework.MetroColorStyle.Green;
            this.sellText.TabIndex = 8;
            this.sellText.Text = "0";
            this.sellText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.sellText.UseSelectable = true;
            this.sellText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sellText_KeyPress);
            // 
            // sellBtn
            // 
            this.sellBtn.Location = new System.Drawing.Point(187, 271);
            this.sellBtn.Name = "sellBtn";
            this.sellBtn.Size = new System.Drawing.Size(101, 23);
            this.sellBtn.TabIndex = 9;
            this.sellBtn.Text = "SELL";
            this.sellBtn.UseSelectable = true;
            this.sellBtn.Click += new System.EventHandler(this.sellBtn_Click);
            // 
            // buyError
            // 
            this.buyError.AutoSize = true;
            this.buyError.ForeColor = System.Drawing.Color.Maroon;
            this.buyError.Location = new System.Drawing.Point(23, 239);
            this.buyError.Name = "buyError";
            this.buyError.Size = new System.Drawing.Size(182, 19);
            this.buyError.Style = MetroFramework.MetroColorStyle.Green;
            this.buyError.TabIndex = 10;
            this.buyError.Text = "Please specify a valid number.";
            this.buyError.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buyError.UseCustomForeColor = true;
            this.buyError.Visible = false;
            // 
            // diginotesAvailableLabel
            // 
            this.diginotesAvailableLabel.AutoSize = true;
            this.diginotesAvailableLabel.Location = new System.Drawing.Point(24, 138);
            this.diginotesAvailableLabel.Name = "diginotesAvailableLabel";
            this.diginotesAvailableLabel.Size = new System.Drawing.Size(65, 19);
            this.diginotesAvailableLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.diginotesAvailableLabel.TabIndex = 11;
            this.diginotesAvailableLabel.Text = "Available:";
            this.diginotesAvailableLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // diginotesAvailableText
            // 
            this.diginotesAvailableText.AutoSize = true;
            this.diginotesAvailableText.Location = new System.Drawing.Point(95, 138);
            this.diginotesAvailableText.Name = "diginotesAvailableText";
            this.diginotesAvailableText.Size = new System.Drawing.Size(16, 19);
            this.diginotesAvailableText.TabIndex = 12;
            this.diginotesAvailableText.Text = "0";
            this.diginotesAvailableText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // balanceAvailableLabel
            // 
            this.balanceAvailableLabel.AutoSize = true;
            this.balanceAvailableLabel.Location = new System.Drawing.Point(164, 138);
            this.balanceAvailableLabel.Name = "balanceAvailableLabel";
            this.balanceAvailableLabel.Size = new System.Drawing.Size(65, 19);
            this.balanceAvailableLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.balanceAvailableLabel.TabIndex = 13;
            this.balanceAvailableLabel.Text = "Available:";
            this.balanceAvailableLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // balanceAvailableText
            // 
            this.balanceAvailableText.Location = new System.Drawing.Point(235, 138);
            this.balanceAvailableText.Name = "balanceAvailableText";
            this.balanceAvailableText.Size = new System.Drawing.Size(53, 19);
            this.balanceAvailableText.TabIndex = 14;
            this.balanceAvailableText.Text = "0.0€";
            this.balanceAvailableText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.balanceAvailableText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // quotationLabel
            // 
            this.quotationLabel.AutoSize = true;
            this.quotationLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.quotationLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.quotationLabel.Location = new System.Drawing.Point(525, 27);
            this.quotationLabel.Name = "quotationLabel";
            this.quotationLabel.Size = new System.Drawing.Size(157, 25);
            this.quotationLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.quotationLabel.TabIndex = 15;
            this.quotationLabel.Text = "Current quotation:";
            this.quotationLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // quotationUpdateText
            // 
            this.quotationUpdateText.AutoSize = true;
            this.quotationUpdateText.Location = new System.Drawing.Point(628, 52);
            this.quotationUpdateText.Name = "quotationUpdateText";
            this.quotationUpdateText.Size = new System.Drawing.Size(138, 19);
            this.quotationUpdateText.TabIndex = 16;
            this.quotationUpdateText.Text = "Last updated at 00h00";
            this.quotationUpdateText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // quotationText
            // 
            this.quotationText.AutoSize = true;
            this.quotationText.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.quotationText.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.quotationText.Location = new System.Drawing.Point(679, 27);
            this.quotationText.Name = "quotationText";
            this.quotationText.Size = new System.Drawing.Size(87, 25);
            this.quotationText.TabIndex = 17;
            this.quotationText.Text = "0.0€ each";
            this.quotationText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // sellError
            // 
            this.sellError.AutoSize = true;
            this.sellError.ForeColor = System.Drawing.Color.Maroon;
            this.sellError.Location = new System.Drawing.Point(24, 297);
            this.sellError.Name = "sellError";
            this.sellError.Size = new System.Drawing.Size(182, 19);
            this.sellError.Style = MetroFramework.MetroColorStyle.Green;
            this.sellError.TabIndex = 18;
            this.sellError.Text = "Please specify a valid number.";
            this.sellError.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.sellError.UseCustomForeColor = true;
            this.sellError.Visible = false;
            // 
            // generalError
            // 
            this.generalError.AutoSize = true;
            this.generalError.ForeColor = System.Drawing.Color.Maroon;
            this.generalError.Location = new System.Drawing.Point(183, 27);
            this.generalError.Name = "generalError";
            this.generalError.Size = new System.Drawing.Size(39, 19);
            this.generalError.TabIndex = 19;
            this.generalError.Text = "Error";
            this.generalError.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.generalError.UseCustomForeColor = true;
            this.generalError.Visible = false;
            // 
            // quotationChart
            // 
            this.quotationChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.quotationChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.quotationChart.Legends.Add(legend1);
            this.quotationChart.Location = new System.Drawing.Point(23, 384);
            this.quotationChart.Name = "quotationChart";
            this.quotationChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Legend = "Legend1";
            series1.Name = "Value";
            this.quotationChart.Series.Add(series1);
            this.quotationChart.Size = new System.Drawing.Size(272, 175);
            this.quotationChart.TabIndex = 20;
            this.quotationChart.Text = "chart1";
            // 
            // quotationTimer
            // 
            this.quotationTimer.Enabled = true;
            this.quotationTimer.Interval = 60000;
            this.quotationTimer.Tick += new System.EventHandler(this.quotationTimer_Tick);
            // 
            // quotationChartLabel
            // 
            this.quotationChartLabel.AutoSize = true;
            this.quotationChartLabel.Location = new System.Drawing.Point(23, 362);
            this.quotationChartLabel.Name = "quotationChartLabel";
            this.quotationChartLabel.Size = new System.Drawing.Size(287, 19);
            this.quotationChartLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.quotationChartLabel.TabIndex = 21;
            this.quotationChartLabel.Text = "Watch as the current market quotation changes:";
            this.quotationChartLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 565);
            this.Controls.Add(this.quotationChartLabel);
            this.Controls.Add(this.quotationChart);
            this.Controls.Add(this.generalError);
            this.Controls.Add(this.sellError);
            this.Controls.Add(this.quotationText);
            this.Controls.Add(this.quotationUpdateText);
            this.Controls.Add(this.quotationLabel);
            this.Controls.Add(this.balanceAvailableText);
            this.Controls.Add(this.balanceAvailableLabel);
            this.Controls.Add(this.diginotesAvailableText);
            this.Controls.Add(this.diginotesAvailableLabel);
            this.Controls.Add(this.buyError);
            this.Controls.Add(this.sellBtn);
            this.Controls.Add(this.sellText);
            this.Controls.Add(this.buyText);
            this.Controls.Add(this.balanceText);
            this.Controls.Add(this.diginotesText);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.diginotesLabel);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.buyBtn);
            this.Controls.Add(this.historyGrid);
            this.Name = "AppForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Diginotes 2015";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.historyGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotationChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid historyGrid;
        private MetroFramework.Controls.MetroButton buyBtn;
        public MetroFramework.Controls.MetroLabel nameText;
        private MetroFramework.Controls.MetroLabel diginotesLabel;
        private MetroFramework.Controls.MetroLabel balanceLabel;
        private MetroFramework.Controls.MetroLabel diginotesText;
        private MetroFramework.Controls.MetroLabel balanceText;
        private MetroFramework.Controls.MetroTextBox buyText;
        private MetroFramework.Controls.MetroTextBox sellText;
        private MetroFramework.Controls.MetroButton sellBtn;
        private MetroFramework.Controls.MetroLabel buyError;
        private MetroFramework.Controls.MetroLabel diginotesAvailableLabel;
        private MetroFramework.Controls.MetroLabel diginotesAvailableText;
        private MetroFramework.Controls.MetroLabel balanceAvailableLabel;
        private MetroFramework.Controls.MetroLabel balanceAvailableText;
        private MetroFramework.Controls.MetroLabel quotationLabel;
        private MetroFramework.Controls.MetroLabel quotationUpdateText;
        private MetroFramework.Controls.MetroLabel quotationText;
        private MetroFramework.Controls.MetroLabel sellError;
        private MetroFramework.Controls.MetroLabel generalError;
        private System.Windows.Forms.DataVisualization.Charting.Chart quotationChart;
        private System.Windows.Forms.Timer quotationTimer;
        private MetroFramework.Controls.MetroLabel quotationChartLabel;
    }
}