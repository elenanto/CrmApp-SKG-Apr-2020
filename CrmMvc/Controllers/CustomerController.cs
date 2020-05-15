using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Options;
using CrmApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrmMvcProj.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerManagement _custMangr;

        public CustomerController(ICustomerManagement custMangr)
        {
            _custMangr = custMangr;
        }

        //   localhost:port/customer/addcustomer
        [HttpPost]
        public Customer AddCustomer([FromBody] CustomerOption custOpt)
        {
            return _custMangr.CreateCustomer(custOpt);
        }

        //get all
        public List<Customer> GetAllCustomers()
        {
            return _custMangr.GetAllCustomers();
        }

    }
}