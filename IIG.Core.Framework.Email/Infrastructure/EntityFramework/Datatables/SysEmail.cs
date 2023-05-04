using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.EntityFramework.Datatables
{
    public class SysEmail
    {
        [Key]
        public Guid Id { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSend { get; set; }
        public string Note { get; set; }
    }
}
