using System;
using System.Collections.Generic;

namespace PackXprezDataAccessLayer.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public string FeedbackType { get; set; }
        public string Comment { get; set; }
    }
}
