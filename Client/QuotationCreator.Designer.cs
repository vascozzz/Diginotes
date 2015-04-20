namespace Client
{
    partial class QuotationCreator
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
            this.quotationLabel = new MetroFramework.Controls.MetroLabel();
            this.quotationText = new MetroFramework.Controls.MetroTextBox();
            this.quotationBtn = new MetroFramework.Controls.MetroButton();
            this.quotationError = new MetroFramework.Controls.MetroLabel();
            this.quotationTimerLabel = new MetroFramework.Controls.MetroLabel();
            this.quotationTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // quotationLabel
            // 
            this.quotationLabel.AutoSize = true;
            this.quotationLabel.Location = new System.Drawing.Point(23, 93);
            this.quotationLabel.Name = "quotationLabel";
            this.quotationLabel.Size = new System.Drawing.Size(167, 19);
            this.quotationLabel.TabIndex = 0;
            this.quotationLabel.Text = "Please set a new quotation:";
            this.quotationLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // quotationText
            // 
            this.quotationText.Lines = new string[0];
            this.quotationText.Location = new System.Drawing.Point(25, 126);
            this.quotationText.MaxLength = 32767;
            this.quotationText.Name = "quotationText";
            this.quotationText.PasswordChar = '\0';
            this.quotationText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.quotationText.SelectedText = "";
            this.quotationText.Size = new System.Drawing.Size(252, 23);
            this.quotationText.TabIndex = 1;
            this.quotationText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.quotationText.UseSelectable = true;
            // 
            // quotationBtn
            // 
            this.quotationBtn.Location = new System.Drawing.Point(97, 193);
            this.quotationBtn.Name = "quotationBtn";
            this.quotationBtn.Size = new System.Drawing.Size(104, 23);
            this.quotationBtn.TabIndex = 2;
            this.quotationBtn.Text = "Confirm";
            this.quotationBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.quotationBtn.UseSelectable = true;
            this.quotationBtn.Click += new System.EventHandler(this.quotationBtn_Click);
            // 
            // quotationError
            // 
            this.quotationError.AutoSize = true;
            this.quotationError.ForeColor = System.Drawing.Color.Maroon;
            this.quotationError.Location = new System.Drawing.Point(23, 49);
            this.quotationError.Name = "quotationError";
            this.quotationError.Size = new System.Drawing.Size(182, 19);
            this.quotationError.TabIndex = 3;
            this.quotationError.Text = "Please specify a valid number.";
            this.quotationError.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.quotationError.UseCustomForeColor = true;
            this.quotationError.Visible = false;
            // 
            // quotationTimerLabel
            // 
            this.quotationTimerLabel.AutoSize = true;
            this.quotationTimerLabel.Location = new System.Drawing.Point(252, 28);
            this.quotationTimerLabel.Name = "quotationTimerLabel";
            this.quotationTimerLabel.Size = new System.Drawing.Size(25, 19);
            this.quotationTimerLabel.TabIndex = 4;
            this.quotationTimerLabel.Text = "XX";
            this.quotationTimerLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // quotationTimer
            // 
            this.quotationTimer.Enabled = true;
            this.quotationTimer.Interval = 1000;
            this.quotationTimer.Tick += new System.EventHandler(this.quotationTimer_Tick);
            // 
            // QuotationCreator
            // 
            this.AcceptButton = this.quotationBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 238);
            this.Controls.Add(this.quotationTimerLabel);
            this.Controls.Add(this.quotationError);
            this.Controls.Add(this.quotationBtn);
            this.Controls.Add(this.quotationText);
            this.Controls.Add(this.quotationLabel);
            this.Name = "QuotationCreator";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "New Quotation";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel quotationLabel;
        private MetroFramework.Controls.MetroTextBox quotationText;
        private MetroFramework.Controls.MetroButton quotationBtn;
        private MetroFramework.Controls.MetroLabel quotationError;
        private MetroFramework.Controls.MetroLabel quotationTimerLabel;
        private System.Windows.Forms.Timer quotationTimer;
    }
}
