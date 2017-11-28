using CarDealership.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddUserVM
    {
        public AppUser User { get; set; }
        public List<SelectListItem> RoleItems { get; set; }

        public AddUserVM()
        {
            User = new AppUser();
            RoleItems = new List<SelectListItem>();
        }

        public void SetRoleItems(IEnumerable<IdentityRole> roles)
        {
            foreach (var role in roles)
            {
                RoleItems.Add(new SelectListItem()
                {
                    Value = role.Id.ToString(),
                    Text = role.Name
                });
            }
        }
    }
}