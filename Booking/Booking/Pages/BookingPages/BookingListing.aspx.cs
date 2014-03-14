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

        }

        //Hämta lista tabell 1
        public IEnumerable<Model.Booking> Unbooked1ListView_GetData()
        {
            return Service.GetUnbooked1();
        }

        //Hämta lista tabell 1
        public IEnumerable<Model.Booking> Unbooked2ListView_GetData()
        {
            return Service.GetUnbooked2();
        }


        public void Unbooked1ListView_EditItem(int BookingID)
        {
            //spara bokningsinformation
            var booking = Service.GetBooking(BookingID);
        }

        public void Unbooked2ListView_EditItem(int BookingID)
        {
            //spara bokningsinformation
            var booking = Service.GetBooking(BookingID);
            //BookingLiteral.Text= String.Format(Service.GetBooking(BookingID))
            //ResultLiteral.Text = String.Format(ResultLiteral.Text, answer);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //visar kundbokning
            CustomerFormView.Visible = true;
            //Ta bort bokningslistor
            Unbooked1ListView.Visible = false;
            Unbooked2ListView.Visible = false;
        }






    }
}