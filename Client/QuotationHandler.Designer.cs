namespace Client
{
    partial class QuotationHandler
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
            this.quotationLabel1 = new MetroFramework.Controls.MetroLabel();
            this.quotationLabel2 = new MetroFramework.Controls.MetroLabel();
            this.quotationLabel3 = new MetroFramework.Controls.MetroLabel();
            this.quotationLabel4 = new MetroFramework.Controls.MetroLabel();
            this.acceptBtn = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // quotationLabel1
            // 
            this.quotationLabel1.AutoSize = true;
            this.quotationLabel1.Location = new System.Drawing.Point(23, 51);
            this.quotationLabel1.Name = "quotationLabel1";
            this.quotationLabel1.Size = new System.Drawing.Size(263, 19);
            this.quotationLabel1.TabIndex = 0;
            this.quotationLabel1.Text = "It seems the market quotation has changed.";
            this.quotationLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // quotationLabel2
            // 
            this.quotationLabel2.AutoSize = true;
            this.quotationLabel2.Location = new System.Drawing.Point(23, 103);
            this.quotationLabel2.Name = "quotationLabel2";
            this.quotationLabel2.Size = new System.Drawing.Size(268, 19);
            this.quotationLabel2.TabIndex = 1;
            this.quotationLabel2.Text = "You can accept the new quotation and apply";
            this.quotationLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // quotationLabel3
            // 
            this.quotationLabel3.AutoSize = true;
            this.quotationLabel3.Location = new System.Drawing.Point(20, 122);
            this.quotationLabel3.Name = "quotationLabel3";
            this.quotationLabel3.Size = new System.Drawing.Size(235, 19);
            this.quotationLabel3.TabIndex = 2;
            this.quotationLabel3.Text = " it to all of your pending exchanges, or";
            this.quotationLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // quotationLabel4
            // 
            this.quotationLabel4.AutoSize = true;
            this.quotationLabel4.Location = new System.Drawing.Point(23, 141);
            this.quotationLabel4.Name = "quotationLabel4";
            this.quotationLabel4.Size = new System.Drawing.Size(200, 19);
            this.quotationLabel4.TabIndex = 3;
            this.quotationLabel4.Text = "reject it by removing all of them.";
            this.quotationLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // acceptBtn
            // 
            this.acceptBtn.Location = new System.Drawing.Point(26, 201);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(110, 23);
            this.acceptBtn.TabIndex = 4;
            this.acceptBtn.Text = "Accept";
            this.acceptBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.acceptBtn.UseSelectable = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(176, 201);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(110, 23);
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Reject";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // QuotationHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 247);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.quotationLabel4);
            this.Controls.Add(this.quotationLabel3);
            this.Controls.Add(this.quotationLabel2);
            this.Controls.Add(this.quotationLabel1);
            this.Name = "QuotationHandler";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Quotation Changed";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel quotationLabel1;
        private MetroFramework.Controls.MetroLabel quotationLabel2;
        private MetroFramework.Controls.MetroLabel quotationLabel3;
        private MetroFramework.Controls.MetroLabel quotationLabel4;
        private MetroFramework.Controls.MetroButton acceptBtn;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}
