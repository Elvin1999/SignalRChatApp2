using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRChatApp2.Data;
using SignalRChatApp2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatApp2.Controllers
{
    public class HomeController:Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ApplicationContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser=await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName=currentUser.UserName;
            var messages = _context.Messages.ToList();
            return View();
        }

        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserName=User.Identity.Name;
                var sender=await _userManager.GetUserAsync(User);
                message.UserId=sender.Id;

                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        public IActionResult Privacy()
        {

            return View();
        }
    }
}
