﻿

namespace DoomGenV1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.DoomExeTextBox = new System.Windows.Forms.TextBox();
            this.IwadTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button19 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button15 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.button22 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 57);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate Shortcut";
            this.toolTip1.SetToolTip(this.button1, "\"Generate a shortcut to always use the settings selceted in the entire program.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Select IWad File";
            this.toolTip1.SetToolTip(this.button2, "Select Doom2.wad");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 26);
            this.button3.TabIndex = 4;
            this.button3.Text = "Select Doom .exe";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DoomExeTextBox
            // 
            this.DoomExeTextBox.AcceptsReturn = true;
            this.DoomExeTextBox.AllowDrop = true;
            this.DoomExeTextBox.Location = new System.Drawing.Point(170, 48);
            this.DoomExeTextBox.Name = "DoomExeTextBox";
            this.DoomExeTextBox.Size = new System.Drawing.Size(534, 23);
            this.DoomExeTextBox.TabIndex = 21;
            this.DoomExeTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox2_DragDrop);
            this.DoomExeTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox2_DragEnter);
            // 
            // IwadTextBox
            // 
            this.IwadTextBox.AllowDrop = true;
            this.IwadTextBox.Location = new System.Drawing.Point(170, 16);
            this.IwadTextBox.Name = "IwadTextBox";
            this.IwadTextBox.Size = new System.Drawing.Size(534, 23);
            this.IwadTextBox.TabIndex = 22;
            this.IwadTextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.IwadTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox3_DragDrop);
            this.IwadTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox3_DragEnter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 334);
            this.tabControl1.TabIndex = 23;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.button21);
            this.tabPage1.Controls.Add(this.button20);
            this.tabPage1.Controls.Add(this.radioButton4);
            this.tabPage1.Controls.Add(this.radioButton5);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.button17);
            this.tabPage1.Controls.Add(this.button16);
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.DoomExeTextBox);
            this.tabPage1.Controls.Add(this.IwadTextBox);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(710, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click_1);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(556, 92);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(151, 19);
            this.checkBox2.TabIndex = 46;
            this.checkBox2.Text = "Enable Oblige/Obsidian";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(202, 251);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 23);
            this.button21.TabIndex = 45;
            this.button21.Text = "Load Test";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(202, 227);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(77, 20);
            this.button20.TabIndex = 44;
            this.button20.Text = "Save Test";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(168, 280);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(148, 19);
            this.radioButton4.TabIndex = 43;
            this.radioButton4.Text = "Use Default Save Folder";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Checked = true;
            this.radioButton5.Location = new System.Drawing.Point(0, 281);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(162, 19);
            this.radioButton5.TabIndex = 42;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Generate New Save Folder";
            this.toolTip1.SetToolTip(this.radioButton5, "Use a seperate folder for saves using this setting/level set, so you\'re doom save" +
        " folder doesn\'t get cluttered.");
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(442, 280);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 19);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Close After Launching";
            this.toolTip1.SetToolTip(this.checkBox1, "Close OZDL after launching game.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(510, 121);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(28, 23);
            this.button17.TabIndex = 39;
            this.button17.Text = "v";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(510, 92);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(28, 23);
            this.button16.TabIndex = 38;
            this.button16.Text = "^";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(603, 133);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(104, 31);
            this.button12.TabIndex = 35;
            this.button12.Text = "String Test";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(340, 224);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(164, 23);
            this.button9.TabIndex = 34;
            this.button9.Text = "Remove Selected Wad(s)";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 92);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(504, 124);
            this.listBox1.TabIndex = 31;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "Additonal wads/pk3s to always load:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 222);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 25);
            this.button5.TabIndex = 33;
            this.button5.Text = "Add Additonal Wad";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(591, 251);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(112, 55);
            this.button7.TabIndex = 23;
            this.button7.Text = "Launch Game";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button19);
            this.tabPage4.Controls.Add(this.textBox5);
            this.tabPage4.Controls.Add(this.button15);
            this.tabPage4.Controls.Add(this.textBox4);
            this.tabPage4.Controls.Add(this.button14);
            this.tabPage4.Controls.Add(this.button13);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.button11);
            this.tabPage4.Controls.Add(this.listBox3);
            this.tabPage4.Controls.Add(this.comboBox1);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.button8);
            this.tabPage4.Controls.Add(this.radioButton3);
            this.tabPage4.Controls.Add(this.radioButton2);
            this.tabPage4.Controls.Add(this.radioButton1);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(710, 306);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Obsidian/Oblige";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(513, 179);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(177, 23);
            this.button19.TabIndex = 42;
            this.button19.Text = "Open Oblige/Obsidian";
            this.toolTip1.SetToolTip(this.button19, "Open selected oblige/obsidian exe.");
            this.button19.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.AllowDrop = true;
            this.textBox5.Location = new System.Drawing.Point(297, 249);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(407, 23);
            this.textBox5.TabIndex = 39;
            this.textBox5.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox5_DragDrop);
            this.textBox5.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox5_DragEnter);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(141, 276);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(150, 23);
            this.button15.TabIndex = 38;
            this.button15.Text = "Open Generator Settings";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(297, 221);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(407, 23);
            this.textBox4.TabIndex = 37;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(141, 221);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(150, 23);
            this.button14.TabIndex = 36;
            this.button14.Text = "Select Config File";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(305, 179);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(180, 23);
            this.button13.TabIndex = 35;
            this.button13.Text = "Remove Obsidian/Oblige Exe";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(397, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "will not generate levels and default to any wad or Iwad level pack selected.";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(0, 179);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(159, 23);
            this.button11.TabIndex = 33;
            this.button11.Text = "Add Obsidian/Oblige Exe";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // listBox3
            // 
            this.listBox3.AllowDrop = true;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 15;
            this.listBox3.Location = new System.Drawing.Point(3, 33);
            this.listBox3.Name = "listBox3";
            this.listBox3.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox3.Size = new System.Drawing.Size(489, 139);
            this.listBox3.TabIndex = 32;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            this.listBox3.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox3_DragDrop);
            this.listBox3.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox3_DragEnter);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "One Map",
            "A Few Maps",
            "One Episode",
            "Whole Game"});
            this.comboBox1.Location = new System.Drawing.Point(542, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 23);
            this.comboBox1.TabIndex = 31;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(542, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Wad Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(632, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Select Level Generator(s) to use, selecting multiple will result in one being ran" +
    "domly selected each time. Selecting none";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(141, 250);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(150, 23);
            this.button8.TabIndex = 23;
            this.button8.Text = "Open Configs Folder";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 275);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(132, 19);
            this.radioButton3.TabIndex = 22;
            this.radioButton3.Text = "Generate Config File";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 250);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 19);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.Text = "Use Config Pool";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 225);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 19);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Load Config File";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.listBox2);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.checkBox4);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(710, 306);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Additional Random Wads";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(452, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "Place your music wads/pk3s in a seperate folder, and one will be selected at rand" +
    "om.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(534, 23);
            this.textBox1.TabIndex = 35;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 236);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 26);
            this.button4.TabIndex = 34;
            this.button4.Text = "Select Music Wad Folder";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(540, 155);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(164, 23);
            this.button10.TabIndex = 28;
            this.button10.Text = "Remove Selected Wad(s)";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(3, 23);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(701, 124);
            this.listBox2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(431, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Additonal wads/pk3s to randomly choose from: (only one is selected at random)";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(3, 184);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(326, 19);
            this.checkBox4.TabIndex = 27;
            this.checkBox4.Text = "Include possibility of none being selected. (Vanilla Mode)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 153);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(137, 25);
            this.button6.TabIndex = 26;
            this.button6.Text = "Add Additonal Wad";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.button22);
            this.tabPage5.Controls.Add(this.textBox6);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.button18);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(710, 306);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Options";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Campaign Count: 0";
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(3, 250);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(174, 23);
            this.button22.TabIndex = 3;
            this.button22.Text = "Reset Campaign Count";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(3, 18);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(552, 23);
            this.textBox6.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Additional Command Line Parameters:";
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(3, 279);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(174, 23);
            this.button18.TabIndex = 0;
            this.button18.Text = "Clear Campaigns Folder";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 350);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = " OZDL Oblige/Obsidian Zdoom Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox DoomExeTextBox;
        private System.Windows.Forms.TextBox IwadTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button22;
    }
}

