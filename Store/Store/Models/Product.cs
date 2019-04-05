using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        [Required]
        public virtual String Description { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public virtual String ProductName { get; set; }
        [Required]
        [Range(0.01, 100000000)]
        [DataType(DataType.Currency)]
        public virtual Decimal Price { get; set; }
        public virtual String ProductPhoto { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Category CategoryName{ get; set; }
    }
}