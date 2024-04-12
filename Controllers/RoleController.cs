using GestionNegocios_PruebraTecnica.Data;
using GestionNegocios_PruebraTecnica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GestionNegocios_PruebraTecnica.Controllers
{
    public class RoleController : Controller
    {
        private readonly AplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(AplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = SD.Admin)]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList(); // Using RoleManager to fetch roles
            return View(roles);
        }

        [HttpGet]
    public IActionResult Upsert(string roleId)
        {
            if (String.IsNullOrEmpty(roleId))
            {
                //Create
                return View();
            }
            else
            {
                //update
                var objFromDb = _db.Roles.FirstOrDefault (x => x.Id == roleId);
                return View(objFromDb);

            }
        }
        [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task< IActionResult> Upsert(IdentityRole releObj)
    {
        if(await _roleManager.RoleExistsAsync(releObj.Name))
        {
            //error
        }
        if (String.IsNullOrEmpty(releObj.NormalizedName))
        {
            //Create
            await _roleManager.CreateAsync(new IdentityRole() {Name = releObj.Name});
           
        }
        else
        {
            //update
            var objFromDb = _db.Roles.FirstOrDefault(x => x.Id == releObj.Id);
                objFromDb.Name = releObj.Name;
                objFromDb.NormalizedName = releObj.Name.ToUpper();
                var result = await _roleManager.UpdateAsync(objFromDb);
            

        }
            return RedirectToAction(nameof(Index));
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string roleId)
        {
           
            
                //delete
                var objFromDb = _db.Roles.FirstOrDefault(x => x.Id == roleId);
                if(objFromDb != null)
            {
                    var result = await _roleManager.DeleteAsync(objFromDb);
            }
                


            
            return RedirectToAction(nameof(Index));
        }
    }
    
}

