using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestSuite.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : Controller // ControllerBase is for use without view support
	{
		[HttpGet]
		public JsonResult Get()
		{
			Console.WriteLine("Get() started");

			var resources = GetResources();

			Console.WriteLine("Get() filter");

			var filtered = resources.Where(r => r.Type == "TESTING");

			Console.WriteLine("Get() return");

			return Json(filtered);
		}

		private IEnumerable<Resource> GetResources()
		{
			Console.WriteLine("GetResources()");

			var resource = new Resource()
			{
				Type = "TESTING"
			};

			return Enumerable.Repeat(resource, 10);
		}
		
		private class Resource
		{
			private bool wasReadOnce;

			private string type;

			public string Type {
				get {
					if (wasReadOnce)
						throw new Exception("Type was already read");

					wasReadOnce = true;
					Console.WriteLine(type);
					return type;
				}
				set {
					type = value;
				}
			}
		}
	}
}
