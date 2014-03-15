﻿using Booking.Model;
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
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel uppstod då kund skulle läggas till.");
                }
        }


        





    }
}