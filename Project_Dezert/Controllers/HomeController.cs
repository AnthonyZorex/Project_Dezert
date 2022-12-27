using Microsoft.AspNetCore.Mvc;
using Project_Dezert.Models;
using System.Diagnostics;
using Project_Dezert.Data;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol.Plugins;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<IActionResult> MessagePage(Users user)
        {
            var person = db.Users.Where(x => user.Id == x.Id);
            var content = db.Photos.Where(x => user.Id == x.UserId).ToList();
            var friend = db.Friends.Where(x => user.Id == x.UserId).ToList();
            user = person.First();
            var users = new Users
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Login = user.Login,
                City = user.City,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber,
                Photo = content,
                ImageName = user.ImageName,
                Age = user.Age,
                ImageFile = user.ImageFile,
                Sername = user.Sername,
                friends = friend
            };
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> FriendsPage(Users user)
        {
            var person = db.Users.Where(x => user.Id == x.Id);
            var content = db.Photos.Where(x => user.Id == x.UserId).ToList();
            var friend = db.Friends.Where(x => user.Id == x.UserId).ToList();
            user = person.First();
            var users = new Users
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Login = user.Login,
                City = user.City,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber,
                Photo = content,
                ImageName = user.ImageName,
                Age = user.Age,
                ImageFile = user.ImageFile,
                Sername = user.Sername,
                friends = friend
            };

            return View(users);
        }
        [HttpGet]
        [Route("Home/HomePage")]
        public async Task<IActionResult> HomePage(Users user)
        {
            var content = db.Photos.Where(x => user.Id == x.UserId).ToList();
            var friend = db.Friends.Where(x => user.Id == x.UserId).ToList();
            var person = db.Users.Where(x=> user.Id == x.Id);
            user = person.First();
            var users = new Users
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Login = user.Login,
                City = user.City,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber,
                Photo = content,
                ImageName = user.ImageName,
                Age = user.Age,
                ImageFile = user.ImageFile,
                Sername = user.Sername,
                friends = friend
            };
            var listUsers = db.Users;
            return View(users);
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(Users user, Photo photo)
        {
            var person = db.Users.ToList();

            var login = person.FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);

            if (login != null)
            {

                var content = db.Photos.Where(x => x.UserId == login.Id).ToList();

                return RedirectToAction("HomePage",new {login.Id});

            }
            else
            {
                ViewBag.ErrorMessage = "Email and Password not found or matched";
                return View("Index");
            }





        }
        //[HttpPost]
        //public async Task<IActionResult> EditPhoto(int? id)
        //{
        //    if (id == null || db.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("HomePage",users);
        //}

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Users user, Photo photo)
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