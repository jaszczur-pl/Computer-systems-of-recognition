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

            string keyword = textKeyWord.Text;
            string stringOfWords = textStringOfWords.Text;
            int neighbours = Convert.ToInt32(textNoOfNeighbours.Text);
            string sizeOfSet = comboBoxSetSize.Text;
            string metric = comboBoxMetric.Text;
            string label = comboBoxLabel.Text;
            string labelToClassify = textLabelToClassify.Text;

            double result = processing.MainProcess(keyword, stringOfWords, sizeOfSet, neighbours, metric, label, labelToClassify);

            textWynik.Text = result.ToString();
        }
    }
}
