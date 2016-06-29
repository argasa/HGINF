using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;
using HGINF;
using System.Diagnostics;


namespace HGINF
{
    public partial class Form1 : Form
    {


        private int width = Screen.PrimaryScreen.Bounds.Width;
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int WM_NCHITTEST = 0x0084;
        const int HTCAPTION = 2;
        bool hidden = false;
        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public Form1()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            

        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN)
            {
                int result = SendMessage(m.HWnd, WM_NCHITTEST, IntPtr.Zero, m.LParam);
                if (result == HTCAPTION)
                    return;
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(width - this.Size.Width, Size.Height/2);//вверх вправо
        }

        private void button1_Click(object sender, EventArgs e)
        {
                     
        }


        public static void SendMail(string smtpServer, string from, string password, string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 formCall = new Form3();
            formCall.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            {
                if (this.hidden == true)
                {
                    for (int j = 0; j < 231; j++)
                    {
                        this.Left -= 1;
                        this.Width += 1;
                        this.Refresh();
                    }
                    this.hidden = false;
                    pictureBox2.Image = Properties.Resources.kreqweqst;
                }
                else if (this.hidden == false)
                {
                    for (int x = 0; x < 231; x++)
                    {
                        this.Left += 1;
                        this.Width -= 1;
                    }
                    this.hidden = true;
                    pictureBox2.Image = Properties.Resources.strelka1;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("TW.exe");
            }
            catch
            {
                MessageBox.Show("Не удалось запустить \"Удаленный помощник\"");
            }
        }
    }
}
