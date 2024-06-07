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
    public abstract class BaseService<TEntity, TDto>
     where TEntity : class
     where TDto : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TDto> _validator;

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<TDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
    }
}
