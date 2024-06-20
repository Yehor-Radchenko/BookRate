using BookRate.BLL.ViewModels.Rate;

namespace BookRate.BLL.ViewModels.User
{
    
    public class InfoViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }
        
        public string Username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }
        
        public string? Interests { get; set; }
        
        public int CountCommentaries { get; set; }
        
        public int CountReviews { get; set; }
        
    }
    
}
