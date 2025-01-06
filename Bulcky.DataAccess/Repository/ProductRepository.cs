using Bulcky.DataAcess.Repository.IRepository;
using Bulky.DataAcess.Data;
using Bulky.Models;

namespace Bulcky.DataAcess.Repository
{
    public class ProductRepository : Repository<Product>, IRepositoryProduct
    {

        private ApplicationDbContext _db;

        //передача db в Repository<Category> для остальниых нереализованих методов
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        //custom update
        public void Update(Product obj)
        {
            _db.Update(obj);
            var objFromDd = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDd != null) 
            {
                objFromDd.Title = obj.Title;
                objFromDd.ISBN = obj.ISBN;
                objFromDd.Price = obj.Price;
                objFromDd.ListPrice = obj.ListPrice;
                objFromDd.Price50 = obj.Price50;
                objFromDd.Price100 = obj.Price100;
                objFromDd.Description = obj.Description;
                objFromDd.Author = obj.Author;
                objFromDd.CategoryId = obj.CategoryId;

            }
            if (obj.ImageUrl !=null) 
            {
                objFromDd.ImageUrl = obj.ImageUrl;
            }


        }

    }
}
