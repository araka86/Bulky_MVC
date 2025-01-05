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



        public void Update(Product obj)
        {
            _db.Update(obj);

        }

    }
}
