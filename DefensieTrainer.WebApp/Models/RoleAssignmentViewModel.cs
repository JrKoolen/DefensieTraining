using Microsoft.CodeAnalysis.CSharp.Syntax;
using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.Enums;

namespace DefensieTrainer.WebApp.Models
{
    public class RoleAssignmentViewModel
    {
        public string Email { get; set; }
        public Dictionary<string, string> Roles { get; set; }
        public string SelectedRole { get; set; }

        public RoleAssignmentViewModel()
        {
            Roles = new Dictionary<string, string>();
        }

        public string GetRoleName()
        {
            if (Enum.TryParse<Role>(SelectedRole, out Role role))
            {
                return role.ToString();
            }
            else
            {
                return "User";
            }
        }
    }
}
