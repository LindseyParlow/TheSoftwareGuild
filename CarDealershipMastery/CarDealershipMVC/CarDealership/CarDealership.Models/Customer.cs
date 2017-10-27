﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneId { get; set; }
        public string CustomerMessage { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}