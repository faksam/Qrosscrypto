using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Qrosscrypto.Models
{
    public class OrderFormModel
    {
        [Required]
        [Display(Name = "E-Currency")]
        public string ECurrency { get; set; }

        [Required]
        [Display(Name = "Amount in USD")]
        public string AmountUSD { get; set; }


        [Display(Name = "Amount in Naira")]
        public string AmountNaira { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        
        [Display(Name = "Wallet Address")]
        public string WalletAddress { get; set; }

        
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
    }
}