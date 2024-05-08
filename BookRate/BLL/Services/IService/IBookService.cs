﻿using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IBookService
    {
        Task<bool> Add(CreateBookDTO dto);
        Task<bool> Update(UpdateBookDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<BookViewModel?> GetSpecificBookInfo(int? id);
        Task<List<BookCardViewModel>> GetTopOfWeekBookCards();
    }
}
