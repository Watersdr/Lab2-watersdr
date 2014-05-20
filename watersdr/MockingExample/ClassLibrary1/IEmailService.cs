using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
