using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;
using HGINF;
using System.Threading;

namespace HGINF
{
    public partial class Form3 : Form
    {
        private int widr = Screen.PrimaryScreen.Bounds.Width;
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int WM_NCHITTEST = 0x0084;
        const int HTCAPTION = 2;
        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        public Form3()
        {
            InitializeComponent();
        }

        Form1 formMain = new Form1();
        private void Form3_Activated(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(widr - pictureBox3.Size.Width, Screen.PrimaryScreen.Bounds.Height/2-pictureBox3.Height);//вверх вправо
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            formMain.Opacity = 0;
            formMain.Show();
            while (formMain.Opacity != 1)
            {
                Thread.Sleep(30);
                formMain.Opacity += 0.1;
            }
            while (this.Opacity != 0)
            {
                Thread.Sleep(30);
                this.Opacity -= 0.1;
            }
        }

    }
}
