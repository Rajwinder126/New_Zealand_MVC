using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace New_Zealand_MVC.Models
    //this class reveals the information about customer details
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Customer_Name { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
