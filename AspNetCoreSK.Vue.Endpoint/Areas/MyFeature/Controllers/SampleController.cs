using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreSK.Vue.Endpoint.Areas.MyFeature.Controllers
{
    [Area("MyFeature")]
    [Route("[area]/api/[controller]")]
    public class SampleController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var model = new string[]
            {
                "Item 1",
                "Item 2",
                "Another item"
            };

            return Ok(model);
        }
    }
}
