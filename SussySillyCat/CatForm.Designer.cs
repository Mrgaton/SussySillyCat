namespace SussySillyCat
{
    partial class CatForm
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
            this.catPictureBox = new System.Windows.Forms.PictureBox();
            this.cardNumberTextBox = new System.Windows.Forms.TextBox();
            this.expirityTextBox = new System.Windows.Forms.TextBox();
            this.securityCodeTextBox = new System.Windows.Forms.TextBox();
            this.thanksTextBox = new System.Windows.Forms.Button();
            this.cardLabel = new System.Windows.Forms.Label();
            this.expirityLabel = new System.Windows.Forms.Label();
            this.securityLabel = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.catPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // catPictureBox
            // 
            this.catPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.catPictureBox.Location = new System.Drawing.Point(0, 0);
            this.catPictureBox.Name = "catPictureBox";
            this.catPictureBox.Size = new System.Drawing.Size(326, 284);
            this.catPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.catPictureBox.TabIndex = 0;
            this.catPictureBox.TabStop = false;
            // 
            // cardNumberTextBox
            // 
            this.cardNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardNumberTextBox.Location = new System.Drawing.Point(480, 104);
            this.cardNumberTextBox.Name = "cardNumberTextBox";
            this.cardNumberTextBox.Size = new System.Drawing.Size(229, 31);
            this.cardNumberTextBox.TabIndex = 1;
            // 
            // expirityTextBox
            // 
            this.expirityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirityTextBox.Location = new System.Drawing.Point(480, 151);
            this.expirityTextBox.Name = "expirityTextBox";
            this.expirityTextBox.Size = new System.Drawing.Size(229, 31);
            this.expirityTextBox.TabIndex = 2;
            // 
            // securityCodeTextBox
            // 
            this.securityCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.securityCodeTextBox.Location = new System.Drawing.Point(480, 197);
            this.securityCodeTextBox.Name = "securityCodeTextBox";
            this.securityCodeTextBox.Size = new System.Drawing.Size(229, 31);
            this.securityCodeTextBox.TabIndex = 3;
            // 
            // thanksTextBox
            // 
            this.thanksTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanksTextBox.Location = new System.Drawing.Point(447, 240);
            this.thanksTextBox.Name = "thanksTextBox";
            this.thanksTextBox.Size = new System.Drawing.Size(130, 35);
            this.thanksTextBox.TabIndex = 4;
            this.thanksTextBox.Text = "Th-thanks";
            this.thanksTextBox.UseVisualStyleBackColor = true;
            // 
            // cardLabel
            // 
            this.cardLabel.AutoSize = true;
            this.cardLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardLabel.Location = new System.Drawing.Point(332, 108);
            this.cardLabel.Name = "cardLabel";
            this.cardLabel.Size = new System.Drawing.Size(135, 24);
            this.cardLabel.TabIndex = 5;
            this.cardLabel.Text = "Card number:";
            // 
            // expirityLabel
            // 
            this.expirityLabel.AutoSize = true;
            this.expirityLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirityLabel.Location = new System.Drawing.Point(342, 155);
            this.expirityLabel.Name = "expirityLabel";
            this.expirityLabel.Size = new System.Drawing.Size(132, 24);
            this.expirityLabel.TabIndex = 6;
            this.expirityLabel.Text = "Expirity date:";
            // 
            // securityLabel
            // 
            this.securityLabel.AutoSize = true;
            this.securityLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.securityLabel.Location = new System.Drawing.Point(329, 204);
            this.securityLabel.Name = "securityLabel";
            this.securityLabel.Size = new System.Drawing.Size(145, 24);
            this.securityLabel.TabIndex = 7;
            this.securityLabel.Text = "Security code:";
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(359, 9);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(322, 72);
            this.mainLabel.TabIndex = 8;
            this.mainLabel.Text = "H-hi there....\r\nDo you th-think I could have your \r\ncredit card information, p-pl" +
    "ease?";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(721, 284);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.securityLabel);
            this.Controls.Add(this.expirityLabel);
            this.Controls.Add(this.cardLabel);
            this.Controls.Add(this.thanksTextBox);
            this.Controls.Add(this.securityCodeTextBox);
            this.Controls.Add(this.expirityTextBox);
            this.Controls.Add(this.cardNumberTextBox);
            this.Controls.Add(this.catPictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatForm";
            this.Text = "Totaly Not Malware";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.catPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox catPictureBox;
        private System.Windows.Forms.TextBox cardNumberTextBox;
        private System.Windows.Forms.TextBox expirityTextBox;
        private System.Windows.Forms.TextBox securityCodeTextBox;
        private System.Windows.Forms.Button thanksTextBox;
        private System.Windows.Forms.Label cardLabel;
        private System.Windows.Forms.Label expirityLabel;
        private System.Windows.Forms.Label securityLabel;
        private System.Windows.Forms.Label mainLabel;
    }
}

