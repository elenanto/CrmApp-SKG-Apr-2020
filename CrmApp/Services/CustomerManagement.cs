﻿using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmApp.Services
{
    public class CustomerManagement: ICustomerManagement
    {
        private CrmDbContext _db;
        
        public CustomerManagement(CrmDbContext db)
        {
            _db = db;
        }
           
        //CRUD
        // create read update delete
        public Customer CreateCustomer(CustomerOption custOption)
        {
            Customer customer = new Customer
            {
                FirstName = custOption.FirstName,
                LastName  = custOption.LastName,
                Address  = custOption.Address,
                Dob  = custOption.Dob,
                Email  = custOption.Email,
                Active = true,
                Balance = 0,
            };

            _db.Customers.Add(customer);
            _db.SaveChanges();
      
            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public Customer FindCustomerById(int customerId)
        {
   
            return _db.Customers.Find(customerId); 
        }

        public List<Customer> FindCustomerByName(CustomerOption custOption)
        {
            return _db.Customers
                .Where(cust => cust.LastName == custOption.LastName)
                .Where(cust => cust.FirstName == custOption.FirstName)
                .ToList();
        }

        public Customer Update(CustomerOption custOption, int customerId)
        {
             
            Customer customer = _db.Customers.Find(customerId);

            if (custOption.FirstName!=null)
                customer.FirstName = custOption.FirstName;
            if (custOption.LastName != null)
                customer.LastName = custOption.LastName;
            if (custOption.Email != null)
                customer.Email = custOption.Email;
            if (custOption.Address != null)
                customer.Address = custOption.Address;

            _db.SaveChanges();
            return customer;
        }

        public bool DeleteCustomerById(int id)
        {
             
            Customer customer = _db.Customers.Find(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
                return true;
            }
            return false;    
        }

        public bool SoftDeleteCustomerById(int id)
        {
            Customer customer = _db.Customers.Find(id);
            if (customer != null)
            {
                customer.Active = false;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
