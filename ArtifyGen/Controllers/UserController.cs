using ArtifyGen.Data;
using ArtifyGen.DTO;
using ArtifyGen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ArtifyGen.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO UserDTO, string Password, string ConfirmPassword, IFormFile FormFile)
        {
            if(FormFile != null)
            {
                using (var stream = FormFile.OpenReadStream())
                using (var reader = new BinaryReader(stream))
                {
                    var byteFile = reader.ReadBytes((int)stream.Length);
                    UserDTO.Image = byteFile;
                }
                UserDTO.ImageName = FormFile.FileName;
                UserDTO.ContentType = FormFile.ContentType;
            }
           
            User User = new User();
            User.ImageName= UserDTO.ImageName;
            User.ContentType= UserDTO.ContentType;
            User.Image= UserDTO.Image;
            User.FirstName = UserDTO.FirstName;
            User.LastName = UserDTO.LastName;
            User.EmailConfirmed = true;
            User.NormalizedEmail = UserDTO.Email.ToUpper();
            User.NormalizedUserName = UserDTO.Email.ToUpper();
            User.UserName = UserDTO.Email;
            User.Role = "User";
            var result = await _userManager.CreateAsync(User, Password);

            var Id = User.Id;
            var roleId = "2";
            var userRole = new IdentityUserRole<string>
            {
                UserId = Id,
                RoleId = roleId
            };
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Profile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = _context.Users.Where(user => user.Id == userId).SingleOrDefault();
            return View(user);
        }
    }
}
