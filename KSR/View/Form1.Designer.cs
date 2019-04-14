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
            this.textKeyWord = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textStringOfWords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMetric = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textWynik = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textNoOfNeighbours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSetSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(131, 338);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Klasyfikuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textKeyWord
            // 
            this.textKeyWord.Location = new System.Drawing.Point(45, 46);
            this.textKeyWord.Name = "textKeyWord";
            this.textKeyWord.Size = new System.Drawing.Size(121, 20);
            this.textKeyWord.TabIndex = 1;
            this.textKeyWord.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "cos";
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Słowo kluczowe";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textStringOfWords
            // 
            this.textStringOfWords.Location = new System.Drawing.Point(45, 104);
            this.textStringOfWords.Name = "textStringOfWords";
            this.textStringOfWords.Size = new System.Drawing.Size(121, 20);
            this.textStringOfWords.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Podciąg wyrazów";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.comboBoxMetric.Location = new System.Drawing.Point(45, 158);
            this.comboBoxMetric.Name = "comboBoxMetric";
            this.comboBoxMetric.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMetric.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Metryka";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textWynik
            // 
            this.textWynik.Location = new System.Drawing.Point(218, 46);
            this.textWynik.Name = "textWynik";
            this.textWynik.ReadOnly = true;
            this.textWynik.Size = new System.Drawing.Size(100, 20);
            this.textWynik.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Wynik";
            // 
            // textNoOfNeighbours
            // 
            this.textNoOfNeighbours.Location = new System.Drawing.Point(45, 216);
            this.textNoOfNeighbours.Name = "textNoOfNeighbours";
            this.textNoOfNeighbours.Size = new System.Drawing.Size(121, 20);
            this.textNoOfNeighbours.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 200);
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
            this.comboBoxSetSize.Location = new System.Drawing.Point(45, 275);
            this.comboBoxSetSize.Name = "comboBoxSetSize";
            this.comboBoxSetSize.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSetSize.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Wielkość zestawu uczącego";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 411);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxSetSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textNoOfNeighbours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textWynik);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxMetric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textStringOfWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textKeyWord);
            this.Controls.Add(button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textKeyWord;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textStringOfWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMetric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textWynik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNoOfNeighbours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSetSize;
        private System.Windows.Forms.Label label6;
    }
}