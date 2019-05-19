namespace KSR.View
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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button button1;
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxMetric = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textWynik = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textNoOfNeighbours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSetSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxLabel = new System.Windows.Forms.ComboBox();
            this.textLabelToClassify = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(45, 358);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Klasyfikuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxMetric
            // 
            this.comboBoxMetric.FormattingEnabled = true;
            this.comboBoxMetric.Items.AddRange(new object[] {
            "Euklidesowa",
            "Uliczna",
            "Czebyszewa",
            "MinMax",
            "MinMax2"});
            this.comboBoxMetric.Location = new System.Drawing.Point(255, 166);
            this.comboBoxMetric.Name = "comboBoxMetric";
            this.comboBoxMetric.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMetric.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Metryka";
            // 
            // textWynik
            // 
            this.textWynik.Location = new System.Drawing.Point(255, 360);
            this.textWynik.Name = "textWynik";
            this.textWynik.ReadOnly = true;
            this.textWynik.Size = new System.Drawing.Size(100, 20);
            this.textWynik.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Wynik";
            // 
            // textNoOfNeighbours
            // 
            this.textNoOfNeighbours.Location = new System.Drawing.Point(255, 224);
            this.textNoOfNeighbours.Name = "textNoOfNeighbours";
            this.textNoOfNeighbours.Size = new System.Drawing.Size(121, 20);
            this.textNoOfNeighbours.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Liczba sąsiadów";
            // 
            // comboBoxSetSize
            // 
            this.comboBoxSetSize.FormattingEnabled = true;
            this.comboBoxSetSize.Items.AddRange(new object[] {
            "20%",
            "40%",
            "60%",
            "80%"});
            this.comboBoxSetSize.Location = new System.Drawing.Point(255, 283);
            this.comboBoxSetSize.Name = "comboBoxSetSize";
            this.comboBoxSetSize.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSetSize.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Wielkość zestawu uczącego";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Etykieta\r\n";
            // 
            // comboBoxLabel
            // 
            this.comboBoxLabel.CausesValidation = false;
            this.comboBoxLabel.FormattingEnabled = true;
            this.comboBoxLabel.Items.AddRange(new object[] {
            "PLACES",
            "TOPICS",
            "PEOPLE",
            "ORGS",
            "EXCHANGES",
            "COMPANIES"});
            this.comboBoxLabel.Location = new System.Drawing.Point(255, 46);
            this.comboBoxLabel.Name = "comboBoxLabel";
            this.comboBoxLabel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLabel.TabIndex = 15;
            // 
            // textLabelToClassify
            // 
            this.textLabelToClassify.Location = new System.Drawing.Point(255, 104);
            this.textLabelToClassify.Name = "textLabelToClassify";
            this.textLabelToClassify.Size = new System.Drawing.Size(121, 20);
            this.textLabelToClassify.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Etykieta do klasyfikacji";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(45, 190);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(163, 17);
            this.checkBox3.TabIndex = 18;
            this.checkBox3.Text = "Czy posiada słowo kluczowe";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(45, 150);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(131, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Liczba słów w tekście";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(45, 170);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(190, 17);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "Liczba słów kluczowych w tekście";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(45, 213);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(203, 17);
            this.checkBox4.TabIndex = 22;
            this.checkBox4.Text = "Pozycja słowa kluczowego w tekście";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(45, 236);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(202, 40);
            this.checkBox5.TabIndex = 23;
            this.checkBox5.Text = "Częstotliwość występowania słowa kluczowego w tekście";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 411);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textLabelToClassify);
            this.Controls.Add(this.comboBoxLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxSetSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textNoOfNeighbours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textWynik);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxMetric);
            this.Controls.Add(button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBoxMetric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textWynik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNoOfNeighbours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSetSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxLabel;
        private System.Windows.Forms.TextBox textLabelToClassify;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
    }
}