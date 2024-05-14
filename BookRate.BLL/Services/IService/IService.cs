using BookRate.BLL.ViewModels.BookEdition;
using BookRate.DAL.DTO.BookEdition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services.NewFolder
{
    public interface IService <CreateDto, UpdateDto, TEntity> 
        where CreateDto : class
        where UpdateDto : class
        where TEntity : class
    {
        Task<bool> Add(CreateDto dto);
        Task<bool> Update(UpdateDto expectedEntityValues);
        Task<bool> Delete(int id);
    }
}
