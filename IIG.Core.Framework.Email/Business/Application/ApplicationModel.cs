using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Business.Application
{
    public class ApplicationModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public string Name { get; set; }
    }
}
