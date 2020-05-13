using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[controller]/customer")]
    public class CrmController : ControllerBase
    {
        private readonly ILogger<CrmController> _logger;
        private readonly ICustomerManagement _custMangr;

        public CrmController(ILogger<CrmController> logger,
            ICustomerManagement custMangr)
        {
            _logger = logger;
            _custMangr = custMangr;
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome to our Site!" + "\n" + DateTime.Now;
        }

        [HttpGet("all")]
        public List<Customer> GetAllCustomers()
        {
            return _custMangr.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            return _custMangr.FindCustomerById(id);
        }

        [HttpPost("")]
        public Customer PostCustomer(CustomerOption custOpt)
        {
            return _custMangr.CreateCustomer(custOpt);
        }

        [HttpPut("{id}")]
        public Customer PutCustomer(int id, CustomerOption custOpt)
        {
            return _custMangr.Update(custOpt, id);
        }

        [HttpDelete("hard/{id}")]
        public bool HardDeleteCustomer(int id)
        {
            return _custMangr.DeleteCustomerById(id);
        }

        [HttpDelete("soft/{id}")]
        public bool SoftDeleteCustomer(int id)
        {
            return _custMangr.SoftDeleteCustomerById(id);
        }
    }
}
