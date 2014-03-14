using Booking.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        private BookingDAL _bookingDAL;
        private BookingDAL BookingDAL
        {
            get { return _bookingDAL ?? (_bookingDAL = new BookingDAL());  }
        }

        #endregion

        public void DeleteCustomer (int customerId)
        {
            CustomerDAL.DeleteCustomer(customerId);
        }

        public Customer GetCustomer(int customerId)
        {
            return CustomerDAL.GetCustomerById(customerId);
        }

        public Booking GetBooking(int BookingID)
        {
            return BookingDAL.GetBookingById(BookingID);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerDAL.GetCustomers();
        }

        public IEnumerable<Booking> GetUnbooked1()
        {
            return BookingDAL.GetUnbookedWeeksProp1();
        }

        public IEnumerable<Booking> GetUnbooked2()
        {
            return BookingDAL.GetUnbookedWeeksProp2();
        }

        public void SaveCustomer(Customer customer)
        {
            //validering
            ICollection<ValidationResult> validationResults;
            if (!customer.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (customer.CustomerID == 0)//Ny post om CustomerId är 0
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