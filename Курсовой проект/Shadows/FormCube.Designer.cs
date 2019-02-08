namespace Shadows
{
    partial class FormCube
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
            this.label1 = new System.Windows.Forms.Label();
            this.textX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textD = new System.Windows.Forms.TextBox();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(51, 45);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(69, 20);
            this.textX.TabIndex = 1;
            this.textX.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Положение";
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(51, 71);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(69, 20);
            this.textY.TabIndex = 4;
            this.textY.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y";
            // 
            // textZ
            // 
            this.textZ.Location = new System.Drawing.Point(51, 97);
            this.textZ.Name = "textZ";
            this.textZ.Size = new System.Drawing.Size(69, 20);
            this.textZ.TabIndex = 6;
            this.textZ.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Длина грани";
            // 
            // textD
            // 
            this.textD.Location = new System.Drawing.Point(210, 45);
            this.textD.Name = "textD";
            this.textD.Size = new System.Drawing.Size(50, 20);
            this.textD.TabIndex = 9;
            this.textD.Text = "200";
            // 
            // comboColor
            // 
            this.comboColor.FormattingEnabled = true;
            this.comboColor.Items.AddRange(new object[] {
            "Красный",
            "Зелёный",
            "Голубой"});
            this.comboColor.Location = new System.Drawing.Point(51, 123);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(81, 21);
            this.comboColor.TabIndex = 11;
            this.comboColor.Text = "Красный";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Цвет";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(110, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Ввод";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 214);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboColor);
            this.Controls.Add(this.textD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textZ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.label1);
            this.Name = "FormCube";
            this.Text = "Куб";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textD;
        private System.Windows.Forms.ComboBox comboColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}