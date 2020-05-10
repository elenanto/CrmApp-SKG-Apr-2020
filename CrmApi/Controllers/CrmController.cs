using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrmController : ControllerBase
    {
        private readonly ILogger<CrmController> _logger;

        public CrmController(ILogger<CrmController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome to our Site!" + "\n" + DateTime.Now;
        }
    }
}
