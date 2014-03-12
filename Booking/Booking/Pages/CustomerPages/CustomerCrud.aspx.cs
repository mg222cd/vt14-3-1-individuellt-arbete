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
        public void CustomerListView_UpdateItem(int customerId)
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