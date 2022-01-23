using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class AdminService : IAdminService
    {
        private AppDbContext _context;

        public AdminService(AppDbContext context)
        {
          _context = context;
        }
        public  IEnumerable<UserWithRoleVM> GetAllUsers()
        {
            // var allUsers = await _context.Users.ToListAsync();
            // return allUsers;
            var allUsers = (from user in _context.Users
                            join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                            join role in _context.Roles on userRoles.RoleId equals role.Id select new UserWithRoleVM
                            {
                                UserId = user.Id,
                                UserName = user.UserName,
                                FullName = user.FullName,
                                Email = user.Email,
                                Role = role.Name
                            }).ToList();
            return allUsers;

        }
    }
}
