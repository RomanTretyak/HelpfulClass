﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace BuildEmail
{
    class SendEmail
    {

/// <summary>
 /// Отправка письма на почтовый ящик C# mail send
 /// </summary>
 /// <param name="smtpServer">Имя SMTP-сервера</param>
 /// <param name="from">Адрес отправителя</param>
 /// <param name="password">пароль к почтовому ящику отправителя</param>
 /// <param name="mailto">Адрес получателя</param>
 /// <param name="caption">Тема письма</param>
 /// <param name="message">Сообщение</param>
 /// <param name="attachFile">Присоединенный файл</param>
        public void SendMail(string smtpServer, string from, string password,
       string mailto1, string mailto2, string mailto3, string mailto4, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto1));
                mail.To.Add(new MailAddress(mailto2));
                mail.To.Add(new MailAddress(mailto3));
                mail.To.Add(new MailAddress(mailto4));
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


    }
}
