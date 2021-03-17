using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DoomGenV1
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                //listBox1.Items.Clear();
            }
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBox1.Items.Add((s[i]));
            //listBox1.Items.Add(Path.GetFileName(s[i]));
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            //Generate Shortcut for generator -> launch game
            //
            string CurrentDir = Directory.GetCurrentDirectory();
            string text =
            "my name is " + "\n" + "dan";
            File.WriteAllTextAsync(CurrentDir + @"\Level Gen\" + "WriteText.bat", text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                DeclareVars frm1 = new DeclareVars();
                frm1.IwadString = sFileName;
                textBox3.Text = frm1.IwadString;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //DeclareVars frm1 = new DeclareVars();
            //textBox3.Text = frm1.IwadString;
            //IwadString
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                DeclareVars frm1 = new DeclareVars();
                frm1.DoomString = sFileName;
                textBox2.Text = frm1.DoomString;
            }
            /*
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    DeclareVars frm1 = new DeclareVars();
                    frm1.DoomString = fbd.SelectedPath;
                    textBox2.Text = frm1.DoomString;
                }
            }
            */
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyoyo";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                //listBox1.Items.Add(sFileName);
                for (int i = 0; i < arrAllFiles.Length; i++)
                {
                    listBox1.Items.Add(arrAllFiles[i]);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = listBox1.SelectedIndices[x];
                //listBox2.Items.Add(listBox1.Items[idx]);
                listBox1.Items.RemoveAt(idx);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int x = listBox2.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = listBox2.SelectedIndices[x];
                //listBox2.Items.Add(listBox1.Items[idx]);
                listBox2.Items.RemoveAt(idx);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string wads = "\"" + textBox3.Text + "\" ";
            string DoomEXE = "\"" + textBox2.Text + "\"";
            string allItems = string.Join("\" \"", listBox1.Items.OfType<object>());
            wads += "\"" + allItems + "\"";
            MessageBox.Show(DoomEXE + " -file "+wads);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Generate save folder, continue shortcut, launch game
            string CurrentDir = Directory.GetCurrentDirectory();

            if (listBox3.Items.Count > 0)
            {
                var random = new Random();
                int ObExe = random.Next(0, listBox3.Items.Count);
                MessageBox.Show(listBox3.Items[ObExe].ToString());
            }
            //string text =
            // "my name is " + "\n" + "dan";
                string wads = "\"" + textBox3.Text + "\" ";
            string DoomEXE = "\"" + textBox2.Text + "\"";
            string allItems = string.Join("\" \"", listBox1.Items.OfType<object>());
            wads += "\"" + allItems + "\"";
            string writeString = DoomEXE + " -file " + wads;
            File.WriteAllTextAsync(CurrentDir + @"\Level Gen\" + "DoomGen.bat", writeString);
            System.Diagnostics.Process.Start(CurrentDir + @"\Level Gen\" + "DoomGen.bat");
            if (checkBox1.Checked == true)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    DeclareVars frm1 = new DeclareVars();
                    frm1.MusicString = fbd.SelectedPath;
                    textBox1.Text = frm1.MusicString;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Checking selected item
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBox1.SelectedIndex + -1;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox1.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBox1.SelectedItem;

            // Removing removable element
            listBox1.Items.Remove(selected);
            // Insert it in new position
            listBox1.Items.Insert(newIndex, selected);
            // Restore selection
            listBox1.SetSelected(newIndex, true);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Checking selected item
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBox1.SelectedIndex + 1;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox1.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBox1.SelectedItem;

            // Removing removable element
            listBox1.Items.Remove(selected);
            // Insert it in new position
            listBox1.Items.Insert(newIndex, selected);
            // Restore selection
            listBox1.SetSelected(newIndex, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                //listBox1.Items.Clear();
            }
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                textBox3.Text=s[i];
            //listBox1.Items.Add(Path.GetFileName(s[i]));
        }

        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                //listBox1.Items.Add(sFileName);
                for (int i = 0; i < arrAllFiles.Length; i++)
                {
                    listBox3.Items.Add(arrAllFiles[i]);
                }
            }
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                //listBox1.Items.Clear();
            }
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                textBox2.Text = s[i];
            //listBox1.Items.Add(Path.GetFileName(s[i]));
        }

        private void listBox3_DragDrop(object sender, DragEventArgs e)
        {
            if (listBox3.Items.Count != 0)
            {
                //listBox1.Items.Clear();
            }
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBox3.Items.Add((s[i]));
            //listBox1.Items.Add(Path.GetFileName(s[i]));
        }

        private void listBox3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            const string sPath = "save.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();

            MessageBox.Show("Programs saved!");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();

                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(f.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);

                    }
                }
            }
        }
    }
}