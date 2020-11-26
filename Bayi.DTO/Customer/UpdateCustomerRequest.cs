using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Customer
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Authorized { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
