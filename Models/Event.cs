using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace New_Zealand_MVC.Models
    //this class gives information about Event details 
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Event_Name { get; set; }
      
        public string Event_Place { get; set; }
        [Required]
        public string Event_Address { get; set; }
          [Required]
        public decimal Event_Price { get; set; }

    } 
}
