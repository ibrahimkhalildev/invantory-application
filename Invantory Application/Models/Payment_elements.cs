using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invantory_Application.Models
{
    public class Payment_elements
    {
        public int val_id {  get; set; }
        public string status { get; set; }
        public DateTime validated_on { get; set; }
        public string currency_type {  get; set; }
        public float currency_amount {  get; set; }
        public float base_fair {  get; set; }
        public DateTime tran_date { set; get; }
        public string tran_id { get; set; }
        public string bank_tran_id {  get; set; }
        public string currency {  get; set; }
        public string card_issuer {  get; set; }
        public string card_brand {  get; set; }
        public string card_issuer_country { get; set; }
        public string card_issuer_country_code { get; set; }
        public string error {  get; set; }
    }
}