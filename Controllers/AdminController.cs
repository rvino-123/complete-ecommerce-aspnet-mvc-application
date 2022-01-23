using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminController : Controller
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        // Admin Panel Can:
        // See all users data including roles/name/email
        // Delete Users
        // See A list of User Orders
        public IActionResult Index()
        {
            var data =  _service.GetAllUsers();
            return View(data);
        }
    }
}
