using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invantory_Application.Models
{
    public class EquipmentList
    {
        public int EquipmentId { get; set; }
        public int CustomerID { get; set; }
        public string EquipmentName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime EntryDate { get; set; }

    }
}