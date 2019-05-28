namespace Tedushop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tedushop.Model.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Tedushop.Data.TedushopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tedushop.Data.TedushopDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //Tạo dữ liệu mẫu cho bảng

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TedushopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TedushopDbContext()));

            //Các cái ApplicationUser có sẵn của hệ thống
            var user = new ApplicationUser()
            {
                UserName = "tedu",
                Email = "proakiss1@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Nguyen Phuong Nam",
                Address= "Ha Noi"
            };
            //Create user với password là 123654$
            manager.Create(user, "123654");

            //Nếu role chưa tồn tại thì tạo 2 role là : admin , user
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }
            //=> Dùng UserRole để tìm user đó (theo email):
            var adminUser = manager.FindByEmail("proakiss1@gmail.com");

            //Nếu thành công=> add user đó vào 2 nhóm admin,user
            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
