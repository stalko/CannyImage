using ColorCannyBitmap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorCannyImage
{
    public partial class ColorCannyImage : Form
    {
        public ColorCannyImage()
        {
            InitializeComponent();
        }

        Canny CannyData;
        private void uploadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                //System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                //sr.Close();
                try
                {
                    pictureBox1.ImageLocation = ofd.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    //IrisImage.Image = Bitmap.FromFile(ofd.FileName);
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cannyButton_Click(object sender, EventArgs e)
        {
            float TH, TL, Sigma;
            int MaskSize;

            TH = (float)Convert.ToDouble(TxtTH.Text);
            TL = (float)Convert.ToDouble(TxtTL.Text);

            MaskSize = Convert.ToInt32(TxtGMask.Text);
            Sigma = (float)Convert.ToDouble(TxtSigma.Text);
            CannyData = new Canny((Bitmap)pictureBox1.Image, TH, TL, MaskSize, Sigma);

            pictureBox2.Image = CannyData.DisplayImage(CannyData.NonMax);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox3.Image = CannyData.DisplayImage(CannyData.FilteredImage);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox4.Image = CannyData.DisplayImage(CannyData.GNL);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox5.Image = CannyData.DisplayImage(CannyData.GNH);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;


            pictureBox6.Image = CannyData.DisplayImage(CannyData.EdgeMap);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox6.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.pictureBox6.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.pictureBox6.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }
    }
}
