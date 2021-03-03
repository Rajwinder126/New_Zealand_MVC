using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace New_Zealand_MVC.Models
    //this class shows the booking details and it has four foriegn keys
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public string No_of_tickets { get; set; }
        public decimal Ticket_price { get; set; }
        [Required]
        //this is customer foriegn key
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        //this is Famous_Hotel foriegn key
        public int Famous_HotelId { get; set; }
        public Famous_Hotel Famous_Hotel { get; set; }
        //this is Attraction foriegn key
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }
        //this is Event foriegn key
        public int EventId { get; set; }
        public Event Event { get; set; }

    }
}
