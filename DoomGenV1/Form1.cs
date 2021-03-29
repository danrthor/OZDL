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
//using IWshRuntimeLibrary;
using shrtcut = IWshRuntimeLibrary;



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

            checkBox6.Checked = Properties.Settings.Default.MakeShrtCt;

            radioButton1.Checked = Properties.Settings.Default.ConfigFile;
            radioButton2.Checked = Properties.Settings.Default.ConfigPool;

            comboBox1.SelectedIndex = Properties.Settings.Default.LengthSet;

            checkBox2.Checked = Properties.Settings.Default.ObligeEnabled;

            cmdAdd.Text = Properties.Settings.Default.AdditionalCmds;

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
            if (checkBox2.Checked == false)
            {
                if (tabControl1.TabPages.Contains(tabPage4))
                { tabControl1.TabPages.Remove(tabPage4); }
            }
            else
            {
                if (tabControl1.TabPages.Contains(tabPage4))
                {

                }
                else { tabControl1.TabPages.Insert(1, tabPage4); }
            }
            if (IwadTextBox.Text != "")
            {
                long length = new System.IO.FileInfo(IwadTextBox.Text).Length;
                if (length > 14000000)
                {
                   // MessageBox.Show("Iwad Size: " + length.ToString());
                }
            }
        }

        public void CreateShortcut(String LnkName, String Target)
        {
            object shDesktop = (object)"Desktop";
            shrtcut.WshShell shell = new shrtcut.WshShell();
            //string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\"+LnkName;
            string shortcutAddress = LnkName;
            shrtcut.IWshShortcut shortcut = (shrtcut.IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "New shortcut for a Notepad";
            shortcut.Hotkey = "Ctrl+Shift+N";
            //shortcut.TargetPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\notepad.exe";
            shortcut.TargetPath = Target;
            shortcut.IconLocation = "C:\\Users\\Dan\\Desktop\\Doom Project\\Data\\Script Settings\\DoomGenIcon2.ico";
            shortcut.WorkingDirectory = Path.GetDirectoryName(Target);
            shortcut.Save();
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

            //CreateShortcut("GenerateDoom");
            //Generate Shortcut for generator -> launch game
            //
            DeclareVars frm1 = new DeclareVars();

            

           //Create New Program/Script Directory/
            string CurrentDir = Directory.GetCurrentDirectory();
            int directoryCount = 0;
            if (Directory.Exists(CurrentDir + @"\Generators\"))
            {
                directoryCount = System.IO.Directory.GetDirectories(CurrentDir + @"\Generators\").Length;
            }
            else {
                Directory.CreateDirectory(CurrentDir + @"\Generators\");
                directoryCount = 0;
            }
            directoryCount += 1;

            /*
            int ScampCount = 0;
            string ScriptDir = Directory.CreateDirectory(CurrentDir + @"\Shortcuts\Shortcut" + directoryCount.ToString()).ToString();
            if (Directory.Exists(ScriptDir + @"\Campaigns\"))
            {
                ScampCount = System.IO.Directory.GetDirectories(ScriptDir + @"\Campaigns\").Length;
            }
            else
            {
                Directory.CreateDirectory(ScriptDir + @"\Campaigns\");
                ScampCount = 0;
            }
            ScampCount += 1;
            string ScampDir = Directory.CreateDirectory(ScriptDir + "\\Campaigns\\"+"Campaign " + ScampCount.ToString()).ToString();
            */

            string ScriptDir = Directory.CreateDirectory(CurrentDir + @"\Generators\Generator" + directoryCount.ToString()).ToString();
            if (Directory.Exists(ScriptDir + @"\Campaigns\"))
            {
                //ScampCount = System.IO.Directory.GetDirectories(ScriptDir + @"\Campaigns\").Length;
            }
            else
            {
                Directory.CreateDirectory(ScriptDir + @"\Campaigns\");
                //ScampCount = 0;
            }

            ///////////////////

            string text =
            "my name is " + "\n" + "dan";

            string scriptgen = "IwadStr = \"\"\"" + IwadTextBox.Text + "\"\"\" " + "\n";
            scriptgen += "DoomStr = \"" + DoomExeTextBox.Text + "\"\n";


            scriptgen += "randomize \n";
            
            if (listBox3.Items.Count > 0)
            {
                scriptgen += "Dim ObArr(" + (listBox3.Items.Count - 1) + ")\n";
                foreach (var listBoxItem in listBox3.Items)
                {
                    scriptgen += "ObArr(" + listBox3.Items.IndexOf(listBoxItem) + ") = \"" + listBoxItem + "\"\n";
                }
                scriptgen += "ObPick = Int(rnd*" + (listBox3.Items.Count) + ") \n";
                scriptgen += "Oblige = ObArr(ObPick) \n";
                //scriptgen += "msgBox Oblige \n";
                //string MoveLine = " \"@MOVE \"\"\" & Cstr(CampCount) & \".wad\"\" \" & \"\"\"\" & Cstr(CampDir+\"\\Campaign \"+Cstr(CampCount)) & \"\\\"\"\" & vbCrLf & ";
            }
            else
            {
                scriptgen += "ObPick = \"\"\n";
            }
            
            if (listBox4.Items.Count > 0)
            {
                scriptgen += "Dim MusArr(" + (listBox4.Items.Count - 1) + ")\n";
                foreach (var listBoxItem in listBox4.Items)
                {
                    scriptgen += "MusArr(" + listBox4.Items.IndexOf(listBoxItem) + ") = \"" + listBoxItem + "\"\n";
                }
                scriptgen += "MusPick = Int(rnd*" + listBox4.Items.Count + ") \n";
                scriptgen += "Music = MusArr(MusPick)\n";

            }
            else
            {
                scriptgen += "MusPick = \"\"\n";
            }
            
            if (listBox2.Items.Count > 0)
            {
                scriptgen += "AdArr(" + (listBox2.Items.Count - 1) + ")\n";
                foreach (var listBoxItem in listBox2.Items)
                {
                    scriptgen += "AdArr(" + listBox2.Items.IndexOf(listBoxItem) + ") = \"" + listBoxItem + "\"\n";
                }
                scriptgen += "AddPick = Int(rnd*" + listBox2.Items.Count + ") \n";
                scriptgen += "AddWad = AdArr(AddPick) \n";
            }
            else
            {
                scriptgen += "AddPick = \"\"\n";
            }

            scriptgen += "Wads = \"\"";
            foreach (var listBoxItem in listBox1.Items)
            {
                if (listBox1.Items.IndexOf(listBoxItem) < (listBox1.Items.Count - 1))
                {
                    scriptgen += "\"" + listBoxItem + "\"\"\" & \" \"";
                }
                else
                {
                    scriptgen += "\"" + listBoxItem + "\"\"\"";
                }
            }
            scriptgen += "\n";

            scriptgen += "Dim FSO \n" + "Set FSO = CreateObject(\"Scripting.FileSystemObject\")\n";
            scriptgen += "CurrentDirectory = FSO.GetAbsolutePathName(\".\")\n";

            if (radioButton1.Checked == true)
            {
                scriptgen += "ConfigPath = " + "\"" + textBox4.Text + "\"" + "\n"; 
            }

            if (radioButton5.Checked == true) //Build & Control Campaign Count
            {
                scriptgen += "CurrentDirectory = FSO.GetAbsolutePathName(\".\")\n";
                scriptgen += "CampCountFile = FSO.BuildPath(CurrentDirectory, \"\\CampaignCount.txt\")\n";
                scriptgen += "CampCount = 1 \n";
                scriptgen += "If FSO.FileExists(CampCountFile) Then \n";
                scriptgen += " Set objFileToRead = CreateObject(\"Scripting.FileSystemObject\").OpenTextFile(CampCountFile,1)\n";
                scriptgen += "Dim strLine \n";
                scriptgen += "do while not objFileToRead.AtEndOfStream \n";
                scriptgen += "strLine = objFileToRead.ReadLine() \n";
                scriptgen += "CampCount = strLine \n";
                scriptgen += "loop \n";
                scriptgen += "OldCampCount = CampCount \n";
                scriptgen += "CampCount = CampCount + 1 \n";
                scriptgen += "outFile3= CampCountFile \n";
                scriptgen += "Set objFile = FSO.CreateTextFile(outFile3,True) \n";
                scriptgen += "objFile.Write Cstr(CampCount) \n";
                scriptgen += "objFile.Close \n";
                scriptgen += "objFileToRead.Close \n";
                scriptgen += "Set objFileToRead = Nothing \n";
                scriptgen += "Else \n";
                scriptgen += "outFile3= CampCountFile \n";
                scriptgen += "Set objFile = FSO.CreateTextFile(outFile3,True) \n";
                scriptgen += "objFile.Write \"1\" \n";
                scriptgen += "objFile.Close \n";
                scriptgen += "End If \n";
                scriptgen += "FSO.CreateFolder Cstr(\"Campaigns\"+\"\\Campaign \"+Cstr(CampCount)+\"\\\")\n";
            }

            //string scriptgen = "Set objShell = WScript.CreateObject(\"WScript.Shell\")\n";
            //scriptgen += "objShell.Run \"\"\"" + DoomExeTextBox.Text + "\"\" -iwad \"\"" + IwadTextBox.Text + "\"\"" + " -file brutalv21.pk3\", 1, True";

            if (radioButton2.Checked == true)
            {
                scriptgen += "intCount = 0 \n";
                scriptgen += "Function fCount(path, ftype1, ftype2)\n";
                scriptgen += "Set objFolder = FSO.GetFolder(path)\n";
                scriptgen += "Set colFiles = objFolder.Files\n";
                scriptgen += "dim FileList()\n";
                scriptgen += "ReDim Preserve FileList(0)\n";
                scriptgen += "For Each objFile in colFiles\n";
                scriptgen += "ReDim Preserve FileList(UBound(FileList) + 1)\n";
                scriptgen += "  If LCase(FSO.GetExtensionName(objFile.Name)) = ftype1 Or LCase(FSO.GetExtensionName(objFile.Name)) = ftype2 Then 'Count only ftype files\n";
                scriptgen += "  FileList(intCount) = objFile.Name \n";
                scriptgen += "intCount = intCount + 1\n";
                scriptgen += "End If\n Next \n randomize\n fCount=FileList(Int(rnd*intCount)) \n End Function \n";
                scriptgen += "ConfigPath = FSO.BuildPath(\""+textBox5.Text+"\",fCount(\"" + textBox5.Text + "\",\"txt\",\"cfg\"))" + "\n";

                
            }

            scriptgen += "obwad = FSO.BuildPath(CurrentDirectory,\"\\Campaigns\\Campaign \"" + " & Cstr(CampCount) & " + "\"\\Campaign\" & " + "Cstr(CampCount)" + "& \".wad\")\n";

            scriptgen += "save_path = FSO.BuildPath(CurrentDirectory,\"\\Campaigns\\Campaign \"" + " & Cstr(CampCount) \n";


            scriptgen += "GenBat = FSO.BuildPath(CurrentDirectory, \"\\GenerateLevels.bat\")\n";
            scriptgen += "outFile=GenBat\n";
            scriptgen += "Set objFile = FSO.CreateTextFile(outFile,True)\n";
            scriptgen += "objFile.Write " + "\"\"\"\" & Oblige & \"\"\"\" & " + "\" --batch Campaign" + "\" & CampCount & \"" + ".wad " + "\" & " + "\"-load "+ "\"\"\" & " + "ConfigPath" + " & \"\"\"\"" + " & " + "vbCrLf & ";
            scriptgen += " \"MOVE \"\"\" & \"Campaign\" & Cstr(CampCount) & \".wad\"\" \" & \"\"\"\" & Cstr(\"Campaigns\"+\"\\Campaign \"+Cstr(CampCount)) & \"\\\"\"\" & vbCrLf & ";

            

            scriptgen += "\"\"\"\"" + " & DoomStr & " + "\"\"\"\"" + " & \" -Iwad \" " + "& IwadStr & " + "\" -file \" & Wads" + " & \" \" & \"\"\"\" & Music & \"\"\"\" " + " & AddPick & " + " \" \" & \"\"\"\" & obwad & \"\"" + "\" +save_dir \" & " + "\"\"\"\"" + " & save_path & " + "\"\"\"\"" + "\n";
            scriptgen += "objFile.Close\n";
            scriptgen += "Set shell = CreateObject(\"WScript.Shell\")\n";
            scriptgen += "shell.Run \"GenerateLevels.bat\"";

            File.WriteAllTextAsync(ScriptDir + "\\GenShortcut.vbs", scriptgen);

            File.WriteAllTextAsync(CurrentDir + @"\Level Gen\" + "GenShortcut.vbs", scriptgen);
            File.WriteAllTextAsync(CurrentDir + @"\Level Gen\" + "WriteText.bat", text);
            //System.Diagnostics.Process.Start(@"C:\my folder\import.vbs");
            //System.Diagnostics.Process.Start(CurrentDir + @"\Level Gen\" + "GenShortcut.vbs");
            //System.Diagnostics.Process.Start(@"cscript GenShortcut.vbs");
            //System.Diagnostics.Process.Start(@"cscript" + CurrentDir + "\\Level Gen\\" + "GenShortcut.vbs");

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Shortcut files (*.lnk)|*.lnk";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(saveFileDialog1.FileName);
                CreateShortcut(saveFileDialog1.FileName, ScriptDir + "\\GenShortcut.vbs");
            }

            System.IO.Directory.CreateDirectory("Campaigns");
            MessageBox.Show("Shortcut saved.");

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
            else
            {
                CampC += 1;
            }

            ////Save Folder///////////////////////////////////////
            ///
            string savePath = "";
            string batSavePath = "";
            if (radioButton5.Checked == true) { 
            savePath = "+set save_path " + "\"" + campFolder + "\"" + " +save_dir " + "\"" + campFolder + "\"";
            batSavePath = "+set save_path " + "\"%~dp0\\\"" + " +save_dir " + "\"%~dp0\\";
            }

            //string text =
            // "my name is " + "\n" + "dan";
            
            string iwadstr = " -iwad \"" + IwadTextBox.Text + "\"";
            string wads = "\"" + CampPath + "\" ";
            string DoomEXE = "\"" + DoomExeTextBox.Text + "\"";
            string allItems = string.Join("\" \"", listBox1.Items.OfType<object>());
            wads += "\"" + allItems + "\"";
            string writeString = ObString + DoomEXE + iwadstr + " -file " + wads + " " + MusicString + " " + cmdAdd.Text + " " + savePath;
            string batString = DoomEXE + iwadstr + " -file " + wads + " " + MusicString + " " + batSavePath;
            if (checkBox6.Checked == true)
            {
                File.WriteAllTextAsync(campFolder + "\\Start.bat", batString);
            }
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

            SaveFile.WriteLine("Iwad=" + IwadTextBox.Text);
            SaveFile.WriteLine("DoomExe=" + DoomExeTextBox.Text);
            SaveFile.WriteLine("CloseAfterLaunch=" + checkBox1.Checked.ToString());
            SaveFile.WriteLine("EnableOblige=" + checkBox2.Checked.ToString());
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine("Wad="+item);
            }
            foreach (var item in listBox3.Items)
            {
                SaveFile.WriteLine("Oblige=" + item);
            }
            foreach (var item in listBox4.Items)
            {
                SaveFile.WriteLine("Music=" + item);
            }
            foreach (var item in listBox2.Items)
            {
                SaveFile.WriteLine("rWad=" + item);
            }

            SaveFile.WriteLine("VanillaMusic=" + checkBox3.Checked.ToString());
            SaveFile.WriteLine("NoWad=" + checkBox4.Checked.ToString());

            SaveFile.WriteLine("NewSave=" + radioButton5.Checked.ToString());

            SaveFile.WriteLine("WadLength=" + comboBox1.SelectedItem);

            SaveFile.WriteLine("UseConfigPool=" + radioButton2.Checked.ToString());
            SaveFile.WriteLine("ConfigFile=" + textBox4.Text);
            SaveFile.WriteLine("ConfigPool=" + textBox5.Text);

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

            Properties.Settings.Default.MakeShrtCt = checkBox6.Checked; 

            Properties.Settings.Default.AdditionalCmds = cmdAdd.Text;

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

                button1.Visible = false;
            }
            else
            {
                if (tabControl1.TabPages.Contains(tabPage4)) {
                    
                }
                else { tabControl1.TabPages.Insert(1, tabPage4); }

                button1.Visible = true;
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
                        listBox1.Items.Clear();
                        listBox3.Items.Clear();
                        IwadTextBox.Text = "";
                        DoomExeTextBox.Text = "";

                        using (myStream)
                        {
                            System.IO.StreamReader file =
                            new System.IO.StreamReader(myStream);
                            while ((line = file.ReadLine()) != null)
                            {
                                //MessageBox.Show(line);
                                //var result = line.Substring(line.IndexOf('=')+1);

                                //listbox1.Items.Clear();
                                if (line.Contains("Iwad="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    IwadTextBox.Text=result;
                                }
                                if (line.Contains("DoomExe="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    DoomExeTextBox.Text = result;
                                }
                                if (line.Contains("CloseAfterLaunch="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    checkBox1.Checked = Convert.ToBoolean(result);
                                }
                                if (line.Contains("EnableOblige="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    checkBox2.Checked = Convert.ToBoolean(result);
                                }
                                if (line.Contains("Wad=")) {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    listBox1.Items.Add(result);
                                }
                                if (line.Contains("Oblige="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    listBox3.Items.Add(result);
                                }
                                if (line.Contains("NewSave="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    radioButton5.Checked = Convert.ToBoolean(result);
                                    if (radioButton5.Checked) { radioButton4.Checked = false; } else { radioButton4.Checked = true; }
                                }
                                if (line.Contains("WadLength="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    comboBox1.SelectedItem = result;
                                }
                                if (line.Contains("UseConfigPool="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    radioButton2.Checked = Convert.ToBoolean(result);
                                    if (radioButton2.Checked) { radioButton1.Checked = false; } else { radioButton1.Checked = true; }
                                }
                                if (line.Contains("ConfigFile="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    textBox4.Text = result;
                                }
                                if (line.Contains("ConfigPool="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    textBox5.Text = result;
                                }
                                if (line.Contains("Music="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    listBox4.Items.Add(result);
                                }
                                if (line.Contains("rWad="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    listBox2.Items.Add(result);
                                }
                                if (line.Contains("VanillaMusice="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    checkBox3.Checked = Convert.ToBoolean(result);
                                }
                                if (line.Contains("NoWad="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    checkBox4.Checked = Convert.ToBoolean(result);
                                }
                                if (line.Contains("NoWad="))
                                {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    cmdAdd.Text = result;
                                }
                                if (line.Contains("MakeShortcut=")) {
                                    var result = line.Substring(line.IndexOf('=') + 1);
                                    checkBox6.Checked = Convert.ToBoolean(result);
                                }
                                
                                //MessageBox.Show(result);
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

        private void button26_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "ozdl files (*.ozdl)|*.ozdl";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(myStream);

                    SaveFile.WriteLine("Iwad=" + IwadTextBox.Text);
                    SaveFile.WriteLine("DoomExe=" + DoomExeTextBox.Text);
                    SaveFile.WriteLine("CloseAfterLaunch=" + checkBox1.Checked.ToString());
                    SaveFile.WriteLine("EnableOblige=" + checkBox2.Checked.ToString());
                    foreach (var item in listBox1.Items)
                    {
                        SaveFile.WriteLine("Wad=" + item);
                    }
                    foreach (var item in listBox3.Items)
                    {
                        SaveFile.WriteLine("Oblige=" + item);
                    }
                    foreach (var item in listBox4.Items)
                    {
                        SaveFile.WriteLine("Music=" + item);
                    }
                    foreach (var item in listBox2.Items)
                    {
                        SaveFile.WriteLine("rWad=" + item);
                    }

                    SaveFile.WriteLine("VanillaMusic=" + checkBox3.Checked.ToString());
                    SaveFile.WriteLine("NoWad=" + checkBox4.Checked.ToString());

                    SaveFile.WriteLine("NewSave=" + radioButton5.Checked.ToString());

                    SaveFile.WriteLine("WadLength=" + comboBox1.SelectedItem);

                    SaveFile.WriteLine("UseConfigPool=" + radioButton2.Checked.ToString());
                    SaveFile.WriteLine("ConfigFile=" + textBox4.Text);
                    SaveFile.WriteLine("ConfigPool=" + textBox5.Text);

                    SaveFile.WriteLine("AddCommands=" + cmdAdd.Text);

                    SaveFile.WriteLine("MakeShortcut=" + checkBox6.Checked.ToString());

                    SaveFile.Close();

                    MessageBox.Show("Settings saved.");

                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://www.doomworld.com/idgames/?random") { UseShellExecute = true });
            //https://www.doomworld.com/idgames/?random
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will delete all files in the \"Campaigns\" directory, proceed?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string path = @"Campaigns";

                DirectoryInfo directory = new DirectoryInfo(path);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}