namespace Shadows
{
    partial class ShadowsForm
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
            this.picture = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTime = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.новаяСценаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьМодельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цилиндрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кубToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.призмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьМодельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCamera = new System.Windows.Forms.TabPage();
            this.textCameraZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textCameraY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textCameraX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSource1 = new System.Windows.Forms.TabPage();
            this.textSource1Size = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboSource1 = new System.Windows.Forms.ComboBox();
            this.textSource1Z = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textSource1Y = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textSource1X = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabSource2 = new System.Windows.Forms.TabPage();
            this.textSource2Size = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkSources = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboSource2 = new System.Windows.Forms.ComboBox();
            this.textSource2Z = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textSource2Y = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textSource2X = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboStep = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCamera.SuspendLayout();
            this.tabSource1.SuspendLayout();
            this.tabSource2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.ErrorImage = null;
            this.picture.InitialImage = null;
            this.picture.Location = new System.Drawing.Point(12, 32);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(761, 705);
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 740);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(12, 570);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 13);
            this.labelTime.TabIndex = 3;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяСценаToolStripMenuItem,
            this.добавитьМодельToolStripMenuItem,
            this.удалитьМодельToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1084, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // новаяСценаToolStripMenuItem
            // 
            this.новаяСценаToolStripMenuItem.Name = "новаяСценаToolStripMenuItem";
            this.новаяСценаToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.новаяСценаToolStripMenuItem.Text = "Новая сцена";
            this.новаяСценаToolStripMenuItem.Click += new System.EventHandler(this.новаяСценаToolStripMenuItem_Click);
            // 
            // добавитьМодельToolStripMenuItem
            // 
            this.добавитьМодельToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цилиндрToolStripMenuItem,
            this.конусToolStripMenuItem,
            this.кубToolStripMenuItem,
            this.призмаToolStripMenuItem});
            this.добавитьМодельToolStripMenuItem.Name = "добавитьМодельToolStripMenuItem";
            this.добавитьМодельToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.добавитьМодельToolStripMenuItem.Text = "Добавить модель";
            // 
            // цилиндрToolStripMenuItem
            // 
            this.цилиндрToolStripMenuItem.Name = "цилиндрToolStripMenuItem";
            this.цилиндрToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.цилиндрToolStripMenuItem.Text = "Цилиндр";
            this.цилиндрToolStripMenuItem.Click += new System.EventHandler(this.цилиндрToolStripMenuItem_Click);
            // 
            // конусToolStripMenuItem
            // 
            this.конусToolStripMenuItem.Name = "конусToolStripMenuItem";
            this.конусToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.конусToolStripMenuItem.Text = "Конус";
            this.конусToolStripMenuItem.Click += new System.EventHandler(this.конусToolStripMenuItem_Click);
            // 
            // кубToolStripMenuItem
            // 
            this.кубToolStripMenuItem.Name = "кубToolStripMenuItem";
            this.кубToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.кубToolStripMenuItem.Text = "Куб";
            this.кубToolStripMenuItem.Click += new System.EventHandler(this.кубToolStripMenuItem_Click);
            // 
            // призмаToolStripMenuItem
            // 
            this.призмаToolStripMenuItem.Name = "призмаToolStripMenuItem";
            this.призмаToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.призмаToolStripMenuItem.Text = "Призма";
            this.призмаToolStripMenuItem.Click += new System.EventHandler(this.призмаToolStripMenuItem_Click);
            // 
            // удалитьМодельToolStripMenuItem
            // 
            this.удалитьМодельToolStripMenuItem.Name = "удалитьМодельToolStripMenuItem";
            this.удалитьМодельToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.удалитьМодельToolStripMenuItem.Text = "Удалить модель";
            this.удалитьМодельToolStripMenuItem.Click += new System.EventHandler(this.удалитьМодельToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCamera);
            this.tabControl.Controls.Add(this.tabSource1);
            this.tabControl.Controls.Add(this.tabSource2);
            this.tabControl.Location = new System.Drawing.Point(779, 32);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(305, 320);
            this.tabControl.TabIndex = 5;
            // 
            // tabCamera
            // 
            this.tabCamera.Controls.Add(this.textCameraZ);
            this.tabCamera.Controls.Add(this.label4);
            this.tabCamera.Controls.Add(this.textCameraY);
            this.tabCamera.Controls.Add(this.label3);
            this.tabCamera.Controls.Add(this.label2);
            this.tabCamera.Controls.Add(this.textCameraX);
            this.tabCamera.Controls.Add(this.label1);
            this.tabCamera.Location = new System.Drawing.Point(4, 22);
            this.tabCamera.Name = "tabCamera";
            this.tabCamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabCamera.Size = new System.Drawing.Size(297, 294);
            this.tabCamera.TabIndex = 0;
            this.tabCamera.Text = "Камера";
            this.tabCamera.UseVisualStyleBackColor = true;
            // 
            // textCameraZ
            // 
            this.textCameraZ.Location = new System.Drawing.Point(85, 80);
            this.textCameraZ.Name = "textCameraZ";
            this.textCameraZ.Size = new System.Drawing.Size(58, 20);
            this.textCameraZ.TabIndex = 6;
            this.textCameraZ.Text = "300";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Z";
            // 
            // textCameraY
            // 
            this.textCameraY.Location = new System.Drawing.Point(85, 54);
            this.textCameraY.Name = "textCameraY";
            this.textCameraY.Size = new System.Drawing.Size(58, 20);
            this.textCameraY.TabIndex = 4;
            this.textCameraY.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Положение";
            // 
            // textCameraX
            // 
            this.textCameraX.Location = new System.Drawing.Point(85, 28);
            this.textCameraX.Name = "textCameraX";
            this.textCameraX.Size = new System.Drawing.Size(58, 20);
            this.textCameraX.TabIndex = 1;
            this.textCameraX.Text = "300";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // tabSource1
            // 
            this.tabSource1.Controls.Add(this.textSource1Size);
            this.tabSource1.Controls.Add(this.label17);
            this.tabSource1.Controls.Add(this.label10);
            this.tabSource1.Controls.Add(this.comboSource1);
            this.tabSource1.Controls.Add(this.textSource1Z);
            this.tabSource1.Controls.Add(this.label6);
            this.tabSource1.Controls.Add(this.textSource1Y);
            this.tabSource1.Controls.Add(this.label7);
            this.tabSource1.Controls.Add(this.label8);
            this.tabSource1.Controls.Add(this.textSource1X);
            this.tabSource1.Controls.Add(this.label9);
            this.tabSource1.Location = new System.Drawing.Point(4, 22);
            this.tabSource1.Name = "tabSource1";
            this.tabSource1.Padding = new System.Windows.Forms.Padding(3);
            this.tabSource1.Size = new System.Drawing.Size(297, 294);
            this.tabSource1.TabIndex = 1;
            this.tabSource1.Text = "Источник 1";
            this.tabSource1.UseVisualStyleBackColor = true;
            // 
            // textSource1Size
            // 
            this.textSource1Size.Location = new System.Drawing.Point(62, 193);
            this.textSource1Size.Name = "textSource1Size";
            this.textSource1Size.Size = new System.Drawing.Size(58, 20);
            this.textSource1Size.TabIndex = 29;
            this.textSource1Size.Text = "8";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 196);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "Размер";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Тип источника";
            // 
            // comboSource1
            // 
            this.comboSource1.FormattingEnabled = true;
            this.comboSource1.Items.AddRange(new object[] {
            "Точечный",
            "Неточечный разбиением",
            "Неточечный ближайший"});
            this.comboSource1.Location = new System.Drawing.Point(116, 35);
            this.comboSource1.Name = "comboSource1";
            this.comboSource1.Size = new System.Drawing.Size(158, 21);
            this.comboSource1.TabIndex = 14;
            this.comboSource1.TabStop = false;
            this.comboSource1.Text = "Точечный";
            // 
            // textSource1Z
            // 
            this.textSource1Z.Location = new System.Drawing.Point(62, 140);
            this.textSource1Z.Name = "textSource1Z";
            this.textSource1Z.Size = new System.Drawing.Size(58, 20);
            this.textSource1Z.TabIndex = 13;
            this.textSource1Z.Text = "300";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Z";
            // 
            // textSource1Y
            // 
            this.textSource1Y.Location = new System.Drawing.Point(62, 114);
            this.textSource1Y.Name = "textSource1Y";
            this.textSource1Y.Size = new System.Drawing.Size(58, 20);
            this.textSource1Y.TabIndex = 11;
            this.textSource1Y.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Положение";
            // 
            // textSource1X
            // 
            this.textSource1X.Location = new System.Drawing.Point(62, 88);
            this.textSource1X.Name = "textSource1X";
            this.textSource1X.Size = new System.Drawing.Size(58, 20);
            this.textSource1X.TabIndex = 8;
            this.textSource1X.Text = "300";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "X";
            // 
            // tabSource2
            // 
            this.tabSource2.Controls.Add(this.textSource2Size);
            this.tabSource2.Controls.Add(this.label16);
            this.tabSource2.Controls.Add(this.checkSources);
            this.tabSource2.Controls.Add(this.label11);
            this.tabSource2.Controls.Add(this.comboSource2);
            this.tabSource2.Controls.Add(this.textSource2Z);
            this.tabSource2.Controls.Add(this.label12);
            this.tabSource2.Controls.Add(this.textSource2Y);
            this.tabSource2.Controls.Add(this.label13);
            this.tabSource2.Controls.Add(this.label14);
            this.tabSource2.Controls.Add(this.textSource2X);
            this.tabSource2.Controls.Add(this.label15);
            this.tabSource2.Location = new System.Drawing.Point(4, 22);
            this.tabSource2.Name = "tabSource2";
            this.tabSource2.Size = new System.Drawing.Size(297, 294);
            this.tabSource2.TabIndex = 2;
            this.tabSource2.Text = "Источник 2";
            this.tabSource2.UseVisualStyleBackColor = true;
            // 
            // textSource2Size
            // 
            this.textSource2Size.Location = new System.Drawing.Point(62, 208);
            this.textSource2Size.Name = "textSource2Size";
            this.textSource2Size.Size = new System.Drawing.Size(58, 20);
            this.textSource2Size.TabIndex = 27;
            this.textSource2Size.Text = "8";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 211);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Размер";
            // 
            // checkSources
            // 
            this.checkSources.AutoSize = true;
            this.checkSources.Location = new System.Drawing.Point(33, 7);
            this.checkSources.Name = "checkSources";
            this.checkSources.Size = new System.Drawing.Size(121, 17);
            this.checkSources.TabIndex = 25;
            this.checkSources.Text = "Используются оба";
            this.checkSources.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Тип источника";
            // 
            // comboSource2
            // 
            this.comboSource2.FormattingEnabled = true;
            this.comboSource2.Items.AddRange(new object[] {
            "Точечный",
            "Неточечный разбиением",
            "Неточечный ближайший"});
            this.comboSource2.Location = new System.Drawing.Point(112, 38);
            this.comboSource2.Name = "comboSource2";
            this.comboSource2.Size = new System.Drawing.Size(163, 21);
            this.comboSource2.TabIndex = 23;
            this.comboSource2.TabStop = false;
            this.comboSource2.Text = "Точечный";
            // 
            // textSource2Z
            // 
            this.textSource2Z.Location = new System.Drawing.Point(58, 143);
            this.textSource2Z.Name = "textSource2Z";
            this.textSource2Z.Size = new System.Drawing.Size(58, 20);
            this.textSource2Z.TabIndex = 22;
            this.textSource2Z.Text = "400";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Z";
            // 
            // textSource2Y
            // 
            this.textSource2Y.Location = new System.Drawing.Point(58, 117);
            this.textSource2Y.Name = "textSource2Y";
            this.textSource2Y.Size = new System.Drawing.Size(58, 20);
            this.textSource2Y.TabIndex = 20;
            this.textSource2Y.Text = "100";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Положение";
            // 
            // textSource2X
            // 
            this.textSource2X.Location = new System.Drawing.Point(58, 91);
            this.textSource2X.Name = "textSource2X";
            this.textSource2X.Size = new System.Drawing.Size(58, 20);
            this.textSource2X.TabIndex = 17;
            this.textSource2X.Text = "-100";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "X";
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(868, 445);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(109, 23);
            this.buttonShow.TabIndex = 6;
            this.buttonShow.Text = "Отобразить";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(790, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Шаг разбиения";
            // 
            // comboStep
            // 
            this.comboStep.FormattingEnabled = true;
            this.comboStep.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "24",
            "28",
            "32",
            "36",
            "40"});
            this.comboStep.Location = new System.Drawing.Point(880, 365);
            this.comboStep.Name = "comboStep";
            this.comboStep.Size = new System.Drawing.Size(46, 21);
            this.comboStep.TabIndex = 8;
            this.comboStep.Text = "16";
            // 
            // ShadowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 762);
            this.Controls.Add(this.comboStep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.picture);
            this.MainMenuStrip = this.menu;
            this.Name = "ShadowsForm";
            this.Text = "Неточечное освещение 1 или 2 источниками";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabCamera.ResumeLayout(false);
            this.tabCamera.PerformLayout();
            this.tabSource1.ResumeLayout(false);
            this.tabSource1.PerformLayout();
            this.tabSource2.ResumeLayout(false);
            this.tabSource2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem новаяСценаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьМодельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьМодельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цилиндрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конусToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кубToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem призмаToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCamera;
        private System.Windows.Forms.TextBox textCameraZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCameraY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCameraX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabSource1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboSource1;
        private System.Windows.Forms.TextBox textSource1Z;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textSource1Y;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textSource1X;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabSource2;
        private System.Windows.Forms.CheckBox checkSources;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboSource2;
        private System.Windows.Forms.TextBox textSource2Z;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textSource2Y;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textSource2X;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.TextBox textSource1Size;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textSource2Size;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboStep;
    }
}

