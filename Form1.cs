using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        int zip = 0;
        string[,] data = new string[12, 8];
        public void imOff()
        {
            if (zip == 0) { pictureBox1.Visible = false; }
            else if (zip == 1) { pictureBox2.Visible = false; }
            else if (zip == 2) { pictureBox3.Visible = false; }
            else if (zip == 3) { pictureBox4.Visible = false; }
            else if (zip == 4) { pictureBox5.Visible = false; }
            else if (zip == 5) { pictureBox6.Visible = false; }
            else if (zip == 6) { pictureBox7.Visible = false; }
            else if (zip == 7) { pictureBox8.Visible = false; }
            else if (zip == 8) { pictureBox9.Visible = false; }
            else if (zip == 9) { pictureBox10.Visible = false; }
            else if (zip == 10) { pictureBox11.Visible = false; }
            else if (zip == 11) { pictureBox12.Visible = false; }
        }
        public void imOn()
        {
            if (zip == 0) { pictureBox1.Visible = true; }
            else if (zip == 1) { pictureBox2.Visible = true; }
            else if (zip == 2) { pictureBox3.Visible = true; }
            else if (zip == 3) { pictureBox4.Visible = true; }
            else if (zip == 4) { pictureBox5.Visible = true; }
            else if (zip == 5) { pictureBox6.Visible = true; }
            else if (zip == 6) { pictureBox7.Visible = true; }
            else if (zip == 7) { pictureBox8.Visible = true; }
            else if (zip == 8) { pictureBox9.Visible = true; }
            else if (zip == 9) { pictureBox10.Visible = true; }
            else if (zip == 10) { pictureBox11.Visible = true; }
            else if (zip == 11) { pictureBox12.Visible = true; }
        }
        public Bitmap chColor(Bitmap im,Color to)
        {
            Color[,] ar10301 = new Color[im.Width, im.Height];
            for (int i = 0; i < im.Width; i++)
            {
                for (int j = 0; j < im.Height; j++)
                {
                    ar10301[i, j] = im.GetPixel(i, j);
                    if (ar10301[i, j].R != 0) { im.SetPixel(i, j, to); }
                }
            }
            return im;
        }
        public Form1()
        {
            InitializeComponent();
            int index2 = 0;
            string remoteUri = "https://raw.githubusercontent.com/nychealth/coronavirus-data/master/latest/last7days-by-modzcta.csv";
            string fileName = "content.txt", myStringWebResource = null;
            Bitmap[] images = new Bitmap[12];
            images[0] = new Bitmap("Im\\10301.png");
            images[1] = new Bitmap("Im\\10302.png");
            images[2] = new Bitmap("Im\\10303.png");
            images[3] = new Bitmap("Im\\10304.png");
            images[4] = new Bitmap("Im\\10305.png");
            images[5] = new Bitmap("Im\\10306.png");
            images[6] = new Bitmap("Im\\10307.png");
            images[7] = new Bitmap("Im\\10308.png");
            images[8] = new Bitmap("Im\\10309.png");
            images[9] = new Bitmap("Im\\10310.png");
            images[10] = new Bitmap("Im\\10312.png");
            images[11] = new Bitmap("Im\\10314.png");
            //images[0] = chColor(images[0], Color.Red);
            //pictureBox1.BackgroundImage = images[0];
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            WebClient myWebClient = new WebClient();
            myStringWebResource = remoteUri + fileName;
            //Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            myWebClient.DownloadFile(remoteUri, fileName);
            //Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            string[] readText = File.ReadAllLines(fileName);
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            foreach (string s in readText)
            {
                if (s.Substring(0, 3) == "103")//filter just staten island zip codes
                {
                    int start = 0, end = 1;
                    int index = 0;
                    while (end < s.Length)
                    {
                        string temp = s.Substring(end, 1);
                        if (temp == ",")
                        {
                            data[index2, index] = s.Substring(start, end - start);
                            Console.Write(data[index2, index] + " ");
                            end += 1;
                            start = end;
                            end += 1;
                            index += 1;
                        }
                        else { end += 1; }
                    }
                    data[index2, index] = s.Substring(start, end - start);
                    Console.Write(data[index2, index] + " ");
                    Console.WriteLine("");
                    index2 += 1;
                    index = 0;
                }
            }
            for(int ind = 0; ind < 12; ind++)//apply colors to images
            {
                Color color=Color.White;
                int cases = Int32.Parse(data[ind, 4]);
                if ( cases < 100) { color = Color.Yellow; }
                else if (cases < 200) { color = Color.Orange; }
                else if (cases >= 200) { color = Color.Red; }
                images[ind] = chColor(images[ind], color);
            }
            pictureBox1.BackgroundImage = images[0];
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.BackgroundImage = images[1];
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.BackgroundImage = images[2];
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.BackgroundImage = images[3];
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.BackgroundImage = images[4];
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.BackgroundImage = images[5];
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.BackgroundImage = images[6];
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.BackgroundImage = images[7];
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.BackgroundImage = images[8];
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.BackgroundImage = images[9];
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.BackgroundImage = images[10];
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.BackgroundImage = images[11];
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox1.Text = data[zip,0] + ", " + data[zip, 1] + ", " + data[zip, 4] + " cases between " + data[zip,7];
            button1.Click += new EventHandler(this.mvLt);
            button2.Click += new EventHandler(this.mvRt);
        }
        void mvLt(Object sender,
                               EventArgs e)
        {
            imOff();
            zip -= 1;
            if (zip < 0) { zip = 11; }
            imOn();
            textBox1.Text = data[zip, 0] + ", " + data[zip, 1] + ", " + data[zip, 4] + " cases between " + data[zip, 7];
        }
        void mvRt(Object sender,
                       EventArgs e)
        {
            imOff();
            zip += 1;
            if (zip > 11) { zip = 0; }
            imOn();
            textBox1.Text = data[zip, 0] + ", " + data[zip, 1] + ", " + data[zip, 4] + " cases between " + data[zip, 7];
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
