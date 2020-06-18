using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackXprezDataAccessLayer.Models
{
    public partial class ServiceAvailable
    {
        public ServiceAvailable()
        {
            Address = new HashSet<Address>();
        }
        [Key]
        public decimal Pincode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        [NotMapped]
        public virtual ICollection<Address> Address { get; set; }
    }
}
