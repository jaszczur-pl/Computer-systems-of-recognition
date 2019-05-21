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
            Dictionary<string, bool> characteristics = new Dictionary<string, bool>();

            characteristics["numberOfWords"] = checkBox1.Checked;
            characteristics["numberOfKeywords"] = checkBox2.Checked;
            characteristics["hasKeyword"] = checkBox3.Checked;
            characteristics["keywordPosition"] = checkBox4.Checked;
            characteristics["keywordFrequency"] = checkBox5.Checked;

            int neighbours = Convert.ToInt32(textNoOfNeighbours.Text);
            string sizeOfSet = comboBoxSetSize.Text;
            string metric = comboBoxMetric.Text;
            string label = comboBoxLabel.Text;

            double result = processing.MainProcess(sizeOfSet, neighbours, metric, label, characteristics);

            textWynik.Text = result.ToString();

        }
    }
}
