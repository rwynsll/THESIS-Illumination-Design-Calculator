using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void addToHistory(string result)
        {

            richtbHistory.Text = result + "\n\n" + richtbHistory.Text ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This is a calculator designed to aid in Illumination Design.", "W E L C O M E");
        }

        double _PI = Math.PI;

        private void button1_Click(object sender, EventArgs e)  
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            p.WaitForInputIdle();
        }


        private void computeLuminaires()
        {
            var length = numLuminairesLength.Value;
            var width = numLuminairesWidth.Value;
            var lumens = numLuminairesLumens.Value;
            var lamps = numLuminairesLamps.Value;
            var cu = numLuminairesCU.Value;
            var mf = numLuminairesMF.Value;
            var illumination = numLuminairesIllumination.Value;

            var top = length * width * illumination;
            var bottom = lamps * lumens * cu * mf;

            if (bottom == 0)
            {
                MessageBox.Show("One of the parameters is zero. Please check and retry.", "Error");
                bottom = 1;
                top = 0;
            }

            var luminaires = top / bottom;

            textLuminairesOutput.Text = luminaires.ToString("#.##");

            // add to history 

            if (luminaires == 0)
            {
                string res = "Error \n";
                addToHistory(res);
            }
            else
            {
                string res = "Number of Luminaires : " + textLuminairesOutput.Text + "   pieces \n";
                addToHistory(res);
            }


        }

        private void computeIllumination()
        {
            var length = numIllumLength.Value;
            var width = numIllumWidth.Value;
            var lumens = numIllumLumens.Value;
            var cu = numIllumCU.Value;
            var mf = numIllumMF.Value;

            var top = lumens * cu;
            var bottom = length * width;

            if (bottom == 0)
            {
                MessageBox.Show("One of the parameters is zero. Please check and retry.", "Error");
                bottom = 1;
                top = 0;
            }

            var initial = top / bottom;
            var maintained = initial * mf;

            textIllumOutputInit.Text = initial.ToString("#.##");
            textIllumOutputMaintained.Text = maintained.ToString("#.##");

            // add to history 

            if (initial == 0)
            {
                string res = "Error \n";
                addToHistory(res);
            }
            else
            {
                string res = "Initial Illumination : " + textIllumOutputInit.Text + "   " + lb24.Text + "\n";
                res += "Maintained Illumination : " + textIllumOutputMaintained.Text + "   " + lb25.Text + "\n";
                addToHistory(res);
            }

        }

        private void computeLuminance()
        {
            var length = numLuminanceLength.Value;
            var width = numLuminanceWidth.Value;
            var lumens = numLuminanceLumens.Value;
            var lamps = numLuminanceLamps.Value;
            var tf = numLuminanceTF.Value;

            var top = lamps * lumens * tf;
            var bottom = length * width;

            if (bottom == 0)
            {
                MessageBox.Show("One of the parameters is zero. Please check and retry.", "Error");
                bottom = 1;
                top = 0;
            }

            var luminance = top / bottom;

            textLuminanceOutput.Text = luminance.ToString("#.##");

            // add to history 
            if (luminance == 0)
            {
                string res = "Error \n";
                addToHistory(res);
            }
            else
            {
                string res = "Luminance : " + textLuminanceOutput.Text + "   " + lb34.Text + "\n";
                addToHistory(res);
            }

        }

        private void computeTwo()
        {
            var length = numTwoLength.Value;
            var width = numTwoWidth.Value;
            var height = numTwoHeight.Value;
            var lumens = numTwoLumens.Value;

            double fourpi = 4 * _PI;
            double i = (double)lumens / (double)fourpi;
            length = length / 2;
            width = width / 2;

            if (height == 0)
            {
                length = 1;
                height = 1;
            } 

            var ratio = length / height;
            var atan = Math.Atan((double)ratio);
            double cosine = Math.Cos((double)atan);
            double top = (double)i * (double)cosine;

            length = length * length;
            width = width * width;
            var bottom = length + width;

            if (bottom == 0)
            {
                MessageBox.Show("One of the parameters is zero. Please check and retry.", "Error");
                bottom = 1;
                top = 0;
            }

            double two = (double)top / (double)bottom;

            textTwoOutput.Text = two.ToString("#.##");

            // add to history 

            if (two == 0)
            {
                string res = "Error \n";
                addToHistory(res);
            }
            else
            {
                string res = "2D Point-by-Point : " + textTwoOutput.Text + "   " + lb45.Text + "\n\n";
                addToHistory(res);
            }

        }

        private void computeThree()
        {
            var length = numTwoLength.Value;
            var width = numTwoWidth.Value;
            var height = numTwoHeight.Value;
            var lumens = numTwoLumens.Value;

            double fourpi = 4 * _PI;
            double i = (double)lumens / (double)fourpi;
            double top = (double)i * (double)height;

            var halflength = length / 2;
            halflength = halflength * halflength;
            var halfwidth = width / 2;
            halfwidth = halfwidth * halfwidth;
            height = height * height;
            var square = height + halfwidth + halflength;
            double bottom = Math.Pow((double)square, (double)1.5);

            if (bottom == 0)
            {
                MessageBox.Show("One of the parameters is zero. Please check and retry.", "Error");
                bottom = 1;
                top = 0;
            }

            double three = (double)top / (double)bottom;

            textThreeOutput.Text = three.ToString("#.##");

            // add to history 

            if (three == 0)
            {
                string res = "Error \n";
                addToHistory(res);
            }
            else
            {
                string res = "3D Point-by-Point : " + textThreeOutput.Text + "   " + lb55.Text + "\n\n";
                addToHistory(res);
            }

        }

        private void computeCavity()
        {

            var length = numCavityLength.Value;
            var width = numCavityWidth.Value;
            var rh = numCavityRH.Value;
            var h = rh;
            var wph = numCavityWPH.Value;
            var cch = numCavityCCH.Value;
            var fch = wph;
            var rch = rh - fch;
            rch = rch - cch;

            if (cch > h)
            {
                MessageBox.Show("The ceiling cavity height exceeds the room height. Please review the input then retry.", "Error");
                h = 0;
                cch = 0;
            }

            if (fch > h)
            {
                MessageBox.Show("The work plane height exceeds the room height. Please review the input then retry.", "Error");
                h = 0;
                fch = 0;
            }

            if (comboCavity.SelectedIndex == 0)
            {
                h = 5 * rh;
            }
            if (comboCavity.SelectedIndex == 1)
            {
                h = 5 * rch;
            }
            if (comboCavity.SelectedIndex == 2)
            {
                h = 5 * cch;
            }
            if (comboCavity.SelectedIndex == 3)
            {
                h = 5 * fch;
            }
            if (comboCavity.SelectedIndex == 4)
            {
                h = rh;
            }

            var lw = length + width;
            var top = h * lw;
            var bottom = length * width;

            if (bottom == 0)
            {
                MessageBox.Show("One of the parameters is zero. Please check and retry.", "Error");
                bottom = 1;
                top = 0;
            }

            var cavity = top / bottom;
            if (comboCavity.SelectedIndex == 4)
            {
                if (top != 0)
                {

                    cavity = 1 / cavity;
                    textCavityOutput.Text = cavity.ToString("#.##");
                }

            }
            else
            {
                textCavityOutput.Text = cavity.ToString("#.##");
            }
            

            // add to history 
            
            if (cavity == 0)
            {
                string res = "Error \n";
                addToHistory(res);
            }
            else
            {
                if (comboCavity.SelectedIndex == 0)
                {
                    string res = "Cavity Ratio : " + textCavityOutput.Text + "\n\n";
                    addToHistory(res);
                }
                if (comboCavity.SelectedIndex == 1)
                {
                    string res = "Room Cavity Ratio : " + textCavityOutput.Text + "\n\n";
                    addToHistory(res);
                }
                if (comboCavity.SelectedIndex == 2)
                {
                    string res = "Ceiling Cavity Ratio : " + textCavityOutput.Text + "\n\n";
                    addToHistory(res);
                }
                if (comboCavity.SelectedIndex == 3)
                {
                    string res = "Floor Cavity Ratio : " + textCavityOutput.Text + "\n\n";
                    addToHistory(res);
                }
                if (comboCavity.SelectedIndex == 4)
                {
                    string res = "Room Index : " + textCavityOutput.Text + "\n\n";
                    addToHistory(res);
                }
            }
        }
        
        private void buttonIllumCalculate_Click(object sender, EventArgs e)
        {
            computeIllumination();
        }


        private void buttonLuminairesCalculate_Click(object sender, EventArgs e)
        {
            computeLuminaires();
        }

        private void buttonLuminanceCalculate_Click(object sender, EventArgs e)
        {
            computeLuminance();
        }

        private void buttonTwoCalculate(object sender, EventArgs e)
        {
            computeTwo();
            computeThree();
        }

        private void buttonCavityCalculate_Click(object sender, EventArgs e)
        {
            computeCavity();
        }

        #region nonuseful


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void rdbEnglish_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }


        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

      


        #endregion

        decimal mft = 3.28084M;
        decimal ftm = 0.3048M;
        decimal luxfc = 0.0929030436M;
        decimal fclux = 10.7639M;

        /*
        decimal millifoot = 0.9290303997M;
        decimal footmilli = 1.076391042M;
        */
           
        private void rdbEnglish_Click(object sender, EventArgs e)
        {
            lb11.Text = "feet";
            lb12.Text = "feet";
            lb14.Text = "fc";
            lb21.Text = "feet";
            lb22.Text = "feet";
            lb24.Text = "fc";
            lb25.Text = "fc";
            lb31.Text = "feet";
            lb32.Text = "feet";
            lb34.Text = "ftLambert";
            lb41.Text = "feet";
            lb42.Text = "feet";
            lb43.Text = "feet";
            lb45.Text = "fc";
            lb55.Text = "fc";
            lb61.Text = "feet";
            lb62.Text = "feet";
            lb63.Text = "feet";
            lb64.Text = "feet";
            lb65.Text = "feet";

            numLuminairesLength.Value = (decimal)numLuminairesLength.Value * mft;
            numLuminairesWidth.Value = (decimal)numLuminairesWidth.Value * mft;
            numLuminairesIllumination.Value = (decimal)numLuminairesIllumination.Value * luxfc;
            textLuminairesOutput.Text = String.Empty;
            numIllumLength.Value = (decimal)numIllumLength.Value * mft;
            numIllumWidth.Value = (decimal)numIllumWidth.Value * mft;
            textIllumOutputInit.Text = String.Empty;
            textIllumOutputMaintained.Text = String.Empty;
            numLuminanceLength.Value = (decimal)numLuminanceLength.Value * mft;
            numLuminanceWidth.Value = (decimal)numLuminanceWidth.Value * mft;
            textLuminanceOutput.Text = String.Empty;
            numTwoLength.Value = (decimal)numTwoLength.Value * mft;
            numTwoWidth.Value = (decimal)numTwoWidth.Value * mft;
            numTwoHeight.Value = (decimal)numTwoHeight.Value * mft;
            textTwoOutput.Text = String.Empty;
            textThreeOutput.Text = String.Empty;
            numCavityLength.Value = (decimal)numCavityLength.Value * mft;
            numCavityWidth.Value = (decimal)numCavityWidth.Value * mft;
            numCavityRH.Value = (decimal)numCavityRH.Value * mft;
            numCavityWPH.Value = (decimal)numCavityWPH.Value * mft;
            numCavityCCH.Value = (decimal)numCavityCCH.Value * mft;
            textCavityOutput.Text = String.Empty;

            MessageBox.Show("Unit system has been set to English. Press 'Calculate' to recalculate the Output.", "Unit System Changed");

        }

        private void rdbMetric_Click(object sender, EventArgs e)
        {
            lb11.Text = "meters";
            lb12.Text = "meters";
            lb14.Text = "lux";
            lb21.Text = "meters";
            lb22.Text = "meters";
            lb24.Text = "lux";
            lb25.Text = "lux";
            lb31.Text = "meters";
            lb32.Text = "meters";
            lb34.Text = "mLambert";
            lb41.Text = "meters";
            lb42.Text = "meters";
            lb43.Text = "meters";
            lb45.Text = "lux";
            lb55.Text = "lux";
            lb61.Text = "meters";
            lb62.Text = "meters";
            lb63.Text = "meters";
            lb64.Text = "meters";
            lb65.Text = "meters";

            numLuminairesLength.Value = (decimal)numLuminairesLength.Value * ftm;
            numLuminairesWidth.Value = (decimal)numLuminairesWidth.Value * ftm;
            numLuminairesIllumination.Value = (decimal)numLuminairesIllumination.Value * fclux;
            textLuminairesOutput.Text = String.Empty;
            numIllumLength.Value = (decimal)numIllumLength.Value * ftm;
            numIllumWidth.Value = (decimal)numIllumWidth.Value * ftm;
            textIllumOutputInit.Text = String.Empty;
            textIllumOutputMaintained.Text = String.Empty;
            numLuminanceLength.Value = (decimal)numLuminanceLength.Value * ftm;
            numLuminanceWidth.Value = (decimal)numLuminanceWidth.Value * ftm;
            textLuminanceOutput.Text = String.Empty;
            numTwoLength.Value = (decimal)numTwoLength.Value * ftm;
            numTwoWidth.Value = (decimal)numTwoWidth.Value * ftm;
            numTwoHeight.Value = (decimal)numTwoHeight.Value * ftm;
            textTwoOutput.Text = String.Empty;
            textThreeOutput.Text = String.Empty;
            numCavityLength.Value = (decimal)numCavityLength.Value * ftm;
            numCavityWidth.Value = (decimal)numCavityWidth.Value * ftm;
            numCavityRH.Value = (decimal)numCavityRH.Value * ftm;
            numCavityWPH.Value = (decimal)numCavityWPH.Value * ftm;
            numCavityCCH.Value = (decimal)numCavityCCH.Value * ftm;
            textCavityOutput.Text = String.Empty;

            MessageBox.Show("Unit system has been set to Metric. Press 'Calculate' to recalculate the Output.", "Unit System Changed");

        }

        private void numIllumLength_Enter(object sender, EventArgs e)
        {
            //numIllumLength.Select(0, numIllumLength.Text.Length);
            numericUpdownSelectAll((NumericUpDown)sender);
        }

        private void numericUpdownSelectAll(NumericUpDown a)
        {
            a.Select(0, a.Text.Length);
        }
        

        //help
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            this.Width = 1100;
        }

        private void buttonHelpHide_Click(object sender, EventArgs e)
        {
            this.Width = 700;
        }

        private void buttonHelpChoose_Click(object sender, EventArgs e)
        {
            if (comboHelp.SelectedIndex == 0)
            {
                rtbHelp.Text = "          " +
                    "Spacing to Height ratio (SHR or S/Hm) is defined as the ratio of the distance between" +
                    " adjacent luminaires (centre to centre), to their height above the working plane." +
                    " For a rectangular arrangement of luminaires and by approximation,";
                pictureSpacing.Visible = true;
                pictureSpacingLayout11.Visible = false;
                pictureSpacingLayout12.Visible = false;
                pictureSpacingLayout21.Visible = false;
                pictureSpacingLayout22.Visible = false;
                pictureSpacing.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureRoomIndex11.Visible = false;
                pictureRoomIndex12.Visible = false;
                pictureRoomIndex21.Visible = false;
                pictureRoomIndex22.Visible = false;
                buttonSpaceHide();
                buttonRoomHide();
            }
            if (comboHelp.SelectedIndex == 1)
            {
                rtbHelp.Text = "          " +
                    "LUMINAIRE SPACING depends upon the customer and the designer itself." +
                    " There are several ways to design the luminaire spacing and these tables" +
                    " provide the typical arrangement of said luminaires. \n\n" +
                "Typical luminaires in various interiors \n\n";
                pictureSpacing.Visible = false;
                pictureSpacingLayout11.Visible = true;
                buttonSpaceShow();
                buttonRoomHide();
                pictureSpacingLayout11.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureSpacingLayout12.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureSpacingLayout21.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureSpacingLayout22.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureRoomIndex11.Visible = false;
                pictureRoomIndex12.Visible = false;
                pictureRoomIndex21.Visible = false;
                pictureRoomIndex22.Visible = false;

            }
            if (comboHelp.SelectedIndex == 2)
            {
                rtbHelp.Text = "          ";
                pictureRoomIndex11.Visible = true;
                pictureSpacing.Visible = false;
                pictureSpacingLayout11.Visible = false;
                pictureSpacingLayout12.Visible = false;
                pictureSpacingLayout21.Visible = false;
                pictureSpacingLayout22.Visible = false;
                buttonRoomShow();
                buttonSpaceHide();
                pictureRoomIndex11.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureRoomIndex12.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureRoomIndex21.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureRoomIndex22.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (comboHelp.SelectedIndex == 3)
            {
                rtbHelp.Text = "          \n" + "TYPES OF LUMINAIRES" +
                    "(this affects the mounting height for the spacing formula, heights depends on distance from floor to luminaire) \n\n" +
                    "     - RECESSED. Installed above the ceiling, this type of lighting has an opening that is flush with the ceiling." +
                    " A recessed light requires at least 6 inches of clearance above the ceiling, and insulation is essential to ensure that" +
                    " condensation does not drip into the fixture. Recessed lighting sends a relatively narrow band of light in one direction;" +
                    " it can be used to provide ambient, task or accent lighting. \n\n" +
                    "     - TRACK. Mounted or suspended from the ceiling, track lighting consists of a linear housing containing several heads" +
                    " that can be positioned anywhere along a track; the direction of the heads is adjustable also. Track lighting is often used" +
                    " for task or accent lighting. \n\n" +
                    "     - UNDERCABINET. Mounted under kitchen cabinets, this type of lighting can be linear or a single puck-shaped fixture." +
                    " Undercabinet lighting is extremely popular as task lighting in a kitchen. \n\n" +
                    "    PENDANTS. Suspended from the ceiling, a pendant light directs its light down, typically over a table or kitchen island." +
                    " A pendant can enhance the decorative style of a room. Pendants can provide ambient or task lighting. (indirect) \n\n" +
                    "     - CHANDELIERS. Suspended from the ceiling, chandeliers direct their light upward, typically over a table." +
                    " They can enhance the decorative style of a room. Chandeliers provide ambient lighting. \n\n" +
                    "     - CEILING. This type of fixture is mounted directly to the ceiling and has a glass or plastic shade concealing the light bulb." +
                    " Ceiling fixtures have been common in homes for nearly a hundred years, often providing all the ambient light in a room.\n\n" +
                    "     - WALL SCONES. Surface-mounted to the wall, sconces can direct light upwards or downwards, and their covers or shades" +
                    " can add a stylistic touch to a room. Wall sconces provide ambient or task lighting. \n\n" +
                    "     - DESK, FLOOR, AND TABLE LAMPS. Made in a wide range of sizes and styles, lamps are extremely versatile and portable" +
                    " sources of light in a room. Most lamps direct light downward, with the exception of a torchiere, which is a floor lamp that" +
                    " directs its light upward. Lamps are often used as task lights, particularly for reading, but can also provide ambient light. \n\n";
                pictureSpacing.Visible = false;
                pictureSpacingLayout11.Visible = false;
                pictureSpacingLayout12.Visible = false;
                pictureSpacingLayout21.Visible = false;
                pictureSpacingLayout22.Visible = false;
                pictureRoomIndex11.Visible = false;
                pictureRoomIndex12.Visible = false;
                pictureRoomIndex21.Visible = false;
                pictureRoomIndex22.Visible = false;
                buttonSpaceHide();
                buttonRoomHide();
            }
        }

        private void buttonSpaceShow()
        {
            buttonSpacingLayout1.Visible = true;
            buttonSpacingLayout2.Visible = true;
            buttonSpacingLayout3.Visible = true;
            buttonSpacingLayout4.Visible = true;
        }
        private void buttonSpaceHide()
        {
            buttonSpacingLayout1.Visible = false;
            buttonSpacingLayout2.Visible = false;
            buttonSpacingLayout3.Visible = false;
            buttonSpacingLayout4.Visible = false;
        }
        private void buttonRoomShow()
        {
            buttonRoomIndex1.Visible = true;
            buttonRoomIndex2.Visible = true;
            buttonRoomIndex3.Visible = true;
            buttonRoomIndex4.Visible = true;
        }
        private void buttonRoomHide()
        {
            buttonRoomIndex1.Visible = false;
            buttonRoomIndex2.Visible = false;
            buttonRoomIndex3.Visible = false;
            buttonRoomIndex4.Visible = false;
        }
        //spacing layout
        private void buttonSpacingLayout1_Click(object sender, EventArgs e)
        {
            pictureSpacingLayout11.Visible = true;
            pictureSpacingLayout12.Visible = false;
            pictureSpacingLayout21.Visible = false;
            pictureSpacingLayout22.Visible = false;
        }

        private void buttonSpacingLayout2_Click(object sender, EventArgs e)
        {
            pictureSpacingLayout11.Visible = false;
            pictureSpacingLayout12.Visible = true;
            pictureSpacingLayout21.Visible = false;
            pictureSpacingLayout22.Visible = false;
        }

        private void buttonSpacingLayout3_Click(object sender, EventArgs e)
        {
            pictureSpacingLayout11.Visible = false;
            pictureSpacingLayout12.Visible = false;
            pictureSpacingLayout21.Visible = true;
            pictureSpacingLayout22.Visible = false;
        }

        private void buttonSpacingLayout4_Click(object sender, EventArgs e)
        {
            pictureSpacingLayout11.Visible = false;
            pictureSpacingLayout12.Visible = false;
            pictureSpacingLayout21.Visible = false;
            pictureSpacingLayout22.Visible = true;
        }

        private void buttonRoomIndex1_Click(object sender, EventArgs e)
        {
            pictureRoomIndex11.Visible = true;
            pictureRoomIndex12.Visible = false;
            pictureRoomIndex21.Visible = false;
            pictureRoomIndex22.Visible = false;
        }

        private void buttonRoomIndex2_Click(object sender, EventArgs e)
        {
            pictureRoomIndex11.Visible = false;
            pictureRoomIndex12.Visible = true;
            pictureRoomIndex21.Visible = false;
            pictureRoomIndex22.Visible = false;
        }

        private void buttonRoomIndex3_Click(object sender, EventArgs e)
        {
            pictureRoomIndex11.Visible = false;
            pictureRoomIndex12.Visible = false;
            pictureRoomIndex21.Visible = true;
            pictureRoomIndex22.Visible = false;
        }

        private void buttonRoomIndex4_Click(object sender, EventArgs e)
        {
            pictureRoomIndex11.Visible = false;
            pictureRoomIndex12.Visible = false;
            pictureRoomIndex21.Visible = false;
            pictureRoomIndex22.Visible = true;
        }

    }
}
