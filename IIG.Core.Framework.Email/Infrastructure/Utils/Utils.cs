using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.Utils
{
    public class Utils
    {
        public static string GetConfig(string code)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                                                                         .Build();

            var value = configuration[code];
            return value;
        }

        public static string PassowrdRandomString(int size)
        {
            byte[] rgb = new byte[size];
            RNGCryptoServiceProvider rngCrypt = new();
            rngCrypt.GetBytes(rgb);
            return Convert.ToBase64String(rgb);
        }
    }
}
