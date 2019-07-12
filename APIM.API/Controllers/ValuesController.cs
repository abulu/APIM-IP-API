using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace APIM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            StringValues xforwardedfor = "";
            this.Request.HttpContext.Request.Headers.TryGetValue("X-Forwarded-For", out xforwardedfor);

            IPHostEntry host = Dns.GetHostEntry(this.Request.Host.Host);
            string hostAndIP = this.Request.Host.Host + "(" + host.AddressList.ToList().FirstOrDefault().ToString() + ")";

            return new string[] { "LocalIpAddress", this.Request.HttpContext.Connection.LocalIpAddress.ToString(),
                "RemoteIpAddress IP is", this.Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            "X-Forwarded-For",xforwardedfor.ToString(),"Host(backend server IP)", hostAndIP};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return " RemoteIpAddress " + this.Request.HttpContext.Connection.RemoteIpAddress.ToString() + "; The IPAddress of the client making the request. Note this may be for a proxy rather than the end user.";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
