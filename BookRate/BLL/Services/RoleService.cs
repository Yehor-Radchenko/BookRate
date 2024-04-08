﻿using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(RoleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RoleViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(RoleDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
