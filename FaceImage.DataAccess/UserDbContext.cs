using System;
using FaceImage.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FaceImage.DataAccess
{
    public class UserDbContext : IdentityDbContext<AppUser, AppUserRole, string>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) 
            : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
    }
}
