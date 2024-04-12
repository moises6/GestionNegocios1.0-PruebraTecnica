using System.Security.Claims;
using System.Collections.Generic; 

namespace GestionNegocios_PruebraTecnica.Data
{
    public class RoleClaim
    {
        public static List<Claim> claimsList = new List<Claim>
        {
            new Claim("Create", "Create"),
            new Claim("Edit", "Edit"), 
            new Claim("Delete", "Delete") 
        };
    }
}
