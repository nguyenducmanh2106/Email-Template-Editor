using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.Utils
{
    public class Constant
    {
        public struct UserExcelColumnName
        {
            public const string col0 = "#";
            public const string col1 = "Username";
            public const string col2 = "Fullname";
            public const string col3 = "IsLocked";
        }

        public struct NotiType
        {
            public const string Warning = "warning";
            public const string Success = "success";
            public const string Info = "info";
            public const string Error = "error";
        }

        public enum Action
        {
            Create,
            Details,
            Edit,
            Delete,
            List,
        }
    }
}
