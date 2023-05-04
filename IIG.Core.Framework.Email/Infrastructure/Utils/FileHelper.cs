using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.Utils
{
    public class FileHelper
    {
        public static FileResult DownloadFile(string filePath, string downloadFileName = "")
        {
            var file = new FileInfo(filePath);
            using var stream = new MemoryStream();
            byte[] fileContent = null;
            byte[] content = File.ReadAllBytes(file.FullName);
            stream.Write(content, 0, content.Length);
            stream.Position = 0;

            fileContent = stream.ToArray();
            stream.Flush();

            FileResult fr = new FileContentResult(fileContent, "application/vnd.ms-excel")
            {
                FileDownloadName = string.IsNullOrEmpty(downloadFileName) ? file.Name : downloadFileName
            };

            return fr;
        }
    }
}
