using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace proj.Api.v0
{
    [Route("api/v0/[controller]/[action]")]
    public class SystemController : Controller
    {
		[HttpGet]
		public object GetTime()
		{
			return new Dictionary<string, string> { { "time", DateTime.Now.ToString() } };
		}
    }
}
