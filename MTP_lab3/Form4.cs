using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTP_lab3
{
    public partial class Form4 : Form
    {
        private string username_ = "username";
        private string password_ = "parolasecreta123";

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ErrorProvider error = new ErrorProvider();
                error.SetError(textBox1, "Introduceti un nume de utilizator!");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                ErrorProvider error = new ErrorProvider();
                error.SetError(textBox2, "Introduceti o parola!");
                return;
            }

            if ((textBox1.Text == username_ ) && (textBox2.Text == password_))
            {
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Nume de utilizator sau parola gresite!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                DialogResult = DialogResult.OK;
                return;
            }
            progressBar1.Value += 1;
        }
    }
}