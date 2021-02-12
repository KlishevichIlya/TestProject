﻿using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject_For_CoralTeam.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "klishevich.ilya@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("***", "***");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

    }
}
