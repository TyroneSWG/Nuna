using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuna
{
    public partial class Git : Form
    {
        public string git_add_server_tpf = "git add c:/swg/dsrc/sku.0/sys.server/compiled/game/object/";
        public string git_add_shared_tpf = "git add c:/swg/dsrc/sku.0/sys.shared/compiled/game/object/";
        public string git_pull = "git pull";
        public string git_push = "git push origin/";
        public string git_commit_m = "git commit -m";
        public Git()
        {
            InitializeComponent();
            
        }
        
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("git.exe", git_pull);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INIFile inif = new INIFile(Application.StartupPath + "/data/nuna.ini");
            var dest = inif.Read("Git", "Branch");
            Process.Start("git.exe", git_push + dest);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("git.exe", git_add_server_tpf);
            Process.Start("git.exe", git_add_shared_tpf);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("git.exe", git_commit_m + "'[Templates]" + textBox1.Text + "'");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var git = new TPFSettings();
            git.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
