using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IAdminService
    {
        IEnumerable<UserWithRoleVM> GetAllUsers();
    }
}
