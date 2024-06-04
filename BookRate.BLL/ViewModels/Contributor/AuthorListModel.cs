using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.ViewModels.Contributor
{
    public class AuthorListModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }
    }
}
