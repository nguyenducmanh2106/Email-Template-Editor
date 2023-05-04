using IIG.Core.Framework.Email.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Business.Email
{
    public interface IEmailHandler
    {
        ResponseData SendEmail(EmailRequest mailRequest);
        Task<ResponseData> SaveDesign(EmailSaveDesign mailRequest);
        Task<ResponseData> SendEmailAsync(EmailRequest mailRequest);
        Task<ResponseData> GetTemplateEmail(Guid id);
        Task<ResponseData> GetTemplateEmails();
    }
}
