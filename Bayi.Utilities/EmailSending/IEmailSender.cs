using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Utilities.EmailSending
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
