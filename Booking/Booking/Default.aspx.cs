using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace Booking
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       //Visa alla kunder
        public IEnumerable<Customer> CustomerListView_GetData()
        {
            return Service.GetCustomers();
        }

        //Lägg till kund
        public void CustomerListView_InsertItem (Customer customer)
        {   
            if (ModelState.IsValid)
            { 
                try
                {
                    Service.SaveCustomer(customer);
                }
                catch (Exception ex)
                {
                    //var validationResults = ex.Data["ValidationResults"] as IEnumerable<ValidationResult>;
                    //if (validationResults != null)
                    //{
                    //    foreach (var validationResult in validationResults)
                    //    {
                    //        foreach (var membername in validationResult.MemberNames)
                    //        {
                    //            ModelState.AddModelError(membername, validationResult.ErrorMessage);
                    //        }
                    //    }
                    //}
                    ModelState.AddModelError(String.Empty, "Ett fel uppstod då kund skulle läggas till.");
                }
            }
        }

        //Uppdatera kund
        public void CustomerListView_UpdateItem (int customerId)
        {
            try
            {
                var customer = Service.GetCustomer(customerId);
                if (customer == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunden med kundnummer {0} hittades inte", customerId));
                }
                if (TryUpdateModel(customer))
                {
                    Service.SaveCustomer(customer);
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett oväntet fel inträffade då kund skulle uppdateras");
            }
        }

        //radera kund
        public void CustomerListView_DeleteItem(int customerId)
        {
            try
            {
                Service.DeleteCustomer(customerId);
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "ETt oväntat fel inträffade då kund skulle raderas");
            }
        }



    }
}