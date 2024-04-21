namespace BookRate.DAL.DTO
{
    public class UpdateNarrativeRevardDTO
    {
        public int Id { get; set; }

        public int NarrativeId { get; set; }

        public int RevardId { get; set; }

        public DateTime DateRevarded { get; set; }
    }
}
