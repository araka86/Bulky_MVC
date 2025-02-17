using BulkyWebRazor_Temp.Models;
using BulkyWebRazor_Temp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext? _db;

        [BindProperty]
        public Category _category{ get; set; }

        public CreateModel(ApplicationDbContext? db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        { 
            _db.Categories.Add(_category);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
