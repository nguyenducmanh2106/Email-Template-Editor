using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Business.Email
{
    public class EmailModel
    {

    }

    public class EmailRequest
    {
        public List<string> ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }

    public class EmailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public class EmailSaveDesign
    {
        public Guid Id { get; set; }
        public long ProjectId { get; set; }
        public string Name { get; set; }
        public string DisplayMode { get; set; }
        public string TemplateHtml { get; set; }
        public string Design { get; set; }

        public dynamic DesignJson { get; set; }
    }
}
