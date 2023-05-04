using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.EntityFramework.Datatables
{
    public class SysHistory
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public DateTime? ActionDate { get; set; }
        public string ObjectId { get; set; }
        public string Detail { get; set; }
    }
}
