using BusinessLogic.Dto;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OdontoSystem.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IViewRender _viewRender;
        protected string user = "info.fleeter.manager@gmail.com";
        protected string password = "mplurmqycnmdrhcv";
        protected string mailServer = "smtp.gmail.com";
        public EmailSender(IViewRender viewRender)
        {
            _viewRender = viewRender;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = mailServer,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, password)
            };

            return client.SendMailAsync(user, email, subject, htmlMessage);
        }

        public Task SendEmailAsync(string to, EmailTemplate template)
        {
            MailAddress addressFrom = new MailAddress(user);
            MailAddress addressTo = new MailAddress(to);
            MailMessage message = new MailMessage(addressFrom, addressTo);

            message.Subject = template.Title;
            message.Body = HtmlTemplate(template).Result;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = mailServer,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, password)
            };

            return client.SendMailAsync(message);
        }
        public async Task<string> HtmlTemplate(EmailTemplate template)
        {
            return await _viewRender.RenderToStringAsync("Shared/EmailTemplate", template);
        }
    }
}
