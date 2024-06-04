using AutoMapper;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services.ServiceAbstraction
{
    public abstract class BaseService<TEntity, TCreateDto, TUpdateDto> : IService<TEntity, TCreateDto, TUpdateDto>
     where TEntity : class
     where TCreateDto : class
     where TUpdateDto : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TUpdateDto> _validator;

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<TUpdateDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<TEntity> PatchAsync(int id, JsonPatchDocument<TUpdateDto> patch)
        {
            var repository = _unitOfWork.GetRepository<TEntity>();
            var entity = await repository.GetAsync(e => EF.Property<int>(e, "Id") == id);

            if (entity == null)
                throw new Exception($"Entity of type {typeof(TEntity).Name} with ID {id} was not found.");

            var dto = _mapper.Map<TUpdateDto>(entity);
            patch.ApplyTo(dto);

            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            _mapper.Map(dto, entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public abstract Task<int> AddAsync(TCreateDto dto);

        public abstract Task<bool> UpdateAsync(TUpdateDto expectedEntityValues);

        public abstract Task<bool> Delete(int id);
    }
}
