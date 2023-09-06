using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MTP_lab3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ErrorProvider error = new ErrorProvider();
                error.SetError(textBox1, "Introduceti numele echipei!");
            }
            else
            {
                Directory.CreateDirectory(textBox1.Text);
                DialogResult = DialogResult.OK;
            }
        }
    }
}