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
        private void Form1_Load(object sender, EventArgs e)
        {
            IwadTextBox.Text = Properties.Settings.Default.IWadSet;
            DoomExeTextBox.Text = Properties.Settings.Default.DoomSet;

            textBox5.Text = Properties.Settings.Default.ConfigPoolFolder;
            textBox4.Text = Properties.Settings.Default.ConfigFileSet;

            radioButton1.Checked = Properties.Settings.Default.ConfigFile;
            radioButton2.Checked = Properties.Settings.Default.ConfigPool;

            comboBox1.SelectedIndex = Properties.Settings.Default.LengthSet;

            checkBox2.Checked = Properties.Settings.Default.ObligeEnabled;

            foreach (object item in Properties.Settings.Default.AlwaysWadSet)
            {

                listBox1.Items.Add(item);

            }

            foreach (object item in Properties.Settings.Default.ObligeSet)
            {

                listBox3.Items.Add(item);

            }

            foreach (object item in Properties.Settings.Default.MusicWadSet)
            {

                listBox4.Items.Add(item);

            }

            if (!Directory.Exists("Campaigns"))
            {
                System.IO.Directory.CreateDirectory("Campaigns");
            }

            DeclareVars frm1 = new DeclareVars();
            int CampC = 0;
            if (File.Exists(frm1.cPath))
            {
                var CampCount = File.ReadAllText(frm1.cPath);
                CampC = Int32.Parse(CampCount);
                label8.Text = "Campaign Count: " + CampC.ToString();
            }

            else
            {

                System.IO.StreamWriter SaveFile1 = new System.IO.StreamWriter(frm1.cPath);
                SaveFile1.WriteLine("0");
                SaveFile1.Close();

            }

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

            ///This needs to generate a vbscript file to randomly choose things each time the user runs it.
            string CurrentDir = Directory.GetCurrentDirectory();
            string text =
            "my name is " + "\n" + "dan";

            string scriptgen = "IwadStr = \"" + IwadTextBox.Text + "\"\n";
            scriptgen += "DoomStr = \"" + DoomExeTextBox.Text + "\"\n";
            scriptgen += "Dim FSO \n" + "Set FSO = CreateObject(\"Scripting.FileSystemObject\")\n";
            scriptgen += "CurrentDirectory = FSO.GetAbsolutePathName(\".\")\n";
            scriptgen += "GenBat = FSO.BuildPath(CurrentDirectory, \"\\GenerateLevels.bat\")\n";
            scriptgen += "outFile=GenBat\n";
            scriptgen += "Set objFile = FSO.CreateTextFile(outFile,True)\n";
            scriptgen += "objFile.Write \"\"\"" + DoomExeTextBox.Text + "\"\"\"\n";
            scriptgen += "objFile.Close\n";
            scriptgen += "Set shell = CreateObject(\"WScript.Shell\")\n";
            scriptgen += "shell.Run \"GenerateLevels.bat\"";
            File.WriteAllTextAsync(CurrentDir + @"\Level Gen\" + "GenShortcut.vbs", scriptgen);
            System.Diagnostics.Process.Start(@"cscript" + CurrentDir + @"\Level Gen\" + "GenShortcut.vbs");
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
                IwadTextBox.Text = frm1.IwadString;
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
                DoomExeTextBox.Text = frm1.DoomString;
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
            string wads = "\"" + IwadTextBox.Text + "\" ";
            string DoomEXE = "\"" + DoomExeTextBox.Text + "\"";
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

            //Campaign Count
            //string cPath = "CampaignCount.txt";
            //System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(cPath);
            //SaveFile.WriteLine("0");
            //SaveFile.Close();
            DeclareVars frm1 = new DeclareVars();

            int CampC = 0;
            if (File.Exists(frm1.cPath))
            {
                var CampCount = File.ReadAllText(frm1.cPath);
                CampC = Int32.Parse(CampCount);
                //label8.Text = "Campaign Count: " + CampC.ToString();
            }

            else
            {

                System.IO.StreamWriter SaveFile1 = new System.IO.StreamWriter(frm1.cPath);
                SaveFile1.WriteLine("0");
                SaveFile1.Close();

            }

            CampC += 1;
            System.IO.StreamWriter SaveFile2 = new System.IO.StreamWriter(frm1.cPath);
            SaveFile2.WriteLine(CampC.ToString());
            SaveFile2.Close();

            string campFolder = "Campaigns\\Campaign " + CampC.ToString();
            System.IO.Directory.CreateDirectory(campFolder);

            string ObLength = "";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ObLength = "length=single";
                    break;
                case 1:
                    ObLength = "length=few";
                    break;
                case 2:
                    ObLength = "length=episode";
                    break;
                case 3:
                    ObLength = "length=game";
                    break;

            }

            string ObConfigPath = "";

            if (radioButton1.Checked == true)
            {
                ObConfigPath = "--load \"" + textBox4.Text + "\"";
            }

            if (radioButton2.Checked == true) {
                var rand = new Random();
                var files = Directory.GetFiles(textBox5.Text, "*.txt");
                ObConfigPath = "--load \"" + Path.GetFullPath(files[rand.Next(files.Length)]) + "\"";
            }

            //Generate save folder, continue shortcut, launch game
            string CurrentDir = Directory.GetCurrentDirectory();
            string ObString = "";
            string CampPath = "";

            if (listBox3.Items.Count > 0)
            {
                ObString += "\"";
                var random = new Random();
                int ObExe = random.Next(0, listBox3.Items.Count);
                ObString += listBox3.Items[ObExe].ToString();
                //MessageBox.Show(listBox3.Items[ObExe].ToString());
                ObString += "\" --batch \"" + campFolder + "\\Campaign " + CampC.ToString() + ".wad\" " + ObConfigPath + " " + ObLength + "\n";
            }



            ////////////////////////////////////////////Music/////////////////////////////
            string MusicString = "";
            if (listBox4.Items.Count > 0)
            {
                MusicString += "\"";
                var random = new Random();
                if (checkBox3.Checked == true)
                {
                    int ObExe = random.Next(0, listBox4.Items.Count + 1);
                    if (ObExe == listBox4.Items.Count + 1)
                    {
                        MusicString = "";
                    }
                    else
                    {
                        MusicString += listBox4.Items[ObExe].ToString() + "\" ";
                    }
                }
                else
                {
                    int ObExe = random.Next(0, listBox3.Items.Count);
                    MusicString += listBox4.Items[ObExe].ToString() + "\" ";
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////

            CampPath = Path.GetFullPath(campFolder + "\\Campaign " + CampC.ToString() + ".wad");

            if (checkBox2.Checked == false)
            {
                ObString = "";
                CampPath = "";
            }

            ////Save Folder///////////////////////////////////////
            ///
            string savePath = "";
            if (radioButton5.Checked == true) { 
            savePath = "+set save_path " + "\"" + campFolder + "\"" + " +save_dir " + "\"" + campFolder + "\"";
            }

            //string text =
            // "my name is " + "\n" + "dan";
            string iwadstr = " -iwad \"" + IwadTextBox.Text + "\"";
            string wads = "\"" + CampPath + "\" ";
            string DoomEXE = "\"" + DoomExeTextBox.Text + "\"";
            string allItems = string.Join("\" \"", listBox1.Items.OfType<object>());
            wads += "\"" + allItems + "\"";
            string writeString = ObString + DoomEXE + iwadstr + " -file " + wads + " " + MusicString + " " + savePath;
            File.WriteAllTextAsync(CurrentDir + @"\Level Gen\" + "DoomGen.bat", writeString);
            System.Diagnostics.Process.Start(CurrentDir + @"\Level Gen\" + "DoomGen.bat");

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(frm1.cPath);
            SaveFile.WriteLine(CampC.ToString());
            SaveFile.Close();

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
                    //textBox1.Text = frm1.MusicString;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = choofdlog.FileName;
                //textBox4.Text = sFileName;   
            }
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
                IwadTextBox.Text=s[i];
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
                DoomExeTextBox.Text = s[i];
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

        private void button13_Click(object sender, EventArgs e)
        {

            for (int x = listBox3.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = listBox3.SelectedIndices[x];
                //listBox2.Items.Add(listBox1.Items[idx]);
                listBox3.Items.RemoveAt(idx);
            }
        }

        private void textBox5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox5_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                textBox5.Text = s[i];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    textBox5.Text = fbd.SelectedPath;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IWadSet = IwadTextBox.Text;
            Properties.Settings.Default.DoomSet = DoomExeTextBox.Text;
            Properties.Settings.Default.LengthSet = comboBox1.SelectedIndex;

            Properties.Settings.Default.ConfigPool = radioButton2.Checked;
            Properties.Settings.Default.ConfigPoolFolder = textBox5.Text;
            Properties.Settings.Default.ConfigFileSet = textBox4.Text;
            Properties.Settings.Default.ConfigFile = radioButton1.Checked;

            Properties.Settings.Default.ObligeEnabled = checkBox2.Checked;

            //Properties.Settings.Default.Save();

            Properties.Settings.Default.AlwaysWadSet.Clear();

            foreach (object item in listBox1.Items)

            {
                Properties.Settings.Default.AlwaysWadSet.Add(Convert.ToString(item));
            }

            Properties.Settings.Default.ObligeSet.Clear();

            foreach (object item in listBox3.Items)

            {
                Properties.Settings.Default.ObligeSet.Add(Convert.ToString(item));
            }

            Properties.Settings.Default.MusicWadSet.Clear();

            foreach (object item in listBox4.Items)

            {
                Properties.Settings.Default.MusicWadSet.Add(Convert.ToString(item));
            }

            Properties.Settings.Default.Save();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
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
                    listBox4.Items.Add(arrAllFiles[i]);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (int x = listBox4.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = listBox4.SelectedIndices[x];
                //listBox2.Items.Add(listBox1.Items[idx]);
                listBox4.Items.RemoveAt(idx);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string allMusic = string.Join("\" \"", listBox4.Items.OfType<object>());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1) {
                MessageBox.Show("Please select an Oblige/Obsidian/Slige version");
            }
            else { 
            System.Diagnostics.Process.Start(listBox3.SelectedItem.ToString());
            }
        }

        private void listBox4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox4_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBox4.Items.Add((s[i]));
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            DeclareVars frm1 = new DeclareVars();
            System.IO.StreamWriter SaveFile1 = new System.IO.StreamWriter(frm1.cPath);
            SaveFile1.WriteLine("0");
            SaveFile1.Close();
            label8.Text = "Campaign Count: 0";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                if (tabControl1.TabPages.Contains(tabPage4))
                { tabControl1.TabPages.Remove(tabPage4); }
            }
            else
            {
                if (tabControl1.TabPages.Contains(tabPage4)) {
                    
                }
                else { tabControl1.TabPages.Insert(1, tabPage4); }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string line;
            Stream myStream = null;

            // Read the file and display it line by line.  
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = f.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            System.IO.StreamReader file =
                            new System.IO.StreamReader(myStream);
                            while ((line = file.ReadLine()) != null)
                            {
                                //MessageBox.Show(line);
                                var result = line.Substring(line.IndexOf('=')+1);
                                MessageBox.Show(result);
                                //System.Console.WriteLine(line);

                            }
                            file.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            
        }
    }
}