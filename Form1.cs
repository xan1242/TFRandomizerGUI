using System.Diagnostics;

namespace TFRandomizerGUI
{
    public partial class Form1 : Form
    {
        private bool bTF3FilesExist = false;

        public Form1()
        {
            InitializeComponent();

            tbSeed.Text = new Random().Next().ToString();
            tbMinPrice.Text = "10";
            tbMaxPrice.Text = "500";
            tbMinCount.Text = "5";
            tbMaxCount.Text = "10";

            lbWaitText.Text = "";

            // acceptors
            tbSeed.TextAcceptor = Int32TextAcceptor;
            tbMinPrice.TextAcceptor = UInt16TextAcceptor;
            tbMaxPrice.TextAcceptor = UInt16TextAcceptor;
            tbMinCount.TextAcceptor = UInt16TextAcceptor2;
            tbMaxCount.TextAcceptor = UInt16TextAcceptor2;
        }
        private int ExtractISO(string InFilename, string OutFolder)
        {
            var sevenzipprocess = new Process { StartInfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = false, FileName = "7z", Arguments = "x \"" + InFilename + "\" -o\"" + OutFolder + "\"" } };
            sevenzipprocess.Start();
            sevenzipprocess.WaitForExit();
            return sevenzipprocess.ExitCode;
        }

        private int DoTFRandomizer_Recipe(bool bShuffle, string RecipeFolder, string OutFolder, bool bIncludePlayerRecipe, int RandomizerSeed)
        {
            var startinfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = true, FileName = "TFRandomizer" };
            int playerrecipe = 0;

            if (bIncludePlayerRecipe)
                playerrecipe = 1;


            if (bShuffle)
                startinfo.Arguments = "-rs ";
            else
                startinfo.Arguments = "-rr ";

            startinfo.Arguments += RecipeFolder + " " + OutFolder + " " + playerrecipe.ToString() + " " + RandomizerSeed.ToString();

