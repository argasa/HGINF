using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace HGINF
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
                MessageBox.Show("Ваша заявка отправлена! Вскоре с вами свяжутся наши специалисты!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Mail.Send: " + e.Message);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strNum = textBox4.Text;
            string strOrg = textBox3.Text;
            string strFIO = textBox2.Text;
            string strText = textBox1.Text;
            string strPNum = textBox5.Text;
            if (strFIO == "" || strOrg == "" || strText == "" || strNum == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
            else
            {
                SendMail("smtp.gmail.com", "hginformer@gmail.com", "Hgroup911adm", "aukustik@yandex.ru", "Заявка от " + strFIO, "Организация: " + strOrg + "\n\nИмя: " + strFIO + "\n\nНомер телефона: " + strPNum +"\n\nНомер ПК: " + strNum + "\n\nТекст Заявки: " + strText, "");
                this.Close();
            }
        }
    }
}
