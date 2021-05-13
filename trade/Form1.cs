using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditSuisse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = false;
            ofd.InitialDirectory = Application.ExecutablePath;
            ofd.Title = "Select file";
            ofd.Filter = "json files (*.json) | *.json";
            ofd.FilterIndex = 2;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
            else
            {
                MessageBox.Show("File selection error", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Trade trade  = new Trade();
            textBox2.Text = string.Join(",", trade.TradeCategories(trade.returnTradeList(textBox1.Text)));

        }
    }
}
