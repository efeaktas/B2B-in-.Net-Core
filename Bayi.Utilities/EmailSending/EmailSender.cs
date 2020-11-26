using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Utilities.EmailSending
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            this._emailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            this.Send(this.CreateEmailMessage(message));
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(this._emailConfig.From));
            mimeMessage.To.AddRange(message.To);
            mimeMessage.Subject = message.Subject;
            //mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            mimeMessage.Body = new TextPart(TextFormat.Plain)
            {
                Text = string.Format("Şifrenizi Buradan Yenileyebilirsiniz {0}",message.Content)
            };
            return mimeMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                smtpClient.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
}
