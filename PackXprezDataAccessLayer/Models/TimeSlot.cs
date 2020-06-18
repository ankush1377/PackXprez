using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PackXprezDataAccessLayer.Models
{
    public partial class TimeSlot
    {
        [Key]
        public decimal? Pincode { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public virtual ServiceAvailable PincodeNavigation { get; set; }
    }
}
