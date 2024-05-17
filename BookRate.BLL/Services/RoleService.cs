﻿using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Genre;
using BookRate.BLL.ViewModels.Role;
using BookRate.DAL.DTO.Role;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class RoleService : BaseService, IService<CreateRoleDTO, UpdateRoleDTO, Role>
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> AddAsync(CreateRoleDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(UpdateRoleDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }

        public async Task<RoleViewModel?> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleViewModel>> GetRoleListModelsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

