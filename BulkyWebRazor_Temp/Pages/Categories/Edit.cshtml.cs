using BulkyWebRazor_Temp.Models;
using BulkyWebRazor_Temp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext? _db;

        [BindProperty]
        public Category _category { get; set; }

        public EditModel(ApplicationDbContext? db)
        {
            _db = db;
        }



        public void OnGet(int? Id)
        {
            if(Id != null && Id !=0)
            {
                _category = _db.Categories.Find(Id);
            }
            


        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(_category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");

            }


            return Page();
        }
    }
}
