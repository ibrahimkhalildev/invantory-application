using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invantory_Application.Models
{
    public class Payment_API
    {
        public string APIConnect { get; set; }
        public int no_of_trans_found { get; set; }
        public List<Payment_elements> payment_elements { get; set; }
    }
}