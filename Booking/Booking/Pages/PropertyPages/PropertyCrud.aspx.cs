using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Booking.Model;

namespace Booking.Pages.PropertyPages
{
    public partial class PropertyCrud : System.Web.UI.Page
    {
        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service());  }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Visar lista
        public IEnumerable<Property> PropertyListView_GetData()
        {
            return Service.GetProperties();
        }
    }
}