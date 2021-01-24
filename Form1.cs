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
        public Form1()
        {
            InitializeComponent();
            string[,] data = new string[12, 7];
            int index2 = 0;
            string remoteUri = "https://raw.githubusercontent.com/nychealth/coronavirus-data/master/latest/last7days-by-modzcta.csv";
            string fileName = "content.txt", myStringWebResource = null;
            WebClient myWebClient = new WebClient();
            myStringWebResource = remoteUri + fileName;
            //Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            myWebClient.DownloadFile(remoteUri, fileName);
            //Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            string[] readText = File.ReadAllLines(fileName);
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
                            //Console.Write(data[index2, index] + " ");
                            end += 1;
                            start = end;
                            end += 1;
                            index += 1;
                        }
                        else { end += 1; }
                    }
                    //Console.WriteLine("");
                    index2 += 1;
                    index = 0;
                }
            }
        }
    }
}
