using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Customer
{
    public class CreateCustomerRequest
    {
        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string Authorized { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
