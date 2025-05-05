using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventory.DataAccess.Repository.Irepositiry;
using Inventory.Models;

namespace inventory.DataAccess.Repository
{
    public interface IProductRepository: IRepository<Product>
    {
       

        void Update(Product obj);
        void save();
       
       
    }
    
}
