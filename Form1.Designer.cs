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
            tbSeed = new FastTextBox();
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
            lbToolTipPackCount = new LinkLabel();
            cbBoxRandomize = new CheckBox();
            cbPackCountRange = new CheckBox();
            label6 = new Label();
            cbPackPriceRange = new CheckBox();
            tbMinCount = new FastTextBox();
            tbMaxCount = new FastTextBox();
            label4 = new Label();
            tbMinPrice = new FastTextBox();
            tbMaxPrice = new FastTextBox();
            btInitSetup = new Button();
            btRandomize = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ofDialogInitSetup = new OpenFileDialog();
            lbWarningNote = new Label();
            sfDialogRandomizer = new SaveFileDialog();
            lbWaitText = new Label();
            cbBanlist = new CheckBox();
            progressBar1 = new ProgressBar();
            lbISOPercent = new Label();
            toolTip1 = new ToolTip(components);
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
            // tbSeed
            // 
            tbSeed.Hint = "";
            tbSeed.Location = new Point(67, 51);
            tbSeed.Name = "tbSeed";
            tbSeed.Size = new Size(123, 23);
            tbSeed.TabIndex = 1;
            tbSeed.TextAcceptor = null;
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
            groupBox1.Controls.Add(tbSeed);
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
            comboBox1.Location = new Point(67, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(207, 23);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Tag Force 3 (ULES-01183)";
            comboBox1.ValueMember = "0";
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
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
            groupBox3.Controls.Add(lbToolTipPackCount);
            groupBox3.Controls.Add(cbBoxRandomize);
            groupBox3.Controls.Add(cbPackCountRange);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cbPackPriceRange);
            groupBox3.Controls.Add(tbMinCount);
            groupBox3.Controls.Add(tbMaxCount);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(tbMinPrice);
            groupBox3.Controls.Add(tbMaxPrice);
            groupBox3.Location = new Point(13, 253);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(279, 108);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Card Shop Boxes";
            // 
            // lbToolTipPackCount
            // 
            lbToolTipPackCount.AutoSize = true;
            lbToolTipPackCount.Location = new Point(146, 77);
            lbToolTipPackCount.Name = "lbToolTipPackCount";
            lbToolTipPackCount.Size = new Size(20, 15);
            lbToolTipPackCount.TabIndex = 10;
            lbToolTipPackCount.TabStop = true;
            lbToolTipPackCount.Text = "(?)";
            // 
            // cbBoxRandomize
            // 
            cbBoxRandomize.AutoSize = true;
            cbBoxRandomize.Checked = true;
            cbBoxRandomize.CheckState = CheckState.Checked;
            cbBoxRandomize.Location = new Point(6, 22);
            cbBoxRandomize.Name = "cbBoxRandomize";
            cbBoxRandomize.Size = new Size(68, 19);
            cbBoxRandomize.TabIndex = 9;
            cbBoxRandomize.Text = "Enabled";
            cbBoxRandomize.UseVisualStyleBackColor = true;
            cbBoxRandomize.CheckedChanged += cbBoxRandomize_CheckedChanged;
            // 
            // cbPackCountRange
            // 
            cbPackCountRange.AutoSize = true;
            cbPackCountRange.Checked = true;
            cbPackCountRange.CheckState = CheckState.Checked;
            cbPackCountRange.Location = new Point(6, 76);
            cbPackCountRange.Name = "cbPackCountRange";
            cbPackCountRange.Size = new Size(144, 19);
            cbPackCountRange.TabIndex = 6;
            cbPackCountRange.Text = "Cards per pack (1 - 63)";
            cbPackCountRange.UseVisualStyleBackColor = true;
            cbPackCountRange.CheckedChanged += cbPackCountRange_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(230, 27);
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
            cbPackPriceRange.Location = new Point(6, 47);
            cbPackPriceRange.Name = "cbPackPriceRange";
            cbPackPriceRange.Size = new Size(171, 19);
            cbPackPriceRange.TabIndex = 3;
            cbPackPriceRange.Text = "Pack price range (0 - 65535)";
            cbPackPriceRange.UseVisualStyleBackColor = true;
            cbPackPriceRange.CheckedChanged += cbPackPriceRange_CheckedChanged;
            // 
            // tbMinCount
            // 
            tbMinCount.Hint = "";
            tbMinCount.Location = new Point(183, 74);
            tbMinCount.Name = "tbMinCount";
            tbMinCount.Size = new Size(41, 23);
            tbMinCount.TabIndex = 5;
            tbMinCount.TextAcceptor = null;
            // 
            // tbMaxCount
            // 
            tbMaxCount.Hint = "";
            tbMaxCount.Location = new Point(230, 74);
            tbMaxCount.Name = "tbMaxCount";
            tbMaxCount.Size = new Size(41, 23);
            tbMaxCount.TabIndex = 7;
            tbMaxCount.TextAcceptor = null;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(183, 27);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 4;
            label4.Text = "Min";
            // 
            // tbMinPrice
            // 
            tbMinPrice.Hint = "";
            tbMinPrice.Location = new Point(183, 45);
            tbMinPrice.Name = "tbMinPrice";
            tbMinPrice.Size = new Size(41, 23);
            tbMinPrice.TabIndex = 1;
            tbMinPrice.TextAcceptor = null;
            // 
            // tbMaxPrice
            // 
            tbMaxPrice.Hint = "";
            tbMaxPrice.Location = new Point(230, 45);
            tbMaxPrice.Name = "tbMaxPrice";
            tbMaxPrice.Size = new Size(41, 23);
            tbMaxPrice.TabIndex = 3;
            tbMaxPrice.TextAcceptor = null;
            // 
            // btInitSetup
            // 
            btInitSetup.Location = new Point(12, 484);
            btInitSetup.Name = "btInitSetup";
            btInitSetup.Size = new Size(98, 23);
            btInitSetup.TabIndex = 6;
            btInitSetup.Text = "Initial Setup";
            btInitSetup.UseVisualStyleBackColor = true;
            btInitSetup.Click += btInitSetup_Click;
            // 
            // btRandomize
            // 
            btRandomize.Location = new Point(12, 392);
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
            lbWarningNote.Location = new Point(12, 451);
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
            lbWaitText.Location = new Point(12, 418);
            lbWaitText.Name = "lbWaitText";
            lbWaitText.Size = new Size(143, 15);
            lbWaitText.TabIndex = 9;
            lbWaitText.Text = "Packing ISO, please wait...";
            // 
            // cbBanlist
            // 
            cbBanlist.AutoSize = true;
            cbBanlist.Location = new Point(13, 367);
            cbBanlist.Name = "cbBanlist";
            cbBanlist.Size = new Size(99, 19);
            cbBanlist.TabIndex = 10;
            cbBanlist.Text = "Enable banlist";
            cbBanlist.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(13, 451);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(279, 23);
            progressBar1.TabIndex = 11;
            progressBar1.Visible = false;
            // 
            // lbISOPercent
            // 
            lbISOPercent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbISOPercent.AutoSize = true;
            lbISOPercent.Location = new Point(248, 477);
            lbISOPercent.Name = "lbISOPercent";
            lbISOPercent.Size = new Size(32, 15);
            lbISOPercent.TabIndex = 12;
            lbISOPercent.Text = "0.0%";
            lbISOPercent.TextAlign = ContentAlignment.TopRight;
            lbISOPercent.UseMnemonic = false;
            lbISOPercent.Visible = false;
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 0;
            toolTip1.UseAnimation = false;
            toolTip1.UseFading = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 519);
            Controls.Add(lbISOPercent);
            Controls.Add(progressBar1);
            Controls.Add(cbBanlist);
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
        private CheckBox cbBoxRandomize;
        private CheckBox cbBanlist;
        private ProgressBar progressBar1;
        private Label lbISOPercent;
        private ToolTip toolTip1;
        private LinkLabel lbToolTipPackCount;
    }
}