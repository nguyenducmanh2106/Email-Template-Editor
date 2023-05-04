using DocumentFormat.OpenXml.Spreadsheet;
using FirebaseAdmin.Messaging;
using IIG.Core.Framework.Email.Infrastructure.EntityFramework.Datatables;
using IIG.Core.Framework.Email.Infrastructure.EntityFramework.Repositories;
using IIG.Core.Framework.Email.Infrastructure.Utils;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Business.Email
{
    public class EmailHandler : IEmailHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly EmailSettings _emailSettings;

        public EmailHandler(IOptions<EmailSettings> mailSettings, IHttpContextAccessor httpContextAccessor)
        {
            _emailSettings = mailSettings.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public ResponseData SendEmail(EmailRequest request)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(_emailSettings.Mail)
                };
                foreach (var item in request.ToEmail)
                {
                    email.To.Add(MailboxAddress.Parse(item));
                }
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                if (request.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in request.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            string contentType = GetMimeType(file.FileName);
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(contentType));
                        }
                    }
                }
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSettings.Mail, _emailSettings.Password);
                var result = smtp.Send(email);
                smtp.Disconnect(true);
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                unitOfWork.Repository<SysEmail>().Insert(new SysEmail()
                {
                    Body = request.Body,
                    Id = Guid.NewGuid(),
                    IsSend = true,
                    Note = result,
                    Subject = request.Subject,
                    ToEmail = request.ToEmail.ToString()
                });
                unitOfWork.Save();
                return new ResponseData() { Code = Code.Success, Message = "" };
            }
            catch (Exception e)
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                unitOfWork.Repository<SysEmail>().Insert(new SysEmail()
                {
                    Body = request.Body,
                    Id = Guid.NewGuid(),
                    IsSend = false,
                    Note = "",
                    Subject = request.Subject,
                    ToEmail = request.ToEmail.ToString()
                });
                unitOfWork.Save();
                return new ResponseData() { Code = Code.ServerError, Message = e.Message };
            }
        }

        /// <summary>
        /// lấy về tên content type của file
        /// </summary>
        /// <param name="fileName">Tên của file</param>
        /// <returns></returns>
        private string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        public async Task<ResponseData> SendEmailAsync(EmailRequest request)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(_emailSettings.Mail)
                };
                foreach (var item in request.ToEmail)
                {
                    email.To.Add(MailboxAddress.Parse(item));
                }
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                if (request.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in request.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            string contentType = GetMimeType(file.FileName);
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(contentType));
                        }
                    }
                }
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSettings.Mail, _emailSettings.Password);
                var result = await smtp.SendAsync(email);
                smtp.Disconnect(true);
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                unitOfWork.Repository<SysEmail>().Insert(new SysEmail()
                {
                    Body = request.Body,
                    Id = Guid.NewGuid(),
                    IsSend = true,
                    Note = result,
                    Subject = request.Subject,
                    ToEmail = request.ToEmail.ToString()
                });
                unitOfWork.Save();
                return new ResponseData() { Code = Code.Success, Message = "" };
            }
            catch (Exception e)
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                unitOfWork.Repository<SysEmail>().Insert(new SysEmail()
                {
                    Body = request.Body,
                    Id = Guid.NewGuid(),
                    IsSend = false,
                    Note = "",
                    Subject = request.Subject,
                    ToEmail = request.ToEmail.ToString()
                });
                unitOfWork.Save();
                return new ResponseData() { Code = Code.ServerError, Message = e.Message };
            }
        }


        public async Task<ResponseData> GetTemplateEmail(Guid id)
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                var templateMailEntity = unitOfWork.Repository<SysEmailTemplate>().GetById(id);
                var result = new EmailSaveDesign()
                {
                    //DesignJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(templateMailEntity.Design),
                    Id = templateMailEntity.Id,
                    DisplayMode = templateMailEntity.DisplayMode,
                    Name = templateMailEntity.Name,
                    ProjectId = templateMailEntity.ProjectId,
                    TemplateHtml = templateMailEntity.TemplateHtml,
                    Design = templateMailEntity.Design,
                };
                return new ResponseDataObject<EmailSaveDesign>(result, Code.Success, "Success");
            }
            catch (Exception e)
            {
                return new ResponseData() { Code = Code.ServerError, Message = e.Message };
            }
        }

        public async Task<ResponseData> GetTemplateEmails()
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                var templateMailEntity = unitOfWork.Repository<SysEmailTemplate>().Get().Select(g => new EmailSaveDesign()
                {
                    Id = g.Id,
                    DisplayMode = g.DisplayMode,
                    Name = g.Name,
                    ProjectId = g.ProjectId,
                }).ToList();

                return new ResponseDataObject<List<EmailSaveDesign>>(templateMailEntity, Code.Success, "Success");
            }
            catch (Exception e)
            {
                return new ResponseData() { Code = Code.ServerError, Message = e.Message };
            }
        }

        public async Task<ResponseData> SaveDesign(EmailSaveDesign email)
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                var a = Newtonsoft.Json.JsonConvert.SerializeObject(email.Design);
                var entity = new SysEmailTemplate()
                {
                    Id = Guid.NewGuid(),
                    ProjectId = 0,
                    Name = email.Name,
                    Design = email.Design,
                    DisplayMode = email.DisplayMode,
                    TemplateHtml = email.TemplateHtml,
                };
                unitOfWork.Repository<SysEmailTemplate>().Insert(entity);
                unitOfWork.Save();
                return new ResponseData() { Code = Code.Success, Message = "Success" };
            }
            catch (Exception e)
            {
                return new ResponseData() { Code = Code.ServerError, Message = e.Message };
            }
        }
    }
}
