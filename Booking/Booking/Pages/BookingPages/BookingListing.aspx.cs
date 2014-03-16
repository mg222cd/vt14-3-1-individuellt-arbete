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
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service());  }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //om det gjorts en bokning
            if (Session["Success"] as bool? == true)
            {
                Literal1.Text = String.Format(Literal1.Text = "Tack för din bokning! Bokningsbekräftelse kommer att skickas inom 48 h");
            }
            //Vid PageLoad initieras ny Session
            if (!IsPostBack)
            {
                Session["BookingId"] = 0;
            }
            
        }

        //Hämta lista tabell 1
        public IEnumerable<Model.Booking> Unbooked1ListView_GetData()
        {
            return Service.GetUnbooked1();
        }

        //Hämta lista tabell 2
        public IEnumerable<Model.Booking> Unbooked2ListView_GetData()
        {
            return Service.GetUnbooked2();
        }

        protected void booking_Command(object sender, CommandEventArgs e)
        {
            //sparar bokningsid för vald post i sessionsvariabeln
            int bookingID = int.Parse((string)e.CommandArgument);
            Session["BookingId"] = ((int?)Session["BookingId"] ?? 0);
            Session["BookingId"] = bookingID;
            //visar kundbokning
            CustomerFormView.Visible = true;
            //Ta bort bokningslistor
            Unbooked1ListView.Visible = false;
            Unbooked2ListView.Visible = false;
            //Information att använda i bekräftelsetext
            Model.Booking bookingObject = new Model.Booking();
            bookingObject = Service.GetBooking(bookingID);
            //Infotext
            MessageLabel.Visible = false;
            Literal1.Visible = true;
            Literal1.Text = String.Format(Literal1.Text="Bokning avseende vecka {0} år {1}. Pris {2}:-.", 
                bookingObject.Week, bookingObject.Year, bookingObject.Price);
            
        }

        //Infoga ny kund och uppdatera bokning
        public void CustomerFormView_InsertItem(Customer customer)
        {
                try
                {
                    //hitta bokningsid
                    int bookingId = ((int?)Session["BookingId"] ?? 0);
                    //infoga och uppdatera
                    Service.SaveCustomerAndUpdateBooking(bookingId, customer);
                    //rensar bokningsid:t
                    Session.Clear();
                    //sparar undan att dte är en bokning
                    Session["Success"] = true;
                    Response.Redirect("BookingListing.aspx");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel uppstod vid bokning.");
                }
        }


        





    }
}