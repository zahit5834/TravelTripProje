using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            by.Deger1= c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(by);
        }
        
        public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x => x.Id == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.Id == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogId == id).ToList();
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }

    }
}