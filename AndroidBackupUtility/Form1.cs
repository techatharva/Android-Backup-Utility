using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;

namespace AndroidBackupUtility
{
    public partial class Form1 : Form
    {
        private Process process = new Process();
        private ProcessStartInfo info = new ProcessStartInfo();

        private string path;

        public Form1()
        {
            InitializeComponent();


            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
        }

        private void DCIMCopy() 
        {
            info.FileName = "adb.exe";
            info.Arguments = $"pull /sdcard/DCIM {path}/DCIM";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }
        private void DocumentsCopy()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"pull /sdcard/Documents {path}/Documents";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }
        private void DownloadCopy()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"pull /sdcard/Download {path}/Download";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }
        private void MovCopy()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"pull /sdcard/Movies {path}/Movies";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }

        private void MusicCopy()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"pull /sdcard/Music {path}/Music";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }

        private void PicCopy()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"pull /sdcard/Pictures {path}/Pictures";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
            MessageBox.Show("Backup completed");
        }

        private void WACopy()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"pull /sdcard/Android/Media/com.whatsapp/WhatsApp {path}/Android/Media/WhatsApp";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }

        private void button3_Click(object sender, EventArgs e)
            {
                try
                {   
                    info.FileName = "adb.exe";
                    info.Arguments = "devices";
                    process.StartInfo = info;

                    process.Start();

                    textBox1.Text += process.StandardOutput.ReadToEnd(); 
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();
            folderBrowse.Description = "Select the folder to copy backed up files";
            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowse.SelectedPath;
                DCIMCopy();
                DocumentsCopy();
                DownloadCopy();
                MovCopy();
                MusicCopy();
                PicCopy();
            }
            else
            {
                MessageBox.Show("Backup cancelled");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "This only works on Android 10 and above. Do you want to continue?";
            string title = "Check Android Version";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                WACopy();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = "e-Mail me on techatharvaofficial@gmail.com for bugs and suggestions.";
            string title = "Reports";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DCIMPush()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"push {path}/DCIM /sdcard/DCIM";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }
        private void DocumentsPush()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"push {path}/Documents /sdcard/Documents";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }
        private void DownloadPush()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"push {path}/Download /sdcard/Download";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }

        private void MovPush()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"push {path}/Movies /sdcard/Movies";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }

        private void MusicPush()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"push {path}/Music /sdcard/Music";
            process.StartInfo = info;

            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
        }

        private void PicPush()
        {
            info.FileName = "adb.exe";
            info.Arguments = $"push {path}/Pictures /sdcard/Pictures";
            process.StartInfo = info;
            
            process.Start();
            textBox1.Text += process.StandardOutput.ReadToEnd();
            MessageBox.Show("Restore completed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();
            folderBrowse.Description = "Select the backup folder to restore from";
            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowse.SelectedPath;
                DCIMCopy();
                DocumentsCopy();
                DownloadCopy();
                MovCopy();
                MusicCopy();
                PicCopy();
            }
            else
            {
                MessageBox.Show("Restore cancelled");
            }
        }
    }
}
