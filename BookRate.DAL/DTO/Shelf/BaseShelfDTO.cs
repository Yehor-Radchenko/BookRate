using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Shelf
{
    public abstract class BaseShelfDTO
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public int UserId { get; set; }

        public IEnumerable<int>? BooksId { get; set; }
    }
}
