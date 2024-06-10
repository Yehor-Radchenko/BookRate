using BookRate.BLL.ViewModels.BookEdition;
using BookRate.DAL.DTO.BookEdition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services.ServiceAbstraction
{
    public interface IService <TDto> 
        where TDto : class
    {
        Task<int> AddAsync(TDto dto);
        Task<bool> UpdateAsync(int id, TDto expectedEntityValues);
        Task<bool> Delete(int id);
    }
}
