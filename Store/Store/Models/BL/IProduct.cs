using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public interface IProduct
    {
        IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }
        Product Save(Product product);
        void Delete(Product product);
        void Dispose();
    }
}