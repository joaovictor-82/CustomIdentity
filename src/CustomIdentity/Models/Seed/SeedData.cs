using CustomIdentity.Models.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CustomIdentity.Models.Seed
{
    public static class SeedData
    {
        public static async void AddRoles(this IApplicationBuilder app)
        {
            var roleManager = app.ApplicationServices.GetService<RoleManager<Role>>();

            var roles = new List<Role>
            {
                new Role { IdRole = 1, NameRole = "Admin" },
                new Role { IdRole = 2, NameRole = "Manager" },
                new Role { IdRole = 3, NameRole = "User" }
            };

            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role.NameRole).Result)
                {
                    var result = await roleManager.CreateAsync(role);

                    if (!result.Succeeded)
                        break;
                }
            }
        }
    }
}
