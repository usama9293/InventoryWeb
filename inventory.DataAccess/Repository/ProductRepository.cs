using inventory.DataAccess.Data;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace inventory.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
       
       private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        
       

        public void save()
        {
            _db.SaveChanges();
        }

       

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
