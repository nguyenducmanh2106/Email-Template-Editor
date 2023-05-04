using IIG.Core.Framework.Email.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Business.Application
{
    public interface IApplicationHandler
    {
        ResponseData Get();
        ResponseData GetById(Guid id);
        ResponseData Create(ApplicationModel model);
        ResponseData Update(Guid id, ApplicationModel model);
        ResponseData Delete(Guid id);
        ResponseData Bootstrap();
    }
}
