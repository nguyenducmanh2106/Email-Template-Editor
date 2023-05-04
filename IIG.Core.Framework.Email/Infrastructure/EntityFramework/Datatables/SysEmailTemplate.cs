using Backend.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.EntityFramework.Datatables
{
    public class SysEmailTemplate : BaseTable<SysEmailTemplate>
    {
        [Key]
        public Guid Id { get; set; }
        public long ProjectId { get; set; }

        public string DisplayMode { get; set; }
        public string Name { get; set; }

        public string Design { get; set; }
        public string TemplateHtml { get; set; }
    }
}
