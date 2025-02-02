using System.ComponentModel.DataAnnotations;

namespace CrudTest25.Web.Models.ViewModels
{
    public class AddCategoryRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}
