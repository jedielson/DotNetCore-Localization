using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TesteInternationalization.Domain.Resources;
using TesteInternationalization.Resources;

namespace TesteInternationalization.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IStringLocalizer<Validations> _validationMessages;
        private readonly IStringLocalizer<Messages> _messages;


        public ValuesController(IStringLocalizer<Validations> validationMessages, IStringLocalizer<Messages> messages)
        {
            _validationMessages = validationMessages;
            _messages = messages;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new [] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("message")]
        public string GetMessage()
        {
            return _messages["HelloWorld"];
        }

        [HttpGet("validation")]
        public string GetValidation()
        {
            return _validationMessages["Validacao1"];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
