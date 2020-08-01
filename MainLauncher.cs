using System;
using System.Diagnostics;
using System.Windows;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Nuna
{
    public partial class MainLauncher : Form
    {
        public MainLauncher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tmpgnr = new TemplateGenerator();
            tmpgnr.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "/data/filegen"))
            {
                Directory.CreateDirectory("/data/filegen");
                updateConsole("[FileGen] Folder created.");
            }
            INIFile inif = new INIFile(Application.StartupPath + "/data/nuna.ini");
            inif.Write("Nuna", "launchPath", Application.StartupPath);
            inif.Write("Nuna", "win32Dir", "c:/swg/exe/win32/");
            inif.Write("Nuna", "developer", Environment.UserName);
            string WIN32 = "C:/swg/exe/win32/";
            updateConsole("[Nuna] Updated ini file.");
            if (!Application.StartupPath.Equals(WIN32))
            {
                updateConsole("[Warning] Application must be started from " + WIN32 + ", please change the applications folder.");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("You are launching the live version of SwgClient. Select 'Yes' to continue. Otherwise select 'No' to launch the development client with debugging or 'Cancel' to abort.", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (confirmResult == DialogResult.Yes)
            {
                startTool("SwgClient_r.exe");
                updateConsole("[Game] Release client started.");
            }
            else if (confirmResult == DialogResult.No)
            {
                startTool("/data/Dbgview/Dbgview.exe");
                startTool("SwgClient_o.exe");
                updateConsole("[Game] Optimized/Internal client started with debug viewer.");
            }
            else
            {
                MessageBox.Show("Aborted.");
                updateConsole("[Game] Aborted Launch");
            }

        }
        private bool startTool(string toolEXEName)
        {
            if (File.Exists(toolEXEName))
            {
                System.Diagnostics.Process.Start(toolEXEName);
                return true;
            }
            else
            {
                updateConsole("Cannot find " + toolEXEName + "!");
                return false;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (startTool("QuestEditor.exe"))
            {
                updateConsole("Quest Editor started.");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (startTool("TerrainEditor.exe"))
            {
                updateConsole("Terrain Editor started.");
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (startTool("NpcEditor.exe"))
            {
                updateConsole("NPC Editor started.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        { 
            if (comboBox1.SelectedText == null)
            {
                updateConsole("[FileGen] File listing failed. Select an option and try again.");
                return;
            }
            if (comboBox1.SelectedItem.Equals(".msh"))
            {
                deleteOldAssetList("msh");
                string[] MESH_FILEPATHS = Directory.GetFiles(@"C:\swg\data\sku.0\sys.client\compiled\game\appearance\mesh", "*.msh");
                if (MESH_FILEPATHS.Length > 500)
                {
                    updateConsole("[FileGen] More than 500 entries discovered. Might want to refine your search.");
                }
                using (StreamWriter outputFile = new StreamWriter(Application.StartupPath + "/data/filegen/msh.txt"))
                {
                    foreach (string line in MESH_FILEPATHS)
                    {
                        outputFile.WriteLine(line);
                        line.Replace(@"C:\swg\data\sku.0\sys.client\compiled\game\", "");
                        line.Replace(@"\", @"/");
                    }
                }
                updateConsole("[FileGen] Mesh file list generated.");
            }
            if (comboBox1.SelectedItem.Equals(".mgn"))
            {
                deleteOldAssetList("mgn");
                File.Delete(Application.StartupPath + "/data/filegen/mgn.txt");
                string[] MGN_FILEPATHS = Directory.GetFiles(@"C:\swg\data\sku.0\sys.client\compiled\game\appearance\mesh", "*.mgn");
                if (MGN_FILEPATHS.Length > 500)
                {
                    MessageBox.Show("More than 500 entries discovered. Might want to refine your search.");
                }
                using (StreamWriter outputFile = new StreamWriter(Application.StartupPath + "/data/filegen/mgn.txt"))
                {
                    foreach (string line in MGN_FILEPATHS)
                    {
                        outputFile.WriteLine(line);
                        line.Replace(@"C:\swg\data\sku.0\sys.client\compiled\game\", "");
                        line.Replace(@"\", @"/");
                    }
                }
                updateConsole("[FileGen] Mesh Generator file list generated.");
            }
            if (comboBox1.SelectedItem.Equals(".lod"))
            {
                deleteOldAssetList("lod");
                string[] LOD_FILEPATHS = Directory.GetFiles(@"C:\swg\data\sku.0\sys.client\compiled\game\appearance\lod", "*.lod");
                using (StreamWriter outputFile = new StreamWriter(Application.StartupPath + "/data/filegen/lod.txt"))
                {
                    foreach (string line in LOD_FILEPATHS)
                    {
                        outputFile.WriteLine(line);   
                        line.Replace(@"C:\swg\data\sku.0\sys.client\compiled\game\", "");
                        line.Replace(@"\", "@/");
                    }
                }
                updateConsole("[FileGen] Level of Detail file list generated.");
            }
            if (comboBox1.SelectedItem.Equals(".apt"))
            {
                deleteOldAssetList("apt");
                File.Delete(Application.StartupPath + "/data/filegen/apt.txt");
                string[] APT_FILEPATHS = Directory.GetFiles(@"C:\swg\data\sku.0\sys.client\compiled\game\appearance\", "*.apt");
                using (StreamWriter outputFile = new StreamWriter(Application.StartupPath + "/data/filegen/apt.txt"))
                {
                    foreach (string line in APT_FILEPATHS)
                    {

                        string apts = line.Substring(line.LastIndexOf("appearance"));
                        outputFile.WriteLine(apts);
                        line.Replace(@"C:\swg\data\sku.0\sys.client\compiled\game\", "");
                        line.Replace(@"\", @"/");
                    }
                }
                updateConsole("[FileGen] Appearance Template Redirector file list generated.");
            }
            if (comboBox1.SelectedItem.Equals(".sat"))
            {
                deleteOldAssetList("sat");
                File.Delete(Application.StartupPath + "/data/filegen/sat.txt");
                string[] SAT_FILEPATHS = Directory.GetFiles(@"C:\swg\data\sku.0\sys.client\compiled\game\appearance\", "*.sat");
                using (StreamWriter outputFile = new StreamWriter(Application.StartupPath + "/data/filegen/sat.txt"))
                {
                    foreach (string line in SAT_FILEPATHS)
                    {
                        outputFile.WriteLine(line);
                        line.Replace(@"C:\swg\data\sku.0\sys.client\compiled\game\", "");
                        line.Replace(@"\", @"/");
                    }
                }
                updateConsole("[FileGen] Skeletal file list generated.");

            }
        }
        private void deleteOldAssetList(string type)
        {
            if (File.Exists(Application.StartupPath + "/data/filegen/apt.txt") && type.Equals("apt"))
            {
                File.Delete(Application.StartupPath + "/data/filegen/apt.txt");
                updateConsole("[FileGen] APT File list nuked.");
            }
            if (File.Exists(Application.StartupPath + "/data/filegen/sat.txt") && type.Equals("sat"))
            {
                File.Delete(Application.StartupPath + "/data/filegen/sat.txt");
                updateConsole("[FileGen] SAT File list nuked.");
            }
            if (File.Exists(Application.StartupPath + "/data/filegen/lod.txt") && type.Equals("lod"))
            {
                File.Delete(Application.StartupPath + "/data/filegen/lod.txt");
                updateConsole("[FileGen] LOD File list nuked.");
            }
            if (File.Exists(Application.StartupPath + "/data/filegen/mgn.txt") && type.Equals("mgn"))
            {
                File.Delete(Application.StartupPath + "/data/filegen/mgn.txt");
                updateConsole("[FileGen] MGN File list nuked.");
            }
            if (File.Exists(Application.StartupPath + "/data/filegen/msh.txt") && type.Equals("msh"))
            {
                File.Delete(Application.StartupPath + "/data/filegen/msh.txt");
                updateConsole("[FileGen] MSH File list nuked.");
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void updateConsole(string msg)
        {
            if (msg == null)
            {
                return;
            }
            RichTextBox itm = new RichTextBox();
            itm.Text = msg;
            string joinedKey = string.Join(Environment.NewLine, richTextBox1.Lines.Distinct());
            richTextBox1.Text = "";
            this.richTextBox1.AppendText(joinedKey + "\n" + msg);
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            var git = new Git();
            git.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
