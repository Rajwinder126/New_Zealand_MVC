using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace New_Zealand_MVC.Models
    //this class reveals the information for attraction details
{
    public class Attraction
    {
        public int Id { get; set; }
        [Required]
        public string Attraction_Name { get; set; }
        public string Attraction_Place { get; set; }
        [Required]
        public string Attraction_Address { get; set; }
        public string Attraction_Description { get; set; }
        [Required]
        public decimal Attraction_Price { get; set; }
        [Required]
        public string Attraction_Open_Hours { get; set; }

    }
}
