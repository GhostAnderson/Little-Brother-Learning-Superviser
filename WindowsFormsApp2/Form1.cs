using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public int minutes = 0;
        public int seconds_left = 0;


        public Form1()
        {
            InitializeComponent();
            cmdkill(true);
        }

        public static void cmdkill(bool a)
        {
            string str;
            //string str = Console.ReadLine();
            if (a)
            { 
                str = @"taskkill /f /im explorer.exe";
            }
            else
            {
                str = @"taskkill /f /im Tasdfsdfgr.exe";

            }
            Process p = new Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.UseShellExecute = false;                 //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;            //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;           //由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;            //重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;                   //不显示程序窗口
            p.Start();                                           //启动程序
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");
            p.StandardInput.AutoFlush = true;
            //p.WaitForExit();//等待程序执行完退出进程
            p.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            辅助弟弟学习 fm2 = new 辅助弟弟学习();
            fm2.ShowDialog(this);
            

            this.label1.Text = (minutes / 60).ToString();
            this.label3.Text = (minutes % 60).ToString();

            this.seconds_left = this.minutes*60;
            //this.seconds_left = 1;
            this.timer1.Enabled = true;

            this.TopMost = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.seconds_left > 0)
            {
                MessageBox.Show("不学了，弟弟¿", "弟弟", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("勤奋先辈suki", "弟弟", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.seconds_left > 0)
            {
                MessageBox.Show("不学了，弟弟¿", "弟弟", MessageBoxButtons.OK, MessageBoxIcon.Question);
                e.Cancel = true;
            }
            Process.Start("explorer.exe");
            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds_left == 0)
                return;
            this.seconds_left -= 1;
            this.label1.Text = (seconds_left / 60 /60).ToString();
            this.label3.Text = (seconds_left /60  % 60).ToString();
            this.label7.Text = (seconds_left % 60).ToString();
            int seconds_elapsed = minutes*60 - seconds_left;
            this.progressBar1.Value = (int)(100 * seconds_elapsed / minutes/60);

            Process[] ps = Process.GetProcesses();
            foreach (Process item in ps)
            {
                if (item.ProcessName == "Taskmgr")
                    item.Kill();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
