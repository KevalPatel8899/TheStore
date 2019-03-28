using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalAssingment.Models
{
    public class Product
    {
        //Primery Key
        [Required]
        public int ProductId { get; set; }

        //Product Name
        [Required]
        public string Name { get; set; }

        //Product Description
        [Required]
        public string Description { get; set; }

        //Product Price in decimals
        [Required]
        [Range (1,10000000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        //Product Categoty ID as foreign key
        public int CategoryId { get; set; }

        //Product category NAME
        public virtual Category CategoryName { get; set; }

    }
}