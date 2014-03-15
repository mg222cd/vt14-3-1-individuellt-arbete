using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Booking.Model;

namespace Booking.Pages.CustomerPages
{
    public partial class CustomerCrud : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //TODO: Ordna UploadLabel så att statusmedelande visas vid lyckad CRUD. FIxa även JS-filen och Falsa kontrollen.

        //Visa alla kunder
        public IEnumerable<Customer> CustomerListView_GetData()
        {
            return Service.GetCustomers();
        }

        //Lägg till kund
        public void CustomerListView_InsertItem(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveCustomer(customer);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel uppstod då kund skulle läggas till.");
                }
            }
        }

        //Uppdatera kund
        public void CustomerListView_UpdateItem(int customerID)
        {
            try
            {
                var customer = Service.GetCustomer(customerID);
                if (customer == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunden med kundnummer {0} hittades inte", customerID));
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
        public void CustomerListView_DeleteItem(int customerID)
        {
            try
            {
                Service.DeleteCustomer(customerID);
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Fel uppstod då kund skulle raderas. Kontrollera att kund inte har bokningar. Isåfall - radera först dessa och försök sedan igen.");
            }
        }
    }
}