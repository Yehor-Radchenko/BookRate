﻿using BookRate.BLL.ViewModels.Reward;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Narrative;
using BookRate.DAL.DTO.NarrativeRevard;

namespace BookRate.BLL.Services.IService
{
    public interface INarrativeRewardService
    {
        Task<bool> Add(CreateNarrativeRewardDTO dto);
        Task<bool> Update(UpdateNarrativeDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<NarrativeRewardViewModel>> GetAll();
        Task<NarrativeRewardViewModel?> GetById(int? id);
    }
}
