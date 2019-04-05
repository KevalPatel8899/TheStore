﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class StoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StoreContext() : base("name=StoreContext")
        {
        }

        public System.Data.Entity.DbSet<Store.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Store.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Store.Models.Feedback> Feedbacks { get; set; }
    }
}
