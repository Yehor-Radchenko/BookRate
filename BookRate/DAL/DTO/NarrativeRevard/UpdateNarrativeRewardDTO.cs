namespace BookRate.DAL.DTO
{
    public class UpdateNarrativeRewardDTO
    {
        public int Id { get; set; }

        public int NarrativeId { get; set; }

        public int RewardId { get; set; }

        public DateTime DateRewarded { get; set; }
    }
}
