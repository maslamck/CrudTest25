using CrudTest25.Web.Models.Domain;

namespace CrudTest25.Web.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        void Update(Category obj);
        void Save();

    }
}
