using Microsoft.AspNetCore.Mvc;
using Project_Dezert.Models;
using System.Diagnostics;
using Project_Dezert.Data;
using Microsoft.Extensions.Hosting;

namespace Project_Dezert.Controllers
{
    public class HomeController : Controller
    {
        Project_DezertContext db;
        private IWebHostEnvironment Environment;
        public HomeController(Project_DezertContext context, IWebHostEnvironment _environment)
        {
            db = context;
            Environment = _environment;
        }
        public async Task<IActionResult> HomePage()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> LogIn(Users user)
        {
            if(user.Login!=null && user.Password != null) 
            {
                var person = db.Users.ToList();

                var login = person.FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);

                return View("HomePage", login);
            }
            else
            {
                return View(TempData["msg"] = "<script>alert('Change succesfully');</script>");
            }
        }
       
        public async Task<IActionResult> Index()
        {

            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Users user,Photo photo)
        {
            string wwwRootPath = Environment.WebRootPath;

            string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);

            string extension = Path.GetExtension(user.ImageFile.FileName);          

            user.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await user.ImageFile.CopyToAsync(fileStream);
               
            }
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("LastPerson");
        }
        public IActionResult LastPerson()
        {
            var person = db.Users.ToList();
            return View("HomePage", person.Last());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}