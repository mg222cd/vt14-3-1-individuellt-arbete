using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Booking.Model;

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
    }
}