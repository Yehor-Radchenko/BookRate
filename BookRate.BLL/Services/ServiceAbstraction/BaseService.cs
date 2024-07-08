using AutoMapper;
using BookRate.DAL.UoW;
using FluentValidation;

namespace BookRate.BLL.Services.ServiceAbstraction
{
    public abstract class BaseService<TEntity, TDto>
     where TEntity : class
     where TDto : class
    {
        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<TDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TDto> _validator;

       

        protected BaseService()
        {
            
        }
    }
}
