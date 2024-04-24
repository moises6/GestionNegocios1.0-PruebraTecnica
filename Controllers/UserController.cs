using GestionNegocios_PruebraTecnica.Data;
using GestionNegocios_PruebraTecnica.Models;
using GestionNegocios_PruebraTecnica.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using static GestionNegocios_PruebraTecnica.Models.ViewModels.ClaimsViewModel;

namespace GestionNegocios_PruebraTecnica.Controllers
{
    public class UserController : Controller
    {
        private readonly AplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(AplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = SD.Administrador)]
        public async Task <IActionResult> Index()
        {
            var userList = _db.AplicationUsers.ToList();

            foreach (var user in userList)
            {
                var user_role = await _userManager.GetRolesAsync(user) as List< string >;
                user.Role = String.Join(",", user_role);
            }

            return View(userList);

        }


        public async Task<IActionResult> ManageRole(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            List<string>? exsitingUserRoles = await _userManager.GetRolesAsync(user) as List<string>;
            var model = new RolesViewModel()
            {
                User = user
            };

            foreach (var role in _roleManager.Roles)
            {
                ClaimSeletion roleSeletion = new()
                {
                    RoleName = role.Name
                };
                if (exsitingUserRoles.Any(c => c == role.Name))
                {
                    roleSeletion.IsSelected = true;
                }
                model.RolesList.Add(roleSeletion);
            }
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRole(RolesViewModel rolesViewModel)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(rolesViewModel.User.Id);
            if (user == null)
            {
                return NotFound();
            }

            var oldUserRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, oldUserRoles);
            if (!result.Succeeded)
            {
                TempData[SD.Error] = "Error al remover el rol";
                return View(rolesViewModel);
            }

            result = await _userManager.AddToRolesAsync(user, rolesViewModel.RolesList.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                TempData[SD.Error] = "Error al agregar el rol";
                return View(rolesViewModel);
            }


            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ManageUserClaim(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var existingUserClaims = await _userManager.GetClaimsAsync(user);
            var model = new ClaimsViewModel()
            {
                User = user
            };

            foreach (Claim claim in RoleClaim.claimsList)
            {

                ClaimSelection userClaim = new()
                {
                    ClaimType = claim.Type,
                    IsSelected = false
                };


                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }


                model.ClaimsList.Add(userClaim);
            }

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserClaim(ClaimsViewModel claimsViewModel)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(claimsViewModel.User.Id);
            if (user == null)
            {
                return NotFound();
            }

            var oldClaims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, oldClaims);
            if (!result.Succeeded)
            {
                TempData[SD.Error] = "Error al remover el Claims";
                return View(claimsViewModel);
            }

            result = await _userManager.AddClaimsAsync(user, claimsViewModel.ClaimsList.Where(x => x.IsSelected).Select(y => new Claim(y.ClaimType, y.IsSelected.ToString())));


            if (!result.Succeeded)
            {
                TempData[SD.Error] = "Error al agregar el Claims";
                return View(claimsViewModel);
            }


            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LockUnLock(string userId)
        {
            ApplicationUser user = _db.AplicationUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now;
            }
            else
            {
                user.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {

            var user = _db.AplicationUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            _db.AplicationUsers.Remove(user);


            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
