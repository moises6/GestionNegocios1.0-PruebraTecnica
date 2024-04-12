namespace GestionNegocios_PruebraTecnica.Models.ViewModels
{
    public class RolesViewModel
    {
       public RolesViewModel() 
        {
            RolesList = [];
        }
        public ApplicationUser User { get; set; }
        public List<ClaimSeletion> RolesList { get; set;}
    }


    public class ClaimSeletion
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
