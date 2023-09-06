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
    public partial class Form3 : Form
    {
        private string whatTeamToAddThePlayer_;

        public Form3()
        {
            InitializeComponent();
        }

        private bool getRidOfPossibleErrors()
        {
            int CNP_LENGTH = 13;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ErrorProvider error = new ErrorProvider();
                error.SetError(textBox1, "Introduceti numele jucatorului!");
                return false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                ErrorProvider error = new ErrorProvider();
                error.SetError(textBox2, "Introduceti CNP-ul jucatorului!");
                return false;
            }
            if (textBox2.Text.Length != CNP_LENGTH)
            {
                ErrorProvider error = new ErrorProvider();
                error.SetError(textBox2, "CNP-ul trebuie sa aiba 13 caractere!");
                return false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                ErrorProvider error = new ErrorProvider();
                error.SetError(textBox3, "Introduceti postul jucatorului!");
                return false;
            }

            return true;
        }

        private void addPlayerToTeam()
        {
            string path = Application.StartupPath;
            string[] folders = Directory.EnumerateDirectories(path).ToArray();

            foreach (var folder in folders)
            {
                DirectoryInfo teamName = new DirectoryInfo(folder);
                if ((teamName.Name == whatTeamToAddThePlayer_) && (!File.Exists(teamName + "\\" + textBox2.Text + ".lpf")))
                {
                    using (StreamWriter streamWriter = new StreamWriter(teamName + "\\" + textBox2.Text + ".lpf", false))
                    {
                        streamWriter.WriteLine(textBox1.Text);
                        streamWriter.WriteLine(textBox3.Text);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getRidOfPossibleErrors())
            {
                addPlayerToTeam();
                DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public string whatTeamToAddThePlayer
        {
            set { whatTeamToAddThePlayer_ = value; }
        }
    }
}