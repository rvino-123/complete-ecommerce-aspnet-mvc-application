using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class AdminController : Controller
    {
        private readonly IAdminService _service;
        private readonly UserManager<ApplicationUser> _userManager;


        public AdminController(IAdminService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
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
        
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return View("NotFound");

            var response = new EditUserVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName
            };
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditUserVM edituserVM)
        {
            //if (!ModelState.IsValid) return View(userwithroleVM);

            var user = await _userManager.FindByIdAsync(edituserVM.Id);

            if (user != null)
            {
                if (!string.IsNullOrEmpty(edituserVM.Email))
                {
                    user.Email = edituserVM.Email;
                }
                if (!string.IsNullOrEmpty(edituserVM.FullName))
                {
                    user.FullName = edituserVM.FullName;
                }
                if (!string.IsNullOrEmpty(edituserVM.FullName))
                {
                    user.UserName = edituserVM.UserName;
                }
            }

            var updatedUserResponse = await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return View("Not Found");
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
