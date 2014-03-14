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

        //När man trycker BOKA
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //hämta bokningsID mm för vald post


        }

        

        
    }
}