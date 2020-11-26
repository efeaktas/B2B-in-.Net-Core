using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.User
{
    public class UpdateAdminPasswordRequest
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
