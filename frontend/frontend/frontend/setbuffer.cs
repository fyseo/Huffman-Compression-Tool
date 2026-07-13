using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class setbuffer : Form
    {
        public string buffer { get; set; }
        public setbuffer()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int test = int.Parse(textBox1.Text);
                buffer = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch
            {
                MessageBox.Show("Invalid buffer value!");
            }
        }
    }
}
