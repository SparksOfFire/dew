using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.EmailService
{
    public class IdentityEmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // 在此处插入电子邮件服务可发送电子邮件。
            //配置      
            var mailMessage = new System.Net.Mail.MailMessage(
                "@.",//email
                message.Destination,
                message.Subject,
                message.Body);
            //发送    
            var client = new System.Net.Mail.SmtpClient();
            client.SendAsync(mailMessage, null);

            return Task.FromResult(0);
        }
    }
}
