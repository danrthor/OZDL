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

using Microsoft.Win32;
using System.Runtime.InteropServices;





namespace OZDL
{


    public partial class Form1 : Form
    {

        string arg1;
        public Form1(string[] args)
        {
            InitializeComponent();
            arg1 = "";
            if (args.Length > 0)
            {
                arg1 = args[0];
                //MessageBox.Show(arg1);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            if (tabControl1.TabPages.Contains(tabPage2))
            { tabControl1.TabPages.Remove(tabPage2); }

            IwadTextBox.Text = Properties.Settings.Default.IWadSet;
            DoomExeTextBox.Text = Properties.Settings.Default.DoomSet;

            //textBox5.Text = Properties.Settings.Default.ConfigPoolFolder;
            textBox4.Text = Properties.Settings.Default.ConfigFileSet;

            checkBox6.Checked = Properties.Settings.Default.MakeShrtCt;

            radioButton1.Checked = Properties.Settings.Default.ConfigFile;
            radioButton2.Checked = Properties.Settings.Default.ConfigPool;

            CloseAfterLaunching.Checked = Properties.Settings.Default.CloseAtLaunch;

            comboBox1.SelectedIndex = Properties.Settings.Default.LengthSet;

            checkBox2.Checked = Properties.Settings.Default.ObligeEnabled;

            foreach (object item in Properties.Settings.Default.AlwaysWadSet)
            {

                AlwaysWadBox.Items.Add(item);

            }

            foreach (object item in Properties.Settings.Default.ObligeSet)
            {

                listBox3.Items.Add(item);

            }

            foreach (object item in Properties.Settings.Default.MusicWadSet)
            {

                musicWadBox.Items.Add(item);

            }
            foreach (object item in Properties.Settings.Default.AdditionalWads)
            {

                additonalWadBox.Items.Add(item);

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

            //Tab 4 Extra/Multi

            cmdAdd.Text = Properties.Settings.Default.AdditionalCmds;

            EnableMultiBox.Checked = Properties.Settings.Default.EnableMulti;

            NetModeBox.SelectedIndex = Properties.Settings.Default.NetModeSet;
            DupBox.SelectedIndex = Properties.Settings.Default.DupSet;

            PortTextBox.Text = Properties.Settings.Default.PortSet;


            ///Arguments
            ///
            if (arg1.Contains(".wad") || arg1.Contains(".pk3") || arg1.Contains(".zip"))
            {
                AlwaysWadBox.Items.Add(arg1);
            }

            if (arg1.Contains(".ozdl"))
            {
                LoadSettings(arg1);
            }

        }

        public void CreateShortcut(String LnkName, String Target)
        {
            object shDesktop = (object)"Desktop";
            shrtcut.WshShell shell = new shrtcut.WshShell();
            //string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\"+LnkName;
            string shortcutAddress = LnkName;
            shrtcut.IWshShortcut shortcut = (shrtcut.IWshShortcut)shell.CreateShortcut(shortcutAddress);
            //shortcut.Description = "New shortcut for a Notepad";
            //shortcut.Hotkey = "Ctrl+Shift+N";
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
            if (AlwaysWadBox.Items.Count != 0)
            {
                //listBox1.Items.Clear();
            }
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                AlwaysWadBox.Items.Add((s[i]));
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
            else
            {
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

            if (musicWadBox.Items.Count > 0)
            {
                scriptgen += "Dim MusArr(" + (musicWadBox.Items.Count - 1) + ")\n";
                foreach (var listBoxItem in musicWadBox.Items)
                {
                    scriptgen += "MusArr(" + musicWadBox.Items.IndexOf(listBoxItem) + ") = \"" + listBoxItem + "\"\n";
                }
                scriptgen += "MusPick = Int(rnd*" + musicWadBox.Items.Count + ") \n";
                scriptgen += "Music = MusArr(MusPick)\n";

            }
            else
            {
                scriptgen += "MusPick = \"\"\n";
            }

            if (additonalWadBox.Items.Count > 0)
            {
                scriptgen += "AdArr(" + (additonalWadBox.Items.Count - 1) + ")\n";
                foreach (var listBoxItem in additonalWadBox.Items)
                {
                    scriptgen += "AdArr(" + additonalWadBox.Items.IndexOf(listBoxItem) + ") = \"" + listBoxItem + "\"\n";
                }
                scriptgen += "AddPick = Int(rnd*" + additonalWadBox.Items.Count + ") \n";
                scriptgen += "AddWad = AdArr(AddPick) \n";
            }
            else
            {
                scriptgen += "AddPick = \"\"\n";
            }

            scriptgen += "Wads = \"\"";
            foreach (var listBoxItem in AlwaysWadBox.Items)
            {
                if (AlwaysWadBox.Items.IndexOf(listBoxItem) < (AlwaysWadBox.Items.Count - 1))
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

            if (UseCampSave.Checked == true) //Build & Control Campaign Count
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
                scriptgen += "ConfigPath = FSO.BuildPath(\"" + textBox4.Text + "\",fCount(\"" + textBox4.Text + "\",\"txt\",\"cfg\"))" + "\n";


            }

            scriptgen += "obwad = FSO.BuildPath(CurrentDirectory,\"\\Campaigns\\Campaign \"" + " & Cstr(CampCount) & " + "\"\\Campaign\" & " + "Cstr(CampCount)" + "& \".wad\")\n";

            scriptgen += "save_path = FSO.BuildPath(CurrentDirectory,\"\\Campaigns\\Campaign \"" + " & Cstr(CampCount)) \n";


            scriptgen += "GenBat = FSO.BuildPath(CurrentDirectory, \"\\GenerateLevels.bat\")\n";
            scriptgen += "outFile=GenBat\n";
            scriptgen += "Set objFile = FSO.CreateTextFile(outFile,True)\n";
            scriptgen += "objFile.Write " + "\"\"\"\" & Oblige & \"\"\"\" & " + "\" --batch Campaign" + "\" & CampCount & \"" + ".wad " + "\" & " + "\"-load " + "\"\"\" & " + "ConfigPath" + " & \"\"\"\"" + " & " + "vbCrLf & ";
            scriptgen += " \"MOVE \"\"\" & \"Campaign\" & Cstr(CampCount) & \".wad\"\" \" & \"\"\"\" & Cstr(\"Campaigns\"+\"\\Campaign \"+Cstr(CampCount)) & \"\\\"\"\" & vbCrLf & ";

            scriptgen += "\"\"\"\"" + " & DoomStr & " + "\"\"\"\"" + " & \" -Iwad \" " + "& IwadStr & " + "\" -file \" & Wads" + " & \" \" & \"\"\"\" & Music & \"\"\"\" " + " & AddPick & " + " \" \" & \"\"\"\" & obwad & \"\"" + "\" +save_dir \" & " + "\"\"\"\"" + " & save_path & " + "\"\"\"\"" + "\n";
            scriptgen += "objFile.Close\n";


            scriptgen += "shrtct = \"Campaigns\\Campaign \"+Cstr(CampCount)+\"\\Start.bat\" \n";
            scriptgen += "Set shrtctF = FSO.CreateTextFile(shrtct,True)\n";
            scriptgen += "shrtctF.Write \"\"\"\"" + " & DoomStr & " + "\"\"\"\"" + " & \" -Iwad \" " + "& IwadStr & " + "\" -file \" & Wads" + " & \" \" & \"\"\"\" & Music & \"\"\"\" " + " & AddPick & " + " \" \" & \"\"\"\" & obwad & \"\"" + "\" +save_dir \" & " + "\"\"\"\"" + " & save_path & " + "\"\"\"\"" + "\n";



            if (checkBox6.Checked == true)
            {


                scriptgen += "Set objShell = WScript.CreateObject(\"WScript.Shell\")\n";
                scriptgen += "Set lnk = objShell.CreateShortcut(\"Campaigns\\Campaign \"+Cstr(CampCount)+\"\\Campaign \"+Cstr(CampCount)+\".lnk\") \n";
                scriptgen += "lnk.TargetPath = CurrentDirectory + \"\\Campaigns\\Campaign \"+Cstr(CampCount)+\"\\Start.bat\" \n";
                //scriptgen += "lnk.Arguments = \"-Iwad \" " + "& IwadStr & " + "\" -file \" & Wads" + " & \" \" & \"\"\"\" & Music & \"\"\"\" " + " & AddPick & " + " \" \" & \"\"\"\" & obwad & \"\"" + "\" +save_dir \" & " + "\"\"\"\"" + " & save_path & " + "\"\"\"\"" + "\n";
                scriptgen += "lnk.WorkingDirectory = \"" + Directory.GetParent(DoomExeTextBox.Text) + "\" \n";
                scriptgen += "lnk.IconLocation = \"C:\\Users\\Dan\\Desktop\\Doom Project\\Data\\Script Settings\\DoomGenIcon2.ico\" \n";
                scriptgen += "lnk.WindowStyle = \"1\" \n";
                scriptgen += "lnk.Save \n";
                scriptgen += "Set lnk = Nothing \n";
            }



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
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "pk3 or wad (*.pk3, *.wad, *.zip)|*.pk3;*.wad*;*.zip";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                //listBox1.Items.Add(sFileName);
                for (int i = 0; i < arrAllFiles.Length; i++)
                {
                    additonalWadBox.Items.Add(arrAllFiles[i]);
                }
            }
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
            choofdlog.Filter = ".wad Files (*.wad*)|*.wad*";
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
            string fi = IwadTextBox.Text;
            if (File.Exists(fi))
            {
                FileInfo size = new FileInfo(fi);
                var iwadsize = size.Length;
                //MessageBox.Show(size.Length.ToString());
                if (iwadsize == 14604584 || iwadsize == 18195736 || iwadsize == 17420824 || iwadsize == 14824716 || iwadsize == 149434000 || iwadsize == 14612688) //If Doom 2, TNT, or Plutonia
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(" ");
                    for (var i = 1; i < 10; i++)
                    {
                        comboBox2.Items.Add("MAP0" + i.ToString());
                    }
                    for (var i = 10; i < 33; i++)
                    {
                        comboBox2.Items.Add("Map" + i.ToString());
                    }
                }

                if (iwadsize == 28544132) //Freedoom Phase 2
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(" ");
                    for (var i = 1; i < 10; i++)
                    {
                        comboBox2.Items.Add("MAP0" + i.ToString());
                    }
                    for (var i = 10; i < 33; i++)
                    {
                        comboBox2.Items.Add("Map" + i.ToString());
                    }
                }

                if (iwadsize == 20083672 || iwadsize == 20128392) //Hexen 1.1 and 1.0
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(" ");
                    for (var i = 1; i < 10; i++)
                    {
                        comboBox2.Items.Add("MAP0" + i.ToString());
                    }
                    for (var i = 10; i < 41; i++)
                    {
                        comboBox2.Items.Add("Map" + i.ToString());
                    }
                }
                if (iwadsize == 12408292) //If Ultimate Doom
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(" ");
                    for (var i = 1; i < 5; i++) //Episodes 1-4
                    {
                        for (var m = 1; m < 10; m++) //Missions 1-9
                        {
                            comboBox2.Items.Add("E" + i.ToString() + "M" + m.ToString());
                        }
                    }
                }
                if (iwadsize == 11159840 || iwadsize == 10396254 || iwadsize == 10399316 || iwadsize == 10395882 || iwadsize == 11159840) //If Doom
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(" ");
                    for (var i = 1; i < 4; i++) //Episodes 1-3
                    {
                        for (var m = 1; m < 10; m++) //Missions 1-9
                        {
                            comboBox2.Items.Add("E" + i.ToString() + "M" + m.ToString());
                        }
                    }
                }
                if (iwadsize == 27284988) //Freedoom Phase 1
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(" ");
                    for (var i = 1; i < 4; i++) //Episodes 1-3
                    {
                        for (var m = 1; m < 10; m++) //Missions 1-9
                        {
                            comboBox2.Items.Add("E" + i.ToString() + "M" + m.ToString());
                        }
                    }
                }
                if (iwadsize == 11096488 || iwadsize == 11095516) //Heretic 1.0, 1.1
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(" ");
                    for (var i = 1; i < 4; i++) //Episodes 1-3
                    {
                        for (var m = 1; m < 10; m++) //Missions 1-9
                        {
                            comboBox2.Items.Add("E" + i.ToString() + "M" + m.ToString());
                        }
                    }
                    comboBox2.Items.Add("E4M1"); //Last mission
                }
                if (iwadsize == 14189976) //Heretic 1.3
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(" ");
                    for (var i = 1; i < 6; i++) //Episodes 1-5
                    {
                        for (var m = 1; m < 10; m++) //Missions 1-9
                        {
                            comboBox2.Items.Add("E" + i.ToString() + "M" + m.ToString());
                        }
                    }
                    comboBox2.Items.Add("E6M1"); //Last missions
                    comboBox2.Items.Add("E6M2"); //Last missions
                    comboBox2.Items.Add("E6M3"); //Last missions
                }
            }
            else
            {
                //MessageBox.Show(fi + " not a recognized IWAD file.");
            }
            //DeclareVars frm1 = new DeclareVars();
            //textBox3.Text = frm1.IwadString;
            //IwadString
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Exe Files (*.exe*)|*.exe*";
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
            choofdlog.Filter = "pk3 or wad (*.pk3, *.wad, *.zip)|*.pk3;*.wad*;*.zip";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                //listBox1.Items.Add(sFileName);
                for (int i = 0; i < arrAllFiles.Length; i++)
                {
                    AlwaysWadBox.Items.Add(arrAllFiles[i]);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            for (int x = AlwaysWadBox.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = AlwaysWadBox.SelectedIndices[x];
                //listBox2.Items.Add(listBox1.Items[idx]);
                AlwaysWadBox.Items.RemoveAt(idx);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int x = additonalWadBox.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = additonalWadBox.SelectedIndices[x];
                //listBox2.Items.Add(listBox1.Items[idx]);
                additonalWadBox.Items.RemoveAt(idx);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string wads = "\"" + IwadTextBox.Text + "\" ";
            string DoomEXE = "\"" + DoomExeTextBox.Text + "\"";
            string allItems = string.Join("\" \"", AlwaysWadBox.Items.OfType<object>());
            wads += "\"" + allItems + "\"";
            MessageBox.Show(DoomEXE + " -file " + wads);
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

            if (CustomCampCheckbox.Checked && CampFolderText.Text != "")
            {
                campFolder = CampFolderText.Text;
                System.IO.Directory.CreateDirectory(campFolder);
            }


            string ObLength = "";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ObLength = "";
                    break;
                case 1:
                    ObLength = "length=single";
                    break;
                case 2:
                    ObLength = "length=few";
                    break;
                case 3:
                    ObLength = "length=episode";
                    break;
                case 4:
                    ObLength = "length=game";
                    break;

            }



            string ObConfigPath = "";

            if (radioButton1.Checked == true)
            {
                ObConfigPath = "--load \"" + textBox4.Text + "\"";
            }

            if (radioButton2.Checked == true)
            {
                var rand = new Random();
                var files = Directory.GetFiles(textBox4.Text, "*.txt");
                ObConfigPath = "--load \"" + Path.GetFullPath(files[rand.Next(files.Length)]) + "\"";
            }

            /////////////////////////////////////////////////////////////////////Obsidian Options
            string ObOptionPath = "";

            string addonString = "";

            if (UseCustomOptions.Checked)
            {
                if (UseOptionsPool.Checked)
                {
                    var rand = new Random();
                    var files = Directory.GetFiles(OptionsTextBox.Text, "*.txt");
                    ObOptionPath = "--options \"" + Path.GetFullPath(files[rand.Next(files.Length)]) + "\" ";
                }
                if (LoadOptionsFile.Checked)
                {
                    ObOptionPath = "--options \"" + OptionsTextBox.Text + "\" ";
                }

                string line = "";
                Stream lines = File.OpenRead(OptionsTextBox.Text);
                System.IO.StreamReader file = new StreamReader(lines);
                while ((line = file.ReadLine()) != null)
                {
                    //MessageBox.Show(line);
                    //var result = line.Substring(line.IndexOf('=')+1);

                    //Addons
                    if (line.Contains("addon = "))
                    {
                        var result = line.Substring(line.IndexOf('=') + 2);
                        addonString += " " + result;
                    }

                    if (OptionOverride.Checked)
                    {
                        //Custom Config
                        if (line.Contains("--Config = "))
                        {
                            var result = line.Substring(line.IndexOf('=') + 2);
                            ObConfigPath = "--load \"" + result + "\"";
                        }
                        else if (line.Contains("--Config Pool = "))
                        {
                            var result = line.Substring(line.IndexOf('=') + 2);
                            var rand = new Random();
                            var files = Directory.GetFiles(result, "*.txt");
                            ObConfigPath = "--load \"" + Path.GetFullPath(files[rand.Next(files.Length)]) + "\"";
                        }
                    }


                }
                lines.Close();

            }

            string ObsAddonString = "";

            if (addonString != "")
            {
                ObsAddonString = "--addon" + addonString + " ";
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
                ObString += "\" --batch \"" + campFolder + "\\Campaign " + CampC.ToString() + ".wad\" " + ObOptionPath + ObsAddonString + ObConfigPath + " " + ObLength + "\n";
            }



            ////////////////////////////////////////////Music/////////////////////////////
            string MusicString = "";
            if (musicWadBox.Items.Count > 0)
            {
                MusicString += "\"";
                var random = new Random();
                if (checkBox3.Checked == true)
                {
                    int MusicWad = random.Next(0, musicWadBox.Items.Count + 1);
                    if (MusicWad == musicWadBox.Items.Count + 1)
                    {
                        MusicString = "";
                    }
                    else
                    {
                        MusicString += musicWadBox.Items[MusicWad].ToString() + "\" ";
                    }
                }
                else
                {
                    int MusicWad = random.Next(0, musicWadBox.Items.Count);
                    MusicString += musicWadBox.Items[MusicWad].ToString() + "\" ";
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////
            ///

            ///////////////////////////////////////////Additonal Wads///////////////////////////////////

            string AddWadString = "";
            if (additonalWadBox.Items.Count > 0)
            {
                AddWadString += "\"";
                var random = new Random();
                if (checkBox4.Checked == true)
                {
                    int Addwad = random.Next(0, additonalWadBox.Items.Count + 1);
                    if (Addwad == additonalWadBox.Items.Count + 1)
                    {
                        AddWadString = "";
                    }
                    else
                    {
                        AddWadString += additonalWadBox.Items[Addwad].ToString() + "\" ";
                    }
                }
                else
                {
                    int Addwad = random.Next(0, additonalWadBox.Items.Count);
                    AddWadString += additonalWadBox.Items[Addwad].ToString() + "\" ";
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////

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

            if (!CustomSaveCheckbox.Checked)
            {

                if (UseCampSave.Checked == true)
                {
                    savePath = "+set save_path " + "\"" + campFolder + "\"" + " +save_dir " + "\"" + campFolder + "\"";
                    batSavePath = "+set save_path " + "\"%~dp0\"" + " +save_dir " + "\"%~dp0\\";
                }
            }
            else
            {
                if (SaveFolderText.Text != "") {
                    savePath = "+set save_path \"" + SaveFolderText.Text + "\" +save_dir \"" + SaveFolderText.Text + "\"";
                }
            }



            string iwadstr = " -iwad \"" + IwadTextBox.Text + "\"";
            string wads = "\"" + CampPath + "\" ";
            string DoomEXE = "\"" + DoomExeTextBox.Text + "\"";
            string allItems = string.Join("\" \"", AlwaysWadBox.Items.OfType<object>());
            wads += "\"" + allItems + "\"";

            if (UseDefaultSave.Checked == true)
            {

                DirectoryInfo networkDir = new DirectoryInfo(DoomExeTextBox.Text);
                DirectoryInfo twoLevelsUp = networkDir.Parent;
                //MessageBox.Show(networkDir.ToString());
                //MessageBox.Show(savePath);
                string savetest3 = networkDir.FullName;
                string bob = Path.GetDirectoryName(savetest3);
                //MessageBox.Show(bob);


                savePath = "-savedir \"" + bob + "\\Save\"" + " +save_dir \"" + bob + "\\Save\"";

            }

            ///////////////////////////////////////// Warp
            string warpstring = "";
            if (comboBox2.SelectedItem != null)
            {
                warpstring = " -warp ";
                string wstr = comboBox2.SelectedItem.ToString();

                if (wstr == " ")
                {
                    warpstring = "";
                }

                //MessageBox.Show(wstr);
                if (wstr.Contains("MAP0"))
                {
                    warpstring += wstr.Substring(wstr.IndexOf('0') + 1);
                    // MessageBox.Show("SingleDigit " + warpstring);
                }
                else
                {
                    if (wstr.Contains("MAP"))
                    {
                        warpstring += wstr.Substring(wstr.IndexOf('p') + 1);
                        //MessageBox.Show("DoubleDigit " + warpstring);
                    }
                }

                if (wstr.Contains("E"))
                {
                    warpstring += wstr.Substring(1, 1) + " " + wstr.Substring(3, 1);
                }
            }
            /////////////////////////////////////////////



            ////////////Multiplayer////////////////////////////

            string multiString = "";
            if (EnableMultiBox.Checked)
            {
                multiString += " -altdeath";


                if (ExtraticBox.Checked)
                {
                    multiString += " -extratic";
                }

                if (PortTextBox.Text != "")
                {
                    multiString += " -port" + PortTextBox.Text;
                }

                if (DupBox.SelectedIndex != -1)
                {
                    multiString += " -dup " + DupBox.SelectedItem;
                }

                if (NetModeBox.SelectedIndex != -1)
                {
                    multiString += " -netmode " + NetModeBox.SelectedIndex.ToString();
                }

            }

            //////////////////////////////
            ///

            string spacestring = "";
            if (cmdAdd.Text != "") {
                spacestring = " ";
            }

            ///////////////////////////////////////////////

            string writeString = ObString + DoomEXE + iwadstr + " -file " + wads + " " + MusicString + spacestring + cmdAdd.Text + spacestring + savePath + " -skill " + comboBox3.SelectedIndex + warpstring + multiString; //+ " -warp " + comboBox2.SelectedItem;
            string batString = DoomEXE + iwadstr + " -file " + wads + " " + MusicString + " " + batSavePath + " -skill " + comboBox3.SelectedIndex + warpstring + multiString; // + " -warp " + comboBox2.SelectedItem;
            if (checkBox6.Checked == true)
            {
                File.WriteAllTextAsync(campFolder + "\\Start.bat", batString);
            }
            File.WriteAllTextAsync(CurrentDir + @"\Level Gen\" + "DoomGen.bat", writeString);
            System.Diagnostics.Process.Start(CurrentDir + @"\Level Gen\" + "DoomGen.bat");

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(frm1.cPath);
            SaveFile.WriteLine(CampC.ToString());
            SaveFile.Close();

            if (CloseAfterLaunching.Checked == true)
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

            if (radioButton1.Checked == true)
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
            else
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);

                        //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                        //MessageBox.Show(fbd.SelectedPath);
                        //DeclareVars frm1 = new DeclareVars();
                        textBox4.Text = fbd.SelectedPath;
                        //textBox1.Text = frm1.MusicString;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Checking selected item
            if (AlwaysWadBox.SelectedItem == null || AlwaysWadBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = AlwaysWadBox.SelectedIndex + -1;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= AlwaysWadBox.Items.Count)
                return; // Index out of range - nothing to do

            object selected = AlwaysWadBox.SelectedItem;

            // Removing removable element
            AlwaysWadBox.Items.Remove(selected);
            // Insert it in new position
            AlwaysWadBox.Items.Insert(newIndex, selected);
            // Restore selection
            AlwaysWadBox.SetSelected(newIndex, true);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Checking selected item
            if (AlwaysWadBox.SelectedItem == null || AlwaysWadBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = AlwaysWadBox.SelectedIndex + 1;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= AlwaysWadBox.Items.Count)
                return; // Index out of range - nothing to do

            object selected = AlwaysWadBox.SelectedItem;

            // Removing removable element
            AlwaysWadBox.Items.Remove(selected);
            // Insert it in new position
            AlwaysWadBox.Items.Insert(newIndex, selected);
            // Restore selection
            AlwaysWadBox.SetSelected(newIndex, true);
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            if (AlwaysWadBox.Items.Count != 0)
            {
                //listBox1.Items.Clear();
            }
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                IwadTextBox.Text = s[i];
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
            choofdlog.Filter = ".exe Files (*.exe*)|*.exe*";
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
            if (AlwaysWadBox.Items.Count != 0)
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
            SaveFile.WriteLine("CloseAfterLaunch=" + CloseAfterLaunching.Checked.ToString());
            SaveFile.WriteLine("EnableOblige=" + checkBox2.Checked.ToString());
            foreach (var item in AlwaysWadBox.Items)
            {
                SaveFile.WriteLine("Wad=" + item);
            }
            foreach (var item in listBox3.Items)
            {
                SaveFile.WriteLine("Oblige=" + item);
            }
            foreach (var item in musicWadBox.Items)
            {
                SaveFile.WriteLine("Music=" + item);
            }
            foreach (var item in additonalWadBox.Items)
            {
                SaveFile.WriteLine("rWad=" + item);
            }

            SaveFile.WriteLine("VanillaMusic=" + checkBox3.Checked.ToString());
            SaveFile.WriteLine("NoWad=" + checkBox4.Checked.ToString());

            SaveFile.WriteLine("NewSave=" + UseCampSave.Checked.ToString());

            SaveFile.WriteLine("WadLength=" + comboBox1.SelectedItem);

            SaveFile.WriteLine("UseConfigPool=" + radioButton2.Checked.ToString());
            SaveFile.WriteLine("ConfigFile=" + textBox4.Text);
            SaveFile.WriteLine("ConfigPool=" + textBox4.Text);

            SaveFile.Close();

            MessageBox.Show("Programs saved!");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                AlwaysWadBox.Items.Clear();

                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(f.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        AlwaysWadBox.Items.Add(line);

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
                textBox4.Text = s[i];
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tab 1 General
            Properties.Settings.Default.IWadSet = IwadTextBox.Text;
            Properties.Settings.Default.DoomSet = DoomExeTextBox.Text;
            Properties.Settings.Default.LengthSet = comboBox1.SelectedIndex;

            Properties.Settings.Default.CloseAtLaunch = CloseAfterLaunching.Checked;


            Properties.Settings.Default.ObligeEnabled = checkBox2.Checked;

            Properties.Settings.Default.MakeShrtCt = checkBox6.Checked;

            Properties.Settings.Default.CampSaveFolder = UseCampSave.Checked;
            Properties.Settings.Default.DefaultSaveFolder = UseDefaultSave.Checked;


            Properties.Settings.Default.AlwaysWadSet.Clear();
            foreach (object item in AlwaysWadBox.Items)
            {
                Properties.Settings.Default.AlwaysWadSet.Add(Convert.ToString(item));
            }


            //Tab 2 Oblige/Obsidian

            Properties.Settings.Default.ConfigPool = radioButton2.Checked;
            Properties.Settings.Default.ConfigPoolFolder = textBox4.Text;
            Properties.Settings.Default.ConfigFileSet = textBox4.Text;
            Properties.Settings.Default.ConfigFile = radioButton1.Checked;

            Properties.Settings.Default.CustomOptions = UseCustomOptions.Checked;

            Properties.Settings.Default.WadLength = comboBox1.SelectedIndex;

            Properties.Settings.Default.ObligeSet.Clear();

            foreach (object item in listBox3.Items)

            {
                Properties.Settings.Default.ObligeSet.Add(Convert.ToString(item));
            }


            //Tab 3 Additional

            Properties.Settings.Default.MusicWadSet.Clear();

            foreach (object item in musicWadBox.Items)

            {
                Properties.Settings.Default.MusicWadSet.Add(Convert.ToString(item));
            }

            Properties.Settings.Default.AdditionalWads.Clear();

            foreach (object item in additonalWadBox.Items)

            {
                Properties.Settings.Default.AdditionalWads.Add(Convert.ToString(item));
            }

            //Tab 4 Extra/Multi

            Properties.Settings.Default.AdditionalCmds = cmdAdd.Text;

            Properties.Settings.Default.EnableMulti = EnableMultiBox.Checked;

            Properties.Settings.Default.CustomSave = CustomSaveCheckbox.Checked;
            Properties.Settings.Default.CustomCamp = CustomCampCheckbox.Checked;

            Properties.Settings.Default.CampText = CampFolderText.Text;
            Properties.Settings.Default.SaveText = SaveFolderText.Text;

            Properties.Settings.Default.NetModeSet = NetModeBox.SelectedIndex;
            Properties.Settings.Default.DupSet = DupBox.SelectedIndex;

            Properties.Settings.Default.PortSet = PortTextBox.Text;

            //Properties.Settings.Default.Save();






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
            choofdlog.Filter = "pk3 or wad (*.pk3, *.wad, *.zip)|*.pk3;*.wad*; *.zip";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                //listBox1.Items.Add(sFileName);
                for (int i = 0; i < arrAllFiles.Length; i++)
                {
                    musicWadBox.Items.Add(arrAllFiles[i]);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (int x = musicWadBox.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = musicWadBox.SelectedIndices[x];
                //listBox2.Items.Add(listBox1.Items[idx]);
                musicWadBox.Items.RemoveAt(idx);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string allMusic = string.Join("\" \"", musicWadBox.Items.OfType<object>());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Oblige/Obsidian version");
            }
            else
            {
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
                musicWadBox.Items.Add((s[i]));
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
                if (tabControl1.TabPages.Contains(tabPage4))
                {

                }
                else { tabControl1.TabPages.Insert(1, tabPage4); }

                button1.Visible = true;
            }
        }

        private void LoadSettings(string loadfile)
        {
            AlwaysWadBox.Items.Clear();
            listBox3.Items.Clear();
            musicWadBox.Items.Clear();
            additonalWadBox.Items.Clear();
            IwadTextBox.Text = "";
            DoomExeTextBox.Text = "";
            string line = "";
            using (StreamReader myStream = new StreamReader(loadfile))
            {
                System.IO.StreamReader file = myStream;

                while ((line = file.ReadLine()) != null)
                {
                    //MessageBox.Show(line);
                    //var result = line.Substring(line.IndexOf('=')+1);

                    //listbox1.Items.Clear();
                    if (line.Contains("Iwad="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        IwadTextBox.Text = result;
                    }
                    if (line.Contains("DoomExe="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        DoomExeTextBox.Text = result;
                    }
                    if (line.Contains("CloseAfterLaunch="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        CloseAfterLaunching.Checked = Convert.ToBoolean(result);
                    }
                    if (line.Contains("EnableOblige="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        checkBox2.Checked = Convert.ToBoolean(result);
                    }
                    if (line.Contains("Wad="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        if (result != "True" && result != "False")
                        {
                            AlwaysWadBox.Items.Add(result);
                        }
                    }
                    if (line.Contains("Oblige="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        if (result != "True" && result != "False")
                        {
                            listBox3.Items.Add(result);
                        }
                    }
                    if (line.Contains("NewSave="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        UseCampSave.Checked = Convert.ToBoolean(result);
                        if (UseCampSave.Checked) { UseDefaultSave.Checked = false; } else { UseDefaultSave.Checked = true; }
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
                        textBox4.Text = result;
                    }

                    if (line.Contains("UseOptionPool="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        UseOptionsPool.Checked = Convert.ToBoolean(result);
                        if (UseOptionsPool.Checked) { LoadOptionsFile.Checked = false; } else { LoadOptionsFile.Checked = true; }
                    }
                    if (line.Contains("OptionFile="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        OptionsTextBox.Text = result;
                    }
                    if (line.Contains("ConfigPool="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        OptionsTextBox.Text = result;
                    }
                    if (line.Contains("OptionOverride="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        OptionOverride.Checked = Convert.ToBoolean(result);
                    }
                        if (line.Contains("Music="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        if (result != "True" && result != "False")
                        {
                            musicWadBox.Items.Add(result);
                        }
                    }
                    if (line.Contains("WadRandom="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        if (result != "True" && result != "False")
                        {
                            additonalWadBox.Items.Add(result);
                        }
                    }
                    if (line.Contains("VanillaMusic="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        checkBox3.Checked = Convert.ToBoolean(result);
                    }
                    if (line.Contains("NoWad="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        checkBox4.Checked = Convert.ToBoolean(result);
                    }

                    //Multi/Extra
                    if (line.Contains("EnableMulti="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        EnableMultiBox.Checked = Convert.ToBoolean(result);
                    }
                    if (line.Contains("NetModeSet="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        NetModeBox.SelectedIndex = Convert.ToInt32(result);
                    }
                    if (line.Contains("DupSet="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        DupBox.SelectedIndex = Convert.ToInt32(result);
                    }
                    if (line.Contains("PortSet="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        PortTextBox.Text = result;
                    }
                    if (line.Contains("AddCmd="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        cmdAdd.Text = result;
                    }
                    if (line.Contains("MakeShortcut="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        checkBox6.Checked = Convert.ToBoolean(result);
                    }

                    if (line.Contains("UseCustomSaveFolder="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        CustomSaveCheckbox.Checked = Convert.ToBoolean(result);
                    }

                    if (line.Contains("UseCustomCampaignFolder="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        CustomCampCheckbox.Checked = Convert.ToBoolean(result);
                    }

                    if (line.Contains("CustomSaveFolder="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        SaveFolderText.Text = result;
                    }

                    if (line.Contains("CustomCampaignFolder="))
                    {
                        var result = line.Substring(line.IndexOf('=') + 1);
                        CampFolderText.Text = result;
                    }
                    //MessageBox.Show(result);
                    //System.Console.WriteLine(line);

                }
                file.Close();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            // Read the file and display it line by line.  
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "ozdl files (*.ozdl)|*.ozdl";
            string fileToOpen = "";
            if (f.ShowDialog() == DialogResult.OK)
            {
                fileToOpen = f.InitialDirectory + f.FileName;
                try
                {
                    LoadSettings(fileToOpen);
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
                    //Tab 1 General
                    SaveFile.WriteLine("Iwad=" + IwadTextBox.Text);
                    SaveFile.WriteLine("DoomExe=" + DoomExeTextBox.Text);
                    SaveFile.WriteLine("CloseAfterLaunch=" + CloseAfterLaunching.Checked.ToString());
                    SaveFile.WriteLine("EnableOblige=" + checkBox2.Checked.ToString());
                    SaveFile.WriteLine("CloseAfterLaunch=" + CloseAfterLaunching.Checked.ToString());
                    SaveFile.WriteLine("MakeShortcut=" + checkBox6.Checked.ToString());
                    foreach (var item in AlwaysWadBox.Items)
                    {
                        SaveFile.WriteLine("Wad=" + item);
                    }
                    //Tab 2 Oblige
                    foreach (var item in listBox3.Items)
                    {
                        SaveFile.WriteLine("Oblige=" + item);
                    }
                    SaveFile.WriteLine("UseConfigPool=" + radioButton2.Checked.ToString());
                    SaveFile.WriteLine("ConfigFile=" + textBox4.Text);
                    SaveFile.WriteLine("ConfigPool=" + textBox4.Text);
                    SaveFile.WriteLine("UseOptionPool=" + UseOptionsPool.Checked.ToString());
                    SaveFile.WriteLine("OptionFile=" + OptionsTextBox.Text);
                    SaveFile.WriteLine("OptionPool=" + OptionsTextBox.Text);
                    SaveFile.WriteLine("OptionOveride=" + OptionOverride.Checked.ToString());
                    //Tab 3 Additional Wads
                    foreach (var item in musicWadBox.Items)
                    {
                        SaveFile.WriteLine("Music=" + item);
                    }
                    foreach (var item in additonalWadBox.Items)
                    {
                        SaveFile.WriteLine("WadRandom=" + item);
                    }
                    SaveFile.WriteLine("VanillaMusic=" + checkBox3.Checked.ToString());
                    SaveFile.WriteLine("NoWad=" + checkBox4.Checked.ToString());
                    //Tab 4 Extra/Multi

                    SaveFile.WriteLine("EnableMulti=" + EnableMultiBox.Checked.ToString());
                    SaveFile.WriteLine("NetModeSet=" + NetModeBox.SelectedIndex.ToString());
                    SaveFile.WriteLine("DupSet=" + DupBox.SelectedIndex.ToString());
                    SaveFile.WriteLine("PortSet=" + PortTextBox.Text);

                    SaveFile.WriteLine("NewSave=" + UseCampSave.Checked.ToString());

                    SaveFile.WriteLine("WadLength=" + comboBox1.SelectedItem);

                    SaveFile.WriteLine("AddCommands=" + cmdAdd.Text);

                    SaveFile.WriteLine("UseCustomSaveFolder=" + CustomSaveCheckbox.Checked.ToString());
                    SaveFile.WriteLine("UseCustomCampaignFolder=" + CustomCampCheckbox.Checked.ToString());

                    SaveFile.WriteLine("CustomSaveFolder=" + SaveFolderText.Text);
                    SaveFile.WriteLine("CustomCampaignFolder=" + CampFolderText.Text);

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

        private void button23_Click_1(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                OptionsTextBox.Text = choofdlog.FileName;
                //textBox4.Text = sFileName;   
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    //textBox1.Text = fbd.SelectedPath;
                }
            }
        }

        private void button24_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadOptionsFile.Checked == true)
            {
                button23.Text = "Select Options File";
            }
            else
            {
                button23.Text = "Select Options Pool";
            }
        }

        private void button18_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button14.Text = "Select Config File";
            }
            else
            {
                button14.Text = "Slect Config Pool";
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button14.Text = "Select Config File";
            }
            else
            {
                button14.Text = "Select Config Pool";
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    //DeclareVars frm1 = new DeclareVars();
                    SaveFolderText.Text = fbd.SelectedPath;
                    //textBox1.Text = frm1.MusicString;
                }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string path = @"Campaigns";
            startInfo.Arguments = string.Format("/C start {0}", path);
            process.StartInfo = startInfo;
            process.Start();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    //DeclareVars frm1 = new DeclareVars();
                    textBox3.Text = fbd.SelectedPath;
                    //textBox1.Text = frm1.MusicString;
                }
            }
        }

        private void button22_Click_1(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {

            FileAssociations.SetAssociation(".pk3", "Doom_Package_File", Application.ExecutablePath, "pk3 File");
            /*
            static void RegisterForFileExtension(string extension, string applicationPath)
            {
                RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + extension);
                FileReg.CreateSubKey("shell\\open\\command").SetValue("", applicationPath + " %1");
                FileReg.Close();

                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
            [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
            */
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //Move this to Form1_Load
            if (arg1.Contains(".pk3") || arg1.Contains(".wad"))
            {
                AlwaysWadBox.Items.Add(arg1);
            }
            
            if (arg1.Contains(".ozdl"))
            {
                //MessageBox.Show(arg1);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Arg Test
                ///








                string line;
                var myStream = new FileStream(arg1, FileMode.OpenOrCreate, FileAccess.Read);

                // Read the file and display it line by line.  

                    try
                    {

                            AlwaysWadBox.Items.Clear();
                            listBox3.Items.Clear();
                            musicWadBox.Items.Clear();
                            additonalWadBox.Items.Clear();
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
                                        IwadTextBox.Text = result;
                                    }
                                    if (line.Contains("DoomExe="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        DoomExeTextBox.Text = result;
                                    }
                                    if (line.Contains("CloseAfterLaunch="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        CloseAfterLaunching.Checked = Convert.ToBoolean(result);
                                    }
                                    if (line.Contains("EnableOblige="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        checkBox2.Checked = Convert.ToBoolean(result);
                                    }
                                    if (line.Contains("Wad="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        if (result != "True" && result != "False")
                                        {
                                            AlwaysWadBox.Items.Add(result);
                                        }
                                    }
                                    if (line.Contains("Oblige="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        if (result != "True" && result != "False")
                                        {
                                            listBox3.Items.Add(result);
                                        }
                                    }
                                    if (line.Contains("NewSave="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        UseCampSave.Checked = Convert.ToBoolean(result);
                                        if (UseCampSave.Checked) { UseDefaultSave.Checked = false; } else { UseDefaultSave.Checked = true; }
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
                                        textBox4.Text = result;
                                    }
                                    if (line.Contains("Music="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        if (result != "True" && result != "False")
                                        {
                                            musicWadBox.Items.Add(result);
                                        }
                                    }
                                    if (line.Contains("rWad="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        if (result != "True" && result != "False")
                                        {
                                            additonalWadBox.Items.Add(result);
                                        }
                                    }
                                    if (line.Contains("VanillaMusic="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        checkBox3.Checked = Convert.ToBoolean(result);
                                    }
                                    if (line.Contains("NoWad="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        checkBox4.Checked = Convert.ToBoolean(result);
                                    }
                                    if (line.Contains("AddCmd="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        cmdAdd.Text = result;
                                    }
                                    if (line.Contains("MakeShortcut="))
                                    {
                                        var result = line.Substring(line.IndexOf('=') + 1);
                                        checkBox6.Checked = Convert.ToBoolean(result);
                                    }

                                    //MessageBox.Show(result);
                                    //System.Console.WriteLine(line);

                                }
                                file.Close();
                            }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                

                /////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://www.doomworld.com/idgames/?random") { UseShellExecute = true });
        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    //DeclareVars frm1 = new DeclareVars();
                    SaveFolderText.Text = fbd.SelectedPath;
                    //textBox1.Text = frm1.MusicString;
                }
            }
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    //DeclareVars frm1 = new DeclareVars();
                    textBox3.Text = fbd.SelectedPath;
                    //textBox1.Text = frm1.MusicString;
                }
            }
        }

        private void textBox6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox6_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                SaveFolderText.Text = s[i];
            //listBox1.Items.Add(Path.GetFileName(s[i]));
        }

        private void button18_Click_2(object sender, EventArgs e)
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

        private void button22_Click_2(object sender, EventArgs e)
        {
            DeclareVars frm1 = new DeclareVars();
            System.IO.StreamWriter SaveFile1 = new System.IO.StreamWriter(frm1.cPath);
            SaveFile1.WriteLine("0");
            SaveFile1.Close();
            label8.Text = "Campaign Count: 0";
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            string path = @"Campaigns";
            startInfo.Arguments = string.Format("/C start {0}", path);
            process.StartInfo = startInfo;
            process.Start();
        }

        private void button24_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Checking this box will enable the program to look for a line in Oblige\\Obsidian's OPTIONS.txt file labeled \"-- Config =\" with a directory path after the '=' sign. \n" +
                "\nFor example \"--Config = C:\\Doom Configs\\Obsidian\\MYCONFIG.txt\" On a seperate line in the OPTIONS.txt folder without the quotes. This can point to a single config file by using \"-- Config = \" \n or a config pool folder " +
                "by using \"-- Config Pool = \"\n\n" +
                "NOTE: You must add this line to the options file yourself, manually. This option is for anyone who wants to use seperate configs based on different enabled addons.");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            string DoomEXE = DoomExeTextBox.Text;
            string savePath = "+set save_path \"" + Directory.GetParent(DoomEXE) + "\\Save\\\"" + " +save_dir \"" + Directory.GetParent(DoomEXE) + "\\Save\\\"";
            DirectoryInfo networkDir = new DirectoryInfo(DoomEXE);
            DirectoryInfo twoLevelsUp = networkDir.Parent;
            //MessageBox.Show(networkDir.ToString());
            //MessageBox.Show(savePath);
            string savetest3 = networkDir.Parent.FullName;
            string bob = Path.GetDirectoryName(savetest3);
            //MessageBox.Show(bob);
        }

        private void button23_Click_2(object sender, EventArgs e)
        {
            //listBox1.Text = "yoyoyo"; //Convert.ToString(dr);
            //using (var fbd =  openFileDialog1())
            if (LoadOptionsFile.Checked)
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = true;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    OptionsTextBox.Text = choofdlog.FileName;
                    //textBox4.Text = sFileName;   
                }
            }
            if (UseOptionsPool.Checked)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);

                        //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                        //MessageBox.Show(fbd.SelectedPath);
                        //DeclareVars frm1 = new DeclareVars();
                        OptionsTextBox.Text = fbd.SelectedPath;
                        //textBox1.Text = frm1.MusicString;
                    }
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Version 1.0 Beta \nMade by MTdan. 2021");
        }

        private void CampFolderButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    //DeclareVars frm1 = new DeclareVars();
                    CampFolderText.Text = fbd.SelectedPath;
                    //textBox1.Text = frm1.MusicString;
                }
            }
        }

        private void NetModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OptionsTextBox_TextChanged(object sender, EventArgs e)
        {
            UseCustomOptions.Checked = true;
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                textBox4.Text = s[i];
           
        }

        private void textBox4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void OptionsTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                OptionsTextBox.Text = s[i];
        }

        private void OptionsTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void CampFolderText_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                CampFolderText.Text = s[i];
        }

        private void CampFolderText_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}

public class LoadFile
{
    public void Load()
    {

    }


}


public class FileAssociation
{
    public string Extension { get; set; }
    public string ProgId { get; set; }
    public string FileTypeDescription { get; set; }
    public string ExecutableFilePath { get; set; }
}

public class FileAssociations
{
    // needed so that Explorer windows get refreshed after the registry is updated
    [System.Runtime.InteropServices.DllImport("Shell32.dll")]
    private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

    private const int SHCNE_ASSOCCHANGED = 0x8000000;
    private const int SHCNF_FLUSH = 0x1000;

    public static void EnsureAssociationsSet()
    {
        var filePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        EnsureAssociationsSet(
            new FileAssociation
            {
                Extension = ".pk3",
                ProgId = "Doom_Package_File",
                FileTypeDescription = "pk3 File",
                ExecutableFilePath = filePath
            });
    }

    public static void EnsureAssociationsSet(params FileAssociation[] associations)
    {
        bool madeChanges = false;
        foreach (var association in associations)
        {
            madeChanges |= SetAssociation(
                association.Extension,
                association.ProgId,
                association.FileTypeDescription,
                association.ExecutableFilePath);
        }

        if (madeChanges)
        {
            SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
        }
    }

    public static bool SetAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath)
    {
        bool madeChanges = false;
        madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + extension, progId);
        madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + progId, fileTypeDescription);
        madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\" \"%1\"");
        return madeChanges;
    }

    private static bool SetKeyDefaultValue(string keyPath, string value)
    {
        using (var key = Registry.CurrentUser.CreateSubKey(keyPath))
        {
            if (key.GetValue(null) as string != value)
            {
                key.SetValue(null, value);
                return true;
            }
        }

        return false;
    }
}