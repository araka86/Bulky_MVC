using Bulcky.DataAcess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();


            return View(objProductList);

        }


        /////////////------------------CREATE----------------/////////////////////
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category
            //   .GetAll()
            //  .Select(u => new SelectListItem
            //  {
            //      Text = u.Name,
            //      Value = u.Id.ToString()
            //  });
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;




            ProductVM productVM = new()
            {
                CatogoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                  Text = u.Name,
                  Value = u.Id.ToString()
                }),
                Product = new Product()
            };


            return View(productVM);


        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {



            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");

            }
            else
            {
                productVM.CatogoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(productVM);
            }
           

        }

        /////////////------------------EDIT----------------/////////////////////
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(x => x.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index", "Product");

            }
            return View();
        }



        /////////////------------------DELETE----------------/////////////////////
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(x => x.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Product? productDel = _unitOfWork.Product.Get(x => x.Id == id);
            if (productDel == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(productDel);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index", "Product");



        }


    }
}
