using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services.IService
{
    public interface INarrativeService
    {
        public Task Create(NarrativeDTO model);
        public Task Delete(int? id);
        public Task<IEnumerable<NarrativeViewModel>> GetAll();
        public Task<Student?> GetById(int? id);
        public Task Update(Student expectedEntityValues);
    }
}
