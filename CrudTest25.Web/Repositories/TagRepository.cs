using CrudTest25.Web.Data;
using CrudTest25.Web.Models.Domain;
using CrudTest25.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrudTest25.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public TagRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await applicationDbContext.Tags.AddAsync(tag);
            await applicationDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> DeleteAsync(int id)
        {
            var tag = await applicationDbContext.Tags.FindAsync(id);
            if (tag != null)
            {
                applicationDbContext.Tags.Remove(tag);
                await applicationDbContext.SaveChangesAsync();
                return tag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await applicationDbContext.Tags.ToListAsync();
        }

        public async Task<Tag> GetAsync(int id)
        {
            var tag = await applicationDbContext.Tags.FindAsync(id);
            if (tag != null)
            {
                return tag;

            }
            return null;
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            var existingTag = await applicationDbContext.Tags.FirstOrDefaultAsync(x => x.Id == tag.Id);
            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;
                await applicationDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }
    }
}
