using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.EntityFramework.Datatables
{
    public class SysApplication
    {
        public string Code { get; set; }
        public string Description { get; set; }
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public string Name { get; set; }
    }
}
