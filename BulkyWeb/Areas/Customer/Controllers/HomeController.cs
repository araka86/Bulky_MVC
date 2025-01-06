using System.Diagnostics;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Customer.Controllers
{

    class MyClass
    {


        public int Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is MyClass other)
            {
                return this.Value == other.Value; // сравнение по значению
            }
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }


    [Area("Customer")]
    public class HomeController : Controller
    {



        public struct Point
        {
            public int X { get; set; }
           

            public Point()
            {
                X = 10;
           
            }
        }




        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

           
           


            MyClass obj1 = new MyClass { Value = 5 };
            MyClass obj2 = new MyClass { Value = 5 };

         
            var qqq = (obj1 == obj2); // False Ч сравнение ссылок
            var qqq1 = obj1.Equals(obj2); // True Ч сравнение по значению

          Point point = new Point();
            var ppp = point.X;
            point.X = 20;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
