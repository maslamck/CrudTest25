using CrudTest25.Web.Data;
using CrudTest25.Web.Models.Domain;
using CrudTest25.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudTest25.Web.Controllers
{
    public class AdminTagController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminTagController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            await applicationDbContext.Tags.AddAsync(tag);
            await applicationDbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tags = await applicationDbContext.Tags.ToListAsync();
            return View(tags);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var tag = applicationDbContext.Tags.Find(id);
            var tag = await applicationDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,

                };
                return View(editTagRequest);

            }
            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            //var tag = new Tag
            //{
            //    Id = editTagRequest.Id,
            //    Name = editTagRequest.Name,
            //    DisplayName = editTagRequest.DisplayName,
            //};

            var existingTag = await applicationDbContext.Tags.FirstOrDefaultAsync(x => x.Id == editTagRequest.Id);
            if (existingTag != null)
            {
                existingTag.Name = editTagRequest.Name;
                existingTag.DisplayName = editTagRequest.DisplayName;
                await applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var tag = await applicationDbContext.Tags.FirstOrDefaultAsync(x => x.Id == editTagRequest.Id);
            if (tag != null)
            {
                applicationDbContext.Tags.Remove(tag);
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction("List");

            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
    }
}
