using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulcky.DataAcess.Repository.IRepository
{
    public interface IRepositoryCategory :IRepository<Category>
    {
        void Update(Category obj);


    }
}
