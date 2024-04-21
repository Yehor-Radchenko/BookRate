﻿using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface INarrativeService
    {
        Task<bool> Add(CreateNarrativeDTO dto);
        Task<bool> Update(UpdateNarrativeDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<NarrativeViewModel>> GetAll();
        Task<NarrativeViewModel?> GetById(int? id);
    }
}
