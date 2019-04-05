using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        [Required]
        [DisplayName("Categories Name")]
        public virtual String CategoryName { get; set; }
        public virtual String ProductPhoto { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}