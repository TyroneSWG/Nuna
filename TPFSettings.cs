using System;
using System.Windows.Forms;

namespace Nuna
{
    public partial class TPFSettings : Form
    {
        public TPFSettings()
        {
            InitializeComponent();
            INIFile inif = new INIFile(Application.StartupPath + "/data/nuna.ini");
            textBox1.Text = inif.Read("TemplateGenerator", "author");
            textBox2.Text = inif.Read("Git", "credential_username");
            textBox3.Text = inif.Read("Git", "credential_email");
            textBox4.Text = inif.Read("Git", "remote-fetch-payload");
            textBox5.Text = inif.Read("Git", "remote-push-payload");

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INIFile inif = new INIFile(Application.StartupPath + "/data/nuna.ini");
            inif.Write("TemplateGenerator", "author", textBox1.Text);
            inif.Write("Git", "credential_username", textBox2.Text);
            inif.Write("Git", "credential_email", textBox3.Text);
            inif.Write("Git", "remote-fetch-payload", textBox4.Text);
            inif.Write("Git", "remote-push-payload", textBox5.Text);
            inif.Write("Git", "Branch", comboBox1.SelectedItem.ToString());
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Make sure you have your proper Github/Bitbucket username or it will error out!");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TPFSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
