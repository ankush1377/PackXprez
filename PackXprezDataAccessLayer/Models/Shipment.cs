using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackXprezDataAccessLayer.Models
{
    public partial class Shipment
    {
        [Key]
        public int TransactionId { get; set; }
        public int Awbnumber { get; set; }
        public string EmailId { get; set; }
        public string ShipmentType { get; set; }
        public decimal? PackageLength { get; set; }
        public decimal? PackageBreadth { get; set; }
        public decimal? PackageHeight { get; set; }
        public decimal? PackageWeight { get; set; }
        public string PackagingRequired { get; set; }
        public string DeliveryType { get; set; }
        public string PickUpTime { get; set; }
        
        public int? SenderAddressId { get; set; }
       
        public int? ReceiverAddressId { get; set; }
        public decimal? TotalCost { get; set; }
        public string OrderStatus { get; set; }


        [NotMapped]
        public virtual Address ReceiverAddress { get; set; }

        [NotMapped]
        public virtual Address SenderAddress { get; set; }
    }
}
