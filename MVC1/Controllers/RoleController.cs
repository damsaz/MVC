
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC1.Models;
using MVC1.ViewModels;
using System;

namespace MVC1.Controllers
    {
    [Authorize(Roles = "Administrator")]

    public class RoleController : Controller
        {
        readonly RoleManager<IdentityRole> roleManager;
        readonly UserManager<ApplicationUser> userManager;  
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
            {
            this.roleManager = roleManager;
            this.userManager = userManager;

            }
        public IActionResult Index()
            {
            ViewData["Roles"] = new SelectList(roleManager.Roles, "Name", "Name");
            ViewData["User"] = new SelectList(userManager.Users, "UserName", "UserName");
            return View(roleManager.Roles);
            }
        public async Task<IActionResult>  Add(String Name)
            {
            
            var identityRole = CreateRule();
            identityRole.Name=Name; 
           await roleManager.CreateAsync(identityRole);
            ViewData["Roles"] = new SelectList(roleManager.Roles, "Name", "Name");
            ViewData["User"] = new SelectList(userManager.Users, "UserName", "UserName");
            return View("index",roleManager.Roles);
            }

        public async Task<IActionResult> Show()
            {
          
              List<UserRole> UserRole = new List<UserRole>();
            foreach(var User in userManager.Users) { 
               
            var Roles = new List<string>(await userManager.GetRolesAsync(User));


                UserRole.Add(new UserRole(User.Id, User.UserName, Roles));
          //  vm.UserName = user.UserName;
                }
            return View(UserRole);
            }

    public async Task<IActionResult> Delete(String Id)
            {
            var role = roleManager.Roles.FirstOrDefault(u => u.Id == Id);
         
            var result2 = await roleManager.DeleteAsync(role);
            ViewData["Roles"] = new SelectList(roleManager.Roles, "Name", "Name");
            ViewData["User"] = new SelectList(userManager.Users, "UserName", "UserName");
            return View("index", roleManager.Roles);
            }
       
        public async Task<IActionResult> DeleteRoleUser(String Role,string UserId)
            {
            var user = await userManager.FindByIdAsync(UserId);
            await userManager.RemoveFromRoleAsync(user, Role);
            List<UserRole> UserRole = new List<UserRole>();
            foreach (var User in userManager.Users)
                {

                var Roles = new List<string>(await userManager.GetRolesAsync(User));


                UserRole.Add(new UserRole(User.Id, User.UserName, Roles));
                //  vm.UserName = user.UserName;
                }
            
            return View("Show",UserRole);
            }
        public async Task<IActionResult> AddUserRole(string User, string Role)
            {
            var username =  userManager.Users.FirstOrDefault(u => u.UserName == User);
             await userManager.AddToRoleAsync(username, Role);
            ViewData["Roles"] = new SelectList(roleManager.Roles, "Name", "Name");
            ViewData["User"] = new SelectList(userManager.Users, "UserName", "UserName");
            return View("index", roleManager.Roles);
            }
        
        private IdentityRole CreateRule()
            {
            try
                {
                return Activator.CreateInstance<IdentityRole>();
                }
            catch
                {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityRole)}'. " +
                    $"Ensure that '{nameof(IdentityRole)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in Role.cshtml");
                }
            }

        }



    }
