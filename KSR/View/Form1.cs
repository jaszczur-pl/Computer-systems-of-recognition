using KSR.Metrics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSR.View
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Processing processing = new Processing();
            List<string> userkeyWords = new List<string>() { textKeyWord.Text };
            string stringOfWords = textStringOfWords.Text;
            int neighbours = Convert.ToInt32(textNoOfNeighbours.Text);
            string sizeOfSet = comboBoxSetSize.Text;
            string metric = comboBoxMetric.Text;
            string label = "PLACES";
            double result = processing.MainProcess(userkeyWords, stringOfWords, sizeOfSet, neighbours, metric, label);
            textWynik.Text = result.ToString();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e) {

        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
    }
}
