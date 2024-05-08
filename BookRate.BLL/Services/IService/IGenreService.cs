using BookRate.BLL.ViewModels.Genre;
using BookRate.DAL.DTO.Genre;

namespace BookRate.BLL.Services.IService
{
    public interface IGenreService
    {
        Task<bool> Add(CreateGenreDTO genreDTO);
        Task<bool> Update(UpdateGenreDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<GenreViewModel>> GetAll();
        Task<GenreViewModel?> GetById(int? id);
    }
}
