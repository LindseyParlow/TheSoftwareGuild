namespace CarDealership.Data.Migrations
{
    using CarDealership.Models.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Data.CarDealershipEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.Data.CarDealershipEntities context)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));


            //================================================
            //AJ's version:

            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new AppRole() { Name = "admin" });
            }

            if (!roleMgr.RoleExists("sales"))
            {
                roleMgr.Create(new AppRole() { Name = "sales" });
            }

            if (!roleMgr.RoleExists("disabled"))
            {
                roleMgr.Create(new AppRole() { Name = "disabled" });
            }

            var disabledUser = new AppUser()
            {
                UserName = "lindsey.parlow@gmail.com",
                FirstName = "Lindsey",
                LastName = "Parlow",
                Email = "lindsey.parlow@gmail.com"
            };

            var salesUser = new AppUser()
            {
                UserName = "aj.rohde@gmail.com",
                FirstName = "AJ",
                LastName = "Rohde",
                Email = "aj.rohde@gmail.com"
            };


            var adminUser = new AppUser()
            {
                UserName = "mark.johnson@gmail.com",
                FirstName = "Mark",
                LastName = "Johnson",
                Email = "mark.johnson@gmail.com"
            };

            if (!userMgr.Users.Any(u => u.UserName == "lindsey.parlow@gmail.com"))
            {
                userMgr.Create(disabledUser, "testing123");

                context.SaveChanges();

                userMgr.AddToRole(disabledUser.Id, "disabled");
            }

            if (!userMgr.Users.Any(u => u.UserName == "aj.rohde@gmail.com"))
            {
                userMgr.Create(salesUser, "testing123");

                context.SaveChanges();

                userMgr.AddToRole(salesUser.Id, "sales");
            }

            if (!userMgr.Users.Any(u => u.UserName == "mark.johnson@gmail.com"))
            {
                userMgr.Create(adminUser, "testing123");

                context.SaveChanges();

                userMgr.AddToRole(adminUser.Id, "admin");
            }
        }
    }
}
