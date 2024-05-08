namespace BookRate.BLL.ViewModels.Reward
{
    public class NarrativeRewardViewModel
    {
        public int Id { get; set; }

        public int NarrativeId { get; set; }

        public int RewardId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Website { get; set; }

        public DateTime DateRewarded { get; set; }
    }
}
