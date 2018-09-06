using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Examen
{
    public partial class Form1 : Form
    {

        Image<Bgr, byte> inputImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inputImage = new Image<Bgr, byte>(ofd.FileName);

                imageBox1.Image = inputImage;
                imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
               
            }

        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DenseHistogram red = new DenseHistogram(256, new RangeF(0, 255));
            red.Calculate(new Image<Gray, byte>[] { inputImage[0] }, false, null);

            Mat m = new Mat();
            red.CopyTo(m);

            histogramBox1.AddHistogram("Histograma rojo", Color.Red, m, 256, new float[] { 0, 255 });

            histogramBox1.Refresh();

        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> imgCanny = new Image<Gray, byte>(inputImage.Width, inputImage.Height, new Gray(0));
            imgCanny = inputImage.Canny(50, 50);
            imageBox1.Image = imgCanny;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estás seguro que deseas salir?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
