using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PackXprezDataAccessLayer.Models
{
    public  class BranchOfficer
    {
        [Key]
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
