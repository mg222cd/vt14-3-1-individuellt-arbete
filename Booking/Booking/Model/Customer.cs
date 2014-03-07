using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking.Model
{
    public class Customer
    {
        //Egeneskaper som motsvarar kolumner i tabellen.
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Ett namn måste anges.")]
        [StringLength(40)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adress måste anges.")]
        [StringLength(40)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postnr måste anges.")]
        [StringLength(6)]
        [RegularExpression(@"^[1-9]\d{2} ?\d{2}", ErrorMessage = "Felaktigt format för postnummer.")]
        public string Postal { get; set; }

        [Required(ErrorMessage = "Ort måste anges.")]
        [StringLength(25)]
        public string City { get; set; }

        [Required(ErrorMessage = "Telefonnummer måste anges.")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email måste anges.")]
        [StringLength(50)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-postadressen är inte giltig.")]
        public string Email { get; set; }
        
    }
}