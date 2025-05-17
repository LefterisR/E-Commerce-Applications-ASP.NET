using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.DataAccess.Data;
using WebShop.DataAccess.Repository.IRepository;
using WebShop.Models;

namespace WebShop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product objProduct)
        {
            _db.Products.Update(objProduct);
        }
    }
}
