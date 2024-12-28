using BulkyWebRazor_Temp.Models;
using BulkyWebRazor_Temp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {


        private readonly ApplicationDbContext? _db;

     
        public Category _category { get; set; }

        public DeleteModel(ApplicationDbContext? db)
        {
            _db = db;
        }

        public void OnGet(int? Id)
        {
            if (Id != null && Id != 0)
            {
                _category = _db.Categories.Find(Id);
            }
        }


        public IActionResult OnPost(int? id)
        {

            Category? categoryDel = _db.Categories.Find(id);
            if (categoryDel == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryDel);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");

        


        }

    }
}
