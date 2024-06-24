namespace BookRate.DAL.DTO.Restrict
{
    public class RestrictDto
    {

        public int UserId { get; init; }

        public string Description { get; init; }

        public DateTime BanRemovaleDate { get; init; } = DateTime.UtcNow;
    }
}
