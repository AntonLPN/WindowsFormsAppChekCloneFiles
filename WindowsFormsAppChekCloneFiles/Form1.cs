using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppChekCloneFiles
{
    public partial class Form1 : Form
    {
        

        string source;
        string receiver;
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            if (folderBrowserDialog.SelectedPath != "")
            {
                source = folderBrowserDialog.SelectedPath;
                textBox1.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            if (folderBrowserDialog.SelectedPath != "")
            {
                receiver = folderBrowserDialog.SelectedPath;
                textBox2.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir1 = new DirectoryInfo(source);
            DirectoryInfo dir2 = new DirectoryInfo(receiver);

            FileInfo[] filesInfo1 = dir1.GetFiles();
            FileInfo[] filesInfo2 = dir2.GetFiles();

            var uniqueFiles = filesInfo1.Except(filesInfo2, new FileComparer());

          

            Parallel.ForEach(uniqueFiles, t =>
            {
                try
                {

                    File.Copy(dir1 + "\\" + t.ToString(), receiver + "\\" + t.ToString());
                    Process.Start(receiver);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("INVALID: " + ex.Message);
                }
            });

        }
    }
}
