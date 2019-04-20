using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing.Imaging;

namespace Fractals
{
    public partial class Form1 : Form
    {
        Bitmap image;

        int WIDTH;
        int HEIGHT;
        int offX = 0;
        int offY = 0;

        double scale = 4;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calcMandelbrot();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs e2 = (MouseEventArgs)e;
            switch (e2.Button)
            {
                case MouseButtons.Left: scale /= 1.5; break;
                case MouseButtons.Right: scale *= 1.5;  break;
            }
            //Console.WriteLine("X: {0} Y: {1}", e2.X, e2.Y);
            offX += e2.X - pictureBox1.Width/2;
            offY += e2.Y - pictureBox1.Height/2;
            calcMandelbrot();
        }

        private void calcMandelbrot()
        {
            WIDTH = pictureBox1.Width;
            HEIGHT = pictureBox1.Height;

            image = new Bitmap(WIDTH, HEIGHT);
            Random r = new Random();

            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    Complex c = new Complex(scale * (((x+offX - WIDTH/2) / (double)WIDTH)), scale * (((y+offY - HEIGHT / 2) / (double)WIDTH)));

                    Color col = Color.Black;
                    Complex z = new Complex(0, 0);

                    for (int i = 0; i < 100; i++)
                    {
                        z = z * z + c;
                        if (z.Magnitude > 2)
                        {
                            switch ((i/10))
                            {
                                case 0: col = Color.White; break;
                                case 1: col = Color.Yellow; break;
                                case 2: col = Color.YellowGreen; break;
                                case 3: col = Color.Green; break;
                                case 4: col = Color.Turquoise; break;
                                case 5: col = Color.Blue; break;
                                case 6: col = Color.Purple; break;
                                case 7: col = Color.Red; break;
                                case 8: col = Color.Brown; break;
                                case 9: col = Color.DarkBlue; break;
                            }
                            //col = Color.White;
                            break;
                        }
                    }
                    /*
                    
                    */
                    image.SetPixel(x, y, col);
                }
            }

            pictureBox1.Image = image;
        }
    }
}
