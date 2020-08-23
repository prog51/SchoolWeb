using SchoolWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Contracts
{
    public interface IMailService
    {
        Task SendEmail(MailRequest mailRequest);
    }
}
