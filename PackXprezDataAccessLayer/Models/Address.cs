using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackXprezDataAccessLayer.Models
{
    public partial class Address
    {
        public Address()
        {
            
            ShipmentReceiverAddress = new HashSet<Shipment>();
            ShipmentSenderAddress = new HashSet<Shipment>();
        }

        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string BuildingNo { get; set; }
        public string StreetNo { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public decimal? Pincode { get; set; }
        public string AddressType { get; set; }

        [NotMapped]
        public virtual ServiceAvailable PincodeNavigation { get; set; }
        public virtual Users User { get; set; }

        [NotMapped]      
        public virtual ICollection<Shipment> ShipmentReceiverAddress { get; set; }
        [NotMapped]
        public virtual ICollection<Shipment> ShipmentSenderAddress { get; set; }
    }
}
