using BookRate.BLL.ViewModels.BookEdition;
using BookRate.DAL.DTO.BookEdition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services.ServiceAbstraction
{
    public interface IService <TEntity, CreateDto, UpdateDto> 
        where CreateDto : class
        where UpdateDto : class
        where TEntity : class
    {
        Task<int> AddAsync(CreateDto dto);
        Task<bool> UpdateAsync(UpdateDto expectedEntityValues);
        Task<bool> Delete(int id);
    }
}
