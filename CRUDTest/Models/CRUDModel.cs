using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDTest.Models
{
    public class CRUDModel
    {
        [Key]
        public int CrudId { get; set; }
        public string Title { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public double TotalCost { get; set; }


    }
}