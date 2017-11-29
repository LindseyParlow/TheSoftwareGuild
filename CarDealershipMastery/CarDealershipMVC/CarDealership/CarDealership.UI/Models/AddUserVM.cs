using CarDealership.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddUserVM
    {
        [Required]
        public AppUser User { get; set; }

        [Required]
        public List<SelectListItem> RoleItems { get; set; }

        public string RoleName { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
                    Value = role.Name,
                    Text = role.Name
                });
            }
        }
    }
}