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
    public class CategoryRespository : Repository<Category>, ICategoryRepository
    {
       
       private readonly AppDbContext _db;
        public CategoryRespository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        
       

        public void save()
        {
            _db.SaveChanges();
        }

       

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
