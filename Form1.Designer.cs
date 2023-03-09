namespace TFRandomizerGUI
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            groupBox1 = new GroupBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            cbPlayerDeck = new CheckBox();
            radioRandomize = new RadioButton();
            radioShuffle = new RadioButton();
            cbDeckRandom = new CheckBox();
            groupBox3 = new GroupBox();
            cbPackCountRange = new CheckBox();
            label6 = new Label();
            cbPackPriceRange = new CheckBox();
            label4 = new Label();
            btInitSetup = new Button();
            btRandomize = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ofDialogInitSetup = new OpenFileDialog();
            lbWarningNote = new Label();
            sfDialogRandomizer = new SaveFileDialog();
            lbWaitText = new Label();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(304, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 54);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 2;
            label1.Text = "Seed";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(280, 89);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "General";
            // 
            // button1
            // 
            button1.Location = new Point(199, 51);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "0";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tag Force 3 (ULES-01183)" });
            comboBox1.Location = new Point(67, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(207, 23);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Tag Force 3 (ULES-01183)";
            comboBox1.ValueMember = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 25);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "Game";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbPlayerDeck);
            groupBox2.Controls.Add(radioRandomize);
            groupBox2.Controls.Add(radioShuffle);
            groupBox2.Controls.Add(cbDeckRandom);
            groupBox2.Location = new Point(12, 122);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(280, 125);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Deck Recipes/Lists";
            // 
            // cbPlayerDeck
            // 
            cbPlayerDeck.AutoSize = true;
            cbPlayerDeck.Location = new Point(6, 97);
            cbPlayerDeck.Name = "cbPlayerDeck";
            cbPlayerDeck.Size = new Size(172, 19);
            cbPlayerDeck.TabIndex = 1;
            cbPlayerDeck.Text = "Affect player's starting deck";
            cbPlayerDeck.UseVisualStyleBackColor = true;
            // 
            // radioRandomize
            // 
            radioRandomize.AutoSize = true;
            radioRandomize.Checked = true;
            radioRandomize.Location = new Point(6, 47);
            radioRandomize.Name = "radioRandomize";
            radioRandomize.Size = new Size(214, 19);
            radioRandomize.TabIndex = 2;
            radioRandomize.TabStop = true;
            radioRandomize.Text = "Randomize (can contain duplicates)";
            radioRandomize.UseVisualStyleBackColor = true;
            // 
            // radioShuffle
            // 
            radioShuffle.AutoSize = true;
            radioShuffle.Location = new Point(6, 72);
            radioShuffle.Name = "radioShuffle";
            radioShuffle.Size = new Size(144, 19);
            radioShuffle.TabIndex = 1;
            radioShuffle.Text = "Shuffle (no duplicates)";
            radioShuffle.UseVisualStyleBackColor = true;
            // 
            // cbDeckRandom
            // 
            cbDeckRandom.AutoSize = true;
            cbDeckRandom.Checked = true;
            cbDeckRandom.CheckState = CheckState.Checked;
            cbDeckRandom.Location = new Point(6, 22);
            cbDeckRandom.Name = "cbDeckRandom";
            cbDeckRandom.Size = new Size(68, 19);
            cbDeckRandom.TabIndex = 0;
            cbDeckRandom.Text = "Enabled";
            cbDeckRandom.UseVisualStyleBackColor = true;
            cbDeckRandom.CheckedChanged += cbDeckRandom_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbPackCountRange);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cbPackPriceRange);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(13, 253);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(279, 100);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Card Shop Boxes";
            // 
            // cbPackCountRange
            // 
            cbPackCountRange.AutoSize = true;
            cbPackCountRange.Checked = true;
            cbPackCountRange.CheckState = CheckState.Checked;
            cbPackCountRange.Location = new Point(6, 65);
            cbPackCountRange.Name = "cbPackCountRange";
            cbPackCountRange.Size = new Size(176, 19);
            cbPackCountRange.TabIndex = 6;
            cbPackCountRange.Text = "Pack count range (1 - 16383)";
            cbPackCountRange.UseVisualStyleBackColor = true;
            cbPackCountRange.CheckedChanged += cbPackCountRange_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(230, 16);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 8;
            label6.Text = "Max";
            // 
            // cbPackPriceRange
            // 
            cbPackPriceRange.AutoSize = true;
            cbPackPriceRange.Checked = true;
            cbPackPriceRange.CheckState = CheckState.Checked;
            cbPackPriceRange.Location = new Point(6, 36);
            cbPackPriceRange.Name = "cbPackPriceRange";
            cbPackPriceRange.Size = new Size(171, 19);
            cbPackPriceRange.TabIndex = 3;
            cbPackPriceRange.Text = "Pack price range (0 - 65535)";
            cbPackPriceRange.UseVisualStyleBackColor = true;
            cbPackPriceRange.CheckedChanged += cbPackPriceRange_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(183, 16);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 4;
            label4.Text = "Min";
            // 
            // btInitSetup
            // 
            btInitSetup.Location = new Point(12, 466);
            btInitSetup.Name = "btInitSetup";
            btInitSetup.Size = new Size(98, 23);
            btInitSetup.TabIndex = 6;
            btInitSetup.Text = "Initial Setup";
            btInitSetup.UseVisualStyleBackColor = true;
            btInitSetup.Click += btInitSetup_Click;
            // 
            // btRandomize
            // 
            btRandomize.Location = new Point(12, 374);
            btRandomize.Name = "btRandomize";
            btRandomize.Size = new Size(280, 23);
            btRandomize.TabIndex = 7;
            btRandomize.Text = "Randomize";
            btRandomize.UseVisualStyleBackColor = true;
            btRandomize.Click += btRandomize_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // ofDialogInitSetup
            // 
            ofDialogInitSetup.DefaultExt = "iso";
            ofDialogInitSetup.Filter = "ISO Image|*.iso";
            ofDialogInitSetup.Title = "Select the game ISO";
            // 
            // lbWarningNote
            // 
            lbWarningNote.AutoSize = true;
            lbWarningNote.Location = new Point(12, 433);
            lbWarningNote.Name = "lbWarningNote";
            lbWarningNote.Size = new Size(187, 30);
            lbWarningNote.TabIndex = 8;
            lbWarningNote.Text = "Game data has not been detected.\r\nPlease do the initial setup first.";
            lbWarningNote.Visible = false;
            // 
            // sfDialogRandomizer
            // 
            sfDialogRandomizer.DefaultExt = "iso";
            sfDialogRandomizer.Filter = "ISO Image|*.iso";
            sfDialogRandomizer.Title = "Select the output ISO location";
            // 
            // lbWaitText
            // 
            lbWaitText.AutoSize = true;
            lbWaitText.Location = new Point(12, 400);
            lbWaitText.Name = "lbWaitText";
            lbWaitText.Size = new Size(143, 15);
            lbWaitText.TabIndex = 9;
            lbWaitText.Text = "Packing ISO, please wait...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 501);
            Controls.Add(lbWaitText);
            Controls.Add(lbWarningNote);
            Controls.Add(btRandomize);
            Controls.Add(btInitSetup);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Tag Force Randomizer GUI";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private FastTextBox tbSeed;
        private Label label1;
        private GroupBox groupBox1;
        private Button button1;
        private ComboBox comboBox1;
        private Label label2;
        private GroupBox groupBox2;
        private CheckBox cbPlayerDeck;
        private RadioButton radioRandomize;
        private RadioButton radioShuffle;
        private CheckBox cbDeckRandom;
        private GroupBox groupBox3;
        private FastTextBox tbMinCount;
        private Label label4;
        private FastTextBox tbMaxPrice;
        private FastTextBox tbMinPrice;
        private Label label6;
        private FastTextBox tbMaxCount;
        private Button btInitSetup;
        private Button btRandomize;
        private System.Windows.Forms.Timer timer1;
        private OpenFileDialog ofDialogInitSetup;
        private Label lbWarningNote;
        private SaveFileDialog sfDialogRandomizer;
        private Label lbWaitText;
        private CheckBox cbPackCountRange;
        private CheckBox cbPackPriceRange;
    }
}