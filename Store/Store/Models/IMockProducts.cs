using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    interface IMockProducts
    {
        IQueryable<Product> Products { get; set; }
        Product Save(Category category);
        void Delete(Category category);

    }
}
