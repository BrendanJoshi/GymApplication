
//using Microsoft.Extensions.Options;
//using MimeKit;

//namespace GymApplication.Services
//{
//    public class EmailServiceProvider : IEmailService
//    {
//        private readonly EmailService _emailService;
//        public EmailServiceProvider(IOptions<EmailService> options)
//        {
//            this._emailService = options.Value;
//        }
//        public Task SendEmailAsync(EmailService mailrequest)
//        {
//            var email = new MimeMessage();
//            email.Sender = MailboxAddress.Parse(_emailService.Email);
//            email.To.Add(MailboxAddress.Parse(mailrequest.Email));
//            throw new NotImplementedException();
//        }
//    }
//}
