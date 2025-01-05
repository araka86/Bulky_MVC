using Bulcky.DataAcess.Repository.IRepository;
using Bulky.DataAcess.Data;
using Bulky.Models;

namespace Bulcky.DataAcess.Repository
{
    public class CategoryRepository : Repository<Category>, IRepositoryCategory 
    {
      
        private ApplicationDbContext _db;

        //передача db в Repository<Category> для остальниых нереализованих методов
        public CategoryRepository(ApplicationDbContext db) :base(db) 
        {
                _db = db;
        }

   

        public void Update(Category obj)
        {
           _db.Update(obj);
          
        }
    }
}
