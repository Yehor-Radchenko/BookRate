using BookRate.BLL.ViewModels.Role;

namespace BookRate.BLL.ViewModels.Contributor
{
    public class ContributorListModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public HashSet<RoleViewModel> Roles { get; set; } = new HashSet<RoleViewModel>();
    }
}
