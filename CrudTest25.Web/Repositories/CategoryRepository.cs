using CrudTest25.Web.Data;
using CrudTest25.Web.Models.Domain;
using System.Linq.Expressions;

namespace CrudTest25.Web.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext applicationDbContext) : base (applicationDbContext)
        {
            _db = applicationDbContext;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);

        }
    }
}