            var randomizerprocess = new Process { StartInfo = startinfo };
            randomizerprocess.Start();
            randomizerprocess.WaitForExit();
            return randomizerprocess.ExitCode;
        }

        private int DoTFRandomizer_Shop(string CardIDList, string ShopPrx, int BoxInfoOffset, int SegmentOffset, int BoxCount, int MinPackPrice, int MaxPackPrice, int MinPackSize, int MaxPackSize, string OutShopPrx, int RandomizerSeed)
        {
            var startinfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = true, FileName = "TFRandomizer" };

            startinfo.Arguments = "-s " + CardIDList + " " + ShopPrx + " " + BoxInfoOffset.ToString("X") + " " + SegmentOffset.ToString("X") + " " + BoxCount.ToString() + " " + MinPackPrice.ToString() + " " + MaxPackPrice.ToString() + " " + MinPackSize.ToString() + " " + MaxPackSize.ToString() + " " + OutShopPrx + " " + RandomizerSeed.ToString();

            var randomizerprocess = new Process { StartInfo = startinfo };
            randomizerprocess.Start();
            randomizerprocess.WaitForExit();
            return randomizerprocess.ExitCode;
        }
        int ExtractEHP(string InFilename, string OutFolder)
        {
            var ehpprocess = new Process { StartInfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = true, FileName = "ehppack.exe", Arguments = "\"" + InFilename + "\" \"" + OutFolder + "\"" } };
            ehpprocess.Start();
            ehpprocess.WaitForExit();
            return ehpprocess.ExitCode;
        }

        int PackEHP(string InFolder, string OutFilename)
        {
            var ehpprocess = new Process { StartInfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = true, FileName = "ehppack.exe", Arguments = "-p \"" + InFolder + "\" \"" + OutFilename + "\"" } };
            ehpprocess.Start();
            ehpprocess.WaitForExit();
            return ehpprocess.ExitCode;
        }

        int PackPSPISO(string Folder, string OutFilename)
        {
            var startinfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = false, FileName = "mkisofs" };

            startinfo.Arguments = "-o \"" + OutFilename + "\" -A \"PSP GAME\" -sysid \"PSP GAME\" -V \"\" -N -noatime -no-pad -max-iso9660-filenames -U " + Folder;

            var mkisofsprocess = new Process { StartInfo = startinfo };
            mkisofsprocess.Start();
            mkisofsprocess.WaitForExit();
            return mkisofsprocess.ExitCode;

        }

        private void PrepareGameData(string InFilename, string OutFolder)
        {
            string ISOoutfolder = OutFolder + "/gamedata";
            string EBOOTfile = OutFolder + "/EBOOT.BIN";
            string EBOOTdest = OutFolder + "/gamedata/PSP_GAME/SYSDIR/EBOOT.BIN";

            if (!Directory.Exists(ISOoutfolder))
                Directory.CreateDirectory(ISOoutfolder);
            else
            {
                Directory.Delete(ISOoutfolder, true);
                Directory.CreateDirectory(ISOoutfolder);
            }

            ExtractISO(InFilename, ISOoutfolder);
            File.Copy(EBOOTfile, EBOOTdest, true);
        }

        private void InitializerOpenFile(string FileName)
        {
            // TODO: add support for other games
            PrepareGameData(FileName, "TF3");
            bTF3FilesExist = true;
        }

        private void StartRandomizer(string GameFolder, string OutISOName)
        {
            int theseed = Int32.Parse(tbSeed.Text);

            if (cbDeckRandom.Checked)
            {
                lbWaitText.Text = "Randomizing deck recipes...";

                string RecipeFolder = GameFolder + "/recipes";
                string OutRecipeFolder = GameFolder + "/randrecipes";
                string OutRecipeEHP = GameFolder + "/gamedata/recipes.ehp";

                if (!Directory.Exists(OutRecipeFolder))
                    Directory.CreateDirectory(OutRecipeFolder);


                if (DoTFRandomizer_Recipe(radioShuffle.Checked, RecipeFolder, OutRecipeFolder, cbPlayerDeck.Checked, theseed) != 0)
                {
                    lbWaitText.Text = "Error during recipe randomization.";
                    return;
                }
                // pack and copy ehp to disc root
                PackEHP(OutRecipeFolder, OutRecipeEHP);
            }

            if (cbPackPriceRange.Checked || cbPackCountRange.Checked)
            {
                lbWaitText.Text = "Randomizing card boxes...";

                // TODO: paths for TF1 and 6 are slightly different
                string CardIDListFile = GameFolder + "/cardlist.ini";
                string ShopPRXFile = GameFolder + "/rel_shop.prx";
                string OutShopPrxFile = GameFolder + "/gamedata/PSP_GAME/USRDIR/gmodule/rel_shop.prx";
                int MinPrice = -1;
                int MaxPrice = -1;
                int MinCount = -1;
                int MaxCount = -1;

                if (cbPackPriceRange.Checked)
                {
                    MinPrice = Int16.Parse(tbMinPrice.Text);
                    MaxPrice = Int16.Parse(tbMaxPrice.Text);
                }

                if (cbPackCountRange.Checked)
                {
                    MinCount = Int16.Parse(tbMinCount.Text);
                    MaxCount = Int16.Parse(tbMaxCount.Text);
                }

                // TODO: add support for other games - currently this is using TF3 offsets
                int BoxInfoOffset = 0x20324;
                int SegmentOffset = 0x54;
                int BoxCount = 48;

                if (DoTFRandomizer_Shop(CardIDListFile, ShopPRXFile, BoxInfoOffset, SegmentOffset, BoxCount, MinPrice, MaxPrice, MinCount, MaxCount, OutShopPrxFile, theseed) != 0)
                {
                    lbWaitText.Text = "Error during shop randomization.";
                    return;
                }
            }

            if (cbDeckRandom.Checked || cbPackPriceRange.Checked || cbPackCountRange.Checked)
            {
                string discRootPath = GameFolder + "/gamedata";
                //lbWaitText.Visible = true;
                lbWaitText.Text = "Packing ISO, please wait...\nCheck the console window if it appears stuck.";
                if (PackPSPISO(discRootPath, OutISOName) != 0)
                {
                    lbWaitText.Text = "Error during ISO packing.";
                    return;
                }
                //lbWaitText.Visible = false;
            }
            lbWaitText.Text = "";
        }

        private bool Int32TextAcceptor(string oldText, string newText, string input, int offset, int length)
        {
            int value = 0;
            return Int32.TryParse(newText, out value);
        }

        private bool UInt16TextAcceptor(string oldText, string newText, string input, int offset, int length)
        {
            UInt16 value = 0;
            return UInt16.TryParse(newText, out value);
        }

        private bool UInt16TextAcceptor2(string oldText, string newText, string input, int offset, int length)
        {
            UInt16 value = 0;

            if (UInt16.TryParse(newText, out value))
            {
                if ((value * 4) <= 0xFFFF)
                    return true;
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbSeed.Text = new Random().Next().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("TF3/gamedata/PSP_GAME"))
                bTF3FilesExist = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbDeckRandom_CheckedChanged(object sender, EventArgs e)
        {
            radioRandomize.Enabled = cbDeckRandom.Checked;
            radioShuffle.Enabled = cbDeckRandom.Checked;
            cbPlayerDeck.Enabled = cbDeckRandom.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((!cbPackPriceRange.Checked && !cbPackCountRange.Checked && !cbDeckRandom.Checked) || !bTF3FilesExist)
                btRandomize.Enabled = false;
            else
                btRandomize.Enabled = true;

            if (!bTF3FilesExist)
                lbWarningNote.Visible = true;
            else
                lbWarningNote.Visible = false;
        }

        private void btInitSetup_Click(object sender, EventArgs e)
        {
            if (ofDialogInitSetup.ShowDialog() == DialogResult.OK)
                InitializerOpenFile(ofDialogInitSetup.FileName);
        }

        private void btRandomize_Click(object sender, EventArgs e)
        {
            if (sfDialogRandomizer.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfDialogRandomizer.FileName))
                    File.Delete(sfDialogRandomizer.FileName);

                StartRandomizer("TF3", sfDialogRandomizer.FileName);
                MessageBox.Show("Randomization complete!");
            }
        }

        private void cbPackPriceRange_CheckedChanged(object sender, EventArgs e)
        {
            tbMinPrice.Enabled = cbPackPriceRange.Checked;
            tbMaxPrice.Enabled = cbPackPriceRange.Checked;
        }

        private void cbPackCountRange_CheckedChanged(object sender, EventArgs e)
        {
            tbMinCount.Enabled = cbPackCountRange.Checked;
            tbMaxCount.Enabled = cbPackCountRange.Checked;
        }
    }
}