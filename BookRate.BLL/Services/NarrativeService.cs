using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Narrative;
using BookRate.DAL.DTO.Narrative;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class NarrativeService : BaseService, IService<CreateNarrativeDTO, UpdateNarrativeDTO, Narrative>
    {
        public NarrativeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> AddAsync(CreateNarrativeDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(UpdateNarrativeDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NarrativeListModel>> GetNarrativeListModelsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<NarrativeViewModel?> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
