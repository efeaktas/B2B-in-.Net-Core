using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Admin
{
    public class UpdateAdminResponse
    {
        public string Email { get; set; }

        public string Phone { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string AuthorizedPerson { get; set; }
    }
}
