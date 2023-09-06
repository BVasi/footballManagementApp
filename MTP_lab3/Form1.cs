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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getDirectories()
        {
            string path = Application.StartupPath;
            string[] folders = Directory.EnumerateDirectories(path).ToArray();

            foreach (var folder in folders)
            {
                DirectoryInfo teamName = new DirectoryInfo(folder);
                comboBox1.Items.Add(teamName.Name);
            }
        }

        private void generateButton(Player player)
        {
            Button button = new Button();
            button.Text = player.getName;
            button.Width = 200;
            button.Click += button_Click;
            button.Tag = player;
            flowLayoutPanel1.Controls.Add(button);
        }

        private void getFiles()
        {
            string path = Application.StartupPath;
            string[] folders = Directory.EnumerateDirectories(path).ToArray();

            foreach (var folder in folders)
            {
                DirectoryInfo teamName = new DirectoryInfo(folder);
                if (teamName.Name == comboBox1.Text)
                {
                    string[] files = Directory.EnumerateFiles(folder).ToArray();
                    foreach (var file in files)
                    {
                        DirectoryInfo info = new DirectoryInfo(file);
                        string playerCnp = info.Name.Split('.')[0];
                        StreamReader reader = new StreamReader(file);
                        string playerName = reader.ReadLine();
                        string playerGamePosition = reader.ReadLine();
                        Player player = new Player(playerName, playerCnp, playerGamePosition);
                        generateButton(player);
                    }
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Player player = (Player)button.Tag;
            textBox1.Text = player.getName;
            textBox2.Text = player.getPlayerGamePosition;
            textBox3.Text = player.getCnp;
            dateTimePicker1.Value = player.getBirthDateFromCnp();
            textBox4.Text = player.getAge();
        }

        private void updateComboBox()
        {
            comboBox1.Items.Clear();
            getDirectories();
        }

        private void updateFlowLayoutPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            getFiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form4 loginForm = new Form4();
            if (loginForm.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
            }
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            getDirectories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 teamAddingForm = new Form2();
            if (teamAddingForm.ShowDialog() == DialogResult.OK)
            {
                teamAddingForm.Close();
                updateComboBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 playerAddingForm = new Form3();
            string whatTeam = comboBox1.Text;
            playerAddingForm.whatTeamToAddThePlayer = whatTeam;
            if (string.IsNullOrEmpty(whatTeam))
            {
                MessageBox.Show("Selectati o echipa pentru a adauga jucator!");
                return;
            }
            if (playerAddingForm.ShowDialog() == DialogResult.OK)
            {
                playerAddingForm.Close();
                updateFlowLayoutPanel();
            }
            else if (playerAddingForm.DialogResult == DialogResult.Cancel)
            {
                playerAddingForm.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFlowLayoutPanel();
        }
    }
}