﻿namespace SistemaPueblito.Web.Helpers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using SistemaPueblito.Web.Models;

    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<User> GetUserByIdAsync(string userId);

        Task<List<User>> GetAllUsersAsync();

        Task RemoveUserFromRoleAsync(User user, string roleName);

        Task DeleteUserAsync(User user);
    }
}
