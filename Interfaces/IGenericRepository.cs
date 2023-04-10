using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppMVP.Interfaces
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        void Add(Entity entity);
        void Edit(Entity entity);
        void Delete(int Id);
        IEnumerable<Entity> GetAll();
        IEnumerable<Entity> GetByValue(string searchValue);
    }
}
