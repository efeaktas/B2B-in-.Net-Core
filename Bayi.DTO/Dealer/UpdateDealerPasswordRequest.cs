using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Dealer
{
    public class UpdateDealerPasswordRequest
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
