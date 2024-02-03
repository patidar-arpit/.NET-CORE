using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Hello(int i=10,int a =20,int b=30)
        {
            Console.WriteLine(i);

            ViewBag.i = i;
            ViewBag.a = a;
            ViewBag.b = b;

            return View("MyView");
        }
    }
}
