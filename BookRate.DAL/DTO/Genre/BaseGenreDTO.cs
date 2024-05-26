using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Genre
{
    public abstract class BaseGenreDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
