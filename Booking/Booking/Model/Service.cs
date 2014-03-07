﻿using Booking.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Model
{
    //Serviceklass som "pratar med " dataåtkomstklassen
    public class Service
    {
        #region privat egenskap som initierar customerDAL-objekt i varje metod i klassen

        private CustomerDAL _customerDAL;
        private CustomerDAL CustomerDAL
        {
            get { return _customerDAL ?? (_customerDAL = new CustomerDAL()); }
        }

        #endregion

        public Customer GetCustomer(int customerId)
        {
            return CustomerDAL.GetCustomerById(customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerDAL.GetCustomers();
        }

        public void SaveCustomer(Customer customer)
        {
            //TODO Validering i Save-metoden!
            if (customer.CustomerId == 0)
            {
                CustomerDAL.InsertCustomer(customer);
            }
            else
            {
                CustomerDAL.UpdateCustomer(customer);
            }
        }


    }
}