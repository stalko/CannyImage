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
        
        private void uploadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        private void cannyButton_Click(object sender, EventArgs e)
        {
            
        }
        public void OpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //(Bitmap)pictureBox1.Image
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void ColorCannyImage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                var imgform = new ImagesForm((Bitmap)pictureBox1.Image);
                imgform.Show();
            }
            else MessageBox.Show("Вы не выбрали картинку");
        }
    }
}
