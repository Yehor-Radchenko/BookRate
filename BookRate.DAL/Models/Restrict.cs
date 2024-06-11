using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime;

namespace BookRate.DAL.Models
{
    public class Restrict
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public string? Description { get; set; }

        public DateTime BanRemovalDate  { get; set; }
    }
    
}
