using CustomIdentity.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentity.Models.Context
{
    public class CustomContext : IdentityDbContext<User, Role, int>
    {
        public CustomContext(DbContextOptions<CustomContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(u =>
            {
                u.ToTable("User");
                u.HasKey(x => x.IdUser);

                u.Ignore(x => x.Logins);
                u.Ignore(x => x.AccessFailedCount);
                u.Ignore(x => x.ConcurrencyStamp);
                u.Ignore(x => x.AccessFailedCount);
                u.Ignore(x => x.NormalizedEmail);
                u.Ignore(x => x.NormalizedUserName);
                u.Ignore(x => x.EmailConfirmed);
                u.Ignore(x => x.LockoutEnabled);
                u.Ignore(x => x.LockoutEnd);
                u.Ignore(x => x.PhoneNumber);
                u.Ignore(x => x.PhoneNumberConfirmed);
                u.Ignore(x => x.PasswordHash);
                u.Ignore(x => x.SecurityStamp);
                u.Ignore(x => x.TwoFactorEnabled);
                u.Ignore(x => x.Id);
                u.Ignore(x => x.UserName);

                /*u.HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.Id);*/
            });

            builder.Entity<Role>(p =>
            {
                p.ToTable("Role");
                p.HasKey(x => x.IdRole);

                p.Ignore(x => x.Id);
                p.Ignore(x => x.Name);
                p.Ignore(x => x.ConcurrencyStamp);
                p.Ignore(x => x.NormalizedName);
            });

            builder.Entity<IdentityUserRole<int>>(ur =>
            {
                ur.ForSqlServerToTable("UserRoles");
                ur.HasKey(x => new { x.UserId, x.RoleId });
                ur.Property(x => x.UserId).HasColumnName("IdUser");
                ur.Property(x => x.RoleId).HasColumnName("IdRole");
            });

            builder.Entity<IdentityUserClaim<int>>(uc =>
            {
                uc.ToTable("UserClaims");
                uc.Property(x => x.Id).ForSqlServerHasColumnName("IdClaim");
                uc.Property(x => x.UserId).ForSqlServerHasColumnName("IdUser");
            });

            builder.Entity<IdentityRoleClaim<int>>(rc =>
            {
                rc.ToTable("RoleClaims");
                rc.Property(x => x.Id).ForSqlServerHasColumnName("IdClaim");
                rc.Property(x => x.RoleId).ForSqlServerHasColumnName("IdRole");
            });

            builder.Ignore<IdentityUserLogin<int>>();
            builder.Ignore<IdentityUserToken<int>>();
        }
    }
}
