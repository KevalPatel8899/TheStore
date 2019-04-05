using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Feedback
    {
        [Key]
        public int CustomerId { get; set; }

        public virtual String CustomerName { get; set; }

        public virtual String CustomerFeedback { get; set; }
    }
}