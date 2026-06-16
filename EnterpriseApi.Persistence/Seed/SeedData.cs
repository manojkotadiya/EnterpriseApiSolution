using EnterpriseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnterpriseApi.Persistence.Seed
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    RoleName = "Admin",
                    Description = "System Administrator"
                },
                new Role
                {
                    RoleId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    RoleName = "Manager",
                    Description = "Business Manager"
                },
                new Role
                {
                    RoleId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    RoleName = "User",
                    Description = "Standard User"
                });
        }
    }
}