﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.Utils
{
    public class ResponseData
    {
        public Code Code { get; set; } = Code.Success;
        public string Message { get; set; } = "Thành công";

        public ResponseData()
        {
        }

        public ResponseData(Code code, string message)
        {
            Code = code;
            Message = message;
        }
    }

    public class ResponseDataObject<T> : ResponseData
    {
        public T Data { get; set; }
        public ResponseDataObject() : base() { }
        public ResponseDataObject(Code code, string message) : base(code, message) { }
        public ResponseDataObject(T data)
        {
            Data = data;
        }

        public ResponseDataObject(T data, Code code, string message) : base(code, message)
        {
            Data = data;
        }
    }

    public class ResponseDataError : ResponseData
    {
        public List<Dictionary<string, string>> ErrorDetail { get; set; }

        public ResponseDataError(Code code, string message, List<Dictionary<string, string>> errorDetail = null) : base(code, message)
        {
            ErrorDetail = errorDetail;
        }
    }

    public enum Code
    {
        Success = 200,
        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        ServerError = 500
    }
}
