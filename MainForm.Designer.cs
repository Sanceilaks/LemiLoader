namespace LemiLoader
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
            this.hacksComboBox = new System.Windows.Forms.ComboBox();
            this.chooseHackLabel = new System.Windows.Forms.Label();
            this.injectButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hacksComboBox
            // 
            this.hacksComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hacksComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hacksComboBox.Location = new System.Drawing.Point(141, 23);
            this.hacksComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.hacksComboBox.Name = "hacksComboBox";
            this.hacksComboBox.Size = new System.Drawing.Size(405, 27);
            this.hacksComboBox.TabIndex = 0;
            // 
            // chooseHackLabel
            // 
            this.chooseHackLabel.AutoSize = true;
            this.chooseHackLabel.Location = new System.Drawing.Point(28, 28);
            this.chooseHackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chooseHackLabel.Name = "chooseHackLabel";
            this.chooseHackLabel.Size = new System.Drawing.Size(94, 19);
            this.chooseHackLabel.TabIndex = 1;
            this.chooseHackLabel.Text = "Choose hack";
            // 
            // injectButton
            // 
            this.injectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.injectButton.Location = new System.Drawing.Point(16, 247);
            this.injectButton.Margin = new System.Windows.Forms.Padding(4);
            this.injectButton.Name = "injectButton";
            this.injectButton.Size = new System.Drawing.Size(532, 34);
            this.injectButton.TabIndex = 2;
            this.injectButton.Text = "Load";
            this.injectButton.UseVisualStyleBackColor = true;
            this.injectButton.Click += new System.EventHandler(this.injectButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 205);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(532, 34);
            this.progressBar.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(16, 181);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(532, 19);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 291);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.injectButton);
            this.Controls.Add(this.chooseHackLabel);
            this.Controls.Add(this.hacksComboBox);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "LL";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hacksComboBox;
        private System.Windows.Forms.Label chooseHackLabel;
        private System.Windows.Forms.Button injectButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statusLabel;
    }
}

