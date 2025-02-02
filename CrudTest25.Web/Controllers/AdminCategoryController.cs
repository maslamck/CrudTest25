using CrudTest25.Web.Data;
using CrudTest25.Web.Models.Domain;
using CrudTest25.Web.Models.ViewModels;
using CrudTest25.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest25.Web.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public AdminCategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(AddCategoryRequest addCategoryRequest)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = addCategoryRequest.Name,
                    DisplayName = addCategoryRequest.DisplayName,
                };
                categoryRepository.Add(category);
                categoryRepository.Save();
                return RedirectToAction("List");
            }
            return View();
            
        }

        [HttpGet]
        public IActionResult List()
        {
            var category = categoryRepository.GetAll().ToList();
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categoryRepository.Get(x=>x.Id==id);
            if (category != null)
            {
                var editCategoryRequest = new EditCategoryRequest
                {
                    Id = category.Id,
                    Name = category.Name,
                    DisplayName = category.DisplayName,
                };
                return View(editCategoryRequest);
            }
            return View(null);
        }
        [HttpPost]
        public IActionResult Edit(EditCategoryRequest editCategoryRequest)
        {
            if (ModelState.IsValid)
            {
                var category = categoryRepository.Get(x => x.Id == editCategoryRequest.Id);
                if (category != null)
                {
                    category.Name = editCategoryRequest.Name;
                    category.DisplayName = editCategoryRequest.DisplayName;

                }
                categoryRepository.Save();
                return RedirectToAction("List");
            }
            return View(null);
        }
        [HttpPost]
        public IActionResult Delete(EditCategoryRequest editCategoryRequest) {
            var category = categoryRepository.Get(x => x.Id == editCategoryRequest.Id);
            if (category != null) {
                categoryRepository.Remove(category);
                categoryRepository.Save();
            }

            return RedirectToAction("List");
        }

    }
}
