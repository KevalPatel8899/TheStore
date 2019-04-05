using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class FeedbackList
    {
        public IEnumerable<Feedback> Feedback { get; set; }
        public Feedback newCustomers { get; set; }
    }
}