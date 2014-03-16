using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Booking.Model;
using System.Web.ModelBinding;

namespace Booking.Pages.BookingPages
{
    public partial class BookingCRD : System.Web.UI.Page
    {
        private Model.Service _service;

        private Model.Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Hämtar alla bokningar
        public IEnumerable<Model.Booking> BookingListView_GetData()
        {
            return Service.GetAllBookings();
        }

        //Raderar bokning
        public void BookingListView_DeleteItem(int bookingId)
        {
            try
            {
                Service.DeleteBooking(bookingId);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel uppstod då bokning skulle raderas.");
            }
        }

        //Ger Namn till FK:s
        protected void BookingListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var bookingInfo = (Booking.Model.Booking)e.Item.DataItem;
            
            if (bookingInfo != null)
            {
                //lägger till stugnamn istället för id
                var property = Service.GetProperty(bookingInfo.PropertyID);
                var propertyIdLabel = e.Item.FindControl("PropertyIDLabel") as Label;
                propertyIdLabel.Text = String.Format("{0}", property.PropertyName);
                //lägger till kundnamn istället för id
                var customer = Service.GetCustomer(bookingInfo.CustomerID);
                var customerIdLabel = e.Item.FindControl("CustomerIDLabel") as Label;
                customerIdLabel.Text = String.Format("{0}", customer.Name);
            }
        }

        //Infogar ny bokning
        public void BookingListView_InsertItem(Model.Booking booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveBooking(booking);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel uppstod då bokning skulle läggas till i listan");
                }
            }
        }

        //DropdownList för Stugnamn - Insert
        public IEnumerable<Property> PropertyNameDropDownList_GetData()
        {
            return Service.GetProperties();
        }

        //Dropdownlist för Kundnamn - Insert
        public IEnumerable<Customer> CustomerNameDropDownList_GetData()
        {
            return Service.GetCustomers();
        }
    }
}