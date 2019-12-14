using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquinoxCore.Infra.CrossCutting.Identity.Services
{
    public class EmailMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //Plug in email service here to send email
            return Task.FromResult(0);
        }
    }

    public class SmsMessageSender : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            //Plug in sms service here to send sms
            return Task.FromResult(0);
        }
    }
}
