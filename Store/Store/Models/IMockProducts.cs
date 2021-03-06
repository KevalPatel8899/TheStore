﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    interface IMockProducts
    {
        IQueryable<Product> Products { get; }
        Product Save(Product product);
        void Delete(Product product);
        void Dispose();
    }
}
