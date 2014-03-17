using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Booking.Pages.BookingPages
{
    public partial class BookingListing : System.Web.UI.Page
    {
        //Referens till Service
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service());  }
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Lagrar BokningsID för vald post
            if (!IsPostBack)
            {
                Session["BookingId"] = 0;
            }
            
        }

        //Lista 1
        public IEnumerable<Model.Booking> Unbooked1ListView_GetData()
        {
            return Service.GetUnbooked1();
        }

        //Lista 2
        public IEnumerable<Model.Booking> Unbooked2ListView_GetData()
        {
            return Service.GetUnbooked2();
        }

        protected void booking_Command(object sender, CommandEventArgs e)
        {
            //sparar bokningsid för vald post
            int bookingID = int.Parse((string)e.CommandArgument);
            Session["BookingId"] = ((int?)Session["BookingId"] ?? 0);
            Session["BookingId"] = bookingID;
            //visar kundbokning & tar bort listor
            CustomerFormView.Visible = true;
            Unbooked1ListView.Visible = false;
            Unbooked2ListView.Visible = false;
            //Information att använda i bokningsinfo
            Model.Booking bookingObject = new Model.Booking();
            bookingObject = Service.GetBooking(bookingID);
            //Bokningsinfo
            Literal2.Visible = true;
            Literal2.Text = String.Format(Literal2.Text="Bokning avseende vecka {0} år {1}. Pris {2}:-.", 
                bookingObject.Week, bookingObject.Year, bookingObject.Price);
        }

        //Infoga ny kund och uppdatera bokning
        public void CustomerFormView_InsertItem(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //hitta bokningsid
                    int bookingId = ((int?)Session["BookingId"] ?? 0);
                    //infoga, uppdatera & visa meddelande
                    Service.SaveCustomerAndUpdateBooking(bookingId, customer);
                    Session.Clear();
                    Response.Redirect("BookingSuccess.aspx");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel uppstod då kund skulle läggas till.");
                }
            }
        }
    }
}