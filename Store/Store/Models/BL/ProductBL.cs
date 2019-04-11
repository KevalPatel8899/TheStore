using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.BL
{
    public class ProductBL : IProductBL
    {
        private StoreContext db = new StoreContext();

        public IQueryable<Product> Products { get { return db.Products; } }

        public void Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Product Save(Product product)
        {
            if (product.ProductId == 0)
            {
                db.Products.Add(product);
            }
            else
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();

            return product;
        }
    }
}