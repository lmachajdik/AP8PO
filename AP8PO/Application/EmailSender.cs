using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AP8PO
{
    public static class EmailSender
    {
        private static SmtpClient Client;
        static EmailSender()
        {
            Client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("d852896cfe4051", "45d5def5894169"),
                EnableSsl = true
            };
        }

        public static Task<SendResponse> Send(FileInfo file, string emailStr)
        {
            Email.DefaultSender = new SmtpSender(Client);
            var email = Email
              .From("tajemnikovac@utb.cz")
              .To(emailStr)
              .Subject("Tajemníkovač")
              .Body("Hello,\n\nyou have recently requested to sent saved data from Tajemníkovač. \nWe have sent it as attachement in this email. \n\nBest regards, \nTajemníkovač")
              .Attach(new FluentEmail.Core.Models.Attachment()
                        {
                            Data = File.OpenRead(file.FullName),
                            Filename=file.Name,
                        });

            return email.SendAsync();
        }
    }
}
