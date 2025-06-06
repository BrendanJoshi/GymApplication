﻿namespace GymApplication.Email
{
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
    public class MailRequest
    {
        public string ToEmail { get; set; } 
        public string Subject { get; set; } 
        public string Body { get; set; } 
    }
}

