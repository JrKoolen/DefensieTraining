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
    }
}
