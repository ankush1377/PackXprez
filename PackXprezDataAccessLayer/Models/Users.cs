using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PackXprezDataAccessLayer.Models
{
    public partial class Users
    {
        public Users()
        {
            Address = new HashSet<Address>();
        }
        [Key]
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string UserPassword { get; set; }
        public decimal? ContactNo { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
