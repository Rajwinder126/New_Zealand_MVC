using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace New_Zealand_MVC.Models
    //New Zealand famous hotals details are showed by this class
{
    public class Famous_Hotel
    {
        public int Id { get; set; }
        [Required]
        public string Hotal_Name { get; set; }
        [Required]
        public string Address { get; set; }
        public decimal Room_Price { get; set; }
        [Required]
        public string Room_Type { get; set; }
       

    }
}

