using Bulcky.DataAcess.Repository.IRepository;
using Bulky.DataAcess.Data;

namespace Bulcky.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {


        private ApplicationDbContext _db;
        public IRepositoryCategory Category { get; private set; }
        public IRepositoryProduct Product { get; private set; }

        public UnitOfWork(ApplicationDbContext db) 
        { 
            _db = db;
            Category = new CategoryRepository(db);
            Product = new ProductRepository(db);
        }

        

   

       
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
