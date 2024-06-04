using BookRate.BLL.ViewModels.Contributor;

namespace BookRate.BLL.ViewModels.Narrative
{
    public class NarrativeListModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public AuthorListModel Author { get; set; }
    }
}
