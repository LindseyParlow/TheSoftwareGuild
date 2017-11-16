using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ContactUsVM
    {
        public ContactUsQuery ContactUs { get; set; }

        public ContactUsVM()
        {
            ContactUs = new ContactUsQuery();
        }
    }
}