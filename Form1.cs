using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using static TFRandomizerGUI.GameInfo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TFRandomizerGUI
{
    public partial class Form1 : Form
    {
        private bool bFilesExist = false;
        private GameType selectedGameType = GameType.TF3_EU;
        StringBuilder ISOPackOutput = new StringBuilder();
        private bool bCurrentlyPacking = false;

        public Form1()
        {
            InitializeComponent();

            tbSeed.Text = new Random().Next().ToString();
            tbMinPrice.Text = "10";
            tbMaxPrice.Text = "500";
            tbMinCount.Text = "1";
            tbMaxCount.Text = "8";

            lbWaitText.Text = "";

            // acceptors
            tbSeed.TextAcceptor = Int32TextAcceptor;
            tbMinPrice.TextAcceptor = UInt16TextAcceptor;
            tbMaxPrice.TextAcceptor = UInt16TextAcceptor;
            tbMinCount.TextAcceptor = UInt8TextAcceptor;
            tbMaxCount.TextAcceptor = UInt8TextAcceptor;

            PopulateComboBox();
            comboBox1.SelectedItem = selectedGameType;

            toolTip1.SetToolTip(lbToolTipPackCount, "This will affect how many cards there are in a pack.\nWARNING: Going over 8 cards per pack is unstable and can crash the shop!");
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

        // int ExtractEHP(string InFilename, string OutFolder)
        // {
        //     var ehpprocess = new Process { StartInfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = true, FileName = "ehppack.exe", Arguments = "\"" + InFilename + "\" \"" + OutFolder + "\"" } };
        //     ehpprocess.Start();
        //     ehpprocess.WaitForExit();
        //     return ehpprocess.ExitCode;
        // }

        int PackEHP(string InFolder, string OutFilename)
        {
            var ehpprocess = new Process { StartInfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = true, FileName = "ehppack.exe", Arguments = "-p \"" + InFolder + "\" \"" + OutFilename + "\"" } };
            ehpprocess.Start();
            ehpprocess.WaitForExit();
            return ehpprocess.ExitCode;
        }

        int PackPSPISO(string Folder, string OutFilename)
        {
            var startinfo = new ProcessStartInfo { UseShellExecute = false, CreateNoWindow = true, FileName = "mkisofs" };

            startinfo.RedirectStandardError = true;
            startinfo.Arguments = "-o \"" + OutFilename + "\" -A \"PSP GAME\" -sysid \"PSP GAME\" -V \"\" -N -noatime -no-pad -max-iso9660-filenames -U " + Folder;

            var mkisofsprocess = new Process { StartInfo = startinfo };

            mkisofsprocess.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
#if DEBUG
                    Console.WriteLine(e.Data);
#endif
                    ISOPackOutput.Append(e.Data + "\n");
                    if (e.Data.Contains("done"))
                    {
                        string percentData = e.Data;
                        percentData = percentData.Trim();
                        percentData = percentData.Substring(0, percentData.IndexOf("%"));
                        if (float.TryParse(percentData, NumberStyles.Float, CultureInfo.InvariantCulture, out float percentage))
                        {
                            UpdateProgressBar(percentage, percentData);
                        }
                    }
                    else if (e.Data.Contains("Total"))
                    {
                        UpdateProgressBar(100.0f, "100.00");
                    }
                }
            });
            ISOPackOutput.Clear();
            mkisofsprocess.Start();

            mkisofsprocess.BeginErrorReadLine();
            mkisofsprocess.WaitForExit();

            return mkisofsprocess.ExitCode;
        }

        private void UpdateProgressBar(float percentage, string pctText)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action<float, string>(UpdateProgressBar), percentage, pctText);
            }
            else
            {
                // Update the ProgressBar value on the UI thread
                progressBar1.Value = (int)(percentage);
                lbISOPercent.Text = pctText + '%';
            }
        }

        private void OnISOPackComplete(int exitCode)
        {
            if (exitCode != 0)
            {
                progressBar1.Visible = false;
                lbISOPercent.Visible = false;
                lbWaitText.Text = "Error during ISO packing.\nCheck the \"mkisofs.log\" file for more information.";
                File.WriteAllText("mkisofs.log", ISOPackOutput.ToString());
                MessageBox.Show("Randomization failed.");
            }
            else
            {
                lbWaitText.Text = "";
                MessageBox.Show("Randomization complete!");
                lbISOPercent.Visible = false;
                progressBar1.Visible = false;
            }
            bCurrentlyPacking = false;
            btRandomize.Enabled = true;
            btInitSetup.Enabled = true;
        }

        private void PrepareGameData(string InFilename, string OutFolder)
        {
            string ISOoutfolder = OutFolder + "/gamedata";
            //string EBOOTfile = OutFolder + "/EBOOT.BIN";
            //string EBOOTdest = OutFolder + "/gamedata/PSP_GAME/SYSDIR/EBOOT.BIN";

            if (!Directory.Exists(ISOoutfolder))
                Directory.CreateDirectory(ISOoutfolder);
            else
            {
                Directory.Delete(ISOoutfolder, true);
                Directory.CreateDirectory(ISOoutfolder);
            }
            lbWaitText.Text = "Extracting ISO, please wait...";
            lbWaitText.Visible = true;
            ExtractISO(InFilename, ISOoutfolder);
            lbWaitText.Visible = false;
            //File.Copy(EBOOTfile, EBOOTdest, true);
        }

        private void InitializerOpenFile(string FileName)
        {
            PrepareGameData(FileName, GameInfo.GameShortNames[selectedGameType]);
            bFilesExist = true;
        }

        private void StartRandomizer(string GameFolder, string OutISOName)
        {
            btRandomize.Enabled = false;
            btInitSetup.Enabled = false;
            bCurrentlyPacking = true;
            int theseed = Int32.Parse(tbSeed.Text);

            string EBOOTfile = GameFolder + "/EBOOT.BIN";
            if (!cbBanlist.Checked)
                EBOOTfile = GameFolder + "/EBOOT_NoBanlist.BIN";

            string EBOOTdest = GameFolder + "/gamedata/PSP_GAME/SYSDIR/EBOOT.BIN";

            File.Copy(EBOOTfile, EBOOTdest, true);

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
            else
            {
                string RecipeFolder = GameFolder + "/recipes";
                string OutRecipeEHP = GameFolder + "/gamedata/recipes.ehp";
                PackEHP(RecipeFolder, OutRecipeEHP);
            }

            if (cbBoxRandomize.Checked)
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
                    MinCount = byte.Parse(tbMinCount.Text);
                    MaxCount = byte.Parse(tbMaxCount.Text);
                }

                int BoxInfoOffset = GameShopInfo.BoxInfoOffsets[selectedGameType];
                int SegmentOffset = GameShopInfo.SegmentOffsets[selectedGameType];
                int BoxCount = GameShopInfo.BoxCounts[selectedGameType];

                if (DoTFRandomizer_Shop(CardIDListFile, ShopPRXFile, BoxInfoOffset, SegmentOffset, BoxCount, MinPrice, MaxPrice, MinCount, MaxCount, OutShopPrxFile, theseed) != 0)
                {
                    lbWaitText.Text = "Error during shop randomization.";
                    return;
                }
            }
            else
            {
                string ShopPRXFile = GameFolder + "/rel_shop.prx";
                string OutShopPrxFile = GameFolder + "/gamedata/PSP_GAME/USRDIR/gmodule/rel_shop.prx";
                File.Copy(ShopPRXFile, OutShopPrxFile, true);
            }

            if (cbDeckRandom.Checked || cbPackPriceRange.Checked || cbPackCountRange.Checked)
            {
                string discRootPath = GameFolder + "/gamedata";
                //lbWaitText.Visible = true;
                lbWaitText.Text = "Packing ISO, please wait...";
                lbISOPercent.Text = "0.00%";
                progressBar1.Value = 0;
                lbISOPercent.Visible = true;
                progressBar1.Visible = true;

                Task.Run(() => PackPSPISO(discRootPath, OutISOName))
            .ContinueWith(task => OnISOPackComplete(task.Result),
                          TaskScheduler.FromCurrentSynchronizationContext());

            }
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

        private bool UInt8TextAcceptor(string oldText, string newText, string input, int offset, int length)
        {
            byte value = 0;

            if (byte.TryParse(newText, out value))
            {
                if ((value * 4) <= 0xFF)
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
            if (Directory.Exists(GameInfo.GameShortNames[selectedGameType] + "/gamedata/PSP_GAME"))
                bFilesExist = true;
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
            if ((!cbPackPriceRange.Checked && !cbPackCountRange.Checked && !cbDeckRandom.Checked) || !bFilesExist || bCurrentlyPacking)
                btRandomize.Enabled = false;
            else
                btRandomize.Enabled = true;

            if (!bFilesExist)
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

                StartRandomizer(GameInfo.GameShortNames[selectedGameType], sfDialogRandomizer.FileName);
                //MessageBox.Show("Randomization complete!");
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

        private void cbBoxRandomize_CheckedChanged(object sender, EventArgs e)
        {
            cbPackPriceRange.Enabled = cbBoxRandomize.Checked;
            cbPackCountRange.Enabled = cbBoxRandomize.Checked;
            label4.Enabled = cbBoxRandomize.Checked;
            label6.Enabled = cbBoxRandomize.Checked;
            tbMinPrice.Enabled = cbBoxRandomize.Checked;
            tbMinCount.Enabled = cbBoxRandomize.Checked;
            tbMaxPrice.Enabled = cbBoxRandomize.Checked;
            tbMaxCount.Enabled = cbBoxRandomize.Checked;
        }

        private void PopulateComboBox()
        {
            foreach (GameType gameType in Enum.GetValues(typeof(GameType)))
            {
                string description = EnumHelper.GetEnumDescription(gameType);
                comboBox1.Items.Add(description);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedDescription = comboBox1.SelectedItem.ToString();

            // Find the matching enum value based on the description
            foreach (GameType gameType in Enum.GetValues(typeof(GameType)))
            {
                if (selectedDescription == EnumHelper.GetEnumDescription(gameType))
                {
                    selectedGameType = gameType;
                    break;
                }
            }

            if (Directory.Exists(GameInfo.GameShortNames[selectedGameType] + "/gamedata/PSP_GAME"))
                bFilesExist = true;
            else
                bFilesExist = false;
        }
    }
}