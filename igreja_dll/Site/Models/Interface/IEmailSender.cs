﻿using System.Threading.Tasks;

namespace Site.Models.Interface
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}