using IIG.Core.Framework.Email.Business.Email;
using IIG.Core.Framework.Email.Infrastructure.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class EmailController : ControllerBase
    {
        private readonly IEmailHandler _handler;

        public EmailController(IEmailHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("sync")]
        public ResponseData SendEmail(EmailRequest email)
        {

            return _handler.SendEmail(email);
        }

        [HttpPost]
        [Route("async")]
        public async Task<ResponseData> SendEmailAsync(EmailRequest email)
        {
            return await _handler.SendEmailAsync(email);
        }

        [HttpPost]
        [Route("async-fromform")]
        public async Task<ResponseData> SendEmailAsyncFormFile([FromForm] EmailRequest email)
        {
            return await _handler.SendEmailAsync(email);
        }

        [HttpGet]
        [Route("template-mail/{id}")]
        public async Task<ResponseData> GetTemplateEmail([FromRoute] Guid id)
        {
            return await _handler.GetTemplateEmail(id);
        }

        [HttpPost]
        [Route("saveDesign")]
        public async Task<ResponseData> SaveDesign([FromBody] EmailSaveDesign email)
        {
            return await _handler.SaveDesign(email);
        }

        [HttpGet]
        [Route("template-mails")]
        public async Task<ResponseData> GetTemplateEmails()
        {
            return await _handler.GetTemplateEmails();
        }
    }
}
