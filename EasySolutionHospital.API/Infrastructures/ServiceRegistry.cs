using EasySolutionHospital.API.Entity;
using EasySolutionHospital.API.Mapping;
using EasySolutionHospital.API.Services;
using EasySolutionHospital.Shared.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasySolutionHospital.API.Infrastructures
{
    public static class ServceRegistry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("Db_Connection")));
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IAdministratorService, AdministratorService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
           .AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders();

            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            return services;
        }

        public static void ApplyDatabaseMigrations(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (dbContext.Database.GetMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
            if (!dbContext.Users.Any())
            {
                string adminEmail = "admin@gmail.com";

                var adminUser = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Super",
                    LastName = "Admin",
                    Address = "Pabna, 6600",
                    DateOfBirth = new DateTime(2000, 01, 01),
                    UserName = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper()
                };
                var adminRole = new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRoleType.Admin.ToString(),
                    NormalizedName = UserRoleType.Admin.ToString().ToUpper(),
                };
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, AppSettings.Settings.AdminPassword);

                dbContext.Users.Add(adminUser);
                dbContext.Roles.AddRange(
                  new List<IdentityRole> {
                        adminRole,
                        new()
                        {
                            Name = UserRoleType.Administrator.ToString(),
                            NormalizedName = UserRoleType.Administrator.ToString().ToUpper()
                        },
                        new()
                        {
                            Name = UserRoleType.Doctor.ToString(),
                            NormalizedName =  UserRoleType.Doctor.ToString().ToUpper()
                        },
                        new()
                        {
                            Name = UserRoleType.User.ToString(),
                            NormalizedName =  UserRoleType.User.ToString().ToUpper()
                        }
                  });
                dbContext.UserRoles.Add(
                   new IdentityUserRole<string>
                   {
                       UserId = adminUser.Id,
                       RoleId = adminRole.Id
                   });

                dbContext.SaveChanges();
            }
        }
    }
}
